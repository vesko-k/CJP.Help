using System.Collections.Generic;
using System.IO;
using CJP.Help.Models;
using Orchard.Environment.Extensions;
using Orchard.FileSystems.VirtualPath;
using Orchard.Localization;

namespace CJP.Help.Providers
{
    [OrchardFeature("CJP.Help.OrchardDocs")]
    public class GitHubHelpProvider : IHelpProvider
    {
        private readonly IVirtualPathProvider _virtualPathProvider;
        public Localizer T { get; set; }

        public GitHubHelpProvider(IVirtualPathProvider virtualPathProvider)
        {
            _virtualPathProvider = virtualPathProvider;
        }

        public IEnumerable<Topic> Topics
        {
            get
            {
                var topics = new List<Topic>();

                var helpPath = _virtualPathProvider.Combine("~/Modules", "CJP.Help","OrchardDocs");
                helpPath = _virtualPathProvider.MapPath(helpPath);


                foreach (var markdownFile in Directory.EnumerateFiles(helpPath, "*.markdown"))
                {
                    var friendlyName = Path.GetFileName(markdownFile).Replace(".markdown", "");

                    topics.Add(new Topic
                    {
                        Identifier = friendlyName,
                        Title = T(friendlyName.Replace("-", " ")),
                        HelpItems = new[]
                                {
                                    new HelpItem
                                    {
                                        FullText =T(File.ReadAllText(markdownFile)),
                                        Identifier = friendlyName,
                                        Title = T(friendlyName.Replace("-", " ")),
                                        TextFlavor = "markdown"
                                    }
                                }
                    });
                }

                return topics;
            }
        }
    }
}