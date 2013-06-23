using System;
using System.Collections.Generic;
using System.Linq;
using CJP.Help.Models;
using CJP.Help.Providers;
using Orchard.Localization;
using Orchard.Services;

namespace CJP.Help.Services
{
    public class HelpService : IHelpService
    {
        private readonly IEnumerable<IHelpProvider> _helpProviders;
        private readonly IEnumerable<IHtmlFilter> _htmlFilters;

        public Localizer T { get; set; }

        public HelpService(IEnumerable<IHelpProvider> helpProviders, IEnumerable<IHtmlFilter> htmlFilters)
        {
            _helpProviders = helpProviders;
            _htmlFilters = htmlFilters;
        }

        public IEnumerable<Topic> GetTopics()
        {
            var topics = new List<Topic>();

            foreach (var identifier in _helpProviders.SelectMany(p => p.Topics).Select(t=>t.Identifier).Distinct())
            {
                var scopedIdentifier = identifier;
                var currentTopics = _helpProviders.SelectMany(p => p.Topics)
                                        .Where(t =>string.Equals(t.Identifier, scopedIdentifier, StringComparison.OrdinalIgnoreCase))
                                        .ToList();

                topics.Add(new Topic
                {
                    Identifier = identifier,
                    Title = currentTopics.Select(t=>t.Title).First(),//this is not the best- each title could be different!
                    HelpItems = currentTopics.SelectMany(t => t.HelpItems)
                });
            }

            return topics;
        } 

        public IEnumerable<HelpItem> GetHelpItems()
        {
            return FormatText(_helpProviders.SelectMany(p => p.Topics.SelectMany(t => t.HelpItems)));
        }

        public IEnumerable<HelpItem> GetHelpItems(string topic)
        {
            return FormatText(_helpProviders
                .SelectMany(p => p.Topics)
                .Where(t => string.Equals(t.Identifier, topic, StringComparison.OrdinalIgnoreCase))
                .SelectMany(t=>t.HelpItems));
        }

        public IEnumerable<HelpItem> GetHelpItems(string topic, string identifier)
        {
            return FormatText(_helpProviders
                .SelectMany(p => p.Topics)
                .Where(t => string.Equals(t.Identifier, topic, StringComparison.OrdinalIgnoreCase))
                .Where(i => string.Equals(i.Identifier, identifier, StringComparison.OrdinalIgnoreCase))
                .SelectMany(t => t.HelpItems));
        }

        public string FilterHtml(string text, string flavor)
        {
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(flavor))
            {
                return _htmlFilters.Aggregate(text, (t, filter) => filter.ProcessContent(t, flavor));
            }
            return text;
        }

        private IEnumerable<HelpItem> FormatText(IEnumerable<HelpItem> items)
        {
            var itemList = new List<HelpItem>();

            foreach (var item in items)
            {
                item.FullText = T(FilterHtml(item.FullText.Text, item.TextFlavor));

                itemList.Add(item);
            }

            return itemList;
        } 
    }
}