using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vacation_Manager.Controllers
{
    [Authorize(Policy = "Team Lead")]
    public class CEOcontroller : Controller
    {
        
        //[Authorize(Roles="CEO")]
        public IActionResult Index()
        {
            return View();
        }

        
        //CEO - View панел за управление
       // [Authorize(Policy = "CEO")]
        public ActionResult CEO_ControlPanel() 
        {
            return View();
        }
    }
}
