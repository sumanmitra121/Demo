using Demo.DL;
using Demo.DTO;
using Demo.Models;
using Demo.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class AuthController : Controller
    {
        //Get
        public IActionResult Login()
        {

            return View();
        }
        //get
        public IActionResult Signup()
        {
            return View();
        }
        //Get
        public IActionResult ForgotPassword()
        {
            return View();
        }


        //For Registration
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(md_user users)
        {
            if (ModelState.IsValid)
            {
                var _user = new AuthDL();
                int res = _user.Signup(users);
                if (res > 0)
                {
                    TempData["alrt_msg"] = UtilityAlert.setAlert<string>(new ErrorViewModel() { class_name = "alert-success", Message = "Registration Successfull" });
                    //TempData["alrt_msg"] = JsonConvert.SerializeObject(new ErrorViewModel() { class_name = "alert-success", Message = "Registration Successfull" });
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["alrt_msg"] = UtilityAlert.setAlert<string>(new ErrorViewModel() { class_name = "alert-danger", Message = "Failed To Register!! something wrong happened." });

                    //TempData["alrt_msg"] = JsonConvert.SerializeObject(new ErrorViewModel() { class_name = "alert-danger", Message = "Failed To Register!! something wrong happened." });
                    return View("Signup");
                }
            }
            return View();
        }

        //For Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(md_userDTO user)
        {
            if (ModelState.IsValid)
            {
                var _user = new AuthDL();
                var  res =  _user.Login(user);
                if (res?.id > 0)
                {
                    HttpContext.Session.SetString("userDtls", JsonConvert.SerializeObject(res));
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    TempData["alrt_msg"] = UtilityAlert.setAlert<string>(new ErrorViewModel() { class_name = "alert-danger", Message = "Please Provide Valid Credentials" });

                    //TempData["alrt_msg"] = JsonConvert.SerializeObject(new ErrorViewModel(){class_name="alert-danger",Message= "Please Provide Valid Credentials"});
                    return View("Login");
                }

            }
            return View();
        }
    }
}
