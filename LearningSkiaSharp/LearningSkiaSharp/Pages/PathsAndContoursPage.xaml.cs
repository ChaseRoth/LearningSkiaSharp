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
    public partial class PathsAndContoursPage : ContentPage
    {
        public PathsAndContoursPage()
        {
            InitializeComponent();
            var canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPaint textPaint = new SKPaint
            {
                Color = SKColors.Black,
                TextSize = 75,
                TextAlign = SKTextAlign.Right
            };

            SKPaint thickLinePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Orange,
                StrokeWidth = 50,
                StrokeJoin = SKStrokeJoin.Bevel
            };

            SKPaint thinLinePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Black,
                StrokeWidth = 2
            };

            float xText = info.Width - 100;
            float xLine1 = 100;
            float xLine2 = info.Width - xLine1;
            float y = 2 * textPaint.FontSpacing;
            string[] strStrokeJoins = { "Miter", "Round", "Bevel" };

            foreach (string strStrokeJoin in strStrokeJoins)
            {
                // Display text
                canvas.DrawText(strStrokeJoin, xText, y, textPaint);

                // Get stroke-join value
                SKStrokeJoin strokeJoin;
                // As we iterate through each string we will parse it and pass it out to a variable of its respective type.
                Enum.TryParse(strStrokeJoin, out strokeJoin);

                // Create path
                SKPath path = new SKPath();
                path.MoveTo(xLine1, y - 80);
                path.LineTo(xLine1, y + 80);
                path.LineTo(xLine2, y + 80);

                // Display thick line
                thickLinePaint.StrokeJoin = strokeJoin;
                canvas.DrawPath(path, thickLinePaint);

                // Display thin line
                canvas.DrawPath(path, thinLinePaint);
                y += 3 * textPaint.FontSpacing;
            }
        }
    }
}