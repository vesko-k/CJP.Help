using System.Linq;
using System.Web.Mvc;
using CJP.Help.Services;
using Orchard.UI.Admin;

namespace CJP.Help.Controllers
{
    [Admin]
    public class HelpController : Controller
    {
        private readonly IHelpService _helpService;

        public HelpController(IHelpService helpService)
        {
            _helpService = helpService;
        }

        public ActionResult Index()
        {
            return View(_helpService.GetTopics().OrderBy(t=>t.Title.Text));
        }

        public ActionResult ListTopic(string topic)
        {
            var helpItems = _helpService.GetHelpItems(topic);
            if (!helpItems.Any())
            {
                return new HttpNotFoundResult();
            }

            return View(helpItems);
        }

        public ActionResult ShowHelp(string topic, string identifier)
        {
            var helpItems = _helpService.GetHelpItems(topic, identifier);
            if (!helpItems.Any())
            {
                return new HttpNotFoundResult();
            }

            return View(helpItems);
        }
    }
}