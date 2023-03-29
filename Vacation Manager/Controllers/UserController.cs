using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Vacation_Manager.GlobalConstants.Repositories;
using Vacation_Manager.Models;
using System.Collections.Generic;
using Vacation_Manager.Areas.Identity.Data;

namespace Vacation_Manager.Controllers
{
    //[Authorize(Policy = GlobalConstants.RoleConstants.Policies.RequireDeveloper)]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var users = _unitOfWork.User.GetUsers();
            return View(users);
        }

        public IActionResult Edit(string id)
        {
            return View(id);
        }
    }
}
