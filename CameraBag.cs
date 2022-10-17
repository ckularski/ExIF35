using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ExIF35
{
    [XmlRootAttribute("Cameras", Namespace = "", IsNullable = false)]
    public class CameraBag
    {
        [XmlArray("Cameras"), XmlArrayItem("Camera", typeof(Camera))]
        public List<Camera> Cameras;
        public CameraBag(List<Camera> tmp)
        {
            Cameras = tmp;
        }
        public CameraBag()
        {
        }
    }
}
