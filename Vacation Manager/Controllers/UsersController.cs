using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Vacation_Manager.Models;

namespace Vacation_Manager.Controllers
{
    public class UsersController : Controller
    {
        
        



        public ActionResult Index()
        { 
        //List с всички потребители
        //List<UserModels> users = new List<UserModels>();

       

        return View();
        }
    }
}
