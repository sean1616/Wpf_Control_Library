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

namespace Wpf_Control_Library
{
    /// <summary>
    /// Interaction logic for TextBox_Only.xaml
    /// </summary>
    public partial class TextBox_Only : UserControl
    {
        public TextBox_Only()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty txtbox_content_Property =
                    DependencyProperty.Register("txtbox_content", typeof(string), typeof(TextBox_Only),
                    new UIPropertyMetadata(null));

        public string txtbox_content //提供內部binding之相依屬性
        {
            get { return (string)GetValue(txtbox_content_Property); }
            set { SetValue(txtbox_content_Property, value); }
        }
    }
}
