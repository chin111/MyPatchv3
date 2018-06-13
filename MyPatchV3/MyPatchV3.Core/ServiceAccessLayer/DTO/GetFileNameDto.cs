using System;
using System.Collections.Generic;

namespace MyPatchV3.SAL.DTO
{
    public class GetFileNameDto
    {
        public string userName { get; set; }
        public List<FileInfoDto> dbFileNames { get; set; }
    }
}
