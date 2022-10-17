using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ExIF35
{
    public partial class Form5 : Form
    {
        public List<Lens> lenses = new List<Lens>();
        int editIndex; 
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lensFLMax.Text.Equals(""))
            {
                lensFLMax.Text = lensFLmin.Text;
            }

            Lens newLens = new Lens(txtMake.Text, lensName.Text, lensFLmin.Text, lensFLMax.Text, fmaxmax.Text, fmaxmin.Text, lensID.Text, txtSerial.Text);
            addLens(newLens);
            txtMake.Text = "";
            lensName.Text = "";
            lensID.Text = "";
            lensFLMax.Text = "";
            lensFLmin.Text = "";
            fmaxmax.Text = "";
            fmaxmin.Text = "";
            txtSerial.Text = ""; 
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            loadLensFile();
        }
        private void loadLensFile()
        {
            String filename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            filename += "\\ExIF35";
            if (!Directory.Exists(filename)) { Directory.CreateDirectory(filename); }
            filename += "\\lenses.xml";

            if (File.Exists(filename))
            {
                LensBag lb = ObjectXMLSerializer<LensBag>.Load(filename);
                foreach (Lens tmp in lb.Lenses)
                {
                    addLens(tmp);
                }
            }
        }

        private void addLens(Lens tempLens)
        {
            lenses.Add(tempLens);
            String lensLength;
            if (tempLens.minFL.Equals(tempLens.maxFL))
            {
                lensLength = tempLens.minFL+" mm";
            }
            else
            {
                lensLength = tempLens.minFL+" - "+tempLens.maxFL+" mm";
            }
            listView1.Items.Add(new ListViewItem(new String[] {tempLens.Make+" "+tempLens.Name, lensLength, tempLens.fmaxmin, tempLens.fmaxmax, tempLens.LensID}));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            editLens(lenses[editIndex], editIndex);
            groupBox1.Text = "Add a Lens";
            button1.Visible = true;
            button2.Visible = false;
            txtMake.Text = "";
            lensName.Text = "";
            lensID.Text = "";
            lensFLMax.Text = "";
            lensFLmin.Text = "";
            fmaxmax.Text = "";
            fmaxmin.Text = "";
            txtSerial.Text = "";
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editPrep();
        }
        public void editPrep()
        {
            int index = listView1.SelectedIndices[0];
            editIndex = index;
            Lens tmp = lenses[index];
            txtMake.Text = tmp.Make; 
            lensName.Text = tmp.Name;
            lensID.Text = tmp.LensID;
            lensFLmin.Text = tmp.minFL;
            lensFLMax.Text = tmp.maxFL;
            fmaxmin.Text = tmp.fmaxmin;
            fmaxmax.Text = tmp.fmaxmax;
            txtSerial.Text = tmp.serialNumber;
            button1.Visible = false;
            button2.Visible = true;
            groupBox1.Text = "Edit a Lens";
        }
        public void editLens(Lens tempLens, int index)
        {
            if (lensFLMax.Text.Equals(""))
            {
                lensFLMax.Text = lensFLmin.Text;
            }
            lenses[index].updateLens(txtMake.Text, lensName.Text, lensFLmin.Text, lensFLMax.Text, fmaxmax.Text, fmaxmin.Text, lensID.Text, txtSerial.Text);
            String lensLength;
            if (tempLens.minFL.Equals(tempLens.maxFL) || tempLens.maxFL.Equals("0"))
            {
                lensLength = tempLens.minFL+" mm";
            }
            else
            {
                lensLength = tempLens.minFL + " - " + tempLens.maxFL +" mm";
            }
            listView1.Items[index]= new ListViewItem(new String[] { tempLens.Make+" "+tempLens.Name, lensLength, tempLens.fmaxmin, tempLens.fmaxmax, tempLens.LensID });
        }

        public void saveFile()
        {
            LensBag lb = new LensBag(lenses);
            String filename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            filename += "\\ExIF35";
            if (!Directory.Exists(filename)) { Directory.CreateDirectory(filename); }
            filename += "\\lenses.xml";
            ObjectXMLSerializer<LensBag>.Save(lb, filename);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteLens();
        }
        private void deleteLens()
        {
            DialogResult result = MessageBox.Show("Are you sure you wish to delete "+ lenses[listView1.SelectedIndices[0]].Name+ "?", "Delete Lens", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                lenses.RemoveAt(listView1.SelectedIndices[0]);
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);


            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editPrep();
        }
    }
}
