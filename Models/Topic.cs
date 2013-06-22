using System.Collections.Generic;
using Orchard.Localization;

namespace CJP.Help.Models
{
    public class Topic
    {
        public string Identifier { get; set; }
        public LocalizedString Title { get; set; }
        public IEnumerable<HelpItem> HelpItems { get; set; }
    }
}