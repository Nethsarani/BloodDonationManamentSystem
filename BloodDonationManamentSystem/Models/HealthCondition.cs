using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManamentSystem.Models
{
    public class HealthCondition
    {
        public float Weight { get; set; }
        public float Hemoglobin { get; set; }

        public bool genDis { get; set; }

        public string genDisD { get; set; }
        public bool otherDis { get; set; }
        public string otherDisD { get; set; }
        public bool surgHis { get; set; }
        public bool sexHis { get; set; }
        public bool skin { get; set; }
        public string Diseases { get; set; }
        public bool Suitability { get; set; }
    }
}
