using System;
using System.Collections.Generic;
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
using MahApps.Metro.IconPacks;

namespace Wpf_Control_Library
{
    /// <summary>
    /// Interaction logic for GooIconButton.xaml
    /// </summary>
    public partial class GooIconButton : UserControl
    {
        public GooIconButton()
        {
            InitializeComponent();
        }

        private void OverrideMetadata(Type type, FrameworkPropertyMetadata frameworkPropertyMetadata)
        {
            throw new NotImplementedException();
        }

        private static object CoerceCornerRadius(DependencyObject d, object value)
        {
            if (value == null)
            {
                return new CornerRadius(0);
            }

            if (int.TryParse(value.ToString(), out int r))
                return r;
            else
                return new CornerRadius(0);
        }

        public static readonly DependencyProperty CornerRadius_Property =
                DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(GooIconButton),
                new FrameworkPropertyMetadata(new CornerRadius(10))
                    );

        public CornerRadius CornerRadius //提供內部binding之相依屬性
        {
            get { return (CornerRadius)GetValue(CornerRadius_Property); }
            set { SetValue(CornerRadius_Property, value); }
        }

        public static readonly DependencyProperty IconName_Property =
                DependencyProperty.Register("IconName", typeof(PackIconBootstrapIconsKind), typeof(GooIconButton),
               new FrameworkPropertyMetadata(
                        PackIconBootstrapIconsKind.Stack,
                        FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
                        null,
                        null,
                        isAnimationProhibited: true,
                        UpdateSourceTrigger.PropertyChanged)
                    );

        public PackIconBootstrapIconsKind IconName //提供內部binding之相依屬性
        {
            get { return (PackIconBootstrapIconsKind)GetValue(IconName_Property); }
            set { SetValue(IconName_Property, value); }
        }

        public static readonly DependencyProperty IconColor_Property =
                  DependencyProperty.Register("IconColor", typeof(SolidColorBrush), typeof(GooIconButton),
                  new UIPropertyMetadata(null));

        public SolidColorBrush IconColor //提供內部binding之相依屬性
        {
            get { return (SolidColorBrush)GetValue(IconColor_Property); }
            set { SetValue(IconColor_Property, value); }
        }

        public static readonly DependencyProperty IconColor_MouseOver_Property =
                 DependencyProperty.Register("IconColor_MouseOver", typeof(SolidColorBrush), typeof(GooIconButton),
                 new UIPropertyMetadata(new SolidColorBrush(Colors.White)));

        public SolidColorBrush IconColor_MouseOver //提供內部binding之相依屬性
        {
            get { return (SolidColorBrush)GetValue(IconColor_MouseOver_Property); }
            set { SetValue(IconColor_MouseOver_Property, value); }
        }

        public static readonly DependencyProperty Background_MouseOver_Property =
                  DependencyProperty.Register("Background_MouseOver", typeof(SolidColorBrush), typeof(GooIconButton),
                  new UIPropertyMetadata(new SolidColorBrush(Colors.White)));

        public SolidColorBrush Background_MouseOver //提供內部binding之相依屬性
        {
            get { return (SolidColorBrush)GetValue(Background_MouseOver_Property); }
            set { SetValue(Background_MouseOver_Property, value); }
        }

        public static readonly DependencyProperty VerticalIconAlignment_Property =
               DependencyProperty.Register("VerticalIconAlignment", typeof(VerticalAlignment), typeof(GooIconButton),
               new UIPropertyMetadata(VerticalAlignment.Stretch));

        public VerticalAlignment VerticalIconAlignment //提供內部binding之相依屬性
        {
            get { return (VerticalAlignment)GetValue(VerticalIconAlignment_Property); }
            set { SetValue(VerticalIconAlignment_Property, value); }
        }

        public static readonly DependencyProperty HorizontalIconAlignment_Property =
               DependencyProperty.Register("HorizontalIconAlignment", typeof(HorizontalAlignment), typeof(GooIconButton),
               new UIPropertyMetadata(HorizontalAlignment.Stretch));

        public HorizontalAlignment HorizontalIconAlignment //提供內部binding之相依屬性
        {
            get { return (HorizontalAlignment)GetValue(HorizontalIconAlignment_Property); }
            set { SetValue(HorizontalIconAlignment_Property, value); }
        }

        public event RoutedEventHandler Click = delegate { };
        private void BTN_Click(object sender, RoutedEventArgs e)
        {
            Click(sender, e);
        }
    }
}
