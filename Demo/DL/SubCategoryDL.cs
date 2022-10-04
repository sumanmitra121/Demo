using Demo.LL;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.DL
{
    public class SubCategoryDL
    {

        public List<md_subcategory> GetSubCategory()
        {
            var subcatgLL = new SubCategoryLL();
            return subcatgLL.GetSubCategory();
        }

        public md_subcategory GetSubCategoryByID(int id)
        {
            var subcatgLL = new SubCategoryLL();
            return subcatgLL.GetSubCategoryByID(id);
        }

        public int ModifySubcategory(md_subcategory subcatg)
        {
            var subcatgLL = new SubCategoryLL();
            return subcatgLL.ModifySubcategory(subcatg);
        }
        public int DeleteSubCategory(int id)
        {
            var subcatgLL = new SubCategoryLL();
            return subcatgLL.DeleteSubCategory(id);
        }
    }
}
