using System.Collections.Generic;
using System.IO;
using System.Linq;
using CJP.Help.Models;
using Orchard.Environment.Descriptor.Models;
using Orchard.Environment.Features;
using Orchard.FileSystems.VirtualPath;
using Orchard.Localization;

namespace CJP.Help.Providers
{
    public class HelpProvider : IHelpProvider
    {
        private readonly IVirtualPathProvider _virtualPathProvider;
        public Localizer T { get; set; }

        public HelpProvider(IVirtualPathProvider virtualPathProvider)
        {
            _virtualPathProvider = virtualPathProvider;
        }

        public IEnumerable<Topic> Topics
        {
            get
            {
                var helpFile = _virtualPathProvider.Combine("~/Modules", "CJP.Help", "Help", "AdditionalFiles", "ExtensionMethods.markdown");
                helpFile = _virtualPathProvider.MapPath(helpFile);

                if (!File.Exists(helpFile)) return null;

                return new[]
                    {
                        new Topic
                            {
                                Identifier = "CJP.Help",
                                Title = T("Help"),
                                HelpItems = new []
                                    {
                                        new HelpItem
                                            {
                                                Identifier = "How-to-provide-help-documentation-for-your-own-modules",
                                                Title = T(""),
                                                TextFlavor = "markdown",
                                                Position = 1,
                                                FullText = T(File.ReadAllText(helpFile)),
                                            },
                                    }
                            }
                    };
            }
        }
    }
}