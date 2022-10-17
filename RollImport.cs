using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExIF35
{
    class RollImport
    {
        public static Roll EXIF4FILM(String filepath, String photographer)
        {
            //create a roll to hold the imported exposures
            Roll newRoll = new Roll();
            String cameraSerialNumber = ""; 

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

            //empty id
            String id = "";

            //variables to handle processing of datetime data
            String[] splittime;
            String ttime = "";

            //variables to store information from the current element for evaluation and storage
            String currentElement = "";
            String currentValue = "";
            Exposure temp;
            int count = 0;

            //XML reader object to read from the file
            System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(filepath);
            while (reader.Read())
            {
                reader.MoveToContent();
                
                if (reader.NodeType == System.Xml.XmlNodeType.Element)
                {
                    currentElement = reader.Name;
                    if (currentElement.Equals("dk.codeunited.exif4film.model.Exposure"))
                    {
                        count++;
                    }
                }

                if (reader.NodeType == System.Xml.XmlNodeType.Text)
                {
                    currentValue = reader.Value;
                    if (currentElement.Equals("exposure_number"))
                    {
                        expNum.Add(count, currentValue);
                    }
                    if (currentElement.Equals("exposure_time_taken"))
                    {
                        ttime = "";
                        ttime = currentValue;
                        ttime = ttime.Replace('-', ':');
                        ttime = ttime.Replace('T', ' ');
                        splittime = ttime.Split(new char[] { 'Z' }, 2);
                        ttime = splittime[0];
                        time.Add(count, ttime);

                    }

                    if (currentElement.Equals("exposure_shutter_speed"))
                    {
                        shutter.Add(count, currentValue);
                    }

                    if (currentElement.Equals("exposure_aperture"))
                    {
                        aperture.Add(count, currentValue);
                    }

                    if (currentElement.Equals("exposure_focal_length"))
                    {
                        focallength.Add(count, currentValue);
                    }

                    if (currentElement.Equals("exposure_compensation"))
                    {
                        comp.Add(count, currentValue);
                    }

                    if (currentElement.Equals("exposure_flash_on"))
                    {

                        if (currentValue.Equals("false")) { flash.Add(count, 0); } else { flash.Add(count, 1); }
                    }

                    if (currentElement.Equals("exposure_description"))
                    {
                        description.Add(count, currentValue);
                    }
                    
                    if (currentElement.Equals("exposure_light_source"))
                    {
                        switch (currentValue)
                        {
                            case "Unknown": light.Add(count, 0); break;
                            case "Daylight": light.Add(count, 1); break;
                            case "Shade": light.Add(count, 7); break;
                            case "Cloudy": light.Add(count, 6); break;
                            case "Fluorescent": light.Add(count, 2); break;
                            case "Tungsten": light.Add(count, 3); break;
                            case "Flash": light.Add(count, 4); break;

                        }
                    }

                    if (currentElement.Equals("exposure_photo_filter_id"))
                    {
                        filterID.Add(count, Convert.ToInt32(currentValue));
                    }

                    if (currentElement.Equals("exposure_lens_id"))
                    {
                        lensID.Add(count, Convert.ToInt32(currentValue));
                    }

                    if (currentElement.Equals("exposure_gps_location"))
                    {
                        gpsID.Add(count, Convert.ToInt32(currentValue));
                    }

                    if (currentElement.Equals("id"))
                    {
                        id = currentValue;
                    }

                    if (currentElement.Equals("filter_title"))
                    {
                        filters.Add(Convert.ToInt32(id), currentValue);
                    }

                    if (currentElement.Equals("lens_title"))
                    {
                        try
                        {
                            lenses.Add(Convert.ToInt32(id), currentValue);
                        }
                        catch (Exception)
                        {
                        }
                    }

                    if (currentElement.Equals("gps_latitude"))
                    {
                        latitudes.Add(Convert.ToInt32(id), Convert.ToDouble(currentValue)); 
                    }

                    if (currentElement.Equals("gps_longitude"))
                    {
                        longitudes.Add(Convert.ToInt32(id), Convert.ToDouble(currentValue));
                    }

                    if (currentElement.Equals("gps_altitude"))
                    {
                        altitudes.Add(Convert.ToInt32(id), Convert.ToDouble(currentValue));
                    }

                    if (currentElement.Equals("camera_serial_number"))
                    {
                        cameraSerialNumber = currentValue; 
                    }

                }
            }

            for (int i = 1; i <= count; i++)
            {
                String ex = "";
                String t = "";
                String s = "";
                String a = "";
                String f = "";
                String d = "";
                String c = "";
                String fltr = "";
                String lens = "";
                Double gpsLat = 0.0;
                Double gpsLon = 0.0;
                Double gpsAlt = 0; 

                int fl = 0;
                int ls = 0;

                if (expNum.ContainsKey(i))
                {
                    ex = expNum[i];
                }
                if (time.ContainsKey(i))
                {
                    t = time[i];
                }

                if (shutter.ContainsKey(i))
                {
                    s = shutter[i];
                }

                if (aperture.ContainsKey(i))
                {
                    a = aperture[i];
                }

                if (focallength.ContainsKey(i))
                {
                    f = focallength[i];
                }

                if (description.ContainsKey(i))
                {
                    d = description[i];
                }

                if (comp.ContainsKey(i))
                {
                    c = comp[i];
                }

                if (flash.ContainsKey(i))
                {
                    fl = flash[i];
                }

                if (light.ContainsKey(i))
                {
                    ls = light[i];
                }

                if (filterID.ContainsKey(i))
                {
                    if (filters.ContainsKey(filterID[i]))
                    {
                        fltr = filters[filterID[i]];
                    }
                }

                if (gpsID.ContainsKey(i))
                {
                    int tmpID = gpsID[i];
                    if (longitudes.ContainsKey(tmpID))
                    {
                        gpsLon = longitudes[tmpID];
                    }
                    if (latitudes.ContainsKey(tmpID))
                    {
                        gpsLat = latitudes[tmpID];
                    }
                    if (altitudes.ContainsKey(tmpID))
                    {
                        gpsAlt = altitudes[tmpID];
                    }
                }


                temp = new Exposure(ex, a, s, t, "", "", d, photographer, f);
                temp.addExtended(0, 0, fl, 0, ls, c, 0, 0, fltr);
                temp.addGPS(gpsLat, gpsLon, gpsAlt);

                if (lensID.ContainsKey(i))
                {
                    if (lenses.ContainsKey(lensID[i]))
                    {
                        lens = lenses[lensID[i]];
                        temp.addLensInfo(lens);
                    }
                }


               
                newRoll.exposures.Add(temp);
                if (!cameraSerialNumber.Equals(""))
                {
                    newRoll.cameraserialnumber = cameraSerialNumber;
                }
            }

            return newRoll;
        }
    }
}
