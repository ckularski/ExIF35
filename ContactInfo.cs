using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace ExIF35
{
    public partial class ContactInfo : Form
    {
        [XmlArray("Photographers"), XmlArrayItem("Photographer", typeof(Photographer))]
        public List<Photographer> photogs = new List<Photographer>();
        int selection;
        public ContactInfo(List<Photographer> pt)
        {
            InitializeComponent();
            photogs = pt;
            foreach (Photographer ptog in photogs)
            {
                listPhotographers.Items.Add(ptog.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Photographer temp = new Photographer(txtName.Text, txtTitle.Text, txtCopyright.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtPostalCode.Text, txtCountry.Text, txtPhone.Text, txtEmail.Text, txtWeb.Text);
            photogs.Add(temp);
            listPhotographers.Items.Add(txtName.Text);
            txtName.Text = "";
            txtTitle.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtPostalCode.Text = "";
            txtCountry.Text = "";
            txtCopyright.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtWeb.Text = "";
        }
        public void saveFile()
        {
            String filename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            filename += "\\ExIF35";
            if (!Directory.Exists(filename)) { Directory.CreateDirectory(filename); }
            filename += "\\photographers.xml";
            ObjectXMLSerializer<List<Photographer>>.Save(photogs, filename);
        }

        private void listPhotographers_MouseClick(object sender, MouseEventArgs e)
        {
            edit();
        }
        public void edit()
        {
            if (listPhotographers.SelectedIndices.Count > 0)
            {
                selection = listPhotographers.SelectedIndices[0];
                txtName.Text = photogs[selection].Name;
                txtTitle.Text = photogs[selection].Title;
                txtAddress.Text = photogs[selection].Address;
                txtCity.Text = photogs[selection].City;
                txtState.Text = photogs[selection].State;
                txtCountry.Text = photogs[selection].Country;
                txtPostalCode.Text = photogs[selection].PostalCode;
                txtPhone.Text = photogs[selection].Phone;
                txtEmail.Text = photogs[selection].Email;
                txtCopyright.Text = photogs[selection].Copyright;
                txtWeb.Text = photogs[selection].WWW;

                button1.Visible = false;
                button2.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listPhotographers.Items[selection] = new ListViewItem(txtName.Text);
            photogs[selection] = new Photographer(txtName.Text, txtTitle.Text, txtCopyright.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtPostalCode.Text, txtCountry.Text,txtPhone.Text, txtEmail.Text, txtWeb.Text);

            txtName.Text = "";
            txtTitle.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtPostalCode.Text = "";
            txtCountry.Text = "";
            txtCopyright.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtWeb.Text = "";

            button1.Visible = true;
            button2.Visible = false;

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deletePhotographer();
        }
        private void deletePhotographer()
        {
            if (listPhotographers.SelectedIndices.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you wish to delete " + photogs[listPhotographers.SelectedIndices[0]].Name + "?", "Delete Info", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    photogs.RemoveAt(listPhotographers.SelectedIndices[0]);
                    listPhotographers.Items.RemoveAt(listPhotographers.SelectedIndices[0]);
                    txtName.Text = "";
                    txtTitle.Text = "";
                    txtAddress.Text = "";
                    txtCity.Text = "";
                    txtState.Text = "";
                    txtPostalCode.Text = "";
                    txtCountry.Text = "";
                    txtCopyright.Text = "";
                    txtEmail.Text = "";
                    txtPhone.Text = "";
                    txtWeb.Text = "";

                    button1.Visible = true;
                    button2.Visible = false;

                }
            }
        }
    }
}
