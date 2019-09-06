using BookSwap.Models;
using BookSwap.ViewModels;
using Plugin.SharedTransitions;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookSwap
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        SKColor _accentColor;
        SKColor _accentDarkColor;
        SKColor _accentExtraDarkColor;
        SKPaint _accentPaint;
        SKPaint _accentDarkPaint;
        SKPaint _accentExtraDarkPaint;

        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = App.MainViewModel;

            _accentColor = ((BooksViewModel)BindingContext).SwapFromBook.Colors.Accent.ToSKColor();
            _accentDarkColor = ((BooksViewModel)BindingContext).SwapFromBook.Colors.DarkAccent.ToSKColor();
            _accentExtraDarkColor = ((BooksViewModel)BindingContext).SwapFromBook.Colors.ExtraDarkAccent.ToSKColor();
            _accentPaint = new SKPaint() { Color = _accentColor };
            _accentDarkPaint = new SKPaint() { Color = _accentDarkColor };
            _accentExtraDarkPaint = new SKPaint() { Color = _accentExtraDarkColor };

            var eff = new XFUtils.Effects.ScrollReporterEffect();
            eff.ScrollChanged += Eff_ScrollChanged;
            BooksListView.Effects.Add(eff);

        }

        private void Eff_ScrollChanged(object sender, XFUtils.Effects.ScrollEventArgs args)
        {
            // send a message to the cell that the scroll position has changes
            MessagingCenter.Send<ScrollMessage, double>(new ScrollMessage(), ScrollMessage.ScrollChanged, args.Y);
        }

        private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            canvas.DrawRect(info.Rect, _accentPaint);

            // create path for light color
            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(info.Width * .7f, 0);
                path.LineTo(info.Width * .2f, info.Height);
                path.LineTo(0, info.Height);
                path.Close();
                canvas.DrawPath(path, _accentDarkPaint);
            }
            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(info.Width * .33f, 0);
                path.LineTo(0, info.Height * .6f);
                path.Close();
                canvas.DrawPath(path, _accentExtraDarkPaint);
            }
        }

        private async void BooksListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // set the selected book
            ((BooksViewModel)BindingContext).SelectedBook = e.Item as Book;
            SharedTransitionNavigationPage.SetTransitionSelectedGroup(this,
                ((BooksViewModel)BindingContext).SelectedBook.Title);
            await Navigation.PushAsync(new SwapDetails());
        }
    }
}
