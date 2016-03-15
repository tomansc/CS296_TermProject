using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toman296NTermProject.Models;

namespace Toman296NTermProject.Controllers
{
    [AllowAnonymous]
    public class CoreController : Controller
    {
        // GET: Core
        public ActionResult Index()
        {
            return View();
        }

        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }

        // GET: About
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Resources()
        {
            return View();
        }

    }
}