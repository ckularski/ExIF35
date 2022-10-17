using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace ExIF35
{
    public partial class frmCameras : Form
    {
        bool saved = false; 
        public frmCameras()
        {
            InitializeComponent();
        }

        private void loadCameraFile()
        {
            String filename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            filename += "\\ExIF35";
            if (!Directory.Exists(filename)) { Directory.CreateDirectory(filename); }
            filename += "\\cameras.xml";

            if (File.Exists(filename))
            {
                CameraBag cb = ObjectXMLSerializer<CameraBag>.Load(filename);
                foreach (Camera tmp in cb.Cameras)
                {
                    addCamera(tmp);
                }
            }
        }

        private void addCamera(Camera tempCam)
        {
            dgvCameras.Rows.Insert(0, 1);
            dgvCameras.Rows[0].Cells[0].Value = tempCam.Name;
            dgvCameras.Rows[0].Cells[1].Value = tempCam.Make;
            dgvCameras.Rows[0].Cells[2].Value = tempCam.Model;
            dgvCameras.Rows[0].Cells[3].Value = tempCam.serialNumber;
   
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Camera> cameras = new List<Camera>(); 
            foreach (DataGridViewRow dgr in dgvCameras.Rows)
            {
                if (!dgr.IsNewRow)
                {
                    cameras.Add(new Camera(dgr.Cells[1].Value.ToString(), dgr.Cells[2].Value.ToString(), dgr.Cells[0].Value.ToString(), dgr.Cells[3].Value.ToString()));
                        
                }
            }

            CameraBag cb = new CameraBag(cameras);
            String filename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            filename += "\\ExIF35";
            if (!Directory.Exists(filename)) { Directory.CreateDirectory(filename); }
            filename += "\\cameras.xml";
            ObjectXMLSerializer<CameraBag>.Save(cb, filename);
            saved = true;
        }

        private void frmCameras_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                DialogResult dr = MessageBox.Show("Items have not been saved. Are you sure you wish to exit?", "Exit Without Saving?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    e.Cancel = true; 
                }
            }
        }

        private void frmCameras_Load(object sender, EventArgs e)
        {
            loadCameraFile();
        }
    }
}
