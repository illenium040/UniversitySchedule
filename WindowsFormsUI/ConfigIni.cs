using IniParser;
using IniParser.Model;

using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsUI
{
    public static class ConfigIni
    {
        private static IniData _data;
        static ConfigIni()
        {
            _data = new FileIniDataParser().ReadFile("config.ini");
        }

        public static string GetConnectionString()
        {
            var conStr = _data.Global["database.connectionString"];
            conStr.Replace("\"", "");
            return conStr;
        }
    }
}
