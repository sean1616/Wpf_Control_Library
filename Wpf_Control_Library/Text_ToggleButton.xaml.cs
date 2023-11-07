using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public static class CustomToggleButtonProperties
    {
        public static readonly DependencyProperty ToggleBTN_True_Main_Color_Property =
            DependencyProperty.RegisterAttached("SwitchColor_True_Main", typeof(SolidColorBrush), typeof(CustomToggleButtonProperties), new PropertyMetadata(null));

        public static void SetToggleButton_MainTrueColor(System.Windows.UIElement element, string value)
        {
            element.SetValue(ToggleBTN_True_Main_Color_Property, value);
        }
    }

    /// <summary>
    /// Interaction logic for Text_ToggleButton.xaml
    /// </summary>
    public partial class Text_ToggleButton : UserControl
    {
        public Text_ToggleButton()
        {
            InitializeComponent();
        }

        #region 定義相依屬性               
        public static readonly DependencyProperty txtbox_content_Property =
                    DependencyProperty.Register("txtbox_content", typeof(string), typeof(Text_ToggleButton),
                    new UIPropertyMetadata(null));

        public static readonly DependencyProperty Ischecked_Property =
                   DependencyProperty.Register("Ischecked", typeof(bool), typeof(Text_ToggleButton),
                   new UIPropertyMetadata(null));

        //public static readonly DependencyProperty txtbox_FontFamily_Property =
        //          DependencyProperty.Register("txtbox_FontFamily", typeof(string), typeof(Text_ToggleButton),
        //          new UIPropertyMetadata(null));

        public static readonly DependencyProperty border_Background_Property =
                  DependencyProperty.Register("border_Background", typeof(SolidColorBrush), typeof(Text_ToggleButton),
                  new UIPropertyMetadata(null));

        public static readonly DependencyProperty SwitchColor_True_Background_Property =
                 DependencyProperty.Register("SwitchColor_True_Background", typeof(SolidColorBrush), typeof(UserControl_Mix),
                 new UIPropertyMetadata(new SolidColorBrush(Color.FromRgb(25, 86, 97)), null));

        public SolidColorBrush SwitchColor_True_Background //提供內部binding之相依屬性
        {
            get { return (SolidColorBrush)GetValue(SwitchColor_True_Background_Property); }
            set { SetValue(SwitchColor_True_Background_Property, value); }
        }

        public static readonly DependencyProperty SwitchColor_True_Property =
                 DependencyProperty.Register("SwitchColor_True", typeof(SolidColorBrush), typeof(UserControl_Mix),
                 new UIPropertyMetadata(new SolidColorBrush(Color.FromRgb(255, 255, 255)), null));

        public SolidColorBrush SwitchColor_True //提供內部binding之相依屬性
        {
            get { return (SolidColorBrush)GetValue(SwitchColor_True_Property); }
            set { SetValue(SwitchColor_True_Property, value); }
        }

        public static readonly DependencyProperty SwitchColor_False_Property =
                DependencyProperty.Register("SwitchColor_False", typeof(SolidColorBrush), typeof(UserControl_Mix),
                new UIPropertyMetadata(new SolidColorBrush(Color.FromRgb(90, 90, 90)), null));

        public SolidColorBrush SwitchColor_False //提供內部binding之相依屬性
        {
            get { return (SolidColorBrush)GetValue(SwitchColor_False_Property); }
            set { SetValue(SwitchColor_False_Property, value); }
        }


        public string txtbox_content //提供內部binding之相依屬性
        {
            get { return (string)GetValue(txtbox_content_Property); }
            set { SetValue(txtbox_content_Property, value); }
        }

        public bool Ischecked //提供內部binding之相依屬性
        {
            get { return (bool)GetValue(Ischecked_Property); }
            set { SetValue(Ischecked_Property, value); }
        }

       

       

        //public string txtbox_FontFamily //提供內部binding之相依屬性
        //{
        //    get { return (string)GetValue(txtbox_FontFamily_Property); }
        //    set { SetValue(txtbox_FontFamily_Property, value); }
        //}

        public SolidColorBrush border_Background //提供內部binding之相依屬性
        {
            get { return (SolidColorBrush)GetValue(border_Background_Property); }
            set { SetValue(border_Background_Property, value); }
        }
        #endregion

        private void userControl_MouseEnter(object sender, MouseEventArgs e)
        {
            //border_background.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF98DEB5"));
            border_background.Background = border_Background;
        }

        private void userControl_MouseLeave(object sender, MouseEventArgs e)
        {
            border_background.Background = Brushes.Transparent;
            //border_background.Background = TBtn_Auto_Connect_TLS.IsFocused ? border_Background : Brushes.Transparent;
        }

        public event RoutedEventHandler Click = delegate { };  //提供外部操作事件參數
        private void ToggleButton_Click_Binding(object sender, RoutedEventArgs e)
        {
            Click(sender, e);
        }

        public event RoutedEventHandler Checked = delegate { };  //提供外部操作事件參數
        private void ToggleButton_Checked_Binding(object sender, RoutedEventArgs e)
        {
            Checked(sender, e);
        }

        public event RoutedEventHandler UnChecked = delegate { };  //提供外部操作事件參數
        private void ToggleButton_UnChecked_Binding(object sender, RoutedEventArgs e)
        {
            UnChecked(sender, e);
        }
    }
}
