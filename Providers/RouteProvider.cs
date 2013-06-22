using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace CJP.Help.Providers
{
    public class RouteProvider : IRouteProvider
    {
        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[]
                {
                    new RouteDescriptor
                        {Route = new Route(
                            "Admin/Help/{topic}",
                            new RouteValueDictionary
                                {
                                    {"area", "CJP.Help"},
                                    {"controller", "Help"},
                                    {"action", "ListTopic"}
                                },
                            new RouteValueDictionary(),
                            new RouteValueDictionary
                                {
                                    {"area", "CJP.Help"}
                                },
                            new MvcRouteHandler())
                        },
                    new RouteDescriptor
                        {Route = new Route(
                            "Admin/Help/{topic}/{identifier}",
                            new RouteValueDictionary
                                {
                                    {"area", "CJP.Help"},
                                    {"controller", "Help"},
                                    {"action", "ShowHelp"}
                                },
                            new RouteValueDictionary(),
                            new RouteValueDictionary
                                {
                                    {"area", "CJP.Help"}
                                },
                            new MvcRouteHandler())
                        },
                    new RouteDescriptor
                        {Route = new Route(
                            "Admin/Help",
                            new RouteValueDictionary
                                {
                                    {"area", "CJP.Help"},
                                    {"controller", "Help"},
                                    {"action", "Index"}
                                },
                            new RouteValueDictionary(),
                            new RouteValueDictionary
                                {
                                    {"area", "CJP.Help"}
                                },
                            new MvcRouteHandler())
                        },
                };
        }

        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }
    }
}