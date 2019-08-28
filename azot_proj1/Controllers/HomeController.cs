﻿using System;
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

        public azot_db1Entities1 db;


        public ActionResult Index() {
            return View(db);
        }

        public ActionResult OldIndex()
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
             db = new azot_db1Entities1();
            
        }

        //><a href="/home/getFirstTable?in_id=@w.id"  пусть тут бует это шоб вызывать метод в новом окне и с аргументом

        public ActionResult getFirstTable(int in_id) {
            //in_id - workshop id
            List<QueryResultModel> list = db.getWarningsBySensorTypes(in_id);
            return PartialView("FirstTable", list);
        }

        public IEnumerable<SelectListItem> GetMyObjects(int in_ws_id)
        {
            var myobjects = db.workshop.ToList().Select(x => new SelectListItem
            {
                Value = x.id.ToString(),
                Text = x.name,
                //хуйня пока. ну кароч выбрать цех нужный, по айдишнику и во вьюхе переделать шоб ызывала с аргументом!!
                //Selected = x.id == in_ws_id ? true : false
            });
            
            return new SelectList(myobjects, "Value", "Text");
        }

        public ActionResult Detalization(int in_ws_id)
        {
            var model = new WorkshopsViewModel
            {
                workshops = GetMyObjects(in_ws_id)
            };
            return View("detalizationView", model);
        }

        public ActionResult DetailedWarningsOfWorkshop(int ws_id, int st_id, int viewtype) {
            List<QueryResultModel> list = db.getDetailedWarnings(ws_id);

            if (viewtype == 1)
            {
                ViewBag.st_id = st_id;
                return PartialView("FilteredDetailedWarningsOfWorkshop", list);
            }
            else if (viewtype == 2)
            {
                ViewBag.st_id = st_id;
                return PartialView("HighlightedDetailedWarningsOfWorkshop", list);
            }
            else {
                return PartialView("DetailedWarningsOfWorkshop", list);

            }
            //return PartialView("DetailedWarningsOfWorkshop", list);
        }
    }
}