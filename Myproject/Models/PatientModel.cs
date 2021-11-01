using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Myproject.Models
{
    public class PatientModel
    {
        public Guid IDPatient { get; set; }

        [Required(ErrorMessage="Mandatory field!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Mandatory field!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Mandatory field!")]
        public string UserAddress { get; set; }
        [Required(ErrorMessage = "Mandatory field!")]
        public int PhoneNumber { get; set; }
    }
}