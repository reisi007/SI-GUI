using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace SI_GUI
{
    [Serializable]
    class DownloadNotAvailableException : WebException
    {
        Downloader.Branch branch;
        public DownloadNotAvailableException(Downloader.Branch b)
            : base("Could not find " + b)
        {
            branch = b;
        }
        public Downloader.Branch getBranch()
        {
            return branch;
        }
    }
}
