using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class md_user
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

        [Required(ErrorMessage = "Please provide password")]
        public string password { get; set; }

        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("password", ErrorMessage = "Password and confirm password does not match")]
        public string confirmPassword { get; set; }

        public string created_by { get; set; }
        public DateTime created_at { get; set; }

        public string img_path { get; set; }
    }
}
