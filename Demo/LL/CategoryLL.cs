using Demo.Dbconnection;
using Demo.Models;
using Demo.Utility;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.LL
{
    public class CategoryLL
    {

        public List<md_category> GetCategory()
        {
            List<md_category> md_catg = new List<md_category>();
            string _query = "SELECT * FROM `md_category`";
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
                                var mdCatg = new md_category();
                                mdCatg.cat_id = UtilityM.CheckNull<int>(reader["cat_id"]);
                                mdCatg.catg_name = UtilityM.CheckNull<string>(reader["catg_name"]);
                                mdCatg.created_by = UtilityM.CheckNull<string>(reader["created_by"]);
                                mdCatg.created_at = UtilityM.CheckNull<DateTime>(reader["created_at"]);
                                md_catg.Add(mdCatg);
                            }
                        }
                        return md_catg;
                    }
                }
                catch (Exception ex)
                {
                    return md_catg;
                }

            }
            catch (Exception ex)
            {
                return md_catg;
            }
        }
        
        public md_category GetCategoryByID(int id)
        {
            string _query = "SELECT * FROM `md_category` WHERE cat_id= '" + id + "'";
            var md_category = new md_category();
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
                                md_category.cat_id = UtilityM.CheckNull<int>(reader["cat_id"]);
                                md_category.catg_name = UtilityM.CheckNull<string>(reader["catg_name"]);
                                md_category.created_by = UtilityM.CheckNull<string>(reader["created_by"]);
                                md_category.created_at = UtilityM.CheckNull<DateTime>(reader["created_at"]);
                              
                            }
                        }
                        return md_category;
                    }
                }
                catch (Exception ex)
                {
                    return md_category;
                }

            }
            catch (Exception ex)
            {
                return md_category;
            }
        }
    
        public int ModifyCategory(md_category catg)
        {
            string _query = null;
            if(catg.cat_id > 0)
            {
                _query = "UPDATE `md_category` SET catg_name = '" +
                          catg.catg_name + "' WHERE cat_id = '" + catg.cat_id + "'";
            }
            else
            {
                _query = "INSERT INTO `md_category`(`catg_name`, `created_by`, `created_at`) VALUES('" +
                         catg.catg_name + "','" + catg.created_by + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss") + "')";
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


        public int DeleteCategory(int id)
        {
            string _query = null;
            _query = "DELETE FROM `md_category` WHERE cat_id = '" + id + "'";
            using var connection = dbConnection.NewConnection;
            try
            {
                using var command = dbConnection.Command(connection, _query);
                try
                {
                    command.ExecuteNonQuery();
                    return DeleteSubCategoryAgainstcategory(id,connection);
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
   
        public int DeleteSubCategoryAgainstcategory(int id,DbConnection connection)
        {
            string _query = null;
            _query = "DELETE FROM `md_subcategory` WHERE cat_id = '" + id + "'";
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
    }
}
