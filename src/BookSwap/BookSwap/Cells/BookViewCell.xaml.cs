using BookSwap.Models;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookSwap.Cells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookViewCell : ViewCell
    {
        SKColor _accentColor;
        SKColor _accentDarkColor;
        SKColor _accentExtraDarkColor;
        SKPaint _accentPaint;
        SKPaint _accentDarkPaint;
        SKPaint _accentExtraDarkPaint;

        double scrollValue;
        IViewLocationFetcher viewLocationFetcher;
        public BookViewCell()
        {
            InitializeComponent();

            
            MessagingCenter.Subscribe<ScrollMessage, double>(this, ScrollMessage.ScrollChanged,
                (sender, scrollInfo) =>
                {
                    // store away the scroll value
                    scrollValue = scrollInfo;

                    // tell the cell to redraw
                    if (CellBackgroundCanvas != null)
                        CellBackgroundCanvas.InvalidateSurface();
                });

            
            viewLocationFetcher = DependencyService.Get<IViewLocationFetcher>();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext != null)
            {
                var colors = ((Book)BindingContext).Colors;

                _accentColor = colors.Accent.ToSKColor();
                _accentDarkColor = colors.DarkAccent.ToSKColor();
                _accentExtraDarkColor = colors.ExtraDarkAccent.ToSKColor();
                _accentPaint = new SKPaint() { Color = _accentColor };
                _accentDarkPaint = new SKPaint() { Color = _accentDarkColor };
                _accentExtraDarkPaint = new SKPaint() { Color = _accentExtraDarkColor };
            }
        }

        private void CellBackgroundCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // work out where the cell actually is on the page
            var thisCellPosition = viewLocationFetcher.GetCoordinates(this.View);

            canvas.DrawRect(info.Rect, _accentPaint);

            // create path for light color
            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo((info.Width) - thisCellPosition.Y, 0);
                path.LineTo(0, info.Height *.8f);
                path.Close();
                canvas.DrawPath(path, _accentDarkPaint);
            }
            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(info.Width - (thisCellPosition.Y * 2f), 0);
                path.LineTo(0, info.Height * .6f);
                path.Close();
                canvas.DrawPath(path, _accentExtraDarkPaint);
            }
        }
    }
}