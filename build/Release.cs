using Bojkowski.Commands.Git;
using Bojkowski.Nuke;
using Nuke.Common.IO;
using Nuke.Common.Tools.DotNet;
using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Release : IRunner
{
    private readonly IGitRunner _gitRunner;

    private static string FeedSecret => GetEnvironmentVariable();

    private static string FeedUrl => GetEnvironmentVariable();

    private static string FeedUser => GetEnvironmentVariable();

    public Release(IGitRunner gitRunner) => _gitRunner = gitRunner;

    private static string GetEnvironmentVariable([CallerMemberName] string variableName = null) =>
        Environment.GetEnvironmentVariable(variableName)
        ?? throw new ArgumentException("Environment variable is not defined: " + variableName);

    private static string PushNuGet()
    {
        const string CurrentDirectory = ".";
        using var config = NuGetConfig.Create(CurrentDirectory, FeedUrl, FeedUser, FeedSecret);
        var packages = PathConstruction.GlobFiles(CurrentDirectory, ["*.nupkg"]);
        Console.WriteLine($"Found {packages.Count} package(s)");
        if (packages.Count != 1)
        {
            throw new ApplicationException($"Expected a single NuGet package!");
        }

        var package = packages.First();
        Console.WriteLine($"Package: {package}");

        DotNetTasks.DotNetNuGetPush((DotNetNuGetPushSettings s) => DotNetNuGetPushSettingsExtensions
            .SetSource(DotNetNuGetPushSettingsExtensions.SetTargetPath(s, package), config.FeedName)
            .SetApiKey("NuGet requires the key but Azure DevOps ignores it"));
        Console.WriteLine($"NuGet package released: {package}");

        var name = Path.GetFileNameWithoutExtension(package);
        return name;
    }

    public async Task<int> RunAsync()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        try
        {
            Directory.SetCurrentDirectory(@"..\drop");
            var nugetPackage = PushNuGet();
            await TagRepositoryAsync(nugetPackage);
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Release failed: {ex}");
            return -1;
        }
        finally
        {
            Directory.SetCurrentDirectory(currentDirectory);
        }
    }

    private async Task TagRepositoryAsync(string packageName)
    {
        Console.WriteLine($"Package name: {packageName}");
        var versionRegex = new Regex("[0-9]+.[0-9]+.[0-9]+$");
        var match = versionRegex.Match(packageName);
        if (!match.Success)
        {
            throw new ApplicationException("Can't recognize NuGet version");
        }

        var version = match.ToString();
        Console.WriteLine($"Package version: {version}");

        Directory.SetCurrentDirectory("repository");
        Console.WriteLine($"Directory changed: {Environment.CurrentDirectory}");

        var output = await _gitRunner.TagAsync(version);
        Console.WriteLine(output);
        Console.WriteLine("Local repository tagged.");

        var originUrl = await _gitRunner.GetOriginUrlAsync();
        Console.WriteLine($"Origin URL: {originUrl}");

        var organizationNameRegex = new Regex("//(.+)@");
        var organizationNameMatch = organizationNameRegex.Match(originUrl);
        if (!organizationNameMatch.Success)
        {
            throw new ApplicationException("Can't recognize organization name from the origin URL");
        }

        var organizationName = organizationNameMatch.Groups[1].ToString();
        Console.WriteLine($"Organization name: {organizationName}");
        if (string.IsNullOrWhiteSpace(organizationName))
        {
            throw new ApplicationException("Organization name can't be empty");
        }

        originUrl = originUrl.Replace($"{organizationName}@", $"{organizationName}:{FeedSecret}@");
        Console.WriteLine($"New origin URL: {originUrl}");

        output = await _gitRunner.SetOriginUrlAsync(originUrl);
        Console.WriteLine("Repository origin URL has been updated.");

        output = await _gitRunner.PushTagAsync(version);
        Console.WriteLine(output);
        Console.WriteLine("Tag pushed to remote repository.");
    }
}