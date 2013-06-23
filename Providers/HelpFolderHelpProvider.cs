using System.Collections.Generic;
using System.IO;
using System.Linq;
using CJP.Help.Models;
using Orchard.Environment.Descriptor.Models;
using Orchard.Environment.Extensions;
using Orchard.Environment.Features;
using Orchard.FileSystems.VirtualPath;
using Orchard.Localization;
using Orchard.Utility.Extensions;

namespace CJP.Help.Providers
{
    public class HelpFolderHelpProvider : IHelpProvider
    {
        private readonly IVirtualPathProvider _virtualPathProvider;
        private readonly IExtensionManager _extensionManager;
        private readonly IFeatureManager _featureManager;
        private readonly ShellDescriptor _shellDescriptor;
        public Localizer T { get; set; }

        public HelpFolderHelpProvider(IVirtualPathProvider virtualPathProvider, IExtensionManager extensionManager, IFeatureManager featureManager, ShellDescriptor shellDescriptor )
        {
            _virtualPathProvider = virtualPathProvider;
            _extensionManager = extensionManager;
            _featureManager = featureManager;
            _shellDescriptor = shellDescriptor;
        }

        public IEnumerable<Topic> Topics
        {
            get
            {
                var topics = new List<Topic>();
                var enabled = _shellDescriptor.Features.Select(x => x.Name);

                var features = _featureManager.GetAvailableFeatures().Where(f => enabled.Contains(f.Id)).ToList();
                foreach (var feature in features)
                {
                    var helpPath = _virtualPathProvider.Combine(feature.Extension.Location, feature.Extension.Id, "Help", feature.Id);
                    helpPath = _virtualPathProvider.MapPath(helpPath);

                    if (!Directory.Exists(helpPath)) continue;

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
                                                FullText = T(File.ReadAllText(markdownFile)),
                                                Identifier = friendlyName,
                                                Title = T(friendlyName.Replace("-", " ")),
                                                TextFlavor = "markdown"
                                            }
                                    }
                            });
                    }
                }

                return topics;
            }
        }
    }
}