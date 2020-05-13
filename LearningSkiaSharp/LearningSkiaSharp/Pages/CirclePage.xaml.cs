using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
/// <summary>
/// 
///     Source: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/graphics/skiasharp/basics/circle
/// 
/// </summary>
namespace LearningSkiaSharp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CirclePage : ContentPage
    {
        const float RADIUS = 200f;

        public CirclePage()
        { 
            Title = "Simple Circle";

            // Creating a new canvasView which will hold our SkiaSharp stuff.
            SKCanvasView canvasView = new SKCanvasView();
            // PaintSurface is fired when it is time to update the display's design.
            //  IMPORTANT: PaintSurface is not fired every time a page needs to be rendered (this isnt a draw function).
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            // Assigning our canvasView to our Page's Content property.
            Content = canvasView;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            // SKImageInfo contains information about the drawing surface.
            SKImageInfo info = args.Info;
            // SKSurface is the object which represents the drawing surface itself.
            SKSurface surface = args.Surface;
            // SKCanvas is a graphics drawing context that you use to perform the actual drawing.
            SKCanvas canvas = surface.Canvas;

            // Clearing the canvas to a empty color.
            canvas.Clear();
            // Below is an overload to set the background to a default color.
            //  SkiaSharp gives us a AWESOME extension method to convert Xamarin.Froms.Color values to SKColor values.
            // canvas.Clear(Color.Red.ToSKColor());

            // Here we are creating a SKPaint object that will be used by our canvas's draw functions.
            //  This allows us to provide extra information about the drawing like if we want to fill or draw as a stoke.
            //  More below:
            SKPaint paintctx = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Red.ToSKColor(),
                StrokeWidth = 25
            };

            // Here we draw the stoked circle to the canvas.
            //  The first two parameters center the circle.
            canvas.DrawCircle(info.Width / 2, info.Height / 2, RADIUS, paintctx);

            // Here we are changing the style and color of our paint object to make the next circle fill and be another color.
            paintctx.Style = SKPaintStyle.Fill;
            paintctx.Color = SKColors.Blue;
            canvas.DrawCircle(info.Width / 2, info.Height / 2, RADIUS, paintctx);            
        }
    }
}