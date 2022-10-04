using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace EZE.Controls
{
    public partial class HowToReceiveCode : MetroUserControl
    {
        private static HowToReceiveCode _instance;
        public static HowToReceiveCode Intance
        {
            get
            {
                if (_instance == null)
                    _instance = new HowToReceiveCode();
                return _instance;
            }
        }
        public HowToReceiveCode()
        {
            InitializeComponent();
        }
    }
}
