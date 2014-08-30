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
