using Inventory.ArqLimpia.BL.DTOs;
using Inventory.ArqLimpia.BL.Interfaces.Interfaces;
using Inventory.ArqLimpia.EN.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace Inventory.Web.Controllers
{

    public class UsersController : Controller
    {
        readonly IUserBL _userBL;
        

        public UsersController(IUserBL userBL) 
        {
            _userBL = userBL;
            
        }
    
        //GET: UsersController/Create
        public ActionResult Login() 
        {
            ViewBag.ErrorMenssge = "";
            return View();
        }
        //POST: UsersController/Create
        [HttpPost]
        public async Task<ActionResult> Login(LoginInputDTO pUser) 
        {
            try
            {
                LoginOutputDTO result = await _userBL.Login(pUser);
                if (result.status == true)
                    return RedirectToAction("Index", "Product");
                else
                {
                    ViewBag.ErrorMessage = "INCORRET PASSWORD OR USER";
                    return View(pUser);
                }
            }
            catch (Exception) 
            {
                return View();
            }

        }

        //GET:UsersController/Create
        public ActionResult Register()
        {
            ViewBag.ErrorMessage = "";
            return View();
        }
        //POST: UsersController/Create
        [HttpPost]
        public async Task<ActionResult> Register(RegisterUserInputDTO pUser) 
        {
            try
            {
                RegisterUserOutputDTO result = await _userBL.Register(pUser);
                if (result != null){
                    return RedirectToAction(nameof(UsersController.Login));
                }
                else
                {
                    ViewBag.ErrorMessage = "";
                    return View(pUser);
                }
            }
            catch (Exception ex )
            {
                 ViewBag.ErrorMessage = ex.Message;
                return View();
            }
       } 
    }
}
