using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExIF35
{

    public class ExifNotesRoll
    {
        public int id { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public string unloaded { get; set; }
        public enCamera camera { get; set; }
        public int iso { get; set; }
        public string format { get; set; }
        public bool archived { get; set; }
        public Filmstock filmStock { get; set; }
        public bool favorite { get; set; }
        public Frame[] frames { get; set; }
    }

    public class enCamera
    {
        public int id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string minShutter { get; set; }
        public string maxShutter { get; set; }
        public string shutterIncrements { get; set; }
        public string exposureCompIncrements { get; set; }
        public string format { get; set; }
    }

    public class Filmstock
    {
        public int id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int iso { get; set; }
        public string type { get; set; }
        public string process { get; set; }
        public bool isPreadded { get; set; }
    }

    public class Frame
    {
        public int id { get; set; }
        public int count { get; set; }
        public string date { get; set; }
        public string shutter { get; set; }
        public string aperture { get; set; }
        public Location location { get; set; }
        public string formattedAddress { get; set; }
        public int focalLength { get; set; }
        public int noOfExposures { get; set; }
        public bool flashUsed { get; set; }
        public string lightSource { get; set; }
        public enLens lens { get; set; }
        public string exposureComp { get; set; }
        public Filter[] filters { get; set; }
        public string description {  get; set; }
    }

    public class Location
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
    }

    public class enLens
    {
        public int id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string serialNumber { get; set; }
        public string minAperture { get; set; }
        public string maxAperture { get; set; }
        public int minFocalLength { get; set; }
        public int maxFocalLength { get; set; }
        public string apertureIncrements { get; set; }
    }

    public class Filter
    {
        public int id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
    }


}
