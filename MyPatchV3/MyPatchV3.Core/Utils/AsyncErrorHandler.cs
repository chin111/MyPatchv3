using System;
using System.Diagnostics;

namespace MyPatchV3
{
    public static class AsyncErrorHandler
    {
        public static void HandleException(Exception exception)
        {
            Debug.WriteLine(exception.Message);
        }
    }
}

