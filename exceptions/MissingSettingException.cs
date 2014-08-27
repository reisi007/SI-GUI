using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI_GUI.exceptions
{
    [Serializable]
    class MissingSettingException : InvalidOperationException
    {
        public MissingSettingException(string s) : base(s) { }
    }
}
