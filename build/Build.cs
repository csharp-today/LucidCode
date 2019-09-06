using Nuke.Common.Execution;
using Nuke.Useful.Builds;

[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
class Build : SimpleBuild
{
    public static int Main () => Execute<Build>(x => x.Test);
}
