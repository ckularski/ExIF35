using System;
using System.Web.UI;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;
//using Microsoft.SolverFoundation.Common;

namespace ExIF35
{
    public partial class Form3 : Form
    {
        Roll thisRoll = new Roll();
        public String copyrightInfo;
        public Boolean writeFilmInfo = false;
        public Boolean writeCopyright = false;
        public Boolean writeContactInfo = false;
        public Boolean overwriteOriginal = false;
        public Boolean detailedDescription = false; 
        List<int> skipNums = new List<int>();
        int activeIndex = -1;
        public int FileSource = 0;
        String writeDirectory = "";
        public String outputPrefix = "";
        int counter = 0;
        
        public Form3(Roll rollOfExposures)
        {
            thisRoll = rollOfExposures;
            InitializeComponent();
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            NameValueCollection nvc;
            configMan cf = new configMan();
            nvc = cf.getConfig();
            if (nvc.Get("validConfig").Equals("true"))
            {
               
                chkCopyright.Checked = Convert.ToBoolean(nvc.Get("writeCopyright"));
                chkPrint.Checked = Convert.ToBoolean(nvc.Get("writeFilmInfo"));
                chkWriteContact.Checked = Convert.ToBoolean(nvc.Get("writeContact"));
                chkOverwrite.Checked = Convert.ToBoolean(nvc.Get("overwriteOriginal"));
                cboFileSource.SelectedIndex = Convert.ToInt32(nvc.Get("fileSource"));
                txtPrefix.Text = nvc.Get("OutputPrefix");

                writeContactInfo = chkWriteContact.Checked;
                writeCopyright = chkCopyright.Checked;
                writeFilmInfo = chkPrint.Checked;
                overwriteOriginal = chkOverwrite.Checked;
                outputPrefix = txtPrefix.Text;
            }

            if (!outputPrefix.Equals(""))
            {
                txtPrefix.Text = outputPrefix;
            }

            foreach (Exposure exp in thisRoll.exposures)
            {
                listView1.Items.Add(new ListViewItem(new String[]{exp.Number, exp.ImageFile}));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (Exposure exp in thisRoll.exposures)
            {
                listView1.Items.Add(new ListViewItem(new String[] { exp.Number, "" }));
                exp.ImageFile = "";
            }
            counter = 0;
            button4.Visible = true;
            txtfromdir.Visible = false;
            label6.Visible = true;
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                doFileProcessing(files);
            }
        }
        private void doFileProcessing(String[] files)
        {
            foreach (String curFileName in files)
            {
                if (skipNums.Contains(counter))
                {
                    counter++;
                }
                if (counter < thisRoll.exposures.Count)
                {

                    if (txtDirectory.Text.Equals(""))
                    {
                        FileInfo tfileinfo = new FileInfo(curFileName);
                        txtDirectory.Text = tfileinfo.DirectoryName;
                    }
                    FileInfo tmpfileio = new FileInfo(curFileName);
                    if (tmpfileio.Extension.Equals(".jpg") || tmpfileio.Extension.Equals(".jpeg") || tmpfileio.Extension.Equals(".JPG") || tmpfileio.Extension.Equals(".JPEG"))
                    {
                        if (!thisRoll.exposures[counter].ImageFile.Equals(""))
                        {
                            DialogResult result = MessageBox.Show("Replace file?", "Exposure " + thisRoll.exposures[counter].Number + " already contains a file, replace?", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                thisRoll.exposures[counter].ImageFile = curFileName;
                                listView1.Items[counter] = new ListViewItem(new String[] { thisRoll.exposures[counter].Number, curFileName });
                            }
                        }
                        else
                        {
                            thisRoll.exposures[counter].ImageFile = curFileName;
                            listView1.Items[counter] = new ListViewItem(new String[] { thisRoll.exposures[counter].Number, curFileName });
                        }
                        counter++;
                    }
                }
            }

          
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Filename: " + thisRoll.exposures[0].ImageFile);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            writeFilmInfo = chkPrint.Checked;
            writeCopyright = chkCopyright.Checked;
            outputPrefix = txtPrefix.Text;
            overwriteOriginal = chkOverwrite.Checked;
            writeContactInfo = chkWriteContact.Checked;
            detailedDescription = chkDetDes.Checked;
            FileSource = cboFileSource.SelectedIndex;
            writeDirectory = txtDirectory.Text;

            label1.Visible = false;
            progressBar1.Visible = true;


            writeEXIF();

            label1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Visible = false;

        }

        private void writeEXIF()
        {
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
            BitmapCreateOptions createOptions = BitmapCreateOptions.PreservePixelFormat | BitmapCreateOptions.IgnoreColorProfile;
            int numdone = 0; 
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

            List<Lens> lenses = new List<Lens>();
            String filename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            filename += "\\ExIF35";
            if (!Directory.Exists(filename)) { Directory.CreateDirectory(filename); }
            filename += "\\lenses.xml";
            LensBag lb = new LensBag();

            String detDesc = "";

            if (File.Exists(filename))
            {
                lb = ObjectXMLSerializer<LensBag>.Load(filename);
            }
            else
            {
                List<Lens> tLenses = new List<Lens>();
                tLenses.Add(new Lens(" ", " ", " ", " ", " ", " ", " ",""));
                lb = new LensBag(tLenses);
            }

            String filenamePT = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            filenamePT += "\\ExIF35";
            if (!Directory.Exists(filenamePT)) { Directory.CreateDirectory(filenamePT); }
            filenamePT += "\\photographers.xml";
            List<Photographer> photogs = new List<Photographer>();
            if (File.Exists(filenamePT))
            {
                photogs = ObjectXMLSerializer<List<Photographer>>.Load(filenamePT);
            }


            Boolean useDirectory = false;
            if (!writeDirectory.Equals(""))
            {
                if (!Directory.Exists(writeDirectory))
                {
                    Directory.CreateDirectory(writeDirectory);
                }

                useDirectory = true;

            }

            foreach (Lens tmp in lb.Lenses)
            {
                lenses.Add(tmp);
            }

            String file;
            Lens expLens = new Lens();
            int orientationbase = 0;
            for (int i = 0; i < counter; i++)
            {
                detDesc = ""; 
                if (!skipNums.Contains(i))
                {
                    numdone = i;
                    progressBar1.Value = Convert.ToInt32(Math.Floor(Convert.ToDecimal((numdone / counter) * 100)));
                    file = thisRoll.exposures[i].ImageFile;
                    Exposure exp = thisRoll.exposures[i];
                    FileInfo infoFile = new FileInfo(file);


                    Photographer pt = new Photographer(exp.Photographer, "", "", "", "", "", "", "", "", "", "");

                    foreach (Photographer tPT in photogs)
                    {
                        if (pt.Name == tPT.Name)
                        {
                            pt = tPT;
                            break;
                        }
                    }

                    if (!exp.Lens.Equals(""))
                    {
                        foreach (Lens len in lenses)
                        {
                            if (len.Name.Equals(exp.Lens))
                            {
                                expLens = len; break;
                            }
                        }
                    }

                    if (exp.DateDigitized.Equals("") || exp.DateDigitized.Equals("    :  :     :  :"))
                    {
                        exp.DateDigitized = infoFile.CreationTime.ToString("yyyy:MM:dd HH:mm:ss");
                    }

                    switch (Convert.ToInt16(exp.Orientation))
                    {
                        case 0: orientationbase = 1; break;
                        case 1: orientationbase = 6; break;
                        case 2: orientationbase = 8; break;
                        case 3: orientationbase = 3; break;
                    }

                    int lightsourcebase = ExifPrep.getLightSource(exp.LightSource);
                    String ExposureModeBase = ExifPrep.getExposureMode(exp.ExposureMode);
                    String FocusModeBase = ExifPrep.getFocusMode(exp.FocusMode);
                    String DigitalFileSource = ExifPrep.getFileSource(FileSource);
                    String digfilesrc = ExifPrep.getFileSourceIPTC(FileSource);
                    Int64 exposureBiasLong = ExifPrep.getExposureBias(exp.ExposureBias);
                    String VRState = ExifPrep.getVR(exp.VR);
                    String MEState = ExifPrep.getME(exp.multipleExposure); 

                    int detCount = 0;

                    if (!exp.Description.Equals(""))
                    {
                        detDesc = exp.Description + "\n";
                        
                    }

                    if (!exp.Aperture.Equals(""))
                    {
                        detDesc = detDesc + "f/" + exp.Aperture + ", ";
                        detCount++;
                    }
                    
                    if (!exp.FocalLength.Equals(""))
                    {
                        detDesc = detDesc + exp.FocalLength + "mm" + ", ";
                        detCount++;
                    }

                    if (!exp.Speed.Equals(""))
                    {
                        detDesc = detDesc + exp.Speed;
                        detCount++;
                    }

                    if (detCount > 0)
                    {
                        detDesc = detDesc + "\n";
                    }

                    if (!exp.ExposureBias.Equals("0.0") && !exp.ExposureBias.Equals("") && !exp.ExposureBias.Equals("0"))
                    {
                        detDesc += "EV: " + exp.ExposureBias + "\n";
                    }

                    if (!exp.Filter.Equals(""))
                    {
                        detDesc = detDesc + "Filter: " + exp.Filter + "\n";
                        detCount++; 
                    }

                    if (!thisRoll.FilmType.Equals(""))
                    {
                        detDesc = detDesc + "Film: " + thisRoll.FilmType + "\n";
                    }

                    if (!thisRoll.DeveloperSolution.Equals(""))
                    {
                        detDesc = detDesc + "Developer: " + thisRoll.DeveloperSolution + " (" + thisRoll.DevelopDuration + ", " + thisRoll.DeveloperTemp + " C) \n";
                        //detDesc = detDesc + "Developer: " + thisRoll.DeveloperSolution + " (" + thisRoll.DevelopDuration + ", " + thisRoll.DeveloperTemp + Convert.ToChar(176) + " C) \n";
                    }

                    if (!thisRoll.DevelopDate.Equals(""))
                    {
                        detDesc = detDesc + "Developed on: " + thisRoll.DevelopDate + "\n";
                    }


                    if (!exp.Remarks.Equals(""))
                    {
                        detDesc = detDesc + "Remarks: " + exp.Remarks + "\n"; 
                    }

                    if (!exp.Photographer.Equals("") && chkPhotogDesc.Checked)
                    {
                        detDesc = detDesc + "Photographer: " + exp.Photographer + "\n";
                    }

                    int fStop = 0;
                    if (!exp.Aperture.Equals(""))
                    {
                        fStop = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(exp.Aperture) * 10));
                    }

                    int maxAp = 0;
                    if (!expLens.fmaxmin.Equals(""))
                    {
                        maxAp = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(expLens.fmaxmin) * 10));
                    }

                    int speedDenom;
                    int speedNum; 

                    if (!exp.Speed.Contains('/') && !exp.Speed.Contains('.'))
                    {
                        if (exp.Speed.Equals(""))
                        {
                            speedDenom = 1;
                            speedNum = 1;
                        }
                        else
                        {
                            speedNum = Convert.ToInt16(exp.Speed);
                            speedDenom = 1;
                        }
                    }
                    else if (exp.Speed.Contains('/') && !exp.Speed.Contains('.'))
                    {
                        speedNum = Convert.ToInt16(exp.Speed.Split('/')[0]);
                        speedDenom = Convert.ToInt16(exp.Speed.Split('/')[1]);
                    }
                    else if (exp.Speed.Contains('/') && exp.Speed.Contains('.'))
                    {
                        double n = Convert.ToDouble(exp.Speed.Split('/')[0]);
                        double d = Convert.ToDouble(exp.Speed.Split('/')[1]);

                        n = n * 100;
                        d = d * 100;
                        n = Math.Floor(n);
                        d = Math.Floor(d);

                        speedNum = Convert.ToInt16(n);
                        speedDenom = Convert.ToInt16(d);
                    }
                    else if (!exp.Speed.Contains('/') && exp.Speed.Contains('.'))
                    {
                        double n = Convert.ToDouble(exp.Speed);
                        n = n * 100;
                        n = Math.Floor(n);
                        speedNum = Convert.ToInt16(n);
                        speedDenom = 100;
                    }
                    else
                    {
                        speedNum = 1;
                        speedDenom = 1;
                    }



                    String writePath = "";
                    if (!overwriteOriginal)
                    {
                        if (useDirectory == true)
                        {
                            if (chkRnEn.Checked)
                            {
                                if (thisRoll.exposures[i].Number.Length == 1)
                                {
                                    writePath = writeDirectory + "\\" + "R" + thisRoll.number + "_" + "E0" + thisRoll.exposures[i].Number + ".jpg";
                                }
                                else
                                {
                                    writePath = writeDirectory + "\\" + "R" + thisRoll.number + "_" + "E" + thisRoll.exposures[i].Number + ".jpg";
                                }
                            }
                            else
                            {
                                writePath = writeDirectory + "\\" + outputPrefix + thisRoll.exposures[i].Number + ".jpg";
                            }

                        }
                        else
                        {
                            if (chkRnEn.Checked)
                            {
                                writePath = "R" + thisRoll.number + "_" + "E" + thisRoll.exposures[i].Number + ".jpg";
                            }
                            else
                            {
                                writePath = outputPrefix + thisRoll.exposures[i].Number + ".jpg";
                            }

                        }

                    }
                    else
                    {
                        writePath = file;

                    }


                    //Section for writing
                    Stream jpgStream = new System.IO.FileStream(exp.ImageFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    BitmapDecoder original = BitmapDecoder.Create(jpgStream, createOptions, BitmapCacheOption.None);
                    JpegBitmapEncoder output = new JpegBitmapEncoder();
                    BitmapMetadata metadata = original.Frames[0].Metadata.Clone() as BitmapMetadata;
                    
                    
                    //Begin EXIF and EXIF/XMP hybrid fields

                    metadata.SetQuery("/app1/ifd/exif/{ushort=37394}", "U");

                    if (!thisRoll.ISO.Equals("")) //System.Photo.ISOSpeed
                    {
                        metadata.SetQuery("/app1/ifd/exif/{ushort=34855}", (ushort)Convert.ToInt16(thisRoll.ISO));
                        //metadata.SetQuery("/app1/ifd/exif/{ushort=34867}", (long)Convert.ToInt16(thisRoll.ISO));
                        metadata.SetQuery("/app1/ifd/exif/{ushort=34864}", (ushort)Convert.ToInt16(3));
                    }

                    if (!thisRoll.ExposureIndex.Equals("")) //System.Photo.ExposureIndex
                    {
                        //metadata.SetQuery("System.Photo.ExposureIndexNumerator", Convert.ToInt16(thisRoll.ExposureIndex));
                        //metadata.SetQuery("System.Photo.ExposureIndexDenominator", 1);
                        metadata.SetQuery("/app1/ifd/exif/{ushort=41493}", ExifPrep.getExposureIndex(thisRoll.ExposureIndex));
                    }
                    if (!exp.Photographer.Equals("")) //System.Author
                    {
                        metadata.SetQuery("/xmp/dc:creator", exp.Photographer);
                        metadata.SetQuery("/app1/ifd/{ushort=315}", exp.Photographer);
                    }
                    if (!exp.Date.Equals("")) //System.Photo.DateTaken
                    {
                        metadata.SetQuery("/app1/ifd/{ushort=306}", exp.Date); //Date Time
                        metadata.SetQuery("/app1/ifd/exif/{ushort=36867}", exp.Date);
                        metadata.SetQuery("/app1/ifd/exif/{ushort=36880}", "-05:00");
                        metadata.SetQuery("/app1/ifd/exif/{ushort=36881}", "-05:00");
                    }
                    if (!exp.DateDigitized.Equals(""))
                    {
                        metadata.SetQuery("/app1/ifd/exif/{ushort=36868}", exp.DateDigitized); //Date Time Digitized
                        metadata.SetQuery("/app1/ifd/exif/{ushort=36882}", "-05:00");
                    }
                    if (exp.Program != 0) //System.Photo.ProgramMode
                    {
                        metadata.SetQuery("/app1/ifd/exif/{ushort=34850}", (ushort)exp.Program); // Program
                    }
                    if (exp.Scene != 0) //0xA406
                    {
                        metadata.SetQuery("/app1/ifd/exif/{ushort=41990}", (ushort)exp.Scene); //Scene Capture Type
                    }
                    if (exp.Meter != 0) //0x9207
                    {
                        metadata.SetQuery("/app1/ifd/exif/{ushort=37383}", (ushort)exp.Meter); //Metering Mode
                    }
                    if (exp.LightSource != 0) //0x9206
                    {
                        metadata.SetQuery("/app1/ifd/exif/{ushort=37384}", (ushort)lightsourcebase); // Light Source
                    }
                    if (exp.SubjectDistance != 0) //0xA40C
                    {
                        metadata.SetQuery("/app1/ifd/exif/{ushort=41996}", (ushort)exp.SubjectDistance); //Subject Distance Range
                    }
                    if (!exp.FocalLength.Equals("")) //System.Photo.FocalLength
                    {
                        metadata.SetQuery("System.Photo.FocalLengthNumerator", Convert.ToUInt32(exp.FocalLength));
                        metadata.SetQuery("System.Photo.FocalLengthDenominator", Convert.ToUInt32(1));
                        metadata.SetQuery("/app1/ifd/exif/{ushort=41989}", Convert.ToUInt16(exp.FocalLength)); //35mm Focal Length
                    }
                    if (!exp.Aperture.Equals("")) //System.Photo.FNumber, System.Photo.Aperture
                    {
                        metadata.SetQuery("System.Photo.FNumberNumerator", Convert.ToUInt32(Math.Floor(Convert.ToDecimal(exp.Aperture) * 10))); //F-Stop
                        metadata.SetQuery("System.Photo.FNumberDenominator", 10);
                        metadata.SetQuery("System.Photo.ApertureNumerator", Convert.ToUInt32(Math.Floor(Convert.ToDecimal(exp.Aperture) * 10))); //Aperture
                        metadata.SetQuery("System.Photo.ApertureDenominator", 10);
                    }
                    if (!exp.Speed.Equals("")) //System.Photo.ExposureTime
                    {
                        metadata.SetQuery("System.Photo.ExposureTimeNumerator", speedNum); //Exposure Time
                        metadata.SetQuery("System.Photo.ExposureTimeDenominator", speedDenom);
                    }
                    if (!exp.Title.Equals("")) //0x010D
                    {
                        metadata.SetQuery("/app1/ifd/exif:{ushort=800}", exp.Title);//Image Title
                        metadata.SetQuery("/app1/ifd/exif:{ushort=269}", exp.Title); //Image Title

                        if (exp.Description.Equals(""))
                        {
                            metadata.SetQuery("/app1/ifd/exif:{ushort=270}", exp.Title); 
                        }
                    }
                    if (detailedDescription)
                    {
                        metadata.SetQuery("/app1/ifd/exif:{ushort=270}", detDesc); //Image Description
                    }
                    else
                    {
                        if (!exp.Description.Equals("")) //0x010E
                        {
                            metadata.SetQuery("/app1/ifd/exif:{ushort=270}", exp.Description); //Image Description
                        }
                    }
                    if (!thisRoll.cameramake.Equals("")) //0x010F
                    {
                        metadata.SetQuery("/app1/ifd/exif:{ushort=271}", thisRoll.cameramake); //Equipment Make
                    }
                    if (!thisRoll.cameramodel.Equals("")) //0x0110
                    {
                        metadata.SetQuery("/app1/ifd/exif:{ushort=272}", thisRoll.cameramodel); //Equipment Model
                    }
                    if (!thisRoll.cameraserialnumber.Equals(""))
                    {
                        metadata.SetQuery("/app1/ifd/exif:{ushort=42033}", thisRoll.cameraserialnumber); //Body Serial Number
                        
                    }

                    if (!expLens.Name.Equals("empty")) //System.Photo.MaxAperture
                    {
                        metadata.SetQuery("System.Photo.MaxApertureNumerator", maxAp);  // Maximum aperture
                        metadata.SetQuery("System.Photo.MaxApertureDenominator", 10);
                        metadata.SetQuery("/app1/ifd/exif:{ushort=42035}", expLens.Make);
                        metadata.SetQuery("/app1/ifd/exif:{ushort=42036}", expLens.Name);
                        metadata.SetQuery("/app1/ifd/exif:{ushort=42037}", expLens.serialNumber);
                        metadata.SetQuery("/xmp/ExIf35:LensSerialNumber", expLens.serialNumber);
                    }

                    if (exp.ExposureMode != 5)
                    {
                        if (exp.ExposureMode < 3)
                        {
                            metadata.SetQuery("/app1/ifd/exif/{ushort=41986}",exp.ExposureMode);
                        }
                        else
                        {
                            metadata.SetQuery("/xmp/ExIf35:ExposureMode", ExposureModeBase);
                        }
                    }

                    if (exp.FocusMode != 0)
                    {
                        metadata.SetQuery("/xmp/ExIf35:FocusMode", FocusModeBase);
                    }


                    if (exp.Longitude != 0 && exp.Latitude != 0) //using Microsoft fields
                    {
                        Dictionary<String, int> longitudeVals = ExifPrep.convertDegrees(exp.Longitude);
                        Dictionary<String, int> latitudeVals = ExifPrep.convertDegrees(exp.Latitude);

                        if (exp.Longitude < 0) { metadata.SetQuery("System.GPS.LongitudeRef", "W"); }
                        else { metadata.SetQuery("System.GPS.LongitudeRef", "E"); }

                        metadata.SetQuery("System.GPS.LatitudeNumerator", new int[3] {latitudeVals["degrees"], latitudeVals["minutes"], latitudeVals["seconds"]});
                        metadata.SetQuery("System.GPS.LatitudeDenominator", new int[3] { 1, 1, 1000});


                        if (exp.Latitude < 0) { metadata.SetQuery("System.GPS.LatitudeRef", "S"); }
                        else { metadata.SetQuery("System.GPS.LatitudeRef", "N"); }

                        metadata.SetQuery("System.GPS.LongitudeNumerator", new int[3]{longitudeVals["degrees"], longitudeVals["minutes"], longitudeVals["seconds"]});
                        metadata.SetQuery("System.GPS.LongitudeDenominator", new int[3] { 1, 1, 1000});

                        if (exp.Altitude != 0)
                        {
                            if (exp.Altitude < 0) { metadata.SetQuery("System.GPS.AltitudeRef", Convert.ToByte(1)); }
                            else { metadata.SetQuery("System.GPS.AltitudeRef", Convert.ToByte(0)); }

                            metadata.SetQuery("System.GPS.AltitudeNumerator", (int)Math.Abs(exp.Altitude));
                            metadata.SetQuery("System.GPS.AltitudeDenominator", 1); 

                        }


                    }

                    /*
                    if (exp.Longitude != 0 && exp.Latitude != 0)//Not yet implemented
                    {
                        
                        metadata.SetQuery("/app1/ifd/exif:{ushort=2}", Math.Abs(exp.Latitude)); //BROKEN: Must write as rational.
                        if (exp.Longitude < 0) {metadata.SetQuery("/app1/ifd/exif:{ushort=1}", "S");}
                        else {metadata.SetQuery("/app1/ifd/exif:{ushort=1}", "N");}

                        metadata.SetQuery("/app1/ifd/exif:{ushort=4}", Math.Abs(exp.Longitude));
                        if (exp.Latitude < 0) { metadata.SetQuery("/app1/ifd/exif:{ushort=3}", "W"); }
                        else { metadata.SetQuery("/app1/ifd/exif:{ushort=3}", "E"); }

                        if (exp.Altitude != 0)
                        {
                            if (exp.Altitude < 0) { metadata.SetQuery("/app1/ifd/exif:{ushort=5}", Convert.ToByte(1)); }
                            else { metadata.SetQuery("/app1/ifd/exif:{ushort=5}", Convert.ToByte(0)); }
                        


                        }
                     
                        byte[] gpsVer = {2, 2, 0, 0};
                        metadata.SetQuery("/app1/ifd/exif:{ushort=0}", gpsVer);

                        //metadata.SetQuery("/app1/ifd/exif:{ushort=12}", "WGS 1984");
                        //metadata.SetQuery("/app1/ifd/exif:{ushort=27}", "MANUAL");
                       
                    }
                    */


                    metadata.SetQuery("/app1/ifd/exif:{ushort=274}", (ushort)orientationbase); //Orientation
                    metadata.SetQuery("/app1/ifd/exif/{ushort=37385}", (ushort)exp.Flash); //Flash
                    metadata.SetQuery("/app1/ifd/exif/{ushort=37380}", exposureBiasLong);
                    metadata.SetQuery("/app1/ifd/exif:{ushort=305}", "ExIf 35"); //Software

                    if (chkPrint.Checked == true)
                    {
                        String filmInfo = "Shot on " + thisRoll.FilmType;
                        Encoding iso = System.Text.Encoding.ASCII;
                        Encoding utf8 = Encoding.UTF8;
                        byte[] utfBytes = utf8.GetBytes(filmInfo);
                        byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
                        string msg = iso.GetString(isoBytes);
                        metadata.SetQuery("/app1/ifd/{ushort=40092}", msg);
                        metadata.SetQuery("System.Comment", filmInfo);
                        if (exp.Remarks.Equals(""))
                        {
                            metadata.SetQuery("/app1/ifd/exif/{ushort=37510}", filmInfo);
                        }
                    }
                    else if (!exp.Remarks.Equals(""))
                    {
                        metadata.SetQuery("/app1/ifd/exif/{ushort=37510}", exp.Remarks);
                        metadata.SetQuery("/xmp/ExIf35:Remarks", exp.Remarks);
                    }

                    if (cboFileSource.SelectedIndex > 0)
                    {
                        metadata.SetQuery("/app1/ifd/exif:{ushort=41728}", FileSource); //File Source
                    }



                        //CAMERA OWNER: 42032


                    //Begin XMP Only Fields
                    if (!exp.Title.Equals(""))
                    {
                        metadata.SetQuery("/xmp/dc:title", exp.Title);
                        metadata.SetQuery("System.Subject", exp.Title);
                    }
                    if (!thisRoll.FilmType.Equals(""))
                    {
                        metadata.SetQuery("/xmp/ExIf35:Film", thisRoll.FilmType);
                    }
                    if (FileSource != 0)
                    {
                        metadata.SetQuery("/xmp/exif:FileSource", FileSource.ToString());
                        metadata.SetQuery("/xmp/ExIf35:FileSource", DigitalFileSource);
                        metadata.SetQuery("/xmp/Iptc4xmpExt:DigitalSourceType", digfilesrc);

                    }
                    metadata.SetQuery("/xmp/ExIf35:SourceFileName", infoFile.Name);


                    String tagstogo = thisRoll.FilmType+"; film photography"; 
                    if (!exp.Filter.Equals(""))
                    {
                        tagstogo += "; " + exp.Filter;
                    }
                    int j = 1;
                    if (exp.Tags.Count > 0)
                    {
                        foreach (String expTag in exp.Tags)
                        {
                            if (j > 0) { tagstogo += "; "; }
                            tagstogo += expTag;
                            j++;

                        }
                    }
                   metadata.SetQuery("System.Keywords", tagstogo);
                   

                    if (!thisRoll.loadDate.Equals(""))
                    {
                        metadata.SetQuery("/xmp/ExIf35:RollLoadDate", thisRoll.loadDate);
                    }
                    if (!thisRoll.unloadDate.Equals(""))
                    {
                        metadata.SetQuery("/xmp/ExIf35:RollUnloadDate", thisRoll.unloadDate);
                    }
                    if (!thisRoll.DeveloperSolution.Equals(""))
                    {
                        metadata.SetQuery("/xmp/ExIf35:DeveloperSolution", thisRoll.DeveloperSolution);
                    }
                    if (!thisRoll.DeveloperTemp.Equals("") && !thisRoll.DeveloperTemp.Equals("0.0"))
                    {
                        metadata.SetQuery("/xmp/ExIf35:DevelopmentTemperature", thisRoll.DeveloperTemp+Convert.ToChar(176)+" C");
                    }
                    if (!thisRoll.DevelopDuration.Equals("  :"))
                    {
                        metadata.SetQuery("/xmp/ExIf35:DevelopDuration", thisRoll.DevelopDuration);
                    }
                    if (!thisRoll.DevelopDate.Equals("    :  :"))
                    {
                        metadata.SetQuery("/xmp/ExIf35:DevelopDate", thisRoll.DevelopDate);
                    }
                    if (!thisRoll.processor.Equals(""))
                    {
                        metadata.SetQuery("/xmp/ExIf35:Processor", thisRoll.processor);
                    }
                    if (!thisRoll.FilmID.Equals(""))
                    {
                        metadata.SetQuery("/xmp/ExIf35:FilmUniqueID", thisRoll.FilmID);
                    }
                    if (!exp.Lens.Equals(""))
                    {

                        metadata.SetQuery("/xmp/MicrosoftPhoto:LensManufacturer", expLens.Make);
                        metadata.SetQuery("/xmp/MicrosoftPhoto:LensModel", exp.Lens);
                        metadata.SetQuery("/xmp/XMP:lens", expLens.Make + " " + exp.Lens);

                        //metadata.SetQuery("/xmp/aux:lens", expLens.Make + " " + exp.Lens);
                        metadata.SetQuery("/xmp/aux:LensID", expLens.LensID);
                        metadata.SetQuery("/xmp/aux:LensInfo", expLens.getAttribs());
                        //metadata.SetQuery("/app1/ifd/exif:{ushort=37500}", exp.Lens);

                    }

                    if (!VRState.Equals(""))
                    {
                        metadata.SetQuery("/xmp/ExIf35:VibrationReduction", VRState);
                    }

                    if (!MEState.Equals(""))
                    {
                        metadata.SetQuery("/xmp/ExIf35:MultipleExposure", MEState);
                    }

                    

                    if (writeCopyright)
                    {
                        metadata.SetQuery("/xmp/dc:rights", pt.Copyright);
                        metadata.SetQuery("/app1/ifd/exif:{ushort=33432}", pt.Copyright);
                    }

                    if (!thisRoll.number.Equals(""))
                    {
                        metadata.SetQuery("/xmp/ExIf35:Roll", thisRoll.number);
                    }
                    if (!exp.Number.Equals(""))
                    {
                        metadata.SetQuery("/xmp/ExIf35:ExposureNumber", exp.Number);
                    }

                    if (!exp.Filter.Equals(""))
                    {
                        metadata.SetQuery("/xmp/ExIf35:Filter", exp.Filter);
                    }
                    if (writeContactInfo)
                    {
                        if (!pt.Title.Equals(""))
                        {
                            metadata.SetQuery("/xmp/photoshop:AuthorsPosition", pt.Title);
                            metadata.SetQuery("/xmp/Iptc4xmpCore:CreatorJobtitle", pt.Title);
                        }
                        if (!pt.Address.Equals(""))
                        {
                            metadata.SetQuery("/xmp/Iptc4xmpCore:CreatorAddress", pt.Address);
                        }
                        if (!pt.City.Equals(""))
                        {
                            metadata.SetQuery("/xmp/Iptc4xmpCore:CreatorCity", pt.City);
                        }
                        if (!pt.State.Equals(""))
                        {
                            metadata.SetQuery("/xmp/Iptc4xmpCore:CreatorRegion", pt.State);
                        }
                        if (!pt.PostalCode.Equals(""))
                        {
                            metadata.SetQuery("/xmp/Iptc4xmpCore:CreatorPostalCode", pt.PostalCode);
                        }
                        if (!pt.Country.Equals(""))
                        {
                            metadata.SetQuery("/xmp/Iptc4xmpCore:CreatorCountry", pt.Country);
                        }
                        if (!pt.Phone.Equals(""))
                        {
                            metadata.SetQuery("/xmp/Iptc4xmpCore:CreatorWorkTelephone", pt.Phone);
                        }
                        if (!pt.Email.Equals(""))
                        {
                            metadata.SetQuery("/xmp/Iptc4xmpCore:CreatorWorkEmail", pt.Email);
                        }
                        if (!pt.WWW.Equals(""))
                        {
                            metadata.SetQuery("/xmp/Iptc4xmpCore:CreatorWorkURL", pt.WWW);
                        }
                        
                    }

                    if (thisRoll.cameramodel.Contains("NIKON F") || thisRoll.cameramodel.Contains("Nikon F") || thisRoll.cameramodel.Contains("NIKON N") || thisRoll.cameramodel.Contains("Nikon N"))
                    {
                        metadata.SetQuery("/xmp/ExIf35:CameraType", "Film SLR");
                    }

                    metadata.SetQuery("/app1/ifd/exif:{ushort=36864}", "0231"); //Exif version

                    output.Frames.Add(BitmapFrame.Create(original.Frames[0], original.Frames[0].Thumbnail, metadata, original.Frames[0].ColorContexts));
                    Stream outputFile = File.Open(writePath + ".tmp", FileMode.Create, FileAccess.ReadWrite);
                    output.Save(outputFile);
                    outputFile.Close();
                    jpgStream.Close();

                    File.Delete(writePath);
                    File.Move(writePath + ".tmp", writePath);
                }
            }
            MessageBox.Show("Finished Wrting ExIf", "Operation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtDirectory.Text = folderBrowserDialog1.SelectedPath;
            
        }

        private void txtDirectory_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkOverwrite_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOverwrite.Checked)
            {
                txtDirectory.Enabled = false;
                txtPrefix.Enabled = false;
            }
            else
            {
                txtDirectory.Enabled = true;
                txtPrefix.Enabled = true;
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.ShowDialog();
            String getPath = folderBrowserDialog2.SelectedPath;
            if (getPath != null)
            {
                doFileProcessing(Directory.GetFiles(getPath));
            }
            button4.Visible = false;
            label6.Visible = false;
            txtfromdir.Text = getPath;
            txtfromdir.Visible = true;

        }

        private void folderBrowserDialog2_HelpRequest(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            label1.Visible = false;
            progressBar1.Visible = true;
            writeEXIF();
        }

        private void txtfromdir_Click(object sender, EventArgs e)
        {
            txtfromdir.Visible = false;
            button4.Visible = true;
            label6.Visible = true;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Visible = false;
        }

        private void skipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int skipNumber = listView1.SelectedIndices[0];
                if (skipNums.Contains(skipNumber))
                {
                    skipNums.Remove(skipNumber);
                    listView1.Items[skipNumber] = new ListViewItem(new string[] {thisRoll.exposures[skipNumber].Number, "File Not Set"});

                }
                else
                {
                    skipNums.Add(skipNumber);
                    listView1.Items[skipNumber] = new ListViewItem(new string[] { thisRoll.exposures[skipNumber].Number, "Skipped" });
                }

            }
        }

        private void setFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                activeIndex = listView1.SelectedIndices[0];
                openFileDialog1.ShowDialog();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            thisRoll.exposures[activeIndex].ImageFile = openFileDialog1.FileName;
            if (skipNums.Contains(activeIndex))
            {
                skipNums.Remove(activeIndex);
            }
            listView1.Items[activeIndex] = new ListViewItem(new string[] { thisRoll.exposures[activeIndex].Number, thisRoll.exposures[activeIndex].ImageFile });
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { this.TopMost = false; }
            else { this.TopMost = true; }
        }

        private void chkKeepExpNum_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }



    }
}
