using Demo.DTO;
using Demo.LL;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.DL
{
    public class AuthDL
    {

        public int Signup(md_user users)
        {
            var authLL = new AuthLL();
            return authLL.Signup(users);
        }
        public md_user Login(md_userDTO users)
        {
            var authLL = new AuthLL();
            return  authLL.Login(users);
        }

        public md_profileDTO getUserById(int id)
        {
            var authLL = new AuthLL();
            return authLL.getuserById(id);
        }

        public int UpdateProfile(md_profileDTO user)
        {
            var authLL = new AuthLL();
            return authLL.updateProfile(user);
        }

        public int UpdateProfilePassword(md_profileDTO user)
        {
            var authLL = new AuthLL();
            return authLL.updateProfilePassword(user);
        }
        public int UploadImage(md_profileDTO user)
        {
            var authLL = new AuthLL();
            return authLL.UpdateProfilePicture(user);
        }

    }
}
