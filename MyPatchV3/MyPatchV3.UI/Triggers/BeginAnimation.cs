﻿using MyPatchV3.UI.Animations.Base;
using Xamarin.Forms;

namespace MyPatchV3.UI.Triggers
{
    public class BeginAnimation : TriggerAction<VisualElement>
    {
        public AnimationBase Animation { get; set; }

        protected override async void Invoke(VisualElement sender)
        {
            if (Animation != null)
                await Animation.Begin();
        }
    }
}
