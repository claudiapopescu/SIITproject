using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Myproject.Models
{
    public class DoctorModel
    {
        public Guid IdDoctor { get; set; }
        public string Name { get; set; }
        public string DoctorCity { get; set; }
        public int EmergencyPone { get; set; }
    }
}