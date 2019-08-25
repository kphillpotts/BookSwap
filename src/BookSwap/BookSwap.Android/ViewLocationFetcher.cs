using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BookSwap.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:Dependency(typeof(ViewLocationFetcher))]
namespace BookSwap.Droid
{
    public class ViewLocationFetcher : IViewLocationFetcher
    {
        public PointF GetCoordinates(VisualElement view)
        {
            var renderer = Platform.GetRenderer(view);
            if (renderer == null)
                return new PointF();
            var nativeView = renderer.View;
            var location = new int[2];

            var density = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density;

            nativeView.GetLocationOnScreen(location);
            return new PointF(location[0] / (float)density, location[1] / (float)density);
        }
    }
}