using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExIF35
{
    public partial class AddBlank : Form
    {
        public int HowMany = 0;
        public AddBlank()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.HowMany = Convert.ToInt16(this.numExp.Text);
            this.Close();
        }
    }
}
