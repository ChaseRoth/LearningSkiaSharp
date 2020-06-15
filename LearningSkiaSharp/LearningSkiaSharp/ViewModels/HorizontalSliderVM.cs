using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace LearningSkiaSharp.ViewModels
{
    public class HorizontalSliderVM : INotifyPropertyChanged
    {       
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private double percent;
        public double Percent
        {
            get => percent;
            set
            {
                percent = value;
                NotifyPropertyChanged();
            }
        }

        private float sliderThumbX;
        public float SliderThumbX
        {
            get => sliderThumbX;
            set
            {
                sliderThumbX = value;
                NotifyPropertyChanged();
            }
        }

        private float sliderThumbXPixels;
        public float SliderThumbXPixel
        {
            get => sliderThumbXPixels;
            set
            {
                sliderThumbXPixels = value;
                NotifyPropertyChanged();
            }
        }
    }
}
