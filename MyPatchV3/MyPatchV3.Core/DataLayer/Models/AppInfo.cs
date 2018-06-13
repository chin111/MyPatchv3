using System;
using System.Collections.Generic;
using System.Text;

namespace MyPatchV3.DL.Models
{
    public class AppInfo
    {
        public string Id { get; set; }
        public string ClientOS { get; set; }
        public string Version { get; set; }
        public string AppStoreURL { get; set; }
        public bool ForceUpdate { get; set; }
        public string Remark { get; set; }
    }
}
