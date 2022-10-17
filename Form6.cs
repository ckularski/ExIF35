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
    public partial class Form6 : Form
    {
        public String Photographer = "";
        public String exposureFilter = "" ;
        public String exposureRemarks = "";
        public String exposureLens = "";
        public String exposureEV = "";
        public int exposureProgram;
        public int exposureFlash;
        public int exposureMeter;
        public int exposureLS;
        public int exposureSubjectDistance;
        public int exposureMode;
        public int exposureFocusMode;
        
        public int exposureScene;

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            if (drpLens.SelectedIndex != -1) { exposureLens = drpLens.SelectedItem.ToString(); }
            Photographer = txtPhotog.Text;

            exposureFilter = txtFilter.Text;
            this.Close();
        }
    }
}
