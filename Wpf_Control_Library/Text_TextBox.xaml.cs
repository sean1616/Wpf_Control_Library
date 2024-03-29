﻿using System;
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

namespace Wpf_Control_Library
{
    /// <summary>
    /// Interaction logic for Text_TextBox.xaml
    /// </summary>
    public partial class Text_TextBox : UserControl
    {
        public Text_TextBox()
        {
            InitializeComponent();
        }
               
        #region 定義相依屬性               
        public static readonly DependencyProperty txtbox_content_Property =
                    DependencyProperty.Register("txtbox_content", typeof(string), typeof(Text_TextBox),
                    new UIPropertyMetadata(null));

        public static readonly DependencyProperty txtbox_value_Property =
                    DependencyProperty.Register("txtbox_value", typeof(string), typeof(Text_TextBox),
                    new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal));

        public static readonly DependencyProperty border_Background_Property =
                   DependencyProperty.Register("border_Background", typeof(SolidColorBrush), typeof(Text_TextBox),
                   new UIPropertyMetadata(null));

        public static readonly DependencyProperty border_CornerRadius_Property =
                   DependencyProperty.Register("border_CornerRadius", typeof(double), typeof(Text_TextBox),
                   new UIPropertyMetadata(null));

        public double border_CornerRadius //提供內部binding之相依屬性
        {
            get { return (double)GetValue(border_CornerRadius_Property); }
            set { SetValue(border_CornerRadius_Property, value); }
        }


        public string txtbox_content //提供內部binding之相依屬性
        {
            get { return (string)GetValue(txtbox_content_Property); }
            set { SetValue(txtbox_content_Property, value); }
        }

        public string txtbox_value //提供內部binding之相依屬性
        {
            get { return (string)GetValue(txtbox_value_Property); }
            set { SetValue(txtbox_value_Property, value); }
        }


        public SolidColorBrush border_Background //提供內部binding之相依屬性
        {
            get { return (SolidColorBrush)GetValue(border_Background_Property); }
            set { SetValue(border_Background_Property, value); }
        }
        #endregion


        #region 定義動作
        private void userControl_MouseEnter(object sender, MouseEventArgs e)
        {
            border_background.Background = border_Background;
        }

        private void userControl_MouseLeave(object sender, MouseEventArgs e)
        {
            border_background.Background = textBox.IsFocused ? border_Background : Brushes.Transparent;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox obj = (TextBox)sender;
            if (e.Key == Key.Enter)
            {
                txtbox_value = obj.Text;
            }
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            border_background.Background = border_Background;
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            border_background.Background = Brushes.Transparent;
        }
        #endregion
    }
}
