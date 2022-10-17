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
    public partial class Form1 : Form
    {
        Boolean editLoad = false;
        Boolean loadDefaults = false;
        Exposure defaultEXP = new Exposure();
        public int returnSelection;
        public int count; 

        public String exposureNumber;
        public String exposureAperture;
        public String exposureSpeed;
        public String exposureDateTime;
        public String exposureDateTimeDigitized;
        public String exposureTitle;
        public String exposureDescription;
        public Exposure theExposure;
        public String exposureFocalLength;
        public String Photographer;
        public String exposureFilter;
        public String exposureRemarks;
        public double exposureLatitude;
        public double exposureLongitude;
        public double exposureAltitude; 
        public int exposureProgram;
        public int exposureOrientation;
        public int exposureFlash;
        public int exposureMeter;
        public int exposureLS;
        public int exposureSubjectDistance;
        public int exposureMode;
        public int exposureFocusMode;
        public List<String> exposureTags = new List<String>();
        public String exposureEV;
        public int exposureScene;
        public bool exposureVR; 
        Exposure thisExposure; 

        public Form1(String photog, int count)
        {
            InitializeComponent();
            this.count = count;
            this.count++;
            Exposure.Text = count.ToString();
            txtPhotog.Text = photog;
            dateTime.Text = DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss");
        }

        public Form1(Exposure thisExposure, int returnselect)
        {
            InitializeComponent();
            this.thisExposure = thisExposure;
            returnSelection = returnselect;
            editLoad = true;
            txtPhotog.Text = thisExposure.Photographer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exposureNumber = Exposure.Text;
            exposureAperture = aperture.Text;
            exposureSpeed = speed.Text;
            exposureDateTime = dateTime.Text;
            exposureDateTimeDigitized = dateTimeDigitized.Text;
            exposureTitle = title.Text;
            exposureDescription = richTextBox1.Text;
            exposureOrientation = drpOrient.SelectedIndex;
            exposureFocalLength = focalLength.Text;
            exposureProgram = drpProgram.SelectedIndex;
            exposureFlash = drpFlash.SelectedIndex;
            exposureMeter = drpMeter.SelectedIndex;
            exposureLS = drpLight.SelectedIndex;
            exposureEV = txtEV.Text;
            exposureMode = drpExposureMode.SelectedIndex;
            exposureFocusMode = drpFocusMode.SelectedIndex;
            exposureSubjectDistance = cboSR.SelectedIndex;
            exposureScene = drpScene.SelectedIndex;
            exposureRemarks = txtRemarks.Text;
            Photographer = txtPhotog.Text;
            exposureFilter = txtFilter.Text;
            exposureVR = chkVR.Checked;
            //Need to add code to update GPS

            if (!txtFilter.AutoCompleteCustomSource.Contains(txtFilter.Text) && !txtFilter.Text.Equals("")) 
            {
                txtFilter.AutoCompleteCustomSource.Add(txtFilter.Text);
                String filenameAF = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
                filenameAF += "\\ExIF35";
                if (!Directory.Exists(filenameAF)) { Directory.CreateDirectory(filenameAF); }
                filenameAF += "\\AuxFilters.E35";
       
                FileStream fs = new FileStream(filenameAF, FileMode.Create, FileAccess.Write);
                StreamWriter textOut = new StreamWriter(fs);
                String value;
                foreach (String auxFilterItem in txtFilter.AutoCompleteCustomSource)
                {
                    value = auxFilterItem;
                    textOut.WriteLine(value);
                }

                textOut.Close();

            }

            if (editLoad == false)
            {
                theExposure = new Exposure(exposureNumber, exposureAperture, exposureSpeed, exposureDateTime, exposureDateTimeDigitized, exposureTitle, exposureDescription, Photographer, exposureFocalLength);
            }
            else
            {
                theExposure = thisExposure;
                thisExposure.updateBase(exposureNumber, exposureAperture, exposureSpeed, exposureDateTime, exposureDateTimeDigitized, exposureTitle, exposureDescription, Photographer, exposureFocalLength);
            }

            theExposure.addExtended(exposureProgram, exposureOrientation, exposureFlash, exposureMeter, exposureLS, exposureEV, exposureScene, exposureSubjectDistance, exposureFilter);
            theExposure.addMoreExtended(exposureMode, exposureFocusMode);
            theExposure.setVR(exposureVR);
            theExposure.updateTags(exposureTags);
            theExposure.Remarks = exposureRemarks;
            
            if (drpLens.SelectedItem != null)
            {
                theExposure.addLensInfo(drpLens.SelectedItem.ToString());
                defaultEXP.addLensInfo(drpLens.SelectedItem.ToString());
            }
            else
            {
                theExposure.addLensInfo(drpLens.Text);
                defaultEXP.addLensInfo(drpLens.Text);
            }

            defaultEXP.addExtended(exposureProgram, 0, exposureFlash, exposureMeter, exposureLS, exposureEV, exposureScene, exposureSubjectDistance, exposureFilter);
            defaultEXP.addMoreExtended(exposureMode, exposureFocusMode);

            if (editLoad == false)
            {
                String filenameDEF = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
                filenameDEF += "\\ExIF35";
                if (!Directory.Exists(filenameDEF)) { Directory.CreateDirectory(filenameDEF); }
                filenameDEF += "\\default_exp.xml";

                ObjectXMLSerializer<Exposure>.Save(defaultEXP, filenameDEF);
            }
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            drpLens.Items.Add("Unknown");

            String filename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            filename += "\\ExIF35";
            if (!Directory.Exists(filename)) { Directory.CreateDirectory(filename); }
            filename += "\\lenses.xml";

            if (File.Exists(filename))
            {
                LensBag lb = ObjectXMLSerializer<LensBag>.Load(filename);
                foreach (Lens tmp in lb.Lenses)
                {
                    drpLens.Items.Add(tmp.Name);
                }
            }

            String filenamePT = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            filenamePT += "\\ExIF35";
            if (!Directory.Exists(filenamePT)) { Directory.CreateDirectory(filenamePT); }
            filenamePT += "\\photographers.xml";
            List<Photographer> photogs = new List<Photographer>();
            if (File.Exists(filenamePT))
            {
                photogs = ObjectXMLSerializer<List<Photographer>>.Load(filenamePT);

                foreach (Photographer pt in photogs)
                {
                    txtPhotog.Items.Add(pt.Name);
                }
            }

            String filenameAF = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            filenameAF += "\\ExIF35";
            if (!Directory.Exists(filenameAF)) { Directory.CreateDirectory(filenameAF); }
            filenameAF += "\\AuxFilters.E35";
            AutoCompleteStringCollection AuxFilterList = new AutoCompleteStringCollection();
          

            if (File.Exists(filenameAF))
            {
                int i = 0;
                FileStream fs = new FileStream(filenameAF, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader textIn = new StreamReader(fs);
                String newline = "";

                while (textIn.Peek() != -1)
                {
                    newline = textIn.ReadLine();
                    AuxFilterList.Add(newline);
                    i++;
                }
                textIn.Close();
                txtFilter.AutoCompleteCustomSource = AuxFilterList; 
            }

            String filenameDEF = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            filenameDEF += "\\ExIF35";
            if (!Directory.Exists(filenameDEF)) { Directory.CreateDirectory(filenameDEF); }
            filenameDEF += "\\default_exp.xml";

            if (File.Exists(filenameDEF))
            {
                defaultEXP = ObjectXMLSerializer<Exposure>.Load(filenameDEF);
                loadDefaults = true;
            }

            if (editLoad == false)
            {
                Exposure.Text = count.ToString();
                if (loadDefaults)
                {
                    drpProgram.SelectedIndex = defaultEXP.Program;
                    drpMeter.SelectedIndex = defaultEXP.Meter;
                    drpLight.SelectedIndex = defaultEXP.LightSource;
                    if (!defaultEXP.Lens.Equals(""))
                    {
                        drpLens.SelectedText = defaultEXP.Lens;
                    }
                    else
                    {
                        drpLens.SelectedIndex = 0;
                    }
                    drpScene.SelectedIndex = defaultEXP.Scene;
                    drpExposureMode.SelectedIndex = defaultEXP.ExposureMode;
                    drpFocusMode.SelectedIndex = defaultEXP.FocusMode;
                    txtPhotog.Text = defaultEXP.Photographer; 
                    cboSR.SelectedIndex = defaultEXP.SubjectDistance;
                    txtEV.Text = defaultEXP.ExposureBias.ToString();

                }
                else
                {
                    drpProgram.SelectedIndex = 0;
                    drpMeter.SelectedIndex = 2;
                    drpLight.SelectedIndex = 0;
                    drpLens.SelectedIndex = 0;
                    drpScene.SelectedIndex = 0;
                    drpExposureMode.SelectedIndex = 7;
                    drpFocusMode.SelectedIndex = 0;
                    cboSR.SelectedIndex = 0;
                }
                drpOrient.SelectedIndex = 0;
                drpFlash.SelectedIndex = 0;
                lblTags.Text = "Image has 0 tags";


            }
            else
            {
                drpProgram.SelectedIndex = thisExposure.Program;
                drpOrient.SelectedIndex = thisExposure.Orientation;
                drpFlash.SelectedIndex = thisExposure.Flash;
                drpMeter.SelectedIndex = thisExposure.Meter;
                drpLight.SelectedIndex = thisExposure.LightSource;
                drpScene.SelectedIndex = thisExposure.Scene;
                cboSR.SelectedIndex = thisExposure.SubjectDistance;
                drpFocusMode.SelectedIndex = thisExposure.FocusMode;
                drpExposureMode.SelectedIndex = thisExposure.ExposureMode;
                txtRemarks.Text = thisExposure.Remarks;
                exposureTags = thisExposure.Tags;
                lblTags.Text = "Image has "+thisExposure.Tags.Count+" tags";

                if (!thisExposure.Lens.Equals(""))
                {
                    drpLens.SelectedText = thisExposure.Lens;
                }
                else
                {
                    drpLens.SelectedIndex = 0;
                }

                Exposure.Text = thisExposure.Number;
                aperture.Text = thisExposure.Aperture;
                speed.Text = thisExposure.Speed;
                txtEV.Text = thisExposure.ExposureBias;
                dateTime.Text = thisExposure.Date;
                dateTimeDigitized.Text = thisExposure.DateDigitized;
                title.Text = thisExposure.Title;
                richTextBox1.Text = thisExposure.Description;
                focalLength.Text = thisExposure.FocalLength;
                txtFilter.Text = thisExposure.Filter;
                chkVR.Checked = thisExposure.VR;
                txtAltitude.Text = thisExposure.Altitude.ToString();
                txtLatitude.Text = thisExposure.Latitude.ToString();
                txtLongitude.Text = thisExposure.Longitude.ToString(); 

                button1.Text = "Save";
            }
        }

        private void dateTimeDigitized_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhotog_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void drpLight_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            txtTags FormTag = new txtTags(exposureTags);
            FormTag.ShowDialog();
            exposureTags = new List<String>();
            foreach (String strTag in FormTag.rtbTags.Text.Split('\n'))
            {
                if (!strTag.Equals(""))
                {
                    exposureTags.Add(strTag);
                }
            }
            lblTags.Text = "Image has "+exposureTags.Count+" tags";
        }

        private void drpMeter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtEV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhotog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
