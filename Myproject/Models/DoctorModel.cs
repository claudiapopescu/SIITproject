using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Myproject.Models
{
    public class DoctorModel
    {
        public Guid IdDoctor { get; set; }
        [Required(ErrorMessage = "Mandatory field!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mandatory field!")]
        public string DoctorCity { get; set; }
        [Required(ErrorMessage = "Mandatory field!")]
        public int EmergencyPhone { get; set; }
    }
}