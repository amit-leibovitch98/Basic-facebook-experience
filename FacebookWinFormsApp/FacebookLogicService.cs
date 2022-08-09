﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using FacebookApplicationLogic;

namespace BasicFacebookFeatures
{
    public class FacebookLogicService
    {
        private InfoLogic m_logic;
        private QuotesLoader m_quotesLoader;
        private InfoLogic m_infoLogic;
        private List<Page> m_artistsList;
        private string m_filePath;
        public User LoggedInUser { get; set; } = null;
        public LoginResult LoginResult { get; set; }
        public int GroupsIndex { get; set; } = 0;
        public int LikedArtistsIndex { get; set; } = 0;
        public AppSettings AppSettings { get; set; }
        public int TeamsIndex { get; set; } = 0;
        public int PageIndex { get; set; } = 0;
        public int PostsIndex { get; set; } = 0;
        public int AlbumIndex { get; set; } = 0;
        public string FilePath { get; }

        public FacebookLogicService()
        {
            m_quotesLoader = new QuotesLoader();
            m_infoLogic = new InfoLogic();
        }
        public void InitPath()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string file = Path.Combine(currentDirectory, @"AppSettings.xml");
            m_filePath = Path.GetFullPath(file);
        }

        public void SetAppSettings()
        {
            if (File.Exists(FilePath) && File.ReadAllText(FilePath) != "")
            {
                AppSettings = AppSettings.LoadFromXmlFile(FilePath);
            }
            else
            {
                AppSettings = new AppSettings();
            }
        }
       

    }
}