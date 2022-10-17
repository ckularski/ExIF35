using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Globalization;

namespace ExIF35
{
    static class ImportMeta35
    {
        public static Roll updateRoll(Roll existingRoll, String filepath)
        {
            Roll updatedRoll = existingRoll;
            List<Dictionary<String, String>> rollData = readFile(filepath);
            List<Lens> lenses = getLensList(); 

            foreach (Exposure exp in updatedRoll.exposures)
            {
                foreach (Dictionary<String, String> expData in rollData)
                {
                    if (expData["frame_number"].Equals(exp.Number))
                    {
                        exp.Program = getExposureProgram(expData["exposure_mode"]);
                        exp.Meter = getMeterMode(expData["metering_mode"]);
                        exp.FocalLength = expData["focal_length"].Replace("mm", "");
                        if (!expData["shutter_speed"].Equals("Lo"))
                        {
                            exp.Speed = expData["shutter_speed"];
                        }
                        exp.Aperture = expData["aperture"].Replace("F/", "");
                        exp.ExposureBias = expData["exp_comp"].Replace(" EV", "");
                        if (expData["exposure_mode"].Equals("Manual"))
                        {
                            exp.ExposureBias = expData["ev_diff"].Replace(" EV", "");
                        }
                        if (expData["flash_metering_mode"].Equals("No flash"))
                        {
                            exp.Flash = 0;
                        }
                        else
                        {
                            exp.Flash = 1; 
                        }
                        
                        
                        DateTime expDate = DateTime.Parse(expData["frame_date"]);
                        DateTime unloadDate = DateTime.Now; 
                        if (!existingRoll.unloadDate.Equals(""))
                        {
                            try
                            {
                                unloadDate = DateTime.ParseExact(existingRoll.unloadDate, "yyyy:MM:dd HH:mm:ss", CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {

                            }
                        }

                        if (expDate.CompareTo(unloadDate) < 0)
                        {
                            exp.Date = expDate.ToString("yyyy") + ":" + expDate.ToString("MM") + ":" + expDate.ToString("dd") + " " + expDate.ToString("HH") + ":" + expDate.ToString("mm") + ":" + expDate.ToString("ss");
                        }
                        exp.Lens = getLensName(lenses, expData["lens"]);
                        
                        if (expData["vr"].Equals("Yes"))
                        {
                            exp.setVR(true);
                        }
                        else
                        {
                            exp.setVR(false);
                        }

                        if (expData["mult_exposure"].Equals("Yes"))
                        {
                            exp.setMultiExp(true); 
                        }
                    }
                }
            }
            return updatedRoll; 
        }

        public static Roll importRoll(Roll currentRoll, String filepath)
        {
            Roll newRoll = currentRoll;
            List<Dictionary<String, String>> rollData = readFile(filepath);

            if (currentRoll.exposures.Count < rollData.Count)
            {
                for (int i = currentRoll.exposures.Count + 1; i <= rollData.Count; i++)
                {
                    newRoll.exposures.Add(new Exposure(i.ToString(), "", "", "", "", "", "", "", ""));
                }
            }
            newRoll = updateRoll(newRoll, filepath);
            return newRoll; 
        }

        private static List<Dictionary<String, String>> readFile(String fileToRead)
        {
            List<Dictionary<String, String>> temp = new List<Dictionary<String, String>>();
            List<String> fields = new List<String>(); 

            if (File.Exists(fileToRead))
            {
                int i = 0; 
                foreach (String line in File.ReadAllLines(fileToRead))
                {
                    String tmp = line.Replace("\"", "");
                    String[] tmpArr;
                    
                    if (i == 3)
                    {
                        tmpArr = tmp.Split('\t');
                        foreach (String st in tmpArr)
                        {
                            fields.Add(st);
                        }
                    }
                    else if (i > 3)
                    {
                        int j = 0; 
                        tmpArr = tmp.Split('\t');
                        if (tmpArr.Length > 0)
                        {
                            Dictionary<String, String> frame = new Dictionary<string, string>(); 
                            foreach (String st in fields)
                            {
                                if (tmpArr.Length > j)
                                {
                                    frame.Add(st, tmpArr[j]);
                                }
                                j++;
                            }
                            temp.Add(frame);
                            
                        }
                    }
                    i++; 
                }
            }

            return temp; 
        }

        private static int getExposureProgram(String textMode)
        {
            int Program = 0; 
            switch (textMode)
            {
                case "Manual":
                    Program = 1;
                    break;
                case "Normal program":
                    Program = 2;
                    break;
                case "Aperture priority":
                    Program = 3;
                    break;
                case "Shutter priority":
                    Program = 4;
                    break;
                case "Creative program":
                    Program = 5;
                    break;
                case "Action program":
                    Program = 6;
                    break;
                case "Portrait program":
                    Program = 7;
                    break;
                case "Landscape program":
                    Program = 8;
                    break;
                default:
                    Program = 0;
                    break;
            }
            return Program; 
        }

        private static int getMeterMode(String textMode)
        {
            int Program = 0;
            switch (textMode)
            {
                case "Average":
                    Program = 1;
                    break;
                case "Center Weighted":
                    Program = 2;
                    break;
                case "Spot":
                    Program = 3;
                    break;
                case "MultiSpot":
                    Program = 4;
                    break;
                case "Multi":
                    Program = 5;
                    break;
                case "Pattern":
                    Program = 5;
                    break;
                case "AmP":
                    Program = 5;
                    break;
                case "Partial":
                    Program = 6;
                    break;
                case "other":
                    Program = 255;
                    break;
                case "Color Matrix":
                    Program = 5;
                    break;
                default:
                    Program = 0;
                    break;
            }
            return Program; 
        }

        private static List<Lens> getLensList()
        {
            List<Lens> temp = new List<Lens>();
            String filename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            filename += "\\ExIF35";
            if (!Directory.Exists(filename)) { Directory.CreateDirectory(filename); }
            filename += "\\lenses.xml";
            LensBag lb = new LensBag();


            if (File.Exists(filename))
            {
                lb = ObjectXMLSerializer<LensBag>.Load(filename);
            }
            else
            {
                List<Lens> tLenses = new List<Lens>();
                tLenses.Add(new Lens(" ", " ", " ", " ", " ", " ", " ", ""));
                lb = new LensBag(tLenses);
            }

            temp = lb.Lenses; 

            return temp; 
        }

        private static String getLensName(List<Lens> lenses, String expLens)
        {
            String exposureLens = expLens;
            foreach (Lens ln in lenses)
            {
                String tmpLensString = "";
                if (ln.maxFL.Equals(ln.minFL))
                {
                    tmpLensString = ln.minFL + "mm";
                }
                else
                {
                    tmpLensString = ln.minFL + "-" + ln.maxFL + "mm";
                }

                if (ln.fmaxmin.Equals(ln.fmaxmax))
                {
                    tmpLensString += " F/" + ln.fmaxmin;
                }
                else
                {
                    tmpLensString += " F/" + ln.fmaxmin + "-" + ln.fmaxmax;
                }

                if (expLens.Equals(tmpLensString))
                {
                    exposureLens = ln.Name;
                }
            }

            return exposureLens; 

        }
    }

    
}
