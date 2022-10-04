using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZE
{
    public class UserFingerprintsClass
    {
        public int ID { get; set; }
        public string Full_Name { get; set; }
        public string Username { get; set; }
        public string User_Type { get; set; }
        public byte[] Fingerprint { get; set; }

    }
}
