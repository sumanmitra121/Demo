using Demo.DL;
using Demo.DTO;
using Demo.Models;
using Demo.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers.Master
{
    public class SubcategoryController : Controller
    {
        public IActionResult SubCategory_Index()
        {
            TempData["Title"] = "Sub-Category";
            ViewData["Title"] = "Sub-Category";
            var subcatgDL = new SubCategoryDL();
            List<md_subcategory> subcatg = subcatgDL.GetSubCategory();
            return View(subcatg);
        }

        [HttpGet]
        public IActionResult ModifySubCategory(int id)
        {
            TempData["ID"] = id;
            ViewData["Title"] = id > 0 ? "Update SubCategory" : "Add SubCategory";
            md_subcategory subCatg = new md_subcategory();
            var catgDL = new CategoryDL();
            List<md_category> catg = catgDL.GetCategory();
            ViewBag.category =catg;
            if (id > 0)
            {
                var subCatgDL = new SubCategoryDL();
                subCatg = subCatgDL.GetSubCategoryByID(id);
            }
            else
            {
                subCatg.subcat_id = id;
                subCatg.category = new md_categoryDTO
                {
                    catg_name = "",
                    cat_id = ""
                };
            }
            ViewBag.SelectedCategory = subCatg.subcat_id > 0 ? Convert.ToString(subCatg.category.cat_id) : "";
            return View(subCatg);
        }

        [HttpPost]
        public IActionResult ModifySubCategory(md_subcategory subcatg)
        {
            if (ModelState.IsValid)
            {
                subcatg.created_by = JsonConvert.DeserializeObject<md_user>(HttpContext.Session.GetString("userDtls")).email;
                var subCatgDL = new SubCategoryDL();
                int res = subCatgDL.ModifySubcategory(subcatg);
                TempData["alrt_msg"] = UtilityAlert.setAlert<string>(new ErrorViewModel() { class_name = res > 0 ? "alert-success" : "alert-danger", Message = res > 0 ? (subcatg.subcat_id > 0 ? "Updation Successfull" : "Insertion Successfull") : "Updation Failed" });
                if (res > 0)
                {
                    return RedirectToAction("SubCategory_Index");
                }
            }
            else
            {
                var catgDL = new CategoryDL();
                List<md_category> catg = catgDL.GetCategory();
                ViewBag.category = catg;
            }
            ViewBag.SelectedCategory = subcatg.subcat_id > 0 ? Convert.ToString(subcatg.category.cat_id) : "";
            return View(subcatg);
        }

        public IActionResult DeleteSubCategory(int id)
        {
            TempData["Title"] = "Sub-Category";
            ViewData["Title"] = "Sub-Category";
            var subCatgDL = new SubCategoryDL();
            int res = subCatgDL.DeleteSubCategory(id);
            TempData["alrt_msg"] = UtilityAlert.setAlert<string>(new ErrorViewModel() { class_name = res > 0 ? "alert-success" : "alert-danger", Message = res > 0 ?  "Deleted Successfull" : "Deletion Not Possible"});
            var subcatgDL = new SubCategoryDL();
            List<md_subcategory> subcatg = subcatgDL.GetSubCategory();
            return View("SubCategory_Index", subcatg);
        }
    }
}
