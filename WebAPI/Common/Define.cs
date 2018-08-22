using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Xml;

namespace Common
{
    public class Define
    {
        static Define _instance;
        public static Define Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Define();
                }
                return _instance;
            }
        }

        public string RootPath { get; set; } = Environment.CurrentDirectory;
        public List<XmlNode> AppConfig { get; set; } = new List<XmlNode>();
        public List<XmlNode> WebConfig { get; set; } = new List<XmlNode>();
        public string AppConfigPath { get { return System.IO.Path.Combine(RootPath, "App.config"); } }
        public string WebConfigPath { get { return System.IO.Path.Combine(RootPath, "Web.config"); } }
        public string ConnectionString { get; set; } = string.Empty;
        public int PageSize { get; private set; } = 10;

        public enum fLogin
        {
            NotFound = 0,
            Disable = 1,
            Success
        }
        public enum fStatus
        {
            Add = 1,
            Edit = 2
        }
        public enum fLog
        {
            Trace = 1,
            Debug = 2,
            Info = 3,
            Warn = 4,
            Error = 5,
            Fatal = 6
        }

        public string MsgGetAll { get; set; } = "[-----Tất cả-----]";
    }
}
