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
    /// Interaction logic for UC_ComboBox.xaml
    /// </summary>
    public partial class UC_ComboBox : UserControl
    {
        public UC_ComboBox()
        {
            InitializeComponent();

        }

        public static readonly DependencyProperty ItemsSource_Property =
                  DependencyProperty.Register("ItemSource", typeof(ObservableCollection<string>), typeof(UC_ComboBox),
                  new UIPropertyMetadata(null));

        public ObservableCollection<string> ItemSource //提供內部binding之相依屬性
        {
            get { return (ObservableCollection<string>)GetValue(ItemsSource_Property); }
            set { SetValue(ItemsSource_Property, value); }
        }

        public static readonly DependencyProperty SelectedIndex_Property =
                  DependencyProperty.Register("SelectedIndex", typeof(int), typeof(UC_ComboBox),
                  new UIPropertyMetadata(null));

        public int SelectedIndex //提供內部binding之相依屬性
        {
            get { return (int)GetValue(SelectedIndex_Property); }
            set { SetValue(SelectedIndex_Property, value); }
        }

        public static readonly DependencyProperty SelectedItem_Property =
                  DependencyProperty.Register("SelectedItem", typeof(string), typeof(UC_ComboBox),
                  new UIPropertyMetadata(null));

        public string SelectedItem //提供內部binding之相依屬性
        {
            get { return (string)GetValue(SelectedItem_Property); }
            set { SetValue(SelectedItem_Property, value); }
        }



        #region 註冊事件


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


    }
}
