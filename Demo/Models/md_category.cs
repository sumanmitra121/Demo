using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class md_category
    {
        [Key]
        public int cat_id { get; set; }

        [Required(ErrorMessage = "Please Provide Category Name")]
        
        public string catg_name { get; set; }
        public string created_by { get; set; }
        public DateTime created_at { get; set; }
    }
}
