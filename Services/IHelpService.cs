using System.Collections.Generic;
using CJP.Help.Models;
using Orchard;

namespace CJP.Help.Services
{
    public interface IHelpService : IDependency
    {
        IEnumerable<Topic> GetTopics();
        IEnumerable<HelpItem> GetHelpItems();
        IEnumerable<HelpItem> GetHelpItems(string topic);
        IEnumerable<HelpItem> GetHelpItems(string topic, string identifier);

        string FilterHtml(string text, string flavor);
    }
}