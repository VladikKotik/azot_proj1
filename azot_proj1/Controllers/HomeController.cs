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

        public azot_db1Entities1 db; //контекст из бд


        public ActionResult Index() {   //метод, открывающий стартовую страницу (название вьюхи совпадает 
            return View(db);            //с названием метода в контроллере, поэтому передается только модель контекста)
        }
        
        public HomeController() {
             db = new azot_db1Entities1();
            
        }
        
        public ActionResult getFirstTable(int in_id) { //метод, возвращающий первую таблицу(вставляется в 
                                                     //detalization view. это partial view(как компонент вставляемый, а не отдельная))
            List<QueryResultModel> list = db.getWarningsBySensorTypes(in_id); //ну вот метод получения из бд нарушений по типам датчиков. ну первая таблица, в общем
            return PartialView("FirstTable", list);
        }

        public IEnumerable<SelectListItem> GetMyObjects(int in_ws_id) //вспомогательный метод для выпадающего списка. получает данные из бд и приводит к особому типу
        {
            var myobjects = db.workshop.ToList().Select(x => new SelectListItem
            {
                Value = x.id.ToString(),
                Text = x.name,
                Selected = x.id == in_ws_id ? true : false
            });
            
            return new SelectList(myobjects, "Value", "Text");
        }

        public ActionResult Detalization(int in_ws_id) //метод возвращающий(открывающий) страничку с детализацией
        {                                            // и передает модель для создания выпдающего списка цехов
            var model = new WorkshopsViewModel         
            {
                workshops = GetMyObjects(in_ws_id)
            };
            return View("detalizationView", model);
        }

        public ActionResult DetailedWarningsOfWorkshop(int ws_id, int st_id, int viewtype) { //метод, возвращающий вторую табличку с детализацией по нарушениям для конкретного типа датчиков
            List<QueryResultModel> list = db.getDetailedWarnings(ws_id);

            if (viewtype == 1)
            {
                ViewBag.st_id = st_id;
                return PartialView("FilteredDetailedWarningsOfWorkshop", list); //режим фильтрации
            }
            else if (viewtype == 2)
            {
                ViewBag.st_id = st_id;
                return PartialView("HighlightedDetailedWarningsOfWorkshop", list); //режим выделения
            }
            else {
                return PartialView("DetailedWarningsOfWorkshop", list); //детализация по всем нарушениям для цеха

            }
        }
    }
}