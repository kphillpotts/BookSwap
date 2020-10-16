using Plugin.SharedTransitions;
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

            // add the elements to the shared transition
            Transition.SetName(FromTitleLabel, "FromTitle");
            Transition.SetName(FromAuthorLabel, "FromAuthor");
            Transition.SetName(SelectedBookTitleLabel, "ToTitle");
            Transition.SetName(SelectedBookAuthorLabel, "ToAuthor");

            // initial view values
            FromTitleLabel.Opacity = 0;
            FromAuthorLabel.Opacity = 0;
            SelectedBookTitleLabel.Opacity = 0;
            SelectedBookAuthorLabel.Opacity = 0;

            DescriptionText.Opacity = 0;
            DescriptionBackground.ScaleX = 0;
            SelectedBookDescriptionText.Opacity = 0;
            SelectedBookDescriptionBackground.ScaleX = 0;

            BookBorderBoxView.Opacity = 0;
            SelectedBookBorderBoxView.Opacity = 0;

            SwapPanel.WidthRequest = 50;
            SwapPanel.Scale = 0;
            SwapLabel.Opacity = 0;
            CycleArrow.Opacity = 0;
            SelectedBookBookmark.Opacity = 0;
            SelectedBookBookmarkShadow.Opacity = 0;
            SwapFromBookmark.Opacity = 0;
            SwapFromBookmarkShadow.Opacity = 0;

            var parentAnim = new Animation();

            // animate the background angle
            parentAnim.Add(0, .3, new Animation(t => 
            {
                _colorAngleAnim = t;
                PageBackground.InvalidateSurface();
            }, 0, 200, Easing.SinInOut));

            // Title Animations
            parentAnim.Add(0.00, 0.15, new Animation(t => FromTitleLabel.TranslationY = t, 50, 0, Easing.SinInOut));
            parentAnim.Add(0.00, 0.18, new Animation(t => FromTitleLabel.Opacity = t, 0, 1, Easing.SinInOut));
            parentAnim.Add(0.00, 0.15, new Animation(t => FromAuthorLabel.TranslationY = t, 50, 0, Easing.SinInOut));
            parentAnim.Add(0.00, 0.15, new Animation(t => FromAuthorLabel.Opacity = t, 0, .5, Easing.SinInOut));

            parentAnim.Add(0.00, 0.15, new Animation(t => SelectedBookTitleLabel.TranslationY = t, 50, 0, Easing.SinInOut));
            parentAnim.Add(0.00, 0.18, new Animation(t => SelectedBookTitleLabel.Opacity = t, 0, 1, Easing.SinInOut));
            parentAnim.Add(0.00, 0.15, new Animation(t => SelectedBookAuthorLabel.TranslationY = t, 50, 0, Easing.SinInOut));
            parentAnim.Add(0.00, 0.15, new Animation(t => SelectedBookAuthorLabel.Opacity = t, 0, .5, Easing.SinInOut));

            // Book Background
            parentAnim.Add(0.05, 0.15, new Animation(t => BookBorderBoxView.Scale = t, 0, 1));
            parentAnim.Add(0.05, 0.15, new Animation(t => BookBorderBoxView.Opacity = t, 0, 1));
            parentAnim.Add(0.05, 0.15, new Animation(t => SelectedBookBorderBoxView.Scale = t, 0, 1));
            parentAnim.Add(0.05, 0.15, new Animation(t => SelectedBookBorderBoxView.Opacity = t, 0, 1));

            // Description Background
            DescriptionBackground.AnchorX = 0;
            parentAnim.Add(0.15, 0.35, new Animation(t => DescriptionBackground.ScaleX = t, 0, 1, Easing.SinInOut));
            SelectedBookDescriptionBackground.AnchorX = 1;
            parentAnim.Add(0.15, 0.35, new Animation(t => SelectedBookDescriptionBackground.ScaleX = t, 0, 1, Easing.SinInOut));

            // Description Text
            parentAnim.Add(0.30, .40, new Animation(t => DescriptionText.Opacity = t, 0, 1, Easing.SinInOut));
            parentAnim.Add(0.30, .40, new Animation(t => SelectedBookDescriptionText.Opacity = t, 0, 1, Easing.SinInOut));

            // Animate in the bookmarks
            parentAnim.Add(0.30, .40, new Animation(t => SelectedBookBookmark.Opacity = t, 0, 1, Easing.SinInOut));
            parentAnim.Add(0.30, .40, new Animation(t => SelectedBookBookmarkShadow.Opacity = t, 0, .5, Easing.SinInOut));
            parentAnim.Add(0.30, .40, new Animation(t => SwapFromBookmark.Opacity = t, 0, 1, Easing.SinInOut));
            parentAnim.Add(0.30, .40, new Animation(t => SwapFromBookmarkShadow.Opacity = t, 0, .5, Easing.SinInOut));

            // animate in the swap panel
            parentAnim.Add(0.45, 0.60, new Animation(t => { SwapPanel.Scale = t; }, 0, 1, Easing.SinInOut));
            parentAnim.Add(0.50, 0.70, new Animation(t => { SwapPanel.WidthRequest = t; }, 50, 200, Easing.SinInOut));
            parentAnim.Add(0.60, 0.70, new Animation(t => { SwapLabel.Opacity = t; }, 0, 1));

            // animate in the arrow
            parentAnim.Add(0.80, 0.85, new Animation(t => { CycleArrow.Opacity = t; }, 0, 1));
            parentAnim.Add(0.80, 1.00, new Animation(t => { CycleArrow.Rotation = t; }, 0, 180, Easing.SinInOut));

            parentAnim.Commit(this, "PageAnimations", 16, 3000);
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
 