using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml.Schema;

namespace BloodDonationManamentSystem
{
    internal class Donor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string NIC { get; set; }
        public DateTime DOB { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string BloodType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
