using System.Collections.Generic;
using CJP.Help.Models;
using Orchard;

namespace CJP.Help.Providers
{
    public interface IHelpProvider : IDependency
    {
        IEnumerable<Topic> Topics { get; } 
    }
}
