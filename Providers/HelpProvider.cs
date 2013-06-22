using System.Collections.Generic;
using CJP.Help.Models;
using Orchard.Localization;

namespace CJP.Help.Providers
{
    public class HelpProvider : IHelpProvider
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
                                Identifier = "CJP.Help",
                                Title = T("Help"),
                                HelpItems = new []
                                    {
                                        new HelpItem
                                            {
                                                Identifier = "Welcome",
                                                Title = T("Welcome to the Help module"),
                                                FullText = T("The help section is here to guide you through Orchard and any third party modules that you may have installed"),
                                            },
                                        new HelpItem
                                            {
                                                Identifier = "Welcome",
                                                Title = T("Welcome to the Help module2"),
                                                FullText = T("This help item has the same identifier as the welcome message"),
                                            },
                                        new HelpItem
                                            {
                                                Identifier = "Welcome",
                                                Title = T("I am looking for help with something that is not covered here. What should I do?"),
                                                FullText = T("If you have found something that is not covered, chances are that the developer of the module you are using has not yet implement help pages for it. You should probably let them know by heading over to the homepage for the module and ask the user to provide help."),
                                            },
                                    }
                            }
                    };
            }
        }
    }
}