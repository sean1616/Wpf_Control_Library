using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Control_Library
{
    public class SliderToWidthConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double sliderValue)
            {
                    return sliderValue * 3;
            }
            return 0.0; // Default value
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class SliderToPosConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //sliderValue, Smax, Smin, Pmax, Pmin
            double Pos = (double.Parse(values[4].ToString()) - (double.Parse(values[3].ToString()) / 2)) * 
                (double.Parse(values[0].ToString())) / (double.Parse(values[1].ToString()) - double.Parse(values[2].ToString())) - (double.Parse(values[3].ToString()) / 4);
            return Pos;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ConcatStringsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var outputString = "";
            foreach (var str in values)
            {
                outputString += str.ToString() + " ";
            }
            return outputString;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Interaction logic for GooSlider.xaml
    /// </summary>
    public partial class GooSlider : UserControl
    {
        public GooSlider()
        {
            InitializeComponent();
        }

        private void slider_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Slider _slider = (Slider)sender;
            var slider_ActualWidth = _slider.ActualWidth;

            //相對於視窗中的滑鼠位置
            var point = e.MouseDevice.GetPosition(_slider);

            //計算滑鼠在Slider X方向上的位置(以百分比計算)
            var percentOfpoint = (point.X / slider_ActualWidth);

            //移動slider至滑鼠位置
            _slider.Value = Math.Round(percentOfpoint * (_slider.Maximum - _slider.Minimum) + _slider.Minimum, 2);
        }

        public string String1 { get; set; } = "Hello";
        public string String2 { get; set; } = "World";

        //private static void OnUriChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    //Shape sh = (Shape)d;
        //    //sh.Fill = new ImageBrush(new BitmapImage((Uri)e.NewValue));

        //}

        //private static object Coerce_slider_valueChanged(DependencyObject d, object value)
        //{
        //    if (value == null)
        //    {
        //        return 0d;
        //    }

        //    if (double.TryParse(value.ToString(), out double r))
        //        return r;
        //    else
        //        return 0d;
        //}



        public static readonly DependencyProperty MsgPosition_Property =
                 DependencyProperty.Register("MsgPosition", typeof(double), typeof(GooSlider),
                 new FrameworkPropertyMetadata(
                       0d,
                       FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
                       null,
                       null,
                       isAnimationProhibited: true,
                       UpdateSourceTrigger.PropertyChanged));

        public double MsgPosition //提供內部binding之相依屬性
        {
            get { return (double)GetValue(MsgPosition_Property); }
            set { SetValue(MsgPosition_Property, value); }
        }

        public static readonly DependencyProperty SliderOrientation_Property =
                  DependencyProperty.Register("Orientation", typeof(Orientation), typeof(GooSlider),
                  new UIPropertyMetadata(Orientation.Horizontal));

        public Orientation Orientation //提供內部binding之相依屬性
        {
            get { return (Orientation)GetValue(SliderOrientation_Property); }
            set { SetValue(SliderOrientation_Property, value); }
        }

        public static readonly DependencyProperty SliderValue_Property =
                  DependencyProperty.Register("Value", typeof(double), typeof(GooSlider),
                  new FrameworkPropertyMetadata(
                        0d,
                        FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
                        null,
                        null,
                        isAnimationProhibited: true,
                        UpdateSourceTrigger.PropertyChanged));

        public double Value //提供內部binding之相依屬性
        {
            get { return (double)GetValue(SliderValue_Property); }
            set { SetValue(SliderValue_Property, value); }
        }

        public static readonly DependencyProperty SliderMax_Property =
                  DependencyProperty.Register("Maximum", typeof(double), typeof(GooSlider),
                  new UIPropertyMetadata(100d));

        public double Maximum //提供內部binding之相依屬性
        {
            get { return (double)GetValue(SliderMax_Property); }
            set { SetValue(SliderMax_Property, value); }
        }

        public static readonly DependencyProperty SliderMin_Property =
                 DependencyProperty.Register("Minimum", typeof(double), typeof(GooSlider),
                 new UIPropertyMetadata(0d));

        public double Minimum //提供內部binding之相依屬性
        {
            get { return (double)GetValue(SliderMin_Property); }
            set { SetValue(SliderMin_Property, value); }
        }


        public static readonly DependencyProperty SliderTickFrequency_Property =
                DependencyProperty.Register("TickFrequency", typeof(double), typeof(GooSlider),
                new UIPropertyMetadata(0.01d));

        public double TickFrequency //提供內部binding之相依屬性
        {
            get { return (double)GetValue(SliderTickFrequency_Property); }
            set { SetValue(SliderTickFrequency_Property, value); }
        }

        public static readonly DependencyProperty SliderThumbSize_Property =
               DependencyProperty.Register("ThumbSize", typeof(double), typeof(GooSlider),
               new UIPropertyMetadata(20d));

        public double ThumbSize //提供內部binding之相依屬性
        {
            get { return (double)GetValue(SliderThumbSize_Property); }
            set { SetValue(SliderThumbSize_Property, value); }
        }


        public static readonly DependencyProperty SliderBaseColor_Property =
                DependencyProperty.Register("SliderBaseColor", typeof(SolidColorBrush), typeof(GooSlider),
                new UIPropertyMetadata(new SolidColorBrush(Colors.DarkGray), null));

        public SolidColorBrush SliderBaseColor //提供內部binding之相依屬性
        {
            get { return (SolidColorBrush)GetValue(SliderBaseColor_Property); }
            set { SetValue(SliderBaseColor_Property, value); }
        }

        public static readonly DependencyProperty SliderBarColor_Property =
                DependencyProperty.Register("SliderBarColor", typeof(SolidColorBrush), typeof(GooSlider),
                new UIPropertyMetadata(new BrushConverter().ConvertFrom("#FF33D3C4"), null));

        public SolidColorBrush SliderBarColor //提供內部binding之相依屬性
        {
            get { return (SolidColorBrush)GetValue(SliderBarColor_Property); }
            set { SetValue(SliderBarColor_Property, value); }
        }

        public static readonly DependencyProperty SliderThumbColor_Property =
                DependencyProperty.Register("SliderThumbColor", typeof(SolidColorBrush), typeof(GooSlider),
                new UIPropertyMetadata(new BrushConverter().ConvertFrom("#FF33D3C4"), null));

        public SolidColorBrush SliderThumbColor //提供內部binding之相依屬性
        {
            get { return (SolidColorBrush)GetValue(SliderThumbColor_Property); }
            set { SetValue(SliderThumbColor_Property, value); }
        }
    }

    

}
