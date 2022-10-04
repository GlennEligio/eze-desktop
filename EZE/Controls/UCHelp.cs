using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZE
{
    public partial class UCHelp : UserControl
    {
        public static UCHelp _instance;
        public static UCHelp Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCHelp();
                return _instance;
            }
        }
        public UCHelp()
        {
            InitializeComponent();
        }
    }
}
