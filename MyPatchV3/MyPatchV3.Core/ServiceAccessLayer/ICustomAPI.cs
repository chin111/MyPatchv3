using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Refit;

namespace MyPatchV3.SAL
{
    [Headers("Accept: application/json")]
    public interface ICustomAPI
    {
        [Get("")]
        [Headers("Accept: application/x-zip-compressed")]
        Task<HttpResponseMessage> DownloadFile();
    }
}
