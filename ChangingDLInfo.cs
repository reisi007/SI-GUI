using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI_GUI
{
    [Serializable]
    public class ChangingDLInfo
    {
        public ChangingDLInfo()
            : this("", "", false,false)
        {

        }
        private ChangingDLInfo(string name, string url, bool helppack,bool sdk)
        {
            this.name = name;
            this.url = url;
            this.helppackAvailable = helppack;
            this.sdkAvailable = sdk;
        }
        public  readonly string name, url;
        public readonly bool helppackAvailable,sdkAvailable;
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
                list.Add(new ChangingDLInfo(tmp[3], tmp[0], Convert.ToBoolean(tmp[1]),Convert.ToBoolean(tmp[2])));
            }

            return list.ToArray();
        }
    }
}
