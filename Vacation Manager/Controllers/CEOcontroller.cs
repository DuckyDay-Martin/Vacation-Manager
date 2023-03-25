using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vacation_Manager.Controllers
{
    
    public class CEOcontroller : Controller
    {
        //private readonly ILogger<CEOcontroller> _logger;

        //public CEOcontroller(ILogger<CEOcontroller> logger)
        //{
        //    _logger = logger;
        //}
        [Authorize(Roles = "CEO")]
        public IActionResult Index()
        {
            return View();
        }

        
        //CEO - View панел за управление
        [Authorize(Roles = "CEO")]
        public ActionResult CEO_ControlPanel() 
        {
            return View();
        }
    }
}
