using SkiaSharp;
using SkiaSharp.Views.Forms;
using LearningSkiaSharp.ViewModels;
using Point = SkiaSharp.SKPoint;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace LearningSkiaSharp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HorizontalSliderPage : ContentPage
    {
        HorizontalSliderVM VM => (HorizontalSliderVM)BindingContext;

        public double Percent
        {
            get => VM.Percent;
            set
            {
                VM.Percent = value;
                CustomSlider.InvalidateSurface();
            }
        }

        public double PixelDensity { get => DeviceDisplay.MainDisplayInfo.Density; }

        SKPaint backgroundBrush = new SKPaint();
        SKRect backgroundBounds;

        public HorizontalSliderPage()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Handles the sender <see cref="TouchTracking.TouchEffect.TouchAction"/> event being fired.
        /// </summary>
        private void TouchEffect_TouchAction(object sender, TouchTracking.TouchActionEventArgs args)
        {           
            VM.SliderThumbX = (float)args.Location.X;
            VM.SliderThumbXPixel = (float)(args.Location.X * PixelDensity);
            // If the X value of our slider set the Percent to 0 (our minimum).
            if (args.Location.X < 25 / PixelDensity)
            {               
                if (Percent != 0) Percent = 0;
                return;
            }
            // If the X value is greater than the width of the slider then assign 100 (our maximum).
            if (args.Location.X > backgroundBounds.Width / PixelDensity)
            {
                if (Percent != 100) Percent = 100;
                return;
            }
            // Calulating the Percentage, Width need to be the width of the sliders range of motion.
            // -20 is the padding to the grid
            Percent = args.Location.X / (backgroundBounds.Width / PixelDensity) * 100;
        }
        private void CustomSlider_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // get the brush based on the theme
            SKColor gradientStart = ((Color)Application.Current.Resources["CoolSlider"]).ToSKColor();
            SKColor gradientEnd = ((Color)Application.Current.Resources["HotSlider"]).ToSKColor();

            // gradient background with 3 colors
            backgroundBrush.Shader = SKShader.CreateLinearGradient(
                new Point(0,0),
                new Point(e.Info.Width, e.Info.Height),
                new SKColor[] { gradientStart, gradientEnd },               
                SKShaderTileMode.Clamp);

            backgroundBounds = new SKRect(0, 0, info.Width, info.Height);
            canvas.DrawRect(backgroundBounds, backgroundBrush);

            SKRect rec = new SKRect(25, info.Height - 50, 75,info.Height);

            // 
            //
            //  -- The slider thumb needs to be based off the backgroundBounds of the gradient, not the view itself.
            //
            //

            rec.Offset((float)Percent / 100 * info.Width - 50, 0);
            canvas.DrawRect(rec, new SKPaint
            {
                Color = SKColors.Black
            });


            //SKPath clipPath = SKPath.ParseSvgPathData("M.021 28.481a25.933 25.933 0 0 0 8.824-2.112 27.72 27.72 0 0 0 7.391-5.581l19.08-17.045S39.879.5 44.516.5s9.352 3.243 9.352 3.243l20.74 18.628a30.266 30.266 0 0 0 4.525 3.545c3.318 2.263 11.011 2.564 11.011 2.564z");

            //canvas.DrawPath(clipPath, new SKPaint
            //{
            //    Color = SKColors.White
            //});

            // get density
            //float density = e.Info.Size.Width / (float)this.Width;
            //var scaledClipPath = new SKPath(clipPath);
            //scaledClipPath.Transform(SKMatrix.MakeScale(density, density));


            //canvas.DrawPath(scaledClipPath, new SKPaint
            //{
            //    Color = SKColors.White
            //});

            //////// get the path of the clip region
            ////var scaledClipPath = new SKPath(clipPath);
            ////scaledClipPath.Transform(SKMatrix.MakeScale(density, density));
            ////scaledClipPath.GetTightBounds(out var tightBounds);

            ////// apply translations to position the clip path
            //canvas.Translate(translateX, translateY);
            //canvas.ClipPath(scaledClipPath, SKClipOperation.Difference, true);
            //canvas.Translate(-translateX, -translateY);
        }
    }
}