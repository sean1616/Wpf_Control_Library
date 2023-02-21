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
using System.Collections.ObjectModel;

namespace Wpf_Control_Library
{
    /// <summary>
    /// Interaction logic for UserControl_Mix.xaml
    /// </summary>
    public partial class UserControl_Mix : UserControl
    {
        public UserControl_Mix()
        {
            InitializeComponent();
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
                    new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string txtbox_value //提供內部binding之相依屬性
        {
            get { return (string)GetValue(txtbox_value_Property); }
            set { SetValue(txtbox_value_Property, value); }
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


        #region For ComboBox
        public static readonly DependencyProperty ItemsSource_Property =
                 DependencyProperty.Register("ItemSource", typeof(IEnumerable<string>), typeof(UserControl_Mix),
                 new UIPropertyMetadata(null));

        public IEnumerable<string> ItemSource //提供內部binding之相依屬性
        {
            get { return (IEnumerable<string>)GetValue(ItemsSource_Property); }
            set { SetValue(ItemsSource_Property, value); }
        }

        public static readonly DependencyProperty SelectedIndex_Property =
                  DependencyProperty.Register("SelectedIndex", typeof(int), typeof(UserControl_Mix),
                  new UIPropertyMetadata(null));

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


        public event EventHandler ComBox_DropDownOpened = delegate { };  //提供外部操作事件參數
        private void ComBox_DropDownOpened_Binding(object sender, EventArgs e)
        {
            ComBox_DropDownOpened(sender, e);
        }

        public event EventHandler ComBox_DropDownClosed = delegate { };  //提供外部操作事件參數
        private void ComBox_DropDownClosed_Binding(object sender, EventArgs e)
        {
            ComBox_DropDownClosed(sender, e);
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

       
    }
}
