using System.Collections.Generic;
using CJP.Help.Models;
using Orchard.Localization;

namespace CJP.Help.Providers
{
    public class LayerHelpProvider2 : IHelpProvider
    {
        public Localizer T { get; set; }

        public IEnumerable<Topic> Topics
        {
            get
            {
                return new[]
                    {
                        new Topic
                            {
                                Identifier = "Layers",
                                Title = T("Layers"),
                                HelpItems = new[]
                                    {
                                        new HelpItem
                                            {
                                                Identifier = "LayerRule",
                                                Title = T("bingogodzlevel"),
                                                FullText =
                                                    T(
                                                        "True if the user is in a level"),
                                            },
                                    }
                            }
                    };
            }
        }
    }
}