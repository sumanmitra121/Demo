using Demo.DL;
using Demo.Models;
using Demo.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers.Master
{
    public class CategoryController : Controller
    {
        public IActionResult category()
        {
            TempData["Title"] = "Category";
            ViewData["Title"] = "Category";
            var catgDL = new CategoryDL();
            List<md_category> catg = catgDL.GetCategory();
            return View(catg);
        }

        [HttpGet]
        public IActionResult modifycategory(int id)
        {
            TempData["ID"] = id;
            ViewData["Title"] = id > 0 ? "Update Category" :  "Add Category";
            md_category category = new md_category();
            if (id > 0)
            {
                var categoryDL = new CategoryDL();
                category = categoryDL.GetCategoryByID(id);
            }
            else
            {
                category.cat_id = id;
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult modifycategory(md_category category)
        {
            if (ModelState.IsValid)
            {
                category.created_by = JsonConvert.DeserializeObject<md_user>(HttpContext.Session.GetString("userDtls")).email;
                var categoryDL = new CategoryDL();
                int res = categoryDL.ModifyCategory(category);
                TempData["alrt_msg"] = UtilityAlert.setAlert<string>(new ErrorViewModel() { class_name = res > 0 ? "alert-success" : "alert-danger", Message = res > 0 ? (category.cat_id > 0 ? "Updation Successfull" : "Insertion Successfull") : "Updation Failed" });
                if (res > 0)
                {
                    return RedirectToAction("category");
                }
            }
            ViewData["Title"] = category.cat_id > 0 ? "Update Category" : "Add Category";
            return View(category);
        }

        public IActionResult deleteCategory(int id)
        {
            TempData["Title"] = "Category";
            ViewData["Title"] = "Category";
            var CatgDL = new CategoryDL();
            int res = CatgDL.DeleteCategory(id);
            TempData["alrt_msg"] = UtilityAlert.setAlert<string>(new ErrorViewModel() { class_name = res > 0 ? "alert-success" : "alert-danger", Message = res > 0 ? "Deleted Successfully" : "Deletion Not Possible" });
             var catgDL = new CategoryDL();
            List<md_category> catg = catgDL.GetCategory();
            return View("category", catg);
        }
    }
}
