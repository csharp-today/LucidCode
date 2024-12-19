using Bojkowski.Commands.Git;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

var services = new ServiceCollection().AddGitCommands();

if (args.Contains("--release"))
{
    Console.WriteLine("Running RELEASE");
    services.AddTransient<IRunner, Release>();
}
else
{
    Console.WriteLine("Running BUILD");
    services.AddTransient<IRunner, Build>();
}

var provider = services.BuildServiceProvider();
var runner = provider.GetRequiredService<IRunner>();
return await runner.RunAsync();