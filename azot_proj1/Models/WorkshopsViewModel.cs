using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace azot_proj1.Models
{
    public class WorkshopsViewModel
    {

            [Display(Name = "Workshop")]
            public int selectedWorkshopId { get; set; }
            public IEnumerable<SelectListItem> workshops { get; set; }


        
    }
}