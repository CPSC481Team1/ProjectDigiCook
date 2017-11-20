using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //advancedImage = new Uri(".\\Images\\Skill_Level\\Advanced.jpg", UriKind.Relative);
            this.Title = "DigiCook";

            // Set window to center of the computer screen at startup
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Turn off resizing
            this.ResizeMode = ResizeMode.NoResize;

            
            MainFrame.Content = new SkillSelection();
            // Code for a message box
            // MessageBoxResult result = MessageBox.Show(SkillLevel.skillLevel.ToString(), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

        }
    }
}
