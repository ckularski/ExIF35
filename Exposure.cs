using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ExIF35
{
    public class Exposure
    {
        public String Number = "";
        public String Aperture = "";
        public String Speed = "";
        public String FocalLength = "";
        public String Date = "";
        public String DateDigitized = "";
        public String Title = "";
        public String Description = "";
        public String Photographer = "";
        public String Lens = "";
        public String Filter = "";
        public String Remarks = "";
        public double Longitude = 0.0;
        public double Latitude = 0.0;
        public double Altitude = 0; 
        public int Program = 0;
        public int ExposureMode = 0;
        public bool multipleExposure = false; 
        public int FocusMode = 0; 
        public String ExposureBias = "0";
        public int SubjectDistance = 0;
        public int Orientation = 0;
        public int Scene = 0;
        public int Flash = 0;
        public int Meter = 0;
        public int LightSource = 0;
        public bool VR = false; 
        [XmlArray("Tags"), XmlArrayItem("Tag", typeof(String))]
        public List<String> Tags = new List<String>(); 
        public String ImageFile = "";

        public Exposure()
        {
        }
        public Exposure(String Number, String Aperture, String Speed, String Date, String DateDigitzed, String Title, String Descriprtion, String Photographer, String FL)
        {
            this.Number = Number;
            this.Aperture = Aperture;
            this.Speed = Speed;
            this.FocalLength = FL;
            this.Date = Date;
            this.DateDigitized = DateDigitzed;
            this.Title = Title;
            this.Description = Descriprtion;
            this.Photographer = Photographer;
        }

        public void linkFile(String file)
        {
            ImageFile = file;
        }

        public void addExtended(int prog, int orient, int flash, int meter, int light, String ev, int Scene, int SD, String filter)
        {
            this.Program = prog;
            this.Orientation = orient;
            this.Flash = flash;
            this.Meter = meter;
            this.LightSource = light;
            this.ExposureBias = ev;
            this.SubjectDistance = SD;
            this.Scene = Scene;
            this.Filter = filter;
        }

        public void addGPS(double latitude, double longitude, double altitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Altitude = altitude;
        }

        public void addMoreExtended(int em, int fm)
        {
            this.ExposureMode = em;
            this.FocusMode = fm;
        }

        public void setVR(bool vr)
        {
            this.VR = vr; 
        }

        public void setMultiExp(bool multiExp)
        {
            this.multipleExposure = multiExp; 
        }

        public void addLensInfo(String Lens)
        {
            this.Lens = Lens;
        }

        public void updateBase(String Number, String Aperture, String Speed, String Date, String DateDigitzed, String Title, String Descriprtion, String Photographer, String FL)
        {
            this.Number = Number;
            this.Aperture = Aperture;
            this.Speed = Speed;
            this.FocalLength = FL;
            this.Date = Date;
            this.DateDigitized = DateDigitzed;
            this.Title = Title;
            this.Description = Descriprtion;
            this.Photographer = Photographer;
        }

        public void updateTags(List<String> tags)
        {
            this.Tags = tags;
        }

    }
}
