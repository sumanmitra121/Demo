using Demo.DL;
using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class UserInfoController : Controller
    {
        public IActionResult users()
        {
            ViewBag.currentUser = Convert.ToInt32(JsonConvert.DeserializeObject<md_user>(HttpContext.Session.GetString("userDtls")).id);
            TempData["Title"] = "Users Info";
            var userInfo = new UserInfoDL();
            List<md_user> mdUsers = userInfo.GetUserInfo();
            return View(mdUsers);
        }
    }
}
