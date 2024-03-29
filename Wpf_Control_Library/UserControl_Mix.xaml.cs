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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Wpf_Control_Library
{
    //自定義相依屬性
    public static class CustomProperties
    {
        public static readonly DependencyProperty WaterMarkProperty =
            DependencyProperty.RegisterAttached("MetroKind", typeof(string), typeof(CustomProperties), new PropertyMetadata(null));

        public static void SetWaterMark(System.Windows.UIElement element, string value)
        {
            element.SetValue(WaterMarkProperty, value);
        }

        public static string GetWaterMark(System.Windows.UIElement element)
        {
            return (string)element.GetValue(WaterMarkProperty);
        }
    }

    /// <summary>
    /// Interaction logic for UserControl_Mix.xaml
    /// </summary>
    public partial class UserControl_Mix : UserControl
    {
        public UserControl_Mix()
        {
            InitializeComponent();
        }

        private bool _isInsideTextContentChange;

        private object _newTextValue = DependencyProperty.UnsetValue;

        private static object CoerceText(DependencyObject d, object value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return value.ToString();
        }

        private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //UserControl_Mix textBox = (UserControl_Mix)d;

            //if (!textBox._isInsideTextContentChange || (textBox._newTextValue != DependencyProperty.UnsetValue && !(textBox._newTextValue is DeferredTextReference)))
            //{
            //textBox.OnTextPropertyChanged((string)e.OldValue, (string)e.NewValue);
            //}
        }

        private static void OnComboBoxWaterMarkPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(_watermark == null || _watermark == string.Empty)
            {
                UserControl_Mix cb = (UserControl_Mix)d;

                if (cb != null)
                {
                    _watermark = cb.UC_WaterMark;
                }
            }
        }

        private static void OnComboBoxSelectedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_Mix cb = (UserControl_Mix)d;

            if(cb != null)
            {
                if(cb.SelectedIndex != -1)
                {
                    cb.UC_WaterMark = "";
                }
                else
                {
                    cb.UC_WaterMark = _watermark;
                }
            }
            //if (!textBox._isInsideTextContentChange || (textBox._newTextValue != DependencyProperty.UnsetValue && !(textBox._newTextValue is DeferredTextReference)))
            //{
            //textBox.OnTextPropertyChanged((string)e.OldValue, (string)e.NewValue);
            //}
        }


        #region 定義相依屬性     

        public static readonly DependencyProperty txtbox_content_Property =
                    DependencyProperty.Register("txtbox_content", typeof(string), typeof(UserControl_Mix),
                    new UIPropertyMetadata(null));

        public string txtbox_content //提供內部binding之相依屬性
        {
            get { return (string)GetValue(txtbox_content_Property); }
            set { SetValue(txtbox_content_Property, value); }
        }

        public static readonly DependencyProperty txtbox_value_Property =
                    DependencyProperty.Register("txtbox_value", typeof(string), typeof(UserControl_Mix),
                    new FrameworkPropertyMetadata(
                        string.Empty, 
                        FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
                        OnTextPropertyChanged, 
                        CoerceText,
                        isAnimationProhibited: true,
                        UpdateSourceTrigger.PropertyChanged));

        [DefaultValue("")]
        [Localizability(LocalizationCategory.Text)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string txtbox_value //提供內部binding之相依屬性
        {
            get { return (string)GetValue(txtbox_value_Property); }
            set { SetValue(txtbox_value_Property, value); }
        }

        public static readonly DependencyProperty Lable_Foreground_Property =
                 DependencyProperty.Register("Lable_Foreground", typeof(SolidColorBrush), typeof(UserControl_Mix),
                 new UIPropertyMetadata(new SolidColorBrush(Colors.Black), null));

        public SolidColorBrush Lable_Foreground //提供內部binding之相依屬性
        {
            get { return (SolidColorBrush)GetValue(Lable_Foreground_Property); }
            set { SetValue(Lable_Foreground_Property, value); }
        }

        public static readonly DependencyProperty Border_Background_MouseEnter_Property =
                   DependencyProperty.Register("Border_Background_MouseEnter", typeof(SolidColorBrush), typeof(UserControl_Mix),
                   new UIPropertyMetadata(new SolidColorBrush(Color.FromRgb(216,243,227)), null));

        public SolidColorBrush Border_Background_MouseEnter //提供內部binding之相依屬性
        {
            get { return (SolidColorBrush)GetValue(Border_Background_MouseEnter_Property); }
            set { SetValue(Border_Background_MouseEnter_Property, value); }
        }

        public static readonly DependencyProperty border_CornerRadius_Property =
                   DependencyProperty.Register("border_CornerRadius", typeof(double), typeof(UserControl_Mix),
                   new UIPropertyMetadata(null));

        public double border_CornerRadius //提供內部binding之相依屬性
        {
            get { return (double)GetValue(border_CornerRadius_Property); }
            set { SetValue(border_CornerRadius_Property, value); }
        }

        public static readonly DependencyProperty UC_Tags_Property =
                  DependencyProperty.Register("UC_Tags", typeof(List<string>), typeof(UserControl_Mix),
                  new UIPropertyMetadata(new List<string>(), null));

        public List<string> UC_Tags //提供內部binding之相依屬性
        {
            get { return (List<string>)GetValue(UC_Tags_Property); }
            set { SetValue(UC_Tags_Property, value); }
        }

        public static readonly DependencyProperty UC_WaterMark_Property =
                  DependencyProperty.Register("UC_WaterMark", typeof(string), typeof(UserControl_Mix),
                  new FrameworkPropertyMetadata(
                        string.Empty,
                        FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal,
                        OnComboBoxWaterMarkPropertyChanged,
                        CoerceText,
                        isAnimationProhibited: true,
                        UpdateSourceTrigger.PropertyChanged));

        public string UC_WaterMark //提供內部binding之相依屬性
        {
            get { return (string)GetValue(UC_WaterMark_Property); }
            set { SetValue(UC_WaterMark_Property, value); }
        }


        #region For ComboBox
        //public static readonly DependencyProperty ItemsSource_Property =
        //         DependencyProperty.Register("ItemSource", typeof(IEnumerable<string>), typeof(UserControl_Mix),
        //         new UIPropertyMetadata(null));

        public static readonly DependencyProperty ItemsSource_Property =
                DependencyProperty.Register("ItemSource", typeof(IEnumerable<string>), typeof(UserControl_Mix),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public IEnumerable<string> ItemSource //提供內部binding之相依屬性
        {
            get { return (IEnumerable<string>)GetValue(ItemsSource_Property); }
            set { SetValue(ItemsSource_Property, value); }
        }

        //public static readonly DependencyProperty SelectedIndex_Property =
        //          DependencyProperty.Register("SelectedIndex", typeof(int), typeof(UserControl_Mix),
        //          new UIPropertyMetadata(null));

        public static readonly DependencyProperty SelectedIndex_Property =
                DependencyProperty.Register("SelectedIndex", typeof(int), typeof(UserControl_Mix),
                        new FrameworkPropertyMetadata(-1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, 
                            OnComboBoxSelectedPropertyChanged, null)
);

        [Bindable(true)]
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Localizability(LocalizationCategory.NeverLocalize)]
        public int SelectedIndex //提供內部binding之相依屬性
        {
            get { return (int)GetValue(SelectedIndex_Property); }
            set { SetValue(SelectedIndex_Property, value); }
        }
        
        //public static readonly DependencyProperty SelectedItem_Property =
        //          DependencyProperty.Register("SelectedItem", typeof(string), typeof(UserControl_Mix),
        //          new UIPropertyMetadata(null));

        public static readonly DependencyProperty SelectedItem_Property =
            DependencyProperty.Register("SelectedItem", typeof(string), typeof(UserControl_Mix),
            new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string SelectedItem //提供內部binding之相依屬性
        {
            get { return (string)GetValue(SelectedItem_Property); }
            set { SetValue(SelectedItem_Property, value); }
        }


        public static readonly DependencyProperty cbx_HorizontalContentAlignment_Property =
                  DependencyProperty.Register("cbx_HorizontalContentAlignment", typeof(HorizontalAlignment), typeof(UserControl_Mix),
                  new UIPropertyMetadata(HorizontalAlignment.Left, null));

        public HorizontalAlignment cbx_HorizontalContentAlignment //提供內部binding之相依屬性
        {
            get { return (HorizontalAlignment)GetValue(cbx_HorizontalContentAlignment_Property); }
            set { SetValue(cbx_HorizontalContentAlignment_Property, value); }
        }
        #endregion

        #region Toggle Button


        //public static readonly DependencyProperty ToggleButton_IsChecked_Property =
        //           DependencyProperty.Register("ToggleButton_IsChecked", typeof(bool), typeof(UserControl_Mix),
        //           new UIPropertyMetadata(null));

        public static readonly DependencyProperty ToggleButton_IsChecked_Property =
                    DependencyProperty.Register("ToggleButton_IsChecked", typeof(bool), typeof(UserControl_Mix),
                    new FrameworkPropertyMetadata(default(bool), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        public bool ToggleButton_IsChecked //提供內部binding之相依屬性
        {
            get { return (bool)GetValue(ToggleButton_IsChecked_Property); }
            set { SetValue(ToggleButton_IsChecked_Property, value); }
        }

        #endregion

        #region For Type Control
        public static readonly DependencyProperty UC_Text_Textbox_Visibility_Property =
                   DependencyProperty.Register("UC_Text_Textbox_Visibility", typeof(Visibility), typeof(UserControl_Mix),
                    new UIPropertyMetadata(Visibility.Collapsed, null));

        public Visibility UC_Text_Textbox_Visibility //提供內部binding之相依屬性
        {
            get { return (Visibility)GetValue(UC_Text_Textbox_Visibility_Property); }
            set { SetValue(UC_Text_Textbox_Visibility_Property, value); }
        }

        public static readonly DependencyProperty UC_Text_Button_Visibility_Property =
                  DependencyProperty.Register("UC_Text_Button_Visibility", typeof(Visibility), typeof(UserControl_Mix),
                  new UIPropertyMetadata(Visibility.Collapsed, null));

        public Visibility UC_Text_Button_Visibility //提供內部binding之相依屬性
        {
            get { return (Visibility)GetValue(UC_Text_Button_Visibility_Property); }
            set { SetValue(UC_Text_Button_Visibility_Property, value); }
        }

        public static readonly DependencyProperty UC_ComboBox_Visibility_Property =
                  DependencyProperty.Register("UC_ComboBox_Visibility", typeof(Visibility), typeof(UserControl_Mix),
                  new UIPropertyMetadata(Visibility.Collapsed, null));

        public Visibility UC_ComboBox_Visibility //提供內部binding之相依屬性
        {
            get { return (Visibility)GetValue(UC_ComboBox_Visibility_Property); }
            set { SetValue(UC_ComboBox_Visibility_Property, value); }
        }

        public static readonly DependencyProperty UC_ToggleButtong_Visibility_Property =
                  DependencyProperty.Register("UC_ToggleButtong_Visibility", typeof(Visibility), typeof(UserControl_Mix),
                  new UIPropertyMetadata(Visibility.Collapsed, null));

        public Visibility UC_ToggleButtong_Visibility //提供內部binding之相依屬性
        {
            get { return (Visibility)GetValue(UC_ToggleButtong_Visibility_Property); }
            set { SetValue(UC_ToggleButtong_Visibility_Property, value); }
        }

        public static readonly DependencyProperty UC_TextBox_Only_Visibility_Property =
                  DependencyProperty.Register("UC_TextBox_Only_Visibility", typeof(Visibility), typeof(UserControl_Mix),
                  new UIPropertyMetadata(Visibility.Collapsed, null));

        public Visibility UC_TextBox_Only_Visibility //提供內部binding之相依屬性
        {
            get { return (Visibility)GetValue(UC_TextBox_Only_Visibility_Property); }
            set { SetValue(UC_TextBox_Only_Visibility_Property, value); }
        }

        //FrameworkPropertyMetadata 可設定參數變化時所要激發的事件
        public static readonly DependencyProperty UC_Vis_Control_Property = DependencyProperty.Register("UC_Vis_Control",
                      typeof(UC_Types),
                      typeof(UserControl_Mix),
                      new FrameworkPropertyMetadata(UC_Types.Text_Textbox, OnUC_Vis_Control_Changed) // Add callback here
                      );

        public UC_Types UC_Type_Select //提供內部binding之相依屬性
        {
            get { return (UC_Types)GetValue(UC_Vis_Control_Property); }
            set { SetValue(UC_Vis_Control_Property, value); }
        }

        public enum UC_Types
        {
            Text_Textbox,
            Text_Button,
            Text_ToggleButton,
            ComboBox,
            Text_Only
        }

        private static void OnUC_Vis_Control_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_Mix control = (UserControl_Mix)d;
            control.UpdateUC_Text_Button_Visibility();
        }

        // Update UC_Text_Button_Visibility property here based on the new value of UC_Vis_Control
        private void UpdateUC_Text_Button_Visibility()
        {
            switch (UC_Type_Select)
            {
                case UC_Types.Text_Textbox:
                    UC_ComboBox_Visibility = Visibility.Collapsed;
                    UC_Text_Button_Visibility = Visibility.Collapsed;
                    UC_Text_Textbox_Visibility = Visibility.Visible;
                    UC_ToggleButtong_Visibility = Visibility.Collapsed;
                    UC_TextBox_Only_Visibility = Visibility.Collapsed;
                    break;

                case UC_Types.Text_Button:
                    UC_ComboBox_Visibility = Visibility.Collapsed;
                    UC_Text_Button_Visibility = Visibility.Visible;
                    UC_Text_Textbox_Visibility = Visibility.Collapsed;
                    UC_ToggleButtong_Visibility = Visibility.Collapsed;
                    UC_TextBox_Only_Visibility = Visibility.Collapsed;
                    break;

                case UC_Types.ComboBox:
                    UC_ComboBox_Visibility = Visibility.Visible;
                    UC_Text_Button_Visibility = Visibility.Collapsed;
                    UC_Text_Textbox_Visibility = Visibility.Collapsed;
                    UC_ToggleButtong_Visibility = Visibility.Collapsed;
                    UC_TextBox_Only_Visibility = Visibility.Collapsed;
                    break;

                case UC_Types.Text_ToggleButton:
                    UC_ComboBox_Visibility = Visibility.Collapsed;
                    UC_Text_Button_Visibility = Visibility.Collapsed;
                    UC_Text_Textbox_Visibility = Visibility.Collapsed;
                    UC_ToggleButtong_Visibility = Visibility.Visible;
                    UC_TextBox_Only_Visibility = Visibility.Collapsed;
                    break;

                case UC_Types.Text_Only:
                    UC_ComboBox_Visibility = Visibility.Collapsed;
                    UC_Text_Button_Visibility = Visibility.Collapsed;
                    UC_Text_Textbox_Visibility = Visibility.Collapsed;
                    UC_ToggleButtong_Visibility = Visibility.Collapsed;
                    UC_TextBox_Only_Visibility = Visibility.Visible;
                    break;
            }
        } 
        #endregion

        #endregion

        #region 註冊事件

        public event RoutedEventHandler Text_Button_Click = delegate { };  //提供外部操作事件參數
        public void Text_Button_Click_Binding(object sender, RoutedEventArgs e)
        {
            Text_Button_Click(sender, e);
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

        static private string _watermark = string.Empty;

        public event EventHandler ComBox_DropDownOpened = delegate { };  //提供外部操作事件參數
        private void ComBox_DropDownOpened_Binding(object sender, EventArgs e)
        {
            //_watermark = UC_WaterMark;
            //UC_WaterMark = "";
            ComBox_DropDownOpened(sender, e);
        }

        public event EventHandler ComBox_DropDownClosed = delegate { };  //提供外部操作事件參數
        private void ComBox_DropDownClosed_Binding(object sender, EventArgs e)
        {
            ComBox_DropDownClosed(sender, e);

            //if(SelectedIndex < 0)
            //{
            //    UC_WaterMark = _watermark;
            //}
        }

      
        #endregion


        #region 定義動作
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateUC_Text_Button_Visibility();
        }

        private void userControl_MouseEnter(object sender, MouseEventArgs e)
        {
            border_background.Background = Border_Background_MouseEnter;
        }

        private void userControl_MouseLeave(object sender, MouseEventArgs e)
        {
            border_background.Background = textBox.IsFocused ? Border_Background_MouseEnter : Brushes.Transparent;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox obj = (TextBox)sender;
            if (e.Key == Key.Enter)
            {
                txtbox_value = obj.Text;
            }
        }



        #endregion


        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var obj = sender as ListBox;

            if (obj == null) return;

            cbx_Main.IsDropDownOpen = false;
            //cbx_Main.SelectedItem = obj.SelectedItem;
            //MessageBox.Show(cbx_Main.SelectedItem.ToString());
        }

        private void listBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var obj = sender as ListBox;

            if (obj == null) return;

            cbx_Main.IsDropDownOpen = false;
            //MessageBox.Show(cbx_Main.SelectedItem.ToString());
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            border_background.Background = new SolidColorBrush(Colors.Transparent);
        }

       
    }
}
