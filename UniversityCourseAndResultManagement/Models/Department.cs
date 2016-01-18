using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class Department
    {
      
    
        public int Id { get; set; }
        [Required(ErrorMessage = "*Please enter department code")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "*Department code must be two (2) to seven (7) characters long")]
        public string Code { get; set; }
        [Required(ErrorMessage = "*Please enter department name")]
        public string Name { get; set; }
   
    }
}