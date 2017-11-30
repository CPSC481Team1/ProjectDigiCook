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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for CustomMsgBoxWPF.xaml
    /// </summary>
    public partial class CustomMsgBoxWPF : UserControl
    {
        public CustomMsgBoxWPF()
        {
            InitializeComponent();
        }

        static CustomMsgBoxWPF MsgBox;
        static bool result = false;
        static Window window;

        public static bool Show(string Text, string btnOK, string btnCancel)
        {
            MsgBox = new CustomMsgBoxWPF();
            MsgBox.label.Content = Text;
            MsgBox.button_yes.Content = btnOK;
            MsgBox.button_no.Content = btnCancel;
        //    Uri iconUri = new Uri(Environment.CurrentDirectory + "/icons/icon.png", UriKind.RelativeOrAbsolute);

            window = new Window
            {
                Title = "DigiCook",
                Content = MsgBox,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
        //        Icon = BitmapFrame.Create(iconUri)
            };

            window.ShowDialog();
            return result;
        }

        private void button_yes_Click(object sender, RoutedEventArgs e)
        {
            result = true;
            window.Close();
        }

        private void button_no_Click(object sender, RoutedEventArgs e)
        {
            result = false;
            window.Close();
        }
    }
}
