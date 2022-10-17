using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace ExIF35
{
    public partial class Form2 : Form
    {
        String filename = "";
        Roll thisRoll= new Roll();
        List<RollStub> library = new List<RollStub>();
        String copyrightInfo = "";
        Boolean writeCopyright = false;
        Boolean writeFilmInfo = false;
        Boolean writeContact = false;
        Boolean overwriteOriginal = false;
        Boolean needsSave = false;
        int fileSource = 0;
        int maxRoll = 0; 

        String outputPrefix = "Exp_";

        int count = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            needsSave = true;
            Form1 newExp = new Form1(txtPhotographer.Text, count);
            newExp.ShowDialog();
            if (newExp.theExposure != null)
            {
                listView1.Items.Add(new ListViewItem(new string[] { newExp.exposureNumber, newExp.exposureDateTime, "F/" + newExp.exposureAperture, newExp.exposureFocalLength + " mm", newExp.exposureSpeed, newExp.exposureTitle }));
                thisRoll.add(newExp.theExposure);
                count = Convert.ToInt32(newExp.exposureNumber); 
            }

        }
        public bool ThumbnailCallback()
        {
            return false;
        }
        private void Form2_Load(object sender, EventArgs e)
        {

            cboDevTempSys.SelectedIndex = 0;

            String filenameDev = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            filenameDev += "\\ExIF35";
            if (!Directory.Exists(filenameDev)) { Directory.CreateDirectory(filenameDev); }
            filenameDev += "\\Developers.E35";
            AutoCompleteStringCollection DeveloperList = new AutoCompleteStringCollection();

            if (File.Exists(filenameDev))
            {
                int i = 0;
                FileStream fs = new FileStream(filenameDev, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader textIn = new StreamReader(fs);
                String newline = "";

                while (textIn.Peek() != -1)
                {
                    newline = textIn.ReadLine();
                    DeveloperList.Add(newline);
                    i++;
                }
                textIn.Close();
                txtDeveloper.AutoCompleteCustomSource = DeveloperList;
            }

            String filenameFilm = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            filenameFilm += "\\ExIF35";
            if (!Directory.Exists(filenameFilm)) { Directory.CreateDirectory(filenameFilm); }
            filenameFilm += "\\Film.E35";
            AutoCompleteStringCollection FilmList = new AutoCompleteStringCollection();

            if (File.Exists(filenameFilm))
            {
                int i = 0;
                FileStream fs = new FileStream(filenameFilm, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader textIn = new StreamReader(fs);
                String newline = "";

                while (textIn.Peek() != -1)
                {
                    newline = textIn.ReadLine();
                    FilmList.Add(newline);
                    i++;
                }
                textIn.Close();
                film.AutoCompleteCustomSource = FilmList;
            }

            String filenameProc = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            filenameProc += "\\ExIF35";
            if (!Directory.Exists(filenameProc)) { Directory.CreateDirectory(filenameProc); }
            filenameFilm += "\\Processor.E35";
            AutoCompleteStringCollection ProcList = new AutoCompleteStringCollection();

            if (File.Exists(filenameProc))
            {
                int i = 0;
                FileStream fs = new FileStream(filenameProc, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader textIn = new StreamReader(fs);
                String newline = "";

                while (textIn.Peek() != -1)
                {
                    newline = textIn.ReadLine();
                    ProcList.Add(newline);
                    i++;
                }
                textIn.Close();
                txtProcessor.AutoCompleteCustomSource = FilmList;
            }

            String directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            directory += "\\ExIF35";
            String file = "rolls.xml";
            String path; 

            if (!Directory.Exists(directory)) { Directory.CreateDirectory(directory); }
            path = directory + "\\" + file;

            if (File.Exists(path))
            {
                library = ObjectXMLSerializer<List<RollStub>>.Load(path);
                refreshLibrary();
            }

            NameValueCollection nvc = new NameValueCollection();
            nvc = new configMan().getConfig();
            if (nvc.Get("validConfig").Equals("true"))
            {
                txtPhotographer.Text = nvc.Get("Photographer");
                ISO.Text = nvc.Get("ISO");
                film.Text = nvc.Get("Film");
                Roll.Text = nvc.Get("Roll");
                try
                {
                    if (!nvc.Get("MaxRoll").Equals(""))
                    {
                      maxRoll = Convert.ToInt32(nvc.Get("MaxRoll"));
                    }
                }
                catch(NullReferenceException x)
                {
                }
              

                cameramodel.Text = nvc.Get("CameraModel");
                cameramake.Text = nvc.Get("CameraMake");
                filename = nvc.Get("filename");
                copyrightInfo = nvc.Get("copyrightInfo");
                writeCopyright = Convert.ToBoolean(nvc.Get("writeCopyright"));
                writeFilmInfo = Convert.ToBoolean(nvc.Get("writeFilmInfo"));
                outputPrefix = nvc.Get("OutputPrefix");
            }

            if (!filename.Equals(""))
            {
                loadFile();
                
            }

            if (Roll.Text.Equals(""))
            {
                Roll.Text = "1";
            }

            splitContainer2.Panel2Collapsed = true;

            needsSave = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (filename.Equals(""))
            {
                saveFileDialog1.ShowDialog();
                filename = saveFileDialog1.FileName;
            }

            saveConfig();
            saveFile();

        }

        public void saveConfig()
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("Photographer", txtPhotographer.Text);
            nvc.Add("CameraMake", cameramake.Text);
            nvc.Add("CameraModel", cameramodel.Text);
            nvc.Add("Film", film.Text);
            nvc.Add("Roll", Roll.Text);
            nvc.Add("ISO", ISO.Text);
            nvc.Add("filename", filename);
            nvc.Add("copyrightInfo", copyrightInfo);
            nvc.Add("writeCopyright", writeCopyright.ToString());
            nvc.Add("writeFilmInfo", writeFilmInfo.ToString());
            nvc.Add("OutputPrefix", outputPrefix);
            nvc.Add("writeContact", writeContact.ToString());
            nvc.Add("overwriteOriginal", overwriteOriginal.ToString());
            nvc.Add("fileSource", fileSource.ToString());
            int currentRollNumber = 0;
            try
            {
                currentRollNumber = Convert.ToInt32(Roll.Text);
            }
            catch (Exception)
            {}


            if (currentRollNumber > maxRoll) { maxRoll = currentRollNumber; }
            nvc.Add("MaxRoll", maxRoll.ToString());

            new configMan().setConfig(nvc);

            if (!txtDeveloper.AutoCompleteCustomSource.Contains(txtDeveloper.Text) && !txtDeveloper.Text.Equals(""))
            {
                txtDeveloper.AutoCompleteCustomSource.Add(txtDeveloper.Text);

                String filenameDev = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
                filenameDev += "\\ExIF35";
                if (!Directory.Exists(filenameDev)) { Directory.CreateDirectory(filenameDev); }
                filenameDev += "\\Developers.E35";

                FileStream fs = new FileStream(filenameDev, FileMode.Create, FileAccess.Write);
                StreamWriter textOut = new StreamWriter(fs);
                String value;
                foreach (String developerItem in txtDeveloper.AutoCompleteCustomSource)
                {
                    value = developerItem;
                    textOut.WriteLine(value);
                }

                textOut.Close();
            }

            if (!film.AutoCompleteCustomSource.Contains(film.Text) && !film.Text.Equals(""))
            {
                film.AutoCompleteCustomSource.Add(film.Text);

                String filenameFilm = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
                filenameFilm += "\\ExIF35";
                if (!Directory.Exists(filenameFilm)) { Directory.CreateDirectory(filenameFilm); }
                filenameFilm += "\\Film.E35";

                FileStream fs = new FileStream(filenameFilm, FileMode.Create, FileAccess.Write);
                StreamWriter textOut = new StreamWriter(fs);
                String value;
                foreach (String filmItem in film.AutoCompleteCustomSource)
                {
                    value = filmItem;
                    textOut.WriteLine(value);
                }

                textOut.Close();
            }

            if (!txtProcessor.AutoCompleteCustomSource.Contains(txtProcessor.Text) && !txtProcessor.Text.Equals(""))
            {
                txtProcessor.AutoCompleteCustomSource.Add(txtProcessor.Text);

                String filenameFilm = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
                filenameFilm += "\\ExIF35";
                if (!Directory.Exists(filenameFilm)) { Directory.CreateDirectory(filenameFilm); }
                filenameFilm += "\\Processor.E35";

                FileStream fs = new FileStream(filenameFilm, FileMode.Create, FileAccess.Write);
                StreamWriter textOut = new StreamWriter(fs);
                String value;
                foreach (String procItem in txtProcessor.AutoCompleteCustomSource)
                {
                    value = procItem;
                    textOut.WriteLine(value);
                }

                textOut.Close();
            }
        }

        public void saveFile()
        {
            thisRoll.FilmType = film.Text;
            thisRoll.ISO = ISO.Text;
            thisRoll.number = Roll.Text;
            thisRoll.FilmID = txtRollID.Text;
            thisRoll.photographer = txtPhotographer.Text;
            thisRoll.cameramake = cameramake.Text;
            thisRoll.cameramodel = cameramodel.Text;
            thisRoll.DevelopDate = txtDevelopDate.Text;
            thisRoll.DeveloperSolution = txtDeveloper.Text;
            thisRoll.description = txtDesc.Text;
            thisRoll.ExposureIndex = txtEI.Text;
            thisRoll.Format = drpFormat.Text;
            thisRoll.DevelopDuration = txtDevDur.Text;
            thisRoll.loadDate = txtLoadDate.Text;
            thisRoll.unloadDate = txtUnloadDate.Text;
            thisRoll.processor = txtProcessor.Text; 

            if (cboDevTempSys.SelectedIndex == 1)
            {
                double tmpDevTemp = Convert.ToDouble(txtDevTemp.Text);
                tmpDevTemp = (tmpDevTemp - 32) * (5 / 9);
                tmpDevTemp = Math.Round(tmpDevTemp, 2);
                thisRoll.DeveloperTemp = tmpDevTemp.ToString();
            }
            else
            {
                thisRoll.DeveloperTemp = txtDevTemp.Text;
            }

            if (thisRoll.exposures.Count < 1)
            {
                thisRoll.exposures.Add(new Exposure("-1", "", "", "", "", "", "", "", ""));
            }

            ObjectXMLSerializer<Roll>.Save(thisRoll, filename);

            if (!library.Contains(thisRoll.getStub()))
            {
                library.Add(thisRoll.getStub(filename));
                refreshLibrary();
            }
            else
            {
                library.Remove(thisRoll.getStub(filename));
                library.Add(thisRoll.getStub(filename));
                refreshLibrary();
            }

            MessageBox.Show("Roll saved to " + filename, "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            needsSave = false;
        }

        public void loadFile()
        {
            if (File.Exists(filename))
            {
                listView1.Items.Clear();
                FileInfo tmpFI = new FileInfo(filename);
                Roll tmpRoll = ObjectXMLSerializer<Roll>.Load(filename);
                thisRoll = new Roll();
                thisRoll.copyData(tmpRoll);
                //thisRoll = tmpRoll; 
                Roll.Text = thisRoll.number;
                int rollNum = Convert.ToInt32(ExifPrep.GetNumbers(thisRoll.number));
                if (rollNum > maxRoll) { maxRoll = rollNum; }
                film.Text = thisRoll.FilmType;
                ISO.Text = thisRoll.ISO;
                txtRollID.Text = thisRoll.FilmID;
                txtPhotographer.Text = thisRoll.photographer; 
                cameramake.Text = thisRoll.cameramake;
                cameramodel.Text = thisRoll.cameramodel;
                txtDevelopDate.Text = thisRoll.DevelopDate;
                txtDeveloper.Text = thisRoll.DeveloperSolution;
                txtEI.Text = thisRoll.ExposureIndex;
                drpFormat.Text = thisRoll.Format;
                txtDevDur.Text = thisRoll.DevelopDuration;
                txtDevTemp.Text = thisRoll.DeveloperTemp;
                txtDesc.Text = thisRoll.description;
                txtLoadDate.Text = thisRoll.loadDate;
                txtUnloadDate.Text = thisRoll.unloadDate;
                txtProcessor.Text = thisRoll.processor;
                filenameSTATUS.Text = tmpFI.Name;
                
                //sort the exposures
                List<Exposure> SortedList = tmpRoll.exposures.OrderBy(o => Convert.ToInt32(o.Number)).ToList();
                tmpRoll.exposures = SortedList;

                    foreach (Exposure exp in tmpRoll.exposures)
                    {
                        if (!exp.Number.Equals("-1"))
                        {
                            listView1.Items.Add(new ListViewItem(new string[] { exp.Number, exp.Date, "F/" + exp.Aperture, exp.FocalLength + " mm", exp.Speed, exp.Title }));
                            thisRoll.exposures.Add(exp);
                        }
                    }
                    if (!library.Contains(thisRoll.getStub()))
                    {
                        library.Add(thisRoll.getStub(filename));
                        refreshLibrary();
                    }
                    else
                    {
                        library.Remove(thisRoll.getStub(filename));
                        library.Add(thisRoll.getStub(filename));
                        refreshLibrary();
                    }

                    if (thisRoll != null && thisRoll.exposures != null && thisRoll.exposures.Count > 0)
                    {
                        count = Convert.ToInt32(thisRoll.exposures[thisRoll.exposures.Count - 1].Number);
                    }
                    else
                    {
                        count = 0;
                    }
                
                    
                
            }
            else
            {
                MessageBox.Show("There may be a problem with your file, " + filename + ". If you believe this is in error, please try to load the file again");
            }
        }

        public void loadFile(String FILE)
        {
            if (File.Exists(FILE))
            {
                needsSave = true;
                FileInfo tmpFI = new FileInfo(FILE);
                Roll tmpRoll = ObjectXMLSerializer<Roll>.Load(FILE);
                
                    foreach (Exposure exp in tmpRoll.exposures)
                    {

                        if (!exp.Number.Equals("-1"))
                        {
                        listView1.Items.Add(new ListViewItem(new string[] { exp.Number, exp.Date, "F/" + exp.Aperture, exp.FocalLength + " mm", exp.Speed, exp.Title }));
                        thisRoll.exposures.Add(exp);
                        }
                    }
                    count++;
            }
            else
            {
                MessageBox.Show("There may be a problem with your file, " + FILE + ". If you believe this is in error, please try to load the file again");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            openRoll();


        }
        private void openRoll()
        {
            if (listView1.Items.Count > 1)
            {
                if (needsSave == true)
                {
                    DialogResult result = MessageBox.Show("Would you like to save active roll?", "Save Current?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (filename.Equals(""))
                        {
                            saveFileDialog1.ShowDialog();
                            filename = saveFileDialog1.FileName;
                        }

                        saveConfig();
                        saveFile();
                    }
                }
            }
            openFileDialog1.ShowDialog();
            filename = openFileDialog1.FileName;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            newRoll();

        }

        private void newRoll()
        {

            filename = "";
            needsSave = true;
            thisRoll = new Roll();
            txtRollID.Text = "";
            txtDeveloper.Text = "";
            txtDevelopDate.Text = "";
            txtDevTemp.Text = "";
            film.Text = "";
            ISO.Text = "";
            txtDevDur.Text = "";
            txtDesc.Text = "";
            txtEI.Text = "";
            txtLoadDate.Text = "";
            txtUnloadDate.Text = ""; 
            listView1.Items.Clear();
            count = 0;
            int RollNum = maxRoll + 1;
            Roll.Text = RollNum.ToString();
            filenameSTATUS.Text = "Not Saved";
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (needsSave == true)
            {
                DialogResult result = MessageBox.Show("Would you like to save active roll?", "Save and Close?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (filename.Equals(""))
                    {
                        saveFileDialog1.ShowDialog();
                        filename = saveFileDialog1.FileName;
                    }

                    saveConfig();
                    saveFile();
                }
            }

            String directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            directory += "\\ExIF35";
            String file = "rolls.xml";
            String path;

            if (!Directory.Exists(directory)) { Directory.CreateDirectory(directory); }
            path = directory + "\\" + file;

            ObjectXMLSerializer<List<RollStub>>.Save(library, path);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            filename = openFileDialog1.FileName;
            loadFile();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            needsSave = true;
            callExIf();

        }

        private void callExIf()
        {

            thisRoll.ISO = ISO.Text;
            thisRoll.DevelopDate = txtDevelopDate.Text;
            thisRoll.DeveloperSolution = txtDeveloper.Text;
            thisRoll.DeveloperTemp = txtDevTemp.Text;
            if (cboDevTempSys.SelectedIndex == 1)
            {
                double tmpDevTemp = Convert.ToDouble(txtDevTemp.Text);
                tmpDevTemp = (tmpDevTemp - 32) * (5 / 9);
                tmpDevTemp = Math.Round(tmpDevTemp, 2);
                thisRoll.DeveloperTemp = tmpDevTemp.ToString();
            }
            else
            {
                thisRoll.number = Roll.Text;
            }

            if (copyrightInfo == null)
            {
                copyrightInfo = "(C) " + DateTime.Now.ToString("yyyy") + " " + txtPhotographer.Text;
            }
            Form3 mapEXIF = new Form3(thisRoll);
            mapEXIF.ShowDialog();
            copyrightInfo = mapEXIF.copyrightInfo;
            writeCopyright = mapEXIF.writeCopyright;
            writeFilmInfo = mapEXIF.writeFilmInfo;
            writeContact = mapEXIF.writeContactInfo;
            overwriteOriginal = mapEXIF.overwriteOriginal;
            outputPrefix = mapEXIF.outputPrefix;
            fileSource = mapEXIF.FileSource;


            saveConfig();
        }
        private void callMate()
        {

            thisRoll.ISO = ISO.Text;
            thisRoll.DevelopDate = txtDevelopDate.Text;
            thisRoll.DeveloperSolution = txtDeveloper.Text;
            if (cboDevTempSys.SelectedIndex == 1)
            {
                double tmpDevTemp = Convert.ToDouble(txtDevTemp.Text);
                tmpDevTemp = (tmpDevTemp - 32) * (5 / 9);
                tmpDevTemp = Math.Round(tmpDevTemp, 2);
                thisRoll.DeveloperTemp = tmpDevTemp.ToString();
            }
            else
            {
                thisRoll.DeveloperTemp = txtDevTemp.Text;
            }
            thisRoll.number = Roll.Text;

            Form4 mapFiles = new Form4(thisRoll);
            mapFiles.ShowDialog();
            fileSource = mapFiles.FileSource;
            
            saveConfig();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("File Name: " + thisRoll.exposures[0].ImageFile);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            editExposure();
            
        }
        private void editExposure()
        {
            
            if (listView1.SelectedIndices.Count > 0)
            {
                needsSave = true;
                int temp = listView1.SelectedIndices[0];
                Form1 newExp = new Form1(thisRoll.exposures[temp], temp);
                newExp.ShowDialog();
                if (newExp.exposureNumber != null)
                {
                    listView1.Items[temp] = new ListViewItem(new string[] { newExp.exposureNumber, newExp.exposureDateTime, "F/" + newExp.exposureAperture, newExp.exposureFocalLength + " mm", newExp.exposureSpeed, newExp.exposureTitle });
                    thisRoll.exposures[temp] = newExp.theExposure;
                }
            }
            else
            {
                MessageBox.Show("You must select an item to edit", "Error: Nothing Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addInfo()
        {

            if (listView1.SelectedIndices.Count > 0)
            {
                needsSave = true;
                //int temp = listView1.SelectedIndices[0];
                Exposure newExp = new Exposure(); 
                Form6 newWindow = new Form6();
                newWindow.ShowDialog();
                List<int> selection = new List<int>();

                foreach (int n in listView1.SelectedIndices)
                {
                    selection.Add(n);
                }

                foreach (int i in selection)
                {
                    int temp = i;
                    newExp = thisRoll.exposures[temp];
                    if (newWindow.exposureProgram != -1)
                    {
                        newExp.Program = newWindow.exposureProgram;
                    }

                    if (newWindow.exposureFlash != -1)
                    {
                        newExp.Flash = newWindow.exposureFlash;
                    }

                    if (newWindow.exposureMeter != -1)
                    {
                        newExp.Meter = newWindow.exposureMeter;
                    }

                    if (newWindow.exposureLS != -1)
                    {
                        newExp.LightSource = newWindow.exposureLS;
                    }

                    if (!newWindow.exposureEV.Equals(""))
                    {
                        newExp.ExposureBias = newWindow.exposureEV;
                    }

                    if (newWindow.exposureMode != -1)
                    {
                        newExp.ExposureMode = newWindow.exposureMode;
                    }

                    if (newWindow.exposureFocusMode != -1)
                    {
                        newExp.FocusMode = newWindow.exposureFocusMode;
                    }

                    if (newWindow.exposureSubjectDistance != -1)
                    {
                        newExp.SubjectDistance = newWindow.exposureSubjectDistance;
                    }

                    if (newWindow.exposureScene != -1)
                    {
                        newExp.Scene = newWindow.exposureScene;
                    }

                    if (!newWindow.exposureRemarks.Equals(""))
                    {
                        newExp.Remarks = newWindow.exposureRemarks;
                    }

                    if (!newWindow.exposureFilter.Equals(""))
                    {
                        newExp.Filter = newWindow.exposureFilter;
                    }

                    if (!newWindow.exposureLens.Equals(""))
                    {
                        newExp.Lens = newWindow.exposureLens;
                    }

                    if (!newWindow.Photographer.Equals(""))
                    {
                        newExp.Photographer = newWindow.Photographer;
                    }

                    if (newExp.Number != null)
                    {
                        //listView1.Items[temp] = new ListViewItem(new string[] { newExp.Number, newExp.Date, "F/" + newExp.Aperture, newExp.FocalLength + " mm", newExp.Speed, newExp.Title });
                        thisRoll.exposures[temp] = newExp;
                    }
                }
            }
            else
            {
                MessageBox.Show("You must select an item to edit", "Error: Nothing Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            editExposure();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteExposure();
        }
        private void deleteExposure()
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you wish to delete exposure " + thisRoll.exposures[listView1.SelectedIndices[0]].Number + "?", "Delete Exposure", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    needsSave = true;
                    thisRoll.exposures.RemoveAt(listView1.SelectedIndices[0]);
                    listView1.Items.RemoveAt(listView1.SelectedIndices[0]);


                }
            }
            else
            {
                MessageBox.Show("You must select an item to delete", "Error: Nothing Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            manageLenses();
        }

        private void manageLenses()
        {
            Form5 winform5 = new Form5();
            winform5.ShowDialog();
            winform5.saveFile();
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editExposure();
        }

        private void Roll_TextChanged(object sender, EventArgs e)
        {
            needsSave = true;
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            manageContact();
        }

        private void manageContact()
        {
            String filenamePT = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            filenamePT += "\\ExIF35";
            if (!Directory.Exists(filenamePT)) { Directory.CreateDirectory(filenamePT); }
            filenamePT += "\\photographers.xml";
            List<Photographer> tmp1 = new List<Photographer>();
            if (File.Exists(filenamePT))
            {
                tmp1 = ObjectXMLSerializer<List<Photographer>>.Load(filenamePT);
            }
            if (tmp1.Count == 0)
            {
                tmp1.Add(new Photographer(txtPhotographer.Text, "", copyrightInfo, "", "", "", "", "", "", "", ""));
            }

            ContactInfo ci = new ContactInfo(tmp1);
            ci.ShowDialog();
            ci.saveFile();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newRoll();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename.Equals(""))
            {
                saveFileDialog1.ShowDialog();
                filename = saveFileDialog1.FileName;
            }

            saveConfig();
            saveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            filename = saveFileDialog1.FileName;
            FileInfo tmpFI = new FileInfo(filename);
            saveConfig();
            saveFile();
            filenameSTATUS.Text = tmpFI.Name;
        }

        private void manageLensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manageLenses();
        }

        private void managePhotographersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manageContact();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editExposure();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openRoll();
        }

        private void writeExIfToImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            callExIf();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            deleteExposure();
        }

        private void backupSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backup formbackup = new backup();
            formbackup.ShowDialog();
        }

        private void mergeFromExistingRollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //openFileDialog2.ShowDialog();
           // MessageBox.Show("Unfortunately this feature has not been implemented yet. Check back in future versions.", "Not Yet Implemented", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No help function has been added yet, however, you may send an email to \"exif35@icurtis.me\" with any problem you may have", "Help", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            loadFile(openFileDialog2.FileName);
        }

        private void addExposureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            needsSave = true;
            Form1 newExp = new Form1(txtPhotographer.Text, count);
            newExp.ShowDialog();
            if (newExp.theExposure != null)
            {
                listView1.Items.Add(new ListViewItem(new string[] { newExp.exposureNumber, newExp.exposureDateTime, "F/" + newExp.exposureAperture, newExp.exposureFocalLength + " mm", newExp.exposureSpeed, newExp.exposureTitle }));
                thisRoll.add(newExp.theExposure);
                count = Convert.ToInt32(newExp.exposureNumber);
            }
        }

        private void txtRollID_TextChanged(object sender, EventArgs e)
        {
            needsSave = true;
        }

        private void txtPhotographer_TextChanged(object sender, EventArgs e)
        {
            needsSave = true;
        }

        private void cameramake_TextChanged(object sender, EventArgs e)
        {
            needsSave = true;
        }

        private void cameramodel_TextChanged(object sender, EventArgs e)
        {
            needsSave = true;
        }

        private void film_TextChanged(object sender, EventArgs e)
        {
            needsSave = true;
        }

        private void ISO_TextChanged(object sender, EventArgs e)
        {
            needsSave = true;
        }

        private void txtDevelopDate_TextChanged(object sender, EventArgs e)
        {
            needsSave = true;
        }

        private void txtDeveloper_TextChanged(object sender, EventArgs e)
        {
            needsSave = true;
        }

        private void moreDevelopmentInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addEmptyExposuresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createBlanks();
        }
        public void createBlanks()
        {
            AddBlank tblank = new AddBlank();
            tblank.ShowDialog();
            for (int i = 0; i < tblank.HowMany; i++)
            {
                count++;
                Exposure tEXPOSURE = new Exposure(count.ToString(), "", "", "", "", "", "", "", "");
                thisRoll.exposures.Add(tEXPOSURE);
                listView1.Items.Add(new ListViewItem(new String[] { tEXPOSURE.Number, "", "", "", "", "" }));
            }
            needsSave = true;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createBlanks();
        }

        private void txtEI_TextChanged(object sender, EventArgs e)
        {
            needsSave = true;
        }

        private void refreshLibrary()
        {
            library.Sort();
            
            listView2.Items.Clear();
            foreach (RollStub rs in library)
            {
                listView2.Items.Add(rs.getListView());
            }
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeRollLibItem();
        }
        private void removeRollLibItem()
        {
            if (listView2.SelectedIndices.Count > 0)
            {
                int useIndex = listView2.SelectedIndices[0];
                DialogResult dr = MessageBox.Show("Are you sure you wish to remove this roll?", "Remove Roll?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    library.RemoveAt(useIndex);
                    refreshLibrary();
                }
            }
            else
            {
                MessageBox.Show("You must select a roll to remove", "Remove ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rToolStripMenuItem_DoubleClick(object sender, EventArgs e)
        {

        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            if (listView2.SelectedIndices.Count > 0)
            {
                int useIndex = listView2.SelectedIndices[0];
                if (needsSave == true)
                {
                    DialogResult result = MessageBox.Show("Would you like to save active roll?", "Save and Close?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (filename.Equals(""))
                        {
                            saveFileDialog1.ShowDialog();
                            filename = saveFileDialog1.FileName;
                        }

                        saveConfig();
                        saveFile();
                    }
                }

                filename = library[useIndex].Filename;
                loadFile();
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedIndices.Count >0)
            {
                label14.Text = library[listView2.SelectedIndices[0]].description;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            if (splitContainer2.Panel2Collapsed == false)
            {
                splitContainer2.Panel2Collapsed = true;
            }
            else
            {
                splitContainer2.Panel2Collapsed = false;
            }
        }

        private void expandDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (splitContainer2.Panel2Collapsed == false)
            {
                splitContainer2.Panel2Collapsed = true;
            }
            else
            {
                splitContainer2.Panel2Collapsed = false;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count >0)
            {
                int selIndex = listView1.SelectedIndices[0];
                lblFSTOP.Text = "f/"+thisRoll.exposures[selIndex].Aperture;
                lblSPEED.Text = thisRoll.exposures[selIndex].Speed + "\"";
                lblFOCAL.Text = thisRoll.exposures[selIndex].FocalLength + "mm";
                lblEV.Text = "EV: "+thisRoll.exposures[selIndex].ExposureBias;
                if (thisRoll.exposures[selIndex].Flash == 0)
                {
                    lblFlash.Text = "No Flash";
                }
                else
                {
                    lblFlash.Text = "Flash Fired";
                }
                lblLight.Text = ExifPrep.getLightSourceString(thisRoll.exposures[selIndex].LightSource);
                lblRemarks.Text = thisRoll.exposures[selIndex].Remarks;
                if (lblRemarks.Text.Equals(""))
                {
                    lblRemarks.Visible = false;
                }
                else
                {
                    lblRemarks.Visible = true;
                }
                lblPhotographer.Text = thisRoll.exposures[selIndex].Photographer;
                lblFocus.Text = "Focus: " + ExifPrep.getFocusMode(thisRoll.exposures[selIndex].FocusMode);

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            needsSave = true;
            callMate();
        }

        private void cboDevTempSys_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void existingExIf35FileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void importFromEXIF4FILMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog3.ShowDialog();
        }

        private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
        {
       
            readEXIF4FILM(openFileDialog3.FileName);
        }

        private void readEXIF4FILM(String file)
        {
            Roll workingRoll = ImportExif4Film.importRoll(file, txtPhotographer.Text);

            foreach (Exposure temp in workingRoll.exposures)
            {
                if (!thisRoll.containsExposure(temp.Number))
                {
                    listView1.Items.Add(new ListViewItem(new string[] { temp.Number, temp.Date, "F/" + temp.Aperture, temp.FocalLength + " mm", temp.Speed, temp.Title }));
                    thisRoll.exposures.Add(temp);
                }
            }

            if (thisRoll.cameraserialnumber.Equals("") && !workingRoll.cameraserialnumber.Equals(""))
            {
                thisRoll.cameraserialnumber = workingRoll.cameraserialnumber; 
            }

            if (thisRoll.loadDate.Equals(""))
            {
                thisRoll.loadDate = workingRoll.loadDate;
                txtLoadDate.Text = workingRoll.loadDate;
            }

            if (thisRoll.unloadDate.Equals(""))
            {
                thisRoll.unloadDate = workingRoll.unloadDate;
                txtUnloadDate.Text = workingRoll.unloadDate;
            }
        }

        private void addInformationToMultipleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addInfo();
        }

        private void manageCamerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCameras camForm = new frmCameras();
            camForm.ShowDialog();

        }

        private void fromMeta35DataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofdMeta35.ShowDialog();
        }

        private void ofdMeta35_FileOk(object sender, CancelEventArgs e)
        {
            
            Roll tempRoll = ImportMeta35.updateRoll(thisRoll, ofdMeta35.FileName);
            thisRoll = tempRoll;
            refreshRoll();
        }

        private void refreshRoll()
        {
            listView1.Items.Clear();
            foreach (Exposure newExp in thisRoll.exposures)
            { 
                listView1.Items.Add(new ListViewItem(new string[] { newExp.Number, newExp.Date, "F/" + newExp.Aperture, newExp.FocalLength + " mm", newExp.Speed, newExp.Title}));
            }
        
        
        }

        private void importFrommeta35ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofdImportMeta35.ShowDialog();

        }

        private void ofdImportMeta35_FileOk(object sender, CancelEventArgs e)
        {
            Roll tempRoll = ImportMeta35.importRoll(thisRoll, ofdMeta35.FileName);
            thisRoll = tempRoll;
            refreshRoll();
        }





    }
}
