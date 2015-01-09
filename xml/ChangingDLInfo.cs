#region Licence

/*This file is part of the project "Reisisoft Separate Install GUI",
 * which is licenced under LGPL v3+. You may find a copy in the source,
 * or obtain one at http://www.gnu.org/licenses/lgpl-3.0-standalone.html */

#endregion Licence

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SI_GUI
{
    [Serializable]
    [XmlRoot(ElementName = "changingDLinfos")]
    public class ChangingDLInfo
    {
        public ChangingDLInfo()
            : this("---", "---", false, false)
        {
        }

        private ChangingDLInfo(string name, string url, bool helppack, bool sdk)
        {
            this.name = name;
            this.url = url;
            this.helppackAvailable = helppack;
            this.sdkAvailable = sdk;
        }

        [XmlElement(ElementName = "name")]
        public string name;

        [XmlElement(ElementName = "url")]
        public string url;

        [XmlElement(ElementName = "hp")]
        public bool helppackAvailable;

        [XmlElement(ElementName = "sdk")]
        public bool sdkAvailable;

        public override string ToString()
        {
            return name;
        }

        public static ChangingDLInfo[] Parse(string[] s)
        {
            List<ChangingDLInfo> list = new List<ChangingDLInfo>();
            for (int i = 1; i < s.Length; i++)
            {
                string line = s[i];
                string[] tmp = line.Split(new char[] { '#' });
                list.Add(new ChangingDLInfo(tmp[3], tmp[0], Convert.ToBoolean(tmp[1]), Convert.ToBoolean(tmp[2])));
            }

            return list.ToArray();
        }
    }
}