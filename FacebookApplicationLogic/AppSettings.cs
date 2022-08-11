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

        public static AppSettings LoadFromXmlFile(string i_FilePath)
        {
            AppSettings appSettings = null;

            using (Stream stream = new FileStream(i_FilePath, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                appSettings = serializer.Deserialize(stream) as AppSettings;
            }

            return appSettings;
        }

        public void SaveToXmlFile(string i_FilePath)
        {
            FileMode fileMode;

            if (File.Exists(i_FilePath))
            {
                fileMode = FileMode.Truncate;
            }
            else
            {
                fileMode = FileMode.CreateNew;
            }

            using (Stream stream = new FileStream(i_FilePath, fileMode))
            {
                XmlSerializer serializer = new XmlSerializer(GetType());
                serializer.Serialize(stream, this);
            }
        }
    }
}
