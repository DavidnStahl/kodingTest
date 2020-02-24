
using System.Web.Mvc;
using TestUppgiftSphinxly.Services;
using TestUppgiftSphinxly.Models;
using TestUppgiftSphinxly.ViewModels;

namespace TestUppgiftSphinxly.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Visitor visitor)
        {
            if(ModelState.IsValid)
            {
                var model = VisitorService.Instance.GetVisitorModel(visitor.Name);
                return RedirectToAction("WelcomeVisitor",model);
            }
            return View();            
        }
        public ActionResult WelcomeVisitor(ResponseViewModel model)
        {
            Session.Add("visitor", model.Name);
            return View(model);
        }
        public ActionResult DeleteVisitorInformation(string visitor)
        {
            VisitorService.Instance.DeleteVisitorData(Session["visitor"].ToString());
            return RedirectToAction("Index");
        }

    }
}