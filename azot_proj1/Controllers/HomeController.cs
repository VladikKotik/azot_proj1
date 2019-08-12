using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using azot_proj1.Models;
using azot_proj1;

namespace azot_proj1.Controllers
{
    public class HomeController : Controller
    {

        public azot_db1Entities db;
        // GET: Home
        public ActionResult Index()
        {
            return View("indexView",db);
        }

        public HomeController() {
             db = new azot_db1Entities();
            
        }
    }
}