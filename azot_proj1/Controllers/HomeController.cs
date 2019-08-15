using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using azot_proj1;
using azot_proj1.Models;

namespace azot_proj1.Controllers
{
    public class HomeController : Controller
    {

        public azot_db1Entities db;
        
        public ActionResult Index()
        {
            return View("indexView",db);
        }

        
        public ActionResult WarningsOfWorkshop(int in_id)
        {
            List<QueryResultModel> list = db.getWarningsForWorkshop(in_id);
            return PartialView(list);
        }

        public ActionResult SensorsDetails(int in_id)
        {
            List<QueryResultModel> list = db.getDataWithSensorValues(in_id);
            return PartialView(list);
        }


        public HomeController() {
             db = new azot_db1Entities();
            
        }
    }
}