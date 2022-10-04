using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.DTO
{
    public class md_profileDTO
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Please provide email")]
        [EmailAddress(ErrorMessage = "Please provide valid email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please provide username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please provide phone number")]
        [StringLength(10, ErrorMessage = "Phone number must be 10 digit", MinimumLength = 10)]
        public string phone_no { get; set; }

        [Required(ErrorMessage = "Please provide name")]
        public string name { get; set; }

        public string img_path { get; set; }

        //[Required(ErrorMessage = "Please provide new password")]

        public string password { get; set; }

        //[Required(ErrorMessage = "Please provide new password")]
        public string new_password { get; set; }

        //[Required(ErrorMessage = "Please provide confirm password")]
        //[Compare("new_password", ErrorMessage = "New Password and confirm password does not match")]

        public string conf_password { get; set; }
    }
}
