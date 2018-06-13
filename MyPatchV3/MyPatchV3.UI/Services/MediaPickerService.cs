﻿using MyPatchV3.UI.Services.Interfaces;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MyPatchV3.UI.Services
{
    public class MediaPickerService : IMediaPickerService
    {
        public async Task<string> PickImageAsBase64String()
        {
            string base64Str = null;

            await CrossMedia.Current.Initialize();

            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                MediaFile media = await CrossMedia.Current.PickPhotoAsync();

                using (Stream mediaStream = media.GetStream())
                using (MemoryStream memStream = new MemoryStream())
                {
                    await mediaStream.CopyToAsync(memStream);
                    base64Str = Convert.ToBase64String(memStream.ToArray());
                }
            }

            return base64Str;
        }
    }
}
