using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacation_Manager.GlobalConstants;

namespace Vacation_Manager.Controllers
{
    [Authorize(Policy = RoleConstants.Policies.RequireCEO)]
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
