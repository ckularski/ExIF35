using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml.Serialization;

namespace ExIF35
{
    [XmlRootAttribute("Roll", Namespace = "", IsNullable = false)]
    public class Roll
    {
        public String cameramake = "";
        public String cameramodel = "";
        public String cameraserialnumber = ""; 
        public String number = "";
        public String description = "";
        public String ISO = "";
        public String ExposureIndex = "";
        public String FilmType = "";
        public String Format = "";
        public String FilmID = "";
        public String loadDate = "";
        public String unloadDate = ""; 
        public String DeveloperSolution = "";
        public String DevelopDuration = "";
        public String DeveloperTemp = "0.0";
        public String DevelopDate = "";
        public String nextExposure = "1";
        public String photographer = "";
        public String processor = "C. Kularski"; 
        

        [XmlArray("Exposures"), XmlArrayItem("Exposure", typeof(Exposure))]
        public List<Exposure> exposures = new List<Exposure>();

        public Roll()
        {
        }

        public void add(Exposure exp)
        {
            exposures.Add(exp);
        }

        public void copyData(Roll otherRoll)
        {
            this.cameramake = otherRoll.cameramake;
            this.cameramodel = otherRoll.cameramodel;
            this.cameraserialnumber = otherRoll.cameraserialnumber;
            this.loadDate = otherRoll.loadDate;
            this.unloadDate = otherRoll.unloadDate;
            this.DevelopDate = otherRoll.DevelopDate;
            this.DeveloperSolution = otherRoll.DeveloperSolution;
            this.DevelopDuration = otherRoll.DevelopDuration;
            this.DeveloperTemp = otherRoll.DeveloperTemp;
            this.FilmID = otherRoll.FilmID;
            this.FilmType = otherRoll.FilmType;
            this.ISO = otherRoll.ISO;
            this.number = otherRoll.number;
            this.nextExposure = otherRoll.nextExposure;
            this.Format = otherRoll.Format;
            this.ExposureIndex = otherRoll.ExposureIndex;
            this.description = otherRoll.description;
            this.photographer = otherRoll.photographer;
            this.processor = otherRoll.processor;
        }

        public RollStub getStub()
        {
            RollStub tmp = new RollStub(this.number, this.FilmID, "", this.FilmType, exposures.Count, this.description);
            return tmp;
        }

        public bool containsExposure(String checkExpNum)
        {
            bool result = false;
            foreach (Exposure exp in exposures)
            {
                if (exp.Number.Equals(checkExpNum))
                {
                    result = true; 
                }
            }
            return result; 
        }

        public RollStub getStub(String FN)
        {
            RollStub tmp = new RollStub(this.number, this.FilmID, FN, this.FilmType, exposures.Count, description);
            return tmp;
        }
    }

}
