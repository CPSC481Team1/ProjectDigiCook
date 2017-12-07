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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



    public partial class SkillSelection : Page
    {

        private Storyboard myStoryboard;

        private Window getWindow()
        {
            return Window.GetWindow(this);
        }

        public SkillSelection()
        {
            InitializeComponent();
        }

        // Code to handle button clicks
        private void Beginner_Button_Click(object sender, RoutedEventArgs e)
        {
            GlobalVars.skillLevel = 1;
            var window = getWindow();
            window.Title = "DigiCook - Beginner";
            this.NavigationService.Navigate(new Uri("./FrontPage.xaml", UriKind.Relative));
            GlobalVars.searchText = GlobalVars.defaultSearchText;

        }
        private void Intermediate_Button_Click(object sender, RoutedEventArgs e)
        {
            GlobalVars.skillLevel = 2;
            var window = getWindow();
            window.Title = "DigiCook - Intermediate";
            this.NavigationService.Navigate(new Uri("./FrontPage.xaml", UriKind.Relative));
            GlobalVars.searchText = GlobalVars.defaultSearchText;
     
        }

        private void Expert_Button_Click(object sender, RoutedEventArgs e)
        {
            
            GlobalVars.skillLevel = 3;
            var window = getWindow();
            window.Title = "DigiCook - Expert";
            this.NavigationService.Navigate(new Uri("./FrontPage.xaml", UriKind.Relative));
            GlobalVars.searchText = GlobalVars.defaultSearchText;
        }

        private void Skip_Button_MouseEnter(object sender, MouseEventArgs e)
        {
        }

        private void SkipButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GlobalVars.skillLevel = 1; // Set to beginner if skip
            var window = getWindow();
            window.Title = "DigiCook - Beginner";
            GlobalVars.searchText = GlobalVars.defaultSearchText;
        }

        #region Event Handling
        private void Expert_MouseEnter(object sender, MouseEventArgs e)
        {
            // advancedImgGray.Visibility = Visibility.Visible;
            //advancedFlavour.Visibility = Visibility.Visible;
        }

        private void Expert_MouseLeave(object sender, MouseEventArgs e)
        {

            //advancedImgGray.Visibility = Visibility.Hidden;
            //advancedFlavour.Visibility = Visibility.Hidden;
        }

        private void Intermediate_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            //intermediateImgGray.Visibility = Visibility.Visible;
            //intermediateFlavour.Visibility = Visibility.Visible;
        }

        private void Intermediate_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            //intermediateImgGray.Visibility = Visibility.Hidden;
            //intermediateFlavour.Visibility = Visibility.Hidden;
        }

        private void Beginner_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            //beginnerImgGray.Visibility = Visibility.Visible;
           // beginnerFlavour.Visibility = Visibility.Visible;
        }

        private void Beginner_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            //beginnerImgGray.Visibility = Visibility.Hidden;
            //beginnerFlavour.Visibility = Visibility.Hidden;
        }

        private void SkipButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalVars.skillLevel = 1;
            var window = getWindow();
            window.Title = "DigiCook - Beginner";
            GlobalVars.searchText = GlobalVars.defaultSearchText;
            this.NavigationService.Navigate(new Uri("./FrontPage.xaml", UriKind.Relative));
        }

        private void ExpertMouseDown(object sender, MouseButtonEventArgs e)
        {
            
            advancedFlavour.Opacity = 0.9;
            advancedImgGray.Opacity = 0.9;
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
        }

        private void helpClick(object sender, RoutedEventArgs e)
        {
            helpWindow help = new helpWindow();
            help.ShowDialog();
        }
    }
    #endregion
}
