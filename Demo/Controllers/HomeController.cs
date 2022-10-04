using Demo.DL;
using Demo.DTO;
using Demo.Models;
using Demo.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment WebHostEnvironment;

        public HomeController(IWebHostEnvironment WebHostEnvironment)
        {
            this.WebHostEnvironment = WebHostEnvironment;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Dashboard";
            var res = getUserDtlsByTheirID();
            return View(res);
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            var res = getUserDtlsByTheirID();
            return PartialView("_EditProfileModalPartial", res);
        }

        [HttpPost]
        public IActionResult EditProfile(md_profileDTO user)
        {
            if (ModelState.IsValid)
            {
                var _user = new AuthDL();
                int res = _user.UpdateProfile(user);
                TempData["alrt_msg"] = UtilityAlert.setAlert<string>(new ErrorViewModel() { class_name = res == 1 ? "alert-success" : "alert-danger", Message = res == 1 ? "Profile Updated Successfully" : "Something wrong happened!! Please try again later" });
            }
            var user_details = getUserDtlsByTheirID();
            return PartialView("_EditProfileModalPartial", user_details);
        }

        [HttpPost]
        public IActionResult EditPassword(md_profileDTO user)
        {
            if (user.password != null && user.new_password != null && user.conf_password != null)
            {
                if (user.new_password == user.conf_password)
                {
                    var _user = new AuthDL();
                    int res = _user.UpdateProfilePassword(user);
                    TempData["alrt_msg_pass"] = UtilityAlert.setAlert<string>(new ErrorViewModel() 
                    {
                        class_name = res > 0 ? "alert-success" : "alert-danger",
                        Message = res > 0 ? "Password Updated Successfully" : res == -2 ? "Old Password does not exist" : "Something wrong happened!! Please try again later" 
                    });
                }
                else
                {
                    TempData["alrt_msg_pass"] = UtilityAlert.setAlert<string>(new ErrorViewModel()
                    {
                        class_name = "alert-danger",
                        Message = "New Password & Confirm Password must be same"
                    });
                }
            }
            else
            {
                TempData["alrt_msg_pass"] = UtilityAlert.setAlert<string>(new ErrorViewModel() { class_name = "alert-danger", Message = "Fields are empty" });
            }
            var user_details = getUserDtlsByTheirID();
            return PartialView("_EditProfileModalPartial", user_details);
        }

        public string uploadProfileImage(IFormFile files, string id)
        {
            string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "Uploads/" + id);
            string fileName = Guid.NewGuid().ToString() + "-" + files.FileName;
            if (!Directory.Exists(uploadDir))
            {
                //If this directory not exist then create this directory

                Directory.CreateDirectory(uploadDir);
            }
            else
            {
                //If this directory exist then delete all of its file
                DirectoryInfo di = new DirectoryInfo(uploadDir);
                FileInfo[] FILES = di.GetFiles();
                foreach (FileInfo file in FILES)
                {
                    file.Delete();
                }
            }
            string path = Path.Combine(uploadDir, fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                files.CopyTo(fileStream);
            }
            return fileName;
        }

        public  IActionResult  UploadImage(IFormFile files,string id,string email)
        {
            if (files != null)
            {
                string fileName = uploadProfileImage(files, id);
                var md_userProfileDTO = new md_profileDTO()
                {
                    id = Convert.ToInt32(id),
                    email = email,
                    img_path = fileName
                };
                var _user = new AuthDL();
                int res = _user.UploadImage(md_userProfileDTO);
                TempData["alrt_msg_img"] = UtilityAlert.setAlert<string>(new ErrorViewModel()
                {
                    class_name = res > 0 ? "alert-success" : "alert-danger",
                    Message = res > 0 ? "Profile Picture Updated Successfully" : "Something wrong happened!! Please try again later"
                });
            }
            else
            {
                TempData["alrt_msg_img"] = UtilityAlert.setAlert<string>(new ErrorViewModel()
                {
                    class_name = "alert-danger",
                    Message = "Please Choose A Image"
                });
            }
            var user = getUserDtlsByTheirID();
            return PartialView("_EditProfileModalPartial", user);
        }

        md_profileDTO getUserDtlsByTheirID()
        {
            var userDtls = JsonConvert.DeserializeObject<md_user>(HttpContext.Session.GetString("userDtls"));
            var _user = new AuthDL();
            return _user.getUserById(userDtls.id);
        }
    }
}
