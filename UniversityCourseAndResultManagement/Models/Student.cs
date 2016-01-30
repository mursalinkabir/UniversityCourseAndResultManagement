using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Provide Name")]
        public string Name { get; set; }

        public string RegNo { get; set; }
        [Required(ErrorMessage = "Provide Email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Provide valid email")]
        
        public string Email { get; set; }
        [Required(ErrorMessage = "Provide Contact Number")]
        [StringLength(11,MinimumLength =7,ErrorMessage = "Contact number ")]
        
        public string ContactNo { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]

        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Provide Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Select a Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
    }
}