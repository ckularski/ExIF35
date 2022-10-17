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
    public partial class txtTags : Form
    {
        List<String> Tags;
        public txtTags(List<String> tags)
        {
            this.Tags = tags;
            InitializeComponent();
        }

        private void txtTags_Load(object sender, EventArgs e)
        {
            
            foreach (String tag in Tags)
            {
                rtbTags.AppendText(tag+"\n");
            }
            rtbTags.Select();
            rtbTags.Focus();
            rtbTags.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
