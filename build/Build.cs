using Bojkowski.Nuke;
using Bojkowski.Nuke.Builds;
using Nuke.Common;
using Nuke.Common.IO;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class Build : AzureDevOpsLibraryBuild, IRunner
{
    private Target Step_10_SaveBuilderAsArtifact => x => x
        .DependsOn(Step_9_SaveArtifacts)
        .Requires(() => ArtifactOutputDirectory)
        .Executes(() =>
        {
            const string NukeBuildOutputDirectory = "build\\bin";
            var directories = Directory.GetDirectories(NukeBuildOutputDirectory);
            Console.WriteLine($"Directories under [{NukeBuildOutputDirectory}]: {string.Join(", ", directories)}");

            var outputDirectory = directories.First();
            Console.WriteLine($"Took directory: {outputDirectory}");

            directories = Directory.GetDirectories(outputDirectory);
            Console.WriteLine($"Directories under [{outputDirectory}]: {string.Join(", ", directories)}");

            outputDirectory = directories.First();
            Console.WriteLine($"Took directory: {outputDirectory}");

            outputDirectory = Path.GetFullPath(outputDirectory);
            Console.WriteLine($"Full path: {outputDirectory}");

            ArtifactStorage.Create(ArtifactOutputDirectory).AddDirectory((AbsolutePath)outputDirectory, "builder");
        });

    private Target Step_11_SaveSourceAsArtifact => x => x
        .DependsOn(Step_10_SaveBuilderAsArtifact)
        .Requires(() => ArtifactOutputDirectory)
        .Executes(() =>
        {
            ArtifactStorage.Create(ArtifactOutputDirectory).AddDirectory((AbsolutePath)Environment.CurrentDirectory, "repository");
        });

    protected override Target RunAllSteps => x => x
        .DependsOn(Step_11_SaveSourceAsArtifact)
        .Executes(DoNothingAction);

    public static int Run() => Execute<Build>(x => x.RunAllSteps);

    public Task<int> RunAsync() => Task.Run(Run);
}