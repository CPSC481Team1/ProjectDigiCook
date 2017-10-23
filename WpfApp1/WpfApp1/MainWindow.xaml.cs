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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Title = "DigiCook";

            // Set window to center of the computer screen at startup
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Turn off resizing
            this.ResizeMode = ResizeMode.NoResize;

            // Code for a message box
            // MessageBoxResult result = MessageBox.Show(SkillLevel.skillLevel.ToString(), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

        }

        // Code to handle button clicks
        private void Beginner_Button_Click(object sender, RoutedEventArgs e)
        {
            SkillLevel.skillLevel = 1;
        }
        private void Intermediate_Button_Click(object sender, RoutedEventArgs e)
        {
            SkillLevel.skillLevel = 2;
        }

        private void Expert_Button_Click(object sender, RoutedEventArgs e)
        {
            SkillLevel.skillLevel = 3;
        }

        private void Skip_Button_MouseEnter(object sender, MouseEventArgs e)
        {
        }

        private void SkipButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }
    }
}
