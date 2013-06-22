using System.Collections.Generic;
using Orchard.Localization;

namespace CJP.Help.Models
{
    public class HelpItem
    {
        public string Identifier { get; set; }
        public LocalizedString Title { get; set; }
        public LocalizedString ShortText { get; set; }
        public LocalizedString FullText { get; set; }
        public string TextFlavor { get; set; }
        public IEnumerable<string> RelatedItems { get; set; }
    }
}