using System.Collections.Generic;
using CJP.Help.Models;
using Orchard.Localization;

namespace CJP.Help.Providers
{
    public class LayerHelpProvider : IHelpProvider
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
                                                Identifier = "AddLayer",
                                                Title = T("Adding a layer"),
                                                TextFlavor = "markdown",
                                                FullText =
                                                    T(@"To add a layer, in the dashboard, click Widgets. On the Widgets screen, click Add a new layer. The Add Layer screen is displayed.
                                                            To define the new layer, enter the name of the layer, a description, and the rule that defines the layer. When you're finished, click Save.
                                                            The Layer Rule value is an expression that resolves to either true or false. If it resolves to true, the widget is displayed; otherwise the widget is not displayed."),
                                            },
                                        new HelpItem
                                            {
                                                Identifier = "LayerRule",
                                                Title = T(""),
                                                TextFlavor = "markdown",
                                                FullText =
                                                    T(@"    url(""<url path>"")"+ System.Environment.NewLine +
    "True if the current URL matches the specified path. If you add an asterisk (*) to the end of the path, all pages found in subfolders under that path will evaluate to true (for example, url(\"~/home*\"))."),
                                            },
                                        new HelpItem
                                            {
                                                Identifier = "LayerRule",
                                                Title = T(""),
                                                TextFlavor = "markdown",
                                                FullText = T("`authenticated` True if the user is logged in."),
                                            },
                                    }
                            }
                    };
            }
        }
    }
}