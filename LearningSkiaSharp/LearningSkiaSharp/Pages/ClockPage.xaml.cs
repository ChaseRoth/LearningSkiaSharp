using SkiaSharp.Views.Forms;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;

namespace LearningSkiaSharp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClockPage : ContentPage
    {
        SKPaint ring = new SKPaint
        {
            StrokeCap = SKStrokeCap.Round,
            StrokeWidth = 15,
            Style = SKPaintStyle.Stroke,
            Color = SKColors.White,
            IsAntialias = true
        };

        SKPaint txt = new SKPaint
        {
            IsAntialias = true,
            Color = SKColors.White,
            TextSize = 35f
        };

        public ClockPage()
        {
            InitializeComponent();
            //Runs 60 times every second since that is a standard refresh rate.
            Device.StartTimer(TimeSpan.FromSeconds(1f / 60), () =>
            {
                canvasView.InvalidateSurface();
                return true;
            });
        }

        private void CanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(SKColors.Black);

            // Basically sets a new origin of our matrix.
            // In this case we will be setting our origin in the center of the screen.            
            canvas.Translate(e.Info.Width / 2, e.Info.Height / 2);
            //canvas.Scale(1.5f);

            // Our new origin is based off the translate above so 0,0 will keep us in the middle of the screen.
            canvas.DrawCircle(0, 0, 400, ring);

            var dateTime = DateTime.Now;
            int time = 12;
            for (int angle = 0; angle > -360; angle -= 30)
            {
                canvas.DrawText(time.ToString(), 0, -350, txt);
                time--;
                canvas.RotateDegrees(-30);
            }

            // Hour hand
            canvas.Save();
            canvas.RotateDegrees(30 * dateTime.Hour + dateTime.Minute / 2f);
            canvas.DrawLine(0, 0, 0, -100, ring);
            canvas.Restore();

            // Minute hand
            canvas.Save();
            canvas.RotateDegrees(6 * dateTime.Minute + dateTime.Second / 10f);
            ring.StrokeWidth = 10;
            canvas.DrawLine(0, 0, 0, -200, ring);
            canvas.Restore();


            // Second hand
            canvas.Save();
            canvas.RotateDegrees(6 * dateTime.Second + dateTime.Millisecond / 1000f);
            ring.StrokeWidth = 5;
            canvas.DrawLine(0, 10, 0, -300, ring);
            canvas.Restore();
        }
    }
}