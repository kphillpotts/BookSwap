using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookSwap
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwapDetails : ContentPage
    {
        SKPaint _accentFromPaint;
        SKPaint _accentToPaint;
        private double _colorAngleAnim;

        public SwapDetails()
        {
            InitializeComponent();
            this.BindingContext = App.MainViewModel;

            _accentFromPaint = new SKPaint() { Color = App.MainViewModel.SwapFromBook.Colors.Accent.ToSKColor() };
            _accentToPaint = new SKPaint() { Color = App.MainViewModel.SelectedBook.Colors.Accent.ToSKColor() };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            FromTitleLabel.Opacity = 0;
            FromAuthorLabel.Opacity = 0;
            DescriptionText.Opacity = 0;
            DescriptionBackground.ScaleX = 0;


            var parentAnim = new Animation();

            // animate the background angle
            parentAnim.Add(0, 1, new Animation(t => 
            {
                _colorAngleAnim = t;
                PageBackground.InvalidateSurface();
                    
            }, 0, 100, Easing.SinInOut));

            // title animations
            parentAnim.Add(.10, .25, new Animation(t => FromTitleLabel.TranslationY = t, 50, 0, Easing.SinInOut));
            parentAnim.Add(.0, .25, new Animation(t => FromTitleLabel.Opacity = t, 0, 1, Easing.SinInOut));
            parentAnim.Add(.10, .3, new Animation(t => FromAuthorLabel.TranslationY = t, 50, 0, Easing.SinInOut));
            parentAnim.Add(.0, .3, new Animation(t => FromAuthorLabel.Opacity = t, 0, .5, Easing.SinInOut));

            // book background
            parentAnim.Add(0, .2, new Animation(t => BookBorderBoxView.Scale = t, 0, 1));

            // description background
            //DescriptionBackground
            DescriptionBackground.AnchorX = 0;
            parentAnim.Add(.2, .4, new Animation(t => DescriptionBackground.ScaleX = t, 0, 1, Easing.SinInOut));

            // description text
            parentAnim.Add(.4, .5, new Animation(t => DescriptionText.Opacity = t, 0, 1, Easing.SinInOut));


            parentAnim.Commit(this, "PageAnimations", 16, 2000);

        }

        private void PageBackground_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // fill the background
            canvas.DrawRect(info.Rect, _accentToPaint);

            // draw the top half
            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(info.Width, 0);
                path.LineTo(info.Width, (info.Height / 2) - (float)_colorAngleAnim);
                path.LineTo(0, (info.Height / 2) + (float)_colorAngleAnim);
                path.Close();

                canvas.DrawPath(path, _accentFromPaint);

            }

        }
    }
}