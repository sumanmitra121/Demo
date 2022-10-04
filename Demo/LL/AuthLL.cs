using Demo.Dbconnection;
using Demo.DTO;
using Demo.Models;
using Demo.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.LL
{
    public class AuthLL
    {
        public int Signup(md_user user)
        {
            string _query = "INSERT INTO `md_user`(`name`, `email`, `username`, `phone_no`, `password`, `created_at`,`created_by`) VALUES ("
                + "'" + user.name + "','"
                + user.email + "','"
                + user.username + "','"
                + user.phone_no + "','"
                + BCrypt.Net.BCrypt.HashPassword(user.password) + "','"
                + DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss") + "','"
                + user.email + "')";
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
        public md_user Login(md_userDTO user)
        {
            var _user = new md_user();
            string _query = "SELECT * FROM md_user WHERE username = '" + user.username + "';";
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

                                if (BCrypt.Net.BCrypt.Verify(user.password, UtilityM.CheckNull<string>(reader["password"])))
                                {
                                    _user.id = UtilityM.CheckNull<int>(reader["id"]);
                                    _user.name = UtilityM.CheckNull<string>(reader["name"]);
                                    _user.email = UtilityM.CheckNull<string>(reader["email"]);
                                    _user.phone_no = UtilityM.CheckNull<string>(reader["phone_no"]);
                                    _user.created_by = UtilityM.CheckNull<string>(reader["created_by"]);
                                    _user.created_at = UtilityM.CheckNull<DateTime>(reader["created_at"]);
                                    _user.username = UtilityM.CheckNull<string>(reader["username"]);

                                }
                            }
                        }
                        return _user;
                    }
                }
                catch (Exception ex)
                {
                    return _user;
                }

            }
            catch (Exception ex)
            {
                return _user;
            }
        }

        public md_profileDTO getuserById(int id)
        {
            var _user = new md_profileDTO();
            string _query = "SELECT * FROM md_user WHERE id = '" + id + "';";
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
                                _user.id = UtilityM.CheckNull<int>(reader["id"]);
                                _user.name = UtilityM.CheckNull<string>(reader["name"]);
                                _user.email = UtilityM.CheckNull<string>(reader["email"]);
                                _user.phone_no = UtilityM.CheckNull<string>(reader["phone_no"]);
                                _user.username = UtilityM.CheckNull<string>(reader["username"]);
                                _user.password = UtilityM.CheckNull<string>(reader["password"]);
                                _user.img_path = UtilityM.CheckNull<string>(reader["img_path"]);
                            }
                        }
                        return _user;
                    }
                }
                catch (Exception ex)
                {
                    return _user;
                }

            }
            catch (Exception ex)
            {
                return _user;
            }
        }

        public int updateProfile(md_profileDTO user)
        {
            string _query = "UPDATE `md_user` SET name = '" +
                             user.name + "', email = '"
                             + user.email + "', username = '"
                             + user.username + "', phone_no = '"
                             + user.phone_no + "', created_by ='"
                             + user.email + "', created_at = '"
                             + DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss") + "'"
                             + " WHERE id = '" + user.id + "'";

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
                    return -1;
                }

            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public int updateProfilePassword(md_profileDTO user)
        {
            var getUserDtls = getuserById(user.id);

            if (BCrypt.Net.BCrypt.Verify(user.password, getUserDtls?.password))
            {
                string _query = "UPDATE `md_user` SET password = '" +
                                 BCrypt.Net.BCrypt.HashPassword(user.new_password) + "', created_at = '"
                                 + DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss") + "'"
                                 + " WHERE id = '" + user.id + "'";

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
                        return -1;
                    }

                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            else
            {
                return -2;
            }

        }

        public int UpdateProfilePicture(md_profileDTO user)
        {

            string _query = "UPDATE `md_user` SET img_path = '" +
                               user.img_path + "'"
                               + " WHERE id = '" + user.id + "'";
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
                    return -1;
                }

            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
