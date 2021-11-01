using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Myproject.Models
{
    public class MedicinesModel
    {
        public Guid IdMedicine { get; set; }
        public string MedicineName { get; set; }
        public int Packages { get; set; }
        public string Invoice { get; set; }
        public string Provider { get; set; }
        public Guid IdDoctor { get; set; }
    }
}