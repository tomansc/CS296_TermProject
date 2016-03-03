using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toman296NTermProject.Models;

namespace Toman296NTermProject.Controllers
{
    public class DataController : Controller
    {
        public APIServiceCaller caller = new APIServiceCaller();
        // GET: Data
        public ActionResult Index()
        {
            List<Group> groupResults = caller.GetGroups();   
            return View("index", groupResults);
        }
    }
}