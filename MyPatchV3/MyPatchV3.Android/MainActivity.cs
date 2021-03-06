﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using UXDivers;
using Acr.UserDialogs;
using FFImageLoading.Forms.Droid;

using MyPatchV3.UI;
using MyPatchV3.UI.ViewModels.Base;

namespace MyPatchV3.Droid
{
    [Activity(Label = "MyPatchV3", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            UserDialogs.Init(this);
            CachedImageRenderer.Init(true);
            ViewModelLocator.Instance.Register<IOperatingSystemVersionProvider, OperatingSystemVersionProvider>();

            LoadApplication(new App());
            //LoadApplication(UXDivers.Gorilla.Droid.Player.CreateApplication(
            //    this,
            //    new UXDivers.Gorilla.Config("Good Gorilla")
            //    ));

            Console.Write("Loading passed");
        }
    }
}

