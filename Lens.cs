using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ExIF35
{
    //Defines a Lens object for storing information relevant to photographic lenses. 
    public class Lens
    {
        public String Make = "";
        public String Name = "empty";
        public String minFL = "";
        public String maxFL = "";
        public String fmaxmax = "";
        public String fmaxmin = "";
        public String LensID = "";
        public String serialNumber = ""; 

        public Lens(String Make, String N, String minFL, String maxFL, String fmaxmax, String fmaxmin, String ID, String SN)
        {
            this.Make = Make;
            this.Name = N;
            this.minFL = minFL;
            this.maxFL = maxFL;
            this.fmaxmax = fmaxmax;
            this.fmaxmin = fmaxmin;
            this.LensID = ID;
            this.serialNumber = SN; 
        }

        public Lens()
        {
        }
        public void updateLens(String M, String N, String minFL, String maxFL, String fmaxmax, String fmaxmin, String ID, String SN)
        {
            this.Make = M;
            this.Name = N;
            this.minFL = minFL;
            this.maxFL = maxFL;
            this.fmaxmax = fmaxmax;
            this.fmaxmin = fmaxmin;
            this.LensID = ID;
            this.serialNumber = SN; 
        }

        public String getAttribs()
        {
            String tmp = "";
            if (this.minFL == this.maxFL)
            {
                tmp = minFL + " mm f/" + fmaxmin;
            }
            else
            {
                tmp = minFL + "-" + maxFL + " mm f/" + fmaxmin + "-" + fmaxmax;
            }

            return tmp;
        }
    }
}
