using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Field is Required")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter an Address")]
        public string Address { get; set; }
        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Enter your email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Enter valid email address")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter the Phone Number")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Select a Designation")]
        [DisplayName("Designation")]
        public int DesignationId { get; set; }
        [Required(ErrorMessage = "Please Select a Department")]
        [DisplayName("Department")]
        public string DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Enter credit Amount")]
        //[RegularExpression(@"^\d+.\d{0,2}$",ErrorMessage = "Enter a non negative Number")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Non Negative Number")]
        [DisplayName("Credit to be taken")]
        public int Credit { get; set; }

        public int RemainCredit { get; set; }
    }
}