using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExIF35
{
    static class ExifPrep
    {
        public static String getFileSource(int FileSource)
        {
            String DigitalFileSource = "Unknown";
            switch (FileSource)
            {
                case 0: DigitalFileSource = "Unknown"; break;
                case 1: DigitalFileSource = "Film Scanner"; break;
                case 2: DigitalFileSource = "Reflected Image Scanner";break;
                case 3: DigitalFileSource = "Digital Still Camera";break;
            }
            return DigitalFileSource;
        }
        public static String getFileSourceIPTC(int FileSource)
        {
            String DigitalFileSource = "Unknown";
            switch (FileSource)
            {
                case 1: DigitalFileSource = "negativeFilm"; break;
                case 2: DigitalFileSource = "print"; break;
                case 3: DigitalFileSource = "digitalCapture"; break;
            }
            return DigitalFileSource;
        }

        public static Int64 getExposureBias(String EBias)
        { 
            if (EBias.Contains("/"))
            {

                EBias = FractionToDouble(EBias).ToString(); 
                /*double tmp = Convert.ToDouble(EBias.Split('/')[0]);
                tmp = tmp / Convert.ToDouble(EBias.Split('/')[1]);
                tmp = Math.Round(tmp, 1);
                EBias = tmp.ToString();*/
                
                

            }

            int exposureBias = Convert.ToInt16(Math.Floor(Convert.ToDouble(EBias) * 10));
            Byte[] exposureBiasByte = new Byte[8];
            if (exposureBias < 0)
            {
                exposureBias = 256 + exposureBias;
                exposureBiasByte[1] = 255;
                exposureBiasByte[2] = 255;
                exposureBiasByte[3] = 255;
            }
            else
            {
                exposureBiasByte[1] = 0;
                exposureBiasByte[2] = 0;
                exposureBiasByte[3] = 0;
            }
            
            exposureBiasByte[0] = Convert.ToByte(exposureBias);
            exposureBiasByte[4] = 10;
            exposureBiasByte[5] = 0;
            exposureBiasByte[6] = 0;
            exposureBiasByte[7] = 0;

            return BitConverter.ToInt64(exposureBiasByte, 0);
        }
        public static Int32 getExposureIndex(String EI)
        {
            Byte[] tmp = new Byte[4];
            tmp = BitConverter.GetBytes(Convert.ToInt16(EI));
            //tmp[1] = BitConverter.GetBytes(Convert.ToInt16(EI))[1];
            //tmp[2] = 1;
            //tmp[3] = 0;

            return BitConverter.ToInt16(tmp, 0);
        }

        public static int getLightSource(int ls)
        {

            int lightsourcebase = 0;
            switch (ls)
            {
                case 0: lightsourcebase = 0; break;
                case 1: lightsourcebase = 1; break;
                case 2: lightsourcebase = 2; break;
                case 3: lightsourcebase = 3; break;
                case 4: lightsourcebase = 4; break;
                case 5: lightsourcebase = 9; break;
                case 6: lightsourcebase = 10; break;
                case 7: lightsourcebase = 11; break;
                case 8: lightsourcebase = 12; break;
                case 9: lightsourcebase = 13; break;
                case 10: lightsourcebase = 14; break;
                case 11: lightsourcebase = 15; break;
                case 12: lightsourcebase = 17; break;
                case 13: lightsourcebase = 18; break;
                case 14: lightsourcebase = 19; break;
                case 15: lightsourcebase = 20; break;
                case 16: lightsourcebase = 21; break;
                case 17: lightsourcebase = 22; break;
                case 18: lightsourcebase = 23; break;
                case 19: lightsourcebase = 24; break;
                case 20: lightsourcebase = 255; break;

            }
            return lightsourcebase;
        }

        public static String getLightSourceString(int ls)
        {

            String lightsourcebase = "";
            switch (ls)
            {
                case 0: lightsourcebase = "Unknown"; break;
                case 1: lightsourcebase = "Daylight"; break;
                case 2: lightsourcebase = "Flourescent"; break;
                case 3: lightsourcebase = "Tungsten"; break;
                case 4: lightsourcebase = "Flash"; break;
                case 5: lightsourcebase = "Fine Weather"; break;
                case 6: lightsourcebase = "Cloudy Weather"; break;
                case 7: lightsourcebase = "Shade"; break;
                case 8: lightsourcebase = "Daylight fluorescent (D 5700 – 7100K)"; break;
                case 9: lightsourcebase = "Day white fluorescent (N 4600 – 5400K)"; break;
                case 10: lightsourcebase = "Cool white fluorescent (W 3900 – 4500K)"; break;
                case 11: lightsourcebase = "White fluorescent (WW 3200 – 3700K)"; break;
                case 12: lightsourcebase = "Standard light A"; break;
                case 13: lightsourcebase = "Standard light B"; break;
                case 14: lightsourcebase = "Standard light C"; break;
                case 15: lightsourcebase = "D55"; break;
                case 16: lightsourcebase = "D65"; break;
                case 17: lightsourcebase = "D75"; break;
                case 18: lightsourcebase = "D50"; break;
                case 19: lightsourcebase = "ISO studio tungsten"; break;
                case 20: lightsourcebase = "Other Light Source"; break;

            }
            return lightsourcebase;
        }

        public static String getFocusMode(int fm)
        {
            String FocusModeBase = "";
            switch (fm)
            {
                case 0: FocusModeBase = "Unknown"; break;
                case 1: FocusModeBase = "AF-S"; break;
                case 2: FocusModeBase = "AF-C"; break;
                case 3: FocusModeBase = "AF-A"; break;
                case 4: FocusModeBase = "M"; break;
            }
            return FocusModeBase;
        }

        public static String getExposureMode(int em)
        {
            String ExposureModeBase = "";
            switch (em)
            {
                case 0: ExposureModeBase = "Auto"; break;
                case 1: ExposureModeBase = "Manual"; break;
                case 2: ExposureModeBase = "Auto Bracket"; break;
                case 3: ExposureModeBase = "Continuous"; break;
                case 4: ExposureModeBase = "Self-Timer"; break;
                case 5: ExposureModeBase = "IR Control"; break;
                case 6: ExposureModeBase = "Cable Release"; break;
                case 7: ExposureModeBase = "Unknown"; break;
            }
            return ExposureModeBase;
        }

        public static String getVR(bool vr)
        {
            String VRState = "False";
            if (vr == true)
            {
                VRState = "True";
            }
            return VRState;
        }

        public static String getME(bool me)
        {
            String MEState = "False";
            if (me == true)
            {
                MEState = "True";
            }

            return MEState; 
        }
        static double FractionToDouble(string fraction)
        {
            double result;

            if (double.TryParse(fraction, out result))
            {
                return result;
            }

            string[] split = fraction.Split(new char[] { ' ', '/' });

            if (split.Length == 2 || split.Length == 3)
            {
                int a, b;

                if (int.TryParse(split[0], out a) && int.TryParse(split[1], out b))
                {
                    if (split.Length == 2)
                    {
                        return (double)a / b;
                    }

                    int c;

                    if (int.TryParse(split[2], out c))
                    {
                        return a + (double)b / c;
                    }
                }
            }

            throw new FormatException("Not a valid fraction.");
        }

        public static Dictionary<String, int> convertDegrees(Double decimalDegrees)
        {
            Dictionary<String, int> output = new Dictionary<String, int>();
            double decimal_degrees = Math.Abs(decimalDegrees); 

            // set decimal_degrees value here
            double degrees = Math.Floor(decimal_degrees);
            double minutes = (decimal_degrees - Math.Floor(decimal_degrees)) * 60.0;
            double seconds = (minutes - Math.Floor(minutes)) * 60000.0;
            //double tenths = (seconds - Math.Floor(seconds)) * 10.0;
            // get rid of fractional part
            minutes = Math.Floor(minutes);
            seconds = Math.Floor(seconds);
            //tenths = Math.Floor(tenths);

            output.Add("degrees", (int)degrees);
            output.Add("minutes", (int)minutes);
            output.Add("seconds", (int)seconds);
            //output.Add("tenths", (int)tenths); 


            return output; 
        }

        public static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }
    }


}
