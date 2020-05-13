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
    public partial class PathFillTypesPage : ContentPage
    {
        public PathFillTypesPage()
        {
            InitializeComponent();
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPoint center = new SKPoint(info.Width / 2, info.Height / 2);
            float radius = 0.45f * Math.Min(info.Width, info.Height);

            SKPath path = new SKPath
            {
                FillType = (SKPathFillType)fillTypePicker.SelectedItem
            };
            path.MoveTo(info.Width / 2, info.Height / 2 - radius);

            for (int i = 1; i < 5; i++)
            {
                // https://setosa.io/ev/sine-and-cosine/
                // http://www.algebralab.org/lessons/lesson.aspx?file=Geometry_AnglesComplementarySupplementaryVertical.xml
                // angle from vertical
                double angle = i * 4 * Math.PI / 5;
                //(x,y) = (rcos(θ),rsin(θ )) we are using this equation to detemine the x and y of the point.
                path.LineTo(center + new SKPoint(radius * (float)Math.Sin(angle), -radius * (float)Math.Cos(angle)));
            }
            path.Close();

            SKPaint strokePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Red,
                StrokeWidth = 50,
                StrokeJoin = SKStrokeJoin.Round
            };

            SKPaint fillPaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.Blue
            };

            switch ((string)drawingModePicker.SelectedItem)
            {
                case "Fill only":
                    canvas.DrawPath(path, fillPaint);
                    break;

                case "Stroke only":
                    canvas.DrawPath(path, strokePaint);
                    break;

                case "Stroke then Fill":
                    canvas.DrawPath(path, strokePaint);
                    canvas.DrawPath(path, fillPaint);
                    break;

                case "Fill then Stroke":
                    canvas.DrawPath(path, fillPaint);
                    canvas.DrawPath(path, strokePaint);
                    break;
            }
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