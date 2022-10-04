using Demo.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class md_subcategory
    {
        [Key]
        public int subcat_id { get; set; }

        [Required(ErrorMessage ="Please Provide Sub Category Name")]
        public string subcat_name { get; set; }
        public md_categoryDTO category { get; set; }
        public string created_by { get; set; }
        public DateTime created_at { get; set; }
    }
}
