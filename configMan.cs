using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.IO;

namespace ExIF35
{
    class configMan
    {
        String path;
        NameValueCollection config = new NameValueCollection();

        public configMan()
        {
            String directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            directory += "\\ExIF35";
            String file = "exif35.config";


            if (!Directory.Exists(directory)) { Directory.CreateDirectory(directory); }
            path = directory + "\\" + file;
        }

        public NameValueCollection getConfig()
        {
            bool isConfig = false;
            int i = 0;
            String[] parts;
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader textIn = new StreamReader(fs);
            String newline = "";
            config.Add("Application", "ExIF35");

            while (textIn.Peek() != -1)
            {

                newline = textIn.ReadLine();
                if (newline.Contains("|"))
                {
                    isConfig = true;
                    parts = newline.Split('|');
                    config.Add(parts[0], parts[1]);
                }
                i++;
            }
            textIn.Close();
            if (isConfig) { config.Add("validConfig", "true"); } else { config.Add("validConfig", "false"); }
            return config;
        }

        public void setConfig(NameValueCollection newConfig)
        {
            config = newConfig;
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter textOut = new StreamWriter(fs);
            String value;
            foreach (String configKey in config.AllKeys)
            {
                value = config.Get(configKey);
                textOut.WriteLine(configKey + "|" + value);
            }

            textOut.Close();

        }
    }
}
