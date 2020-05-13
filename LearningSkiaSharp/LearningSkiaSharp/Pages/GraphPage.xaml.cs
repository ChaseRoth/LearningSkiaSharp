using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningSkiaSharp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraphPage : ContentPage
    {
        ///// <summary>
        /////     This is the space between the outer edges of the View and the axis lines.
        ///// </summary>
        //private float graphAxisPadding = 150;
        ///// <summary>
        /////     This is the length of the scale lines on the axis lines. The total length of the scale lines is twice the value of this variable.
        /////     This merely acts as a offset for the start and end points of drawing the scale lines.
        ///// </summary>
        //private float graphScaleLinesLength = 20; 

        //SKPoint originPoint;
        //SKPoint xEndPoint;
        //SKPoint yEndPoint;

        //SKPaint axisLine = new SKPaint
        //{
        //    Color = SKColors.Black,
        //    StrokeWidth = 15,
        //    StrokeCap = SKStrokeCap.Butt
        //};
        //SKPaint scaleLine = new SKPaint
        //{
        //    Color = SKColors.Blue,
        //    StrokeWidth = 8
        //};
        //SKPaint scaleText = new SKPaint
        //{
        //    Color = SKColors.Black,
        //    TextSize = 40          
        //};
        //SKPaint backgroundLine = new SKPaint
        //{
        //    Color = SKColors.Gray,
        //    StrokeWidth = 2
        //};

        public GraphPage()
        {
            InitializeComponent();
        }

        //private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        //{
        //    SKSurface surface = e.Surface;
        //    SKCanvas canvas = surface.Canvas;

        //    var originYValue = e.Info.Height - graphAxisPadding;

        //    originPoint = new SKPoint(graphAxisPadding, originYValue);
        //    xEndPoint = new SKPoint(e.Info.Width - graphAxisPadding, originYValue);
        //    yEndPoint = new SKPoint(graphAxisPadding, graphAxisPadding);

        //    canvas.Clear(SKColors.White);

        //    // Draw Y Axis Line
        //    canvas.DrawLine(originPoint, yEndPoint, axisLine);

        //    // Draw X Axis Line
        //    canvas.DrawLine(originPoint, xEndPoint, axisLine);

        //    // Drawing the text value
        //    canvas.DrawText("0", originPoint.X - 40, originPoint.Y + 40, scaleText);

        //    {
        //        // Draw Y Axis Values
        //        float yAxisScaleValue = 50;
        //        int[] scaleValues = new int[] { 1,2,3,4,5,6,7,8,9,10 };
        //        byte counter = 0;
        //        // Calulating the x and y positions for the scale lines.
        //        var x = yEndPoint.Y - graphScaleLinesLength;
        //        var y = yEndPoint.Y + graphScaleLinesLength;
        //        // We are generating the values (lines) that go on the yAxis.yAxisScaleValue
        //        // We must not print a value at the 0,0 of the graph so we offset by the factor of yAxisScaleValue.
        //        for (float i = (originYValue - yAxisScaleValue); i > graphAxisPadding; i -= yAxisScaleValue)
        //        {
        //            // Drawing a scale line.
        //            canvas.DrawLine(x, i, y, i, scaleLine);
        //            // Drawing a background line.
        //            canvas.DrawLine(y, i, xEndPoint.X, i, backgroundLine);
        //            // Drawing the scale text label.
        //            canvas.DrawText(scaleValues[counter++].ToString(), x - 75, i, scaleText);
        //        }
        //    }


        //    /// Draw X Axis Values
        //    float xAxisScaleValue = 50;
        //    for (float i = (originPoint.X + xAxisScaleValue); i < xEndPoint.X; i += xAxisScaleValue)
        //    {               
        //        canvas.DrawLine(i, xEndPoint.Y - graphScaleLinesLength, i, xEndPoint.Y + graphScaleLinesLength, scaleLine);
        //        // Drawing a background line.
        //        canvas.DrawLine(i, xEndPoint.Y - graphScaleLinesLength, i, yEndPoint.Y, backgroundLine);
        //    }
        //}
    }
}