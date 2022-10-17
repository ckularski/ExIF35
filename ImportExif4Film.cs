using System;
using System.Collections.Generic;
using System.Xml;

namespace ExIF35
{
    class ImportExif4Film
    {
        public static Roll importRoll(String filepath, String photographer)
        {
            Roll newRoll = new Roll();
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            

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

            //
            String tLensName = "";
            String t1 = "";
            String t2 = "";
            String t3 = "";

            foreach (XmlNode n in doc.ChildNodes)
            {
                foreach (XmlNode m in n.ChildNodes)
                {
                    if (m.Name.Equals("Lens") || m.Name.Equals("GpsLocation") || m.Name.Equals("Exposure") || m.Name.Equals("PhotoFilter") || m.Name.Equals("Camera") || m.Name.Equals("ExposedRoll"))
                    {

                        foreach (XmlNode m2 in m.ChildNodes)
                        {
                            if (m2.Name.Equals("dk.codeunited.exif4film.model.Lens"))
                            {
                                foreach (XmlNode o in m2.ChildNodes)
                                {
                                    if (o.Name.Equals("id")) { id = o.InnerText; }
                                    if (o.Name.Equals("lens_title")) { tLensName = o.InnerText; }
                                    
                                }
                                lenses.Add(Convert.ToInt32(id), tLensName);
                            }

                            if (m2.Name.Equals("dk.codeunited.exif4film.model.PhotoFilter"))
                            {
                                foreach (XmlNode o in m2.ChildNodes)
                                {
                                    if (o.Name.Equals("id")) { id = o.InnerText; }
                                    if (o.Name.Equals("filter_title")) { tLensName = o.InnerText; }

                                }
                                filters.Add(Convert.ToInt32(id), tLensName);
                            }

                            if (m2.Name.Equals("dk.codeunited.exif4film.model.GpsLocation"))
                            {
                                foreach (XmlNode o in m2.ChildNodes)
                                {
                                    if (o.Name.Equals("id")) { id = o.InnerText; }
                                    if (o.Name.Equals("gps_latitude")) { t1 = o.InnerText; }
                                    if (o.Name.Equals("gps_longitude")) { t2 = o.InnerText; }
                                    if (o.Name.Equals("gps_altitude")) { t3 = o.InnerText; }
                                }
                                latitudes.Add(Convert.ToInt32(id), Convert.ToDouble(t1));
                                longitudes.Add(Convert.ToInt32(id), Convert.ToDouble(t2));
                                altitudes.Add(Convert.ToInt32(id), Convert.ToDouble(t3));
                            }

                            if (m2.Name.Equals("dk.codeunited.exif4film.model.Exposure"))
                            {
                                count++; 
                                foreach (XmlNode o in m2.ChildNodes)
                                {
                                    if (o.Name.Equals("exposure_number"))
                                    {
                                        expNum.Add(count, o.InnerText);
                                    }
                                    if (o.Name.Equals("exposure_time_taken"))
                                    {
                                        ttime = "";
                                        ttime = o.InnerText;
                                        ttime = ttime.Replace('-', ':');
                                        ttime = ttime.Replace('T', ' ');
                                        splittime = ttime.Split(new char[] { 'Z' }, 2);
                                        ttime = splittime[0];
                                        time.Add(count, ttime);

                                    }

                                    if (o.Name.Equals("exposure_shutter_speed"))
                                    {
                                        shutter.Add(count, o.InnerText);
                                    }

                                    if (o.Name.Equals("exposure_aperture"))
                                    {
                                        aperture.Add(count, o.InnerText);
                                    }

                                    if (o.Name.Equals("exposure_focal_length"))
                                    {
                                        focallength.Add(count, o.InnerText);
                                    }

                                    if (o.Name.Equals("exposure_compensation"))
                                    {
                                        comp.Add(count, o.InnerText);
                                    }

                                    if (o.Name.Equals("exposure_flash_on"))
                                    {

                                        if (o.InnerText.Equals("false")) { flash.Add(count, 0); } else { flash.Add(count, 1); }
                                    }

                                    if (o.Name.Equals("exposure_description"))
                                    {
                                        description.Add(count, o.InnerText);
                                    }

                                    if (o.Name.Equals("exposure_light_source"))
                                    {
                                        switch (o.InnerText)
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

                                    if (o.Name.Equals("exposure_photo_filter_id"))
                                    {
                                        filterID.Add(count, Convert.ToInt32(o.InnerText));
                                    }

                                    if (o.Name.Equals("exposure_lens_id"))
                                    {
                                        lensID.Add(count, Convert.ToInt32(o.InnerText));
                                    }

                                    if (o.Name.Equals("exposure_gps_location"))
                                    {
                                        gpsID.Add(count, Convert.ToInt32(o.InnerText));
                                    }

                                }
                                
                            }

                            if (m2.Name.Equals("dk.codeunited.exif4film.model.Camera"))
                            {
                                foreach (XmlNode o in m2.ChildNodes)
                                {
                                    if (o.Name.Equals("camera_serial_number")) { cameraSerialNumber = o.InnerText; }

                                }
                            } 

                            if (m2.Name.Equals("dk.codeunited.exif4film.model.ExposedRoll"))
                            {
                                foreach (XmlNode o in m2.ChildNodes)
                                {
                                    if (o.Name.Equals("exposedroll_time_loaded")) { t1 = o.InnerText; }
                                    if (o.Name.Equals("exposedroll_time_unloaded")) { t2 = o.InnerText; }
                                }
                                ttime = t1.Replace('-', ':').Replace('T', ' ');
                                splittime = ttime.Split(new char[] { 'Z' }, 2);
                                loadDate = splittime[0];

                                ttime = t2.Replace('-', ':').Replace('T', ' ');
                                splittime = ttime.Split(new char[] { 'Z' }, 2);
                                unloadDate = splittime[0];
                            }
                        }
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


                temp = new Exposure(ex, a, s, t, "", "", "", photographer, f);
                temp.addExtended(0, 0, fl, 0, ls, c, 0, 0, fltr);
                temp.addGPS(gpsLat, gpsLon, gpsAlt);
                temp.Remarks = d; 

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

                newRoll.loadDate = loadDate;
                newRoll.unloadDate = unloadDate;
            }

            return newRoll;

        }
    }
}
