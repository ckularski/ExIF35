using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExIF35
{
    public class Camera
    {
        public String Make = "";
        public String Model = ""; 
        public String Name = "empty";
        public String serialNumber = ""; 

        public Camera(String mk, String mdl, String nme, String sn)
        {
            this.Make = mk;
            this.Model = mdl;
            this.Name = nme;
            this.serialNumber = sn; 
        }
        public Camera()
        {
        }
        public void updateCamera(String mk, String mdl, String nme, String sn)
        {
            this.Make = mk;
            this.Model = mdl;
            this.Name = nme;
            this.serialNumber = sn; 
        }
    }
}
