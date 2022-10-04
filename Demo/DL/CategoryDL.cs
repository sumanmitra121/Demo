using Demo.LL;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.DL
{
    public class CategoryDL
    {

        public List<md_category> GetCategory()
        {
            var catgLL = new CategoryLL();
            return catgLL.GetCategory();
        }

        public md_category GetCategoryByID(int id)
        {
            var catgLL = new CategoryLL();
            return catgLL.GetCategoryByID(id);
        }

        public int ModifyCategory(md_category catg)
        {
            var catgLL = new CategoryLL();
            return catgLL.ModifyCategory(catg);
        }

        public int DeleteCategory(int id)
        {
            var catgLL = new CategoryLL();
            return catgLL.DeleteCategory(id);
        }


    }
}
