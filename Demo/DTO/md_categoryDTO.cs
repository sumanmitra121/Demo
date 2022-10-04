using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.DTO
{
    public class md_categoryDTO
    {
        [Required(ErrorMessage ="Please Provide Category")]
        public string cat_id { get; set; }
        public string catg_name { get; set; }

    }
}
