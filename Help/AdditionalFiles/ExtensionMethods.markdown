However, if you are reading this file from the Help section of your Orchard site, then you can see that this page has been extended with extra content.

You can programatically extend documentation that already exists, or even create new pages or topics by implementing `IHelpProvider`.

You can extend this page by implementing the interface as so:

        public IEnumerable<Topic> Topics
        {
            get
            {
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
                                                FullText = T("Put the contents of your help here")),
                                            },
                                    }
                            }
                    };
            }
        }

There's a few concepts to get down here, so I'll take you through exactly what we've done.

Your `IHelpProvider` needs to return an `IEnumerable<Topic>`. A `Topic` consists of some identifying information with an `IEnumerable<HelpItem>`. A `HelpItem` contains the documentation that is rendered to the user.

Extension is done by convention. All help items in the same topic that have the same identifier will be merged. So, in the example above, we have extended this page by doing the following things:

+ The Identifier for the topic should be the Id of the feature that you want to extend the documentation for.
+ The Title for the topic should be the Name of the feature that you want to extend the documentation for.
+ The Identifier for the help item should be the name of the .markdown file that you want to extend the documentation for.

Additionally, we can also:

* Specify the order on that page that this content should be rendered in. The `.markdown` files are placed with a Position of 0. Specifying a number greater than 0 will place your content after it, and specifying a number less that 0 will place your content before it.
* Specify the TextFlavor that your content should be rendered in. Any TextFlavor available to you for use on the Body part of a page will also be available to you here.

Implementing `IHelpProvider` means that you have no restrictions on where your help content is pulled from. You could take it from a database, file system, Git repository, or anything else you can think of.