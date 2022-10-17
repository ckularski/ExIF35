using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ExIF35
{
    public partial class backup : Form
    {
        String directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
        

        public backup()
        {
            InitializeComponent();
            directory += "\\ExIF35";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBackupLoc.Text.Equals(""))
            {
                MessageBox.Show("You must specificy a location", "Location Not Specified", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
                directory += "\\ExIF35";

                String[] filelist =  Directory.GetFiles(directory);
                foreach (String file in filelist)
                {
                    FileInfo tmpfileinfo = new FileInfo(file);
                    String newFile = txtBackupLoc.Text + "\\" + tmpfileinfo.Name;
                    if (File.Exists(newFile))
                    {
                        File.Delete(newFile);
                    }
                    File.Copy(file, newFile);
                    
                }
                MessageBox.Show("Your settings have been backed up to " + txtBackupLoc.Text, "Operation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtBackupLoc.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtRestoreLoc.Text.Equals(""))
            {
                MessageBox.Show("You must specificy a location", "Location Not Specified", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
                directory += "\\ExIF35";

                int countert = 0;
                String[] filelist = Directory.GetFiles(txtRestoreLoc.Text);
                foreach (String file in filelist)
                {

                    FileInfo tmpfileinfo = new FileInfo(file);
                    String newFile =  directory + "\\" + tmpfileinfo.Name;
                    if (tmpfileinfo.Name.Equals("exif35.config") || tmpfileinfo.Name.Equals("lenses.xml") || tmpfileinfo.Name.Equals("photographers.xml") || tmpfileinfo.Name.Equals("rolls.xml") || tmpfileinfo.Name.Equals("default_exp.xml"))
                    {
                        //MessageBox.Show(newFile);
                        
                        if (File.Exists(newFile))
                        {
                            File.Delete(newFile);
                        }
                        File.Copy(file, newFile);
                        countert++;
                    }

                }
                if (countert == 0)
                {
                    MessageBox.Show("No configuration files found, please check your path and try again", "No Settings Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Your settings have been restored from " + txtRestoreLoc.Text, "Operation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtRestoreLoc.Text = folderBrowserDialog1.SelectedPath;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            Process.Start(directory);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you wish to reset your configuration?", "Reset Config?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                File.Copy(directory + "\\exif35.config", directory + "\\exif35.bak");
                File.Delete(directory + "\\exif35.config");

                if (!File.Exists(directory + "\\exif35.config"))
                {
                    MessageBox.Show("Configuration reset to defaults. Please restart Exif35 now", "Configuration Reset", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void KillSwitch_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
            tabPage3.BackColor = Color.Red;
            DialogResult dr = MessageBox.Show("Are you absolutely certain that you wish to kill all configuration files (main, lens info, photographers, exposure defaults, etc)? There is no undo for this function (except resoring a backup).", "KILL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                int i = 0;
                foreach (String file in Directory.GetFiles(directory))
                {
                    File.Delete(file);
                    i++;
                }
                MessageBox.Show(i.ToString() + " files removed. Configuration has been terminated", "Operation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            tabPage3.BackColor = tabPage4.BackColor;
            this.BackColor = tabPage4.BackColor;
        }

        private void backup_Load(object sender, EventArgs e)
        {

        }
    }
}
