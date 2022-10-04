using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.DTO
{
    public class md_userDTO
    {
        [Required(ErrorMessage = "Please provide username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please provide password")]
        public string password { get; set; }
    }
}
