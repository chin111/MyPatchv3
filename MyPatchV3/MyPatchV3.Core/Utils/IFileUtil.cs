using System;

namespace MyPatchV3.Utils
{
    public interface IFileUtil
    {
        string GetTempZipFileName();
        string GetTempDBFileName();
        string GetTempDirectoryPath();
        string GetMasterDBPath();
        string GetAuditDBPath();
    }
}
