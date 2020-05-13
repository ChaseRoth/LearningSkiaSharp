using SkiaSharp.Views.Forms;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningSkiaSharp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SquarePage : ContentPage
    {
        const float WIDTH = 350;
        const float HEIGHT = 500;

        public SquarePage()
        {
            InitializeComponent();

            var canvasView = new SKCanvasView();
            canvasView.PaintSurface += CanvasView_PaintSurface;
            Content = canvasView;
        }

        private void CanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;

            surface.Canvas.Clear();

            SKPaint paintcontext = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 50,
                Color = Color.Blue.ToSKColor()
            };
            // Centering our rectanle or square position and then drawing it.
            surface.Canvas.DrawRect(info.Width / 2 - WIDTH / 2, info.Height / 2 - HEIGHT / 2, WIDTH, HEIGHT, paintcontext);

            paintcontext.Color = SKColors.Black;
            paintcontext.Style = SKPaintStyle.Fill;

            surface.Canvas.DrawRect(info.Width / 2 - WIDTH / 2, info.Height / 2 - HEIGHT / 2, WIDTH, HEIGHT, paintcontext);
        }
    }
}