using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Diagnostics;

namespace ExIF35
{
    class ImportExifNotes
    {
        public static Roll importRoll(String filepath, String photographer)
        {
            Roll newRoll = new Roll();

            string jsonString = File.ReadAllText(filepath);
            ExifNotesRoll theRoll = JsonSerializer.Deserialize<ExifNotesRoll>(jsonString);

            newRoll.cameramake = theRoll.camera.make;
            newRoll.cameramodel = theRoll.camera.model;
            newRoll.FilmType = theRoll.filmStock.make + " " + theRoll.filmStock.model;
            newRoll.loadDate = theRoll.date.Replace('-', ':').Replace('T', ' ');

            if (theRoll.unloaded != null)
            {
                newRoll.unloadDate = theRoll.unloaded.Replace('-', ':').Replace('T', ' ');
            }

            String cameraSerialNumber = "";
            String loadDate = "";
            String unloadDate = ""; 

            //create objects to hold exposure IDs and content for various attributes
            Dictionary<int, int> flash = new Dictionary<int, int>();
            Dictionary<int, String> description = new Dictionary<int, String>();
            Dictionary<int, String> expNum = new Dictionary<int, String>();
            Dictionary<int, String> comp = new Dictionary<int, String>();
            Dictionary<int, String> focallength = new Dictionary<int, String>();
            Dictionary<int, String> aperture = new Dictionary<int, String>();
            Dictionary<int, String> shutter = new Dictionary<int, String>();
            Dictionary<int, String> time = new Dictionary<int, String>();
            Dictionary<int, int> filterID = new Dictionary<int, int>();
            Dictionary<int, int> lensID = new Dictionary<int, int>();
            Dictionary<int, int> gpsID = new Dictionary<int, int>();
            Dictionary<int, int> light = new Dictionary<int, int>();

            Dictionary<int, String> filters = new Dictionary<int, String>();
            Dictionary<int, String> lenses = new Dictionary<int, String>();
            Dictionary<int, Double> longitudes = new Dictionary<int, double>();
            Dictionary<int, Double> latitudes = new Dictionary<int, double>();
            Dictionary<int, Double> altitudes = new Dictionary<int, double>();

            foreach (Frame fr in theRoll.frames)
            {
                int usedflash = 0; 
                if (fr.flashUsed)
                {
                    usedflash = 1; 
                }
                int lightSource = 0;
                switch (fr.lightSource)
                {
                    case "Unknown": lightSource = 0; break;
                    case "Daylight": lightSource = 1; break;
                    case "Shade": lightSource =  7; break;
                    case "Cloudy": lightSource = 6; break;
                    case "Fluorescent": lightSource = 2; break;
                    case "Tungsten": lightSource = 3; break;
                    case "Flash": lightSource = 4; break;
                    case "Sunny": lightSource = 9; break;
                }

                String usedfilters = "";
                int filteri = 0;
                if (fr.filters != null)
                {
                    foreach (Filter tFilter in fr.filters)
                    {
                        if (filteri > 0)
                        {
                            usedfilters += ", ";
                        }
                        usedfilters += tFilter.model;
                        filteri++;
                    }
                }


                //String Number, String Aperture, String Speed, String Date, String DateDigitzed, String Title, String Descriprtion, String Photographer, String FL
                Exposure tempExp = new Exposure(fr.count.ToString(), fr.aperture, fr.shutter, fr.date.Replace('-', ':').Replace('T', ' '), "", "", fr.description, photographer, fr.focalLength.ToString());
                tempExp.addExtended(0, 0, usedflash, 0, lightSource, fr.exposureComp, 0, 0, usedfilters);
                tempExp.addLensInfo(fr.lens.model);
                tempExp.addGPS(fr.location.latitude, fr.location.longitude, 0);
                newRoll.add(tempExp);

            }

            return newRoll;

        }
    }
}
