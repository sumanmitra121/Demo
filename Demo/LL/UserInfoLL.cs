using Demo.Dbconnection;
using Demo.Models;
using Demo.Utility;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.LL
{
    public class UserInfoLL
    {
       public List<md_user> GetUserInfo()
        { 
            List<md_user> mdUsers = new List<md_user>();
            string _query = "SELECT * FROM `md_user`";
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
                                md_user userInfo = new md_user();
                                userInfo.id = UtilityM.CheckNull<int>(reader["id"]);
                                userInfo.name = UtilityM.CheckNull<string>(reader["name"]);
                                userInfo.email = UtilityM.CheckNull<string>(reader["email"]);
                                userInfo.username = UtilityM.CheckNull<string>(reader["username"]);
                                userInfo.img_path = UtilityM.CheckNull<string>(reader["img_path"]);
                                userInfo.phone_no = UtilityM.CheckNull<string>(reader["phone_no"]);
                                mdUsers.Add(userInfo);
                            }
                        }
                        return mdUsers;
                    }
                }
                catch (Exception ex)
                {
                    return mdUsers;
                }

            }
            catch (Exception ex)
            {
                return mdUsers;
            }
        }
    }
}
