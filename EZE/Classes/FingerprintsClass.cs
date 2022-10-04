using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZE
{
    public class FingerprintsClass
    {
        public int ID { get; set; }
        public string Student_Number { get; set; }
        public string Full_Name { get; set; }
        public string Year_and_Section { get; set; }
        public string Year_Level { get; set; }
        public byte[] Fingerprint { get; set; }        
    }
}
