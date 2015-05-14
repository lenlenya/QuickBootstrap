using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickBootstrap.Controllers
{
    public class SecondDomainController : Controller
    {
        // GET: SecondDomain
        public ActionResult Index(string company)
        {
            ViewBag.Company = company;
            return View();
        }
    }
}