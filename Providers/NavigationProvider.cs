using System;
using Orchard.Localization;
using Orchard.UI.Navigation;

namespace CJP.Help.Providers
{
    public class NavigationProvider : INavigationProvider
    {
        public Localizer T { get; set; }
        public string MenuName { get { return "admin"; } }

        public void GetNavigation(NavigationBuilder builder)
        {
            builder.Add(T("Help"), "999", item => item.Action("Index", "Help", new { area = "CJP.Help" }));
        }
    }
}