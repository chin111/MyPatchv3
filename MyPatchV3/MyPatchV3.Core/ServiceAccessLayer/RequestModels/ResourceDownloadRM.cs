using System;

namespace MyPatchV3.SAL.RequestModels
{
    public class ResourceDownloadRM
    {
        public string FileName { get; set; }

        public ResourceDownloadRM(string param_filename)
        {
            this.FileName = param_filename;
        }
    }
}
