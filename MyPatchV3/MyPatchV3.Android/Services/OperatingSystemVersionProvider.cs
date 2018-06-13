using System;
using Android.OS;
using MyPatchV3.UI;

namespace MyPatchV3.Droid
{
	public class OperatingSystemVersionProvider : IOperatingSystemVersionProvider
	{
		public string GetOperatingSystemVersionString()
		{
			return Build.VERSION.Release;
		}
	}
}
