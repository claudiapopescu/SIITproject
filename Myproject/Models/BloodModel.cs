using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Myproject.Models
{
    public class BloodModel
    {
        public Guid IdBlood { get; set; }
        public string Type { get; set; }
        public string RhType { get; set; }
        public string BloodLocation { get; set; }
        public int Stock { get; set; }
        public DateTime EntryDate { get; set; }
        public string LinkToTests { get; set; }
    }
}