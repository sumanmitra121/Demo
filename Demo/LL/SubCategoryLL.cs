using Demo.Dbconnection;
using Demo.DTO;
using Demo.Models;
using Demo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.LL
{
    public class SubCategoryLL
    {

        public List<md_subcategory> GetSubCategory()
        {
            List<md_subcategory> md_subcatg = new List<md_subcategory>();
            string _query = "SELECT a.subcat_name as subcat_name,a.subcat_id as subcat_id," +
                            " b.catg_name as cat_name,a.cat_id as cat_id ,a.created_by as created_by," +
                            " a.created_at as created_at FROM `md_subcategory` as a JOIN `md_category` " +
                            " as b WHERE a.cat_id = b.cat_id;";
            using var connection = dbConnection.NewConnection;
            try
            {
                using var command = dbConnection.Command(connection, _query);
                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                md_subcategory subCat = new md_subcategory();
                                subCat.subcat_name = UtilityM.CheckNull<string>(reader["subcat_name"]);
                                subCat.subcat_id = UtilityM.CheckNull<int>(reader["subcat_id"]);
                                subCat.category = new md_categoryDTO()
                                {
                                    cat_id =Convert.ToString(UtilityM.CheckNull<int>(reader["cat_id"])),
                                    catg_name = UtilityM.CheckNull<string>(reader["cat_name"])
                                };
                                subCat.created_by = UtilityM.CheckNull<string>(reader["created_by"]);
                                subCat.created_at = UtilityM.CheckNull<DateTime>(reader["created_at"]);
                                md_subcatg.Add(subCat);
                            }
                        }
                        return md_subcatg;
                    }
                }
                catch (Exception ex)
                {
                    return md_subcatg;
                }

            }
            catch (Exception ex)
            {
                return md_subcatg;
            }

        }

        public md_subcategory GetSubCategoryByID(int id)
        {
            md_subcategory subCatg = new md_subcategory();
            string _query = "SELECT a.subcat_id, a.cat_id, a.subcat_name, b.catg_name FROM " +
                            "`md_subcategory` as a JOIN `md_category` as b ON a.cat_id = b.cat_id " +
                            " WHERE a.subcat_id = '" + id +"'";
            using var connection = dbConnection.NewConnection;
            try
            {
                using var command = dbConnection.Command(connection, _query);
                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                subCatg.subcat_name = UtilityM.CheckNull<string>(reader["subcat_name"]);
                                subCatg.subcat_id = UtilityM.CheckNull<int>(reader["subcat_id"]);
                                subCatg.category = new md_categoryDTO()
                                {
                                    cat_id = Convert.ToString(UtilityM.CheckNull<int>(reader["cat_id"])),
                                    catg_name = UtilityM.CheckNull<string>(reader["catg_name"])
                                };
                            }
                        }
                        return subCatg;
                    }
                }
                catch (Exception ex)
                {
                    return subCatg;
                }

            }
            catch (Exception ex)
            {
                return subCatg;
            }
        }
   
        public int ModifySubcategory(md_subcategory subcatg)
        {
            string _query = null;
            if (subcatg.subcat_id > 0)
            {
                _query = "UPDATE `md_subcategory` SET subcat_name = '" + subcatg.subcat_name 
                                + "', cat_id = '" + subcatg.category.cat_id 
                                + "' WHERE subcat_id = '" + subcatg.subcat_id + "'";               
            }
            else
            {
                _query = "INSERT INTO `md_subcategory`(`subcat_name`, `cat_id`, `created_by`,`created_at`) VALUES ("
                + "'" + subcatg.subcat_name + "','"
                + subcatg.category.cat_id + "','"
                + subcatg.created_by + "','"
                + DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss") + "')";
            }
            using var connection = dbConnection.NewConnection;
            try
            {
                using var command = dbConnection.Command(connection, _query);
                try
                {
                    command.ExecuteNonQuery();
                    return 1;
                }
                catch (Exception ex)
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                return -1;
            }
        }
  
        public int DeleteSubCategory(int id)
        {
            string _query = "DELETE FROM `md_subcategory` WHERE subcat_id = '" + id + "'";
            using var connection = dbConnection.NewConnection;
            try
            {
                using var command = dbConnection.Command(connection, _query);
                try
                {
                    command.ExecuteNonQuery();
                    return 1;
                }
                catch (Exception ex)
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
