using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ExIF35
{
    [XmlRootAttribute("Lenses", Namespace = "", IsNullable = false)]
    public class LensBag
    {
        [XmlArray("Lenses"), XmlArrayItem("Lens", typeof(Lens))]
        public List<Lens> Lenses;
        public LensBag(List<Lens> tmp)
        {
            Lenses = tmp;
        }
        public LensBag()
        {
        }
    }

}
