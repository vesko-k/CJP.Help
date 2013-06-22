using System;
using System.Collections.Generic;
using System.Linq;
using CJP.Help.Models;
using CJP.Help.Providers;
using Orchard.Services;

namespace CJP.Help.Services
{
    public class HelpService : IHelpService
    {
        private readonly IEnumerable<IHelpProvider> _helpProviders;
        private readonly IEnumerable<IHtmlFilter> _htmlFilters;

        public HelpService(IEnumerable<IHelpProvider> helpProviders, IEnumerable<IHtmlFilter> htmlFilters)
        {
            _helpProviders = helpProviders;
            _htmlFilters = htmlFilters;
        }

        public IEnumerable<Topic> GetTopics()
        {
            return _helpProviders.SelectMany(p => p.Topics);
        } 

        public IEnumerable<HelpItem> GetHelpItems()
        {
            return _helpProviders.SelectMany(p => p.Topics.SelectMany(t=>t.HelpItems));
        }

        public IEnumerable<HelpItem> GetHelpItems(string topic)
        {
            return _helpProviders
                .SelectMany(p => p.Topics)
                .Where(t => string.Equals(t.Identifier, topic, StringComparison.OrdinalIgnoreCase))
                .SelectMany(t=>t.HelpItems);
        }

        public IEnumerable<HelpItem> GetHelpItems(string topic, string identifier)
        {
            return _helpProviders
                .SelectMany(p => p.Topics)
                .Where(t => string.Equals(t.Identifier, topic, StringComparison.OrdinalIgnoreCase))
                .Where(i => string.Equals(i.Identifier, identifier, StringComparison.OrdinalIgnoreCase))
                .SelectMany(t => t.HelpItems);
        }

        public string FilterHtml(string text, string flavor)
        {
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(flavor))
            {
                return _htmlFilters.Aggregate(text, (t, filter) => filter.ProcessContent(t, flavor));
            }
            return text;
        }
    }
}