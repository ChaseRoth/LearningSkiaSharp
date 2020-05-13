using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningSkiaSharp.Pages.Nav
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        private void SKCanvas_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            var surface = e.Surface;
            var canvas = surface.Canvas;

            canvas.Clear();

            using (SKPaint paint = new SKPaint())
            {
                // Create linear gradient from upper-left to lower-right
                paint.Shader = SKShader.CreateLinearGradient(
                                    new SKPoint(0, 0),
                                    new SKPoint(e.Info.Width, e.Info.Height),                                    
                                    new SKColor[] { SKColor.Parse(((Color)App.Current.Resources[App.LIGHT_PRIMARY_KEY]).ToHex()), SKColor.Parse(((Color)App.Current.Resources[App.DARK_PRIMARY_KEY]).ToHex()) },
                                    null,
                                    SKShaderTileMode.Repeat);

                // Draw the gradient on the rectangle
                canvas.DrawRect(0, 0, e.Info.Width, e.Info.Height, paint);
            }
        }
    }
}