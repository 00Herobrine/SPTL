using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Connection : Form
    {
        private static bool enabled = false;
        public Connection()
        {
            InitializeComponent();
        }

        public static void show()
        {
            Form1 f1 = new Form1();
            f1.Close();
            Connection f2 = new Connection();
            f2.Show();
            enabled = true;
        }

        public static bool isEnabled()
        {
            return enabled;
        }
        
    }
}
