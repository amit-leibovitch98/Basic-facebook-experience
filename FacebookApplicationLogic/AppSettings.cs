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

        private AppSettings()
        {
            WindowSize = new Size(770, 565);
            WindowLocation = new Point(0, 0);
            AccessToken = string.Empty;
            RememberMe = false;
        }

        public void LoadFromXmlFile(string i_FilePath)
        {
            AppSettings savedAppSettings = null;

            using (Stream stream = new FileStream(i_FilePath, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                savedAppSettings = serializer.Deserialize(stream) as AppSettings;
            }

            WindowSize = savedAppSettings.WindowSize;
            WindowLocation = savedAppSettings.WindowLocation;
            AccessToken = savedAppSettings.AccessToken;
            RememberMe = savedAppSettings.RememberMe;
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
