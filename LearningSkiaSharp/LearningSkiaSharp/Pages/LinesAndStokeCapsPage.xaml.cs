using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningSkiaSharp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LinesAndStokeCapsPage : ContentPage
    {
        public LinesAndStokeCapsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Handles the PaintSurface event being fired.
        /// </summary>
        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // Create an array of points scattered through the page.
            SKPoint[] points = new SKPoint[10];

            for (int column = 0; column < 2; column++)
            {
                // Deteming the x value for the column.
                float x = (0.1f + 0.8f * column) * info.Width;

                for (int row = 0; row < 5; row++)
                {
                    // Determining the row y value inside its respective column.
                    float y = (0.1f + 0.2f * row) * info.Height;
                    // Detemining the index like this allows for the points to be generated in two rows.
                    // The first column each has a even index from 0 to 10 and the ladder for the 2nd column.
                    // This allows polygon mode to have a nice zigzag pattern across the screen instead of a big 'U' shape.
                    points[2 * row + column] = new SKPoint(x, y);
                }
            }

            SKPaint paintctx = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.DarkOrchid,
                StrokeWidth = 50,
                StrokeCap = (SKStrokeCap)strokeCapPicker.SelectedItem
            };

            // Render the points by calling DrawPoints
            SKPointMode pointMode = (SKPointMode)pointModePicker.SelectedItem;
            // Drawning the points.
            canvas.DrawPoints(pointMode, points, paintctx);
        }

        /// <summary>
        ///     This function invalidates the layout forcing it to fire the PaintSurface event.
        /// </summary>
        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            if (canvasView != null)
            {
                canvasView.InvalidateSurface();
            }
        }
    }
}