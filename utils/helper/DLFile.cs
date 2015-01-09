#region Licence

/*This file is part of the project "Reisisoft Separate Install GUI",
 * which is licenced under LGPL v3+. You may find a copy in the source,
 * or obtain one at http://www.gnu.org/licenses/lgpl-3.0-standalone.html */

#endregion Licence

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI_GUI.utils.helper
{
    public class DLFile
    {
        public DLFile(string location, Downloader.Version version, int hashCodeWC)
        {
            this.location = location;
            this.version = version;
            this.hashCodeWC = hashCodeWC;
        }

        public string location;
        public Downloader.Version version;
        public int hashCodeWC;
        public long received, totalToreceive;
    }
}