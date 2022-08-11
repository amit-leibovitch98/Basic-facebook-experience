using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;

namespace FacebookApplicationLogic
{
    public class AppSettings
    {
        public Size WindowSize { get; set; }
        public Point WindowLocation { get; set; }
        public string AccessToken { get; set; }
        public bool RememberMe { get; set; }

        public AppSettings()
        {
            WindowSize = new Size(770, 565);
            WindowLocation = new Point(0, 0);
            AccessToken = string.Empty;
            RememberMe = false;
        }

        public void SaveToXmlFile(string filePath)
        {
            FileMode fileMode;

            if (File.Exists(filePath))
            {
                fileMode = FileMode.Truncate;
            }
            else
            {
                fileMode = FileMode.CreateNew;
            }
            
            using (Stream stream = new FileStream(filePath, fileMode))
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stream, this);
            }
        }

        public static AppSettings LoadFromXmlFile(string filePath)
        {
            AppSettings appSettings = null;

            using (Stream stream = new FileStream(filePath, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                appSettings = serializer.Deserialize(stream) as AppSettings;
            }

            return appSettings;
        }
    }
}
