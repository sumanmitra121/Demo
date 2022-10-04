using Demo.LL;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.DL
{
    public class UserInfoDL
    {

        public List<md_user> GetUserInfo()
        {
            var userInfoLL = new UserInfoLL();
            return userInfoLL.GetUserInfo();
        }
    }
}
