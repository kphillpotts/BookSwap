using System;
using System.Collections.Generic;
using System.Text;

namespace BookSwap
{
    public interface IViewLocationFetcher
    {
        System.Drawing.PointF GetCoordinates(global::Xamarin.Forms.VisualElement view);
    }
}
