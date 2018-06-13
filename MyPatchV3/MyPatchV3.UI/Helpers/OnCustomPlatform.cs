namespace MyPatchV3.UI.Helpers
{
    public sealed class OnCustomPlatform<T>
    {
        public OnCustomPlatform()
        {
            Android = default(T);
            iOS = default(T);
            Other = default(T);
        }

        public T Android { get; set; }

        public T iOS { get; set; }

        public T Other { get; set; }

        public static implicit operator T(OnCustomPlatform<T> onPlatform)
        {
            switch (Xamarin.Forms.Device.OS)
            {
                case Xamarin.Forms.TargetPlatform.Android:
                    return onPlatform.Android;
                case Xamarin.Forms.TargetPlatform.iOS:
                    return onPlatform.iOS;
                default:
                    return onPlatform.Other;
            }
        }
    }
}