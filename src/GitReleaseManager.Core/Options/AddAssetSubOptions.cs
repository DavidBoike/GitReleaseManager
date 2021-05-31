using System.Collections.Generic;
using CommandLine;

namespace GitReleaseManager.Core.Options
{
    [Verb("addasset", HelpText = "Adds an asset to an existing release.")]
    public class AddAssetSubOptions : BaseVcsOptions
    {
        [Option('a', "assets", Separator = ',', HelpText = "Paths to the files to include in the release.", Required = true)]
        public IList<string> AssetPaths { get; set; }

        [Option('t', "tagName", HelpText = "The name of the release (Typically this is the generated SemVer Version Number).", Required = true)]
        public string TagName { get; set; }
    }
}