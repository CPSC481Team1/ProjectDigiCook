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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class SkillSelection : Page
    {
        private Storyboard myStoryboard;

        public SkillSelection()
        {
            InitializeComponent();
            //advancedImage = new Uri(".\\Images\\Skill_Level\\Advanced.jpg", UriKind.Relative);
            this.Title = "DigiCook";


        }

        // Code to handle button clicks
        private void Beginner_Button_Click(object sender, RoutedEventArgs e)
        {
            SkillLevel.skillLevel = 1;
            this.NavigationService.Navigate(new Uri("./FrontPage.xaml", UriKind.Relative));
        }
        private void Intermediate_Button_Click(object sender, RoutedEventArgs e)
        {
            SkillLevel.skillLevel = 2;
            this.NavigationService.Navigate(new Uri("./FrontPage.xaml", UriKind.Relative));

        }

        private void Expert_Button_Click(object sender, RoutedEventArgs e)
        {
            SkillLevel.skillLevel = 3;
            this.NavigationService.Navigate(new Uri("./FrontPage.xaml", UriKind.Relative));

        }

        private void Skip_Button_MouseEnter(object sender, MouseEventArgs e)
        {
        }

        private void SkipButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SkillLevel.skillLevel = 1; // Set to beginner if skip
        }

        #region Event Handling
        private void Expert_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation();

            animation.From = 1.0;
            animation.To = 0.0;

            animation.Duration = new Duration(TimeSpan.FromSeconds(4));

            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(animation);
            Storyboard.SetTargetName(animation, Expert_Button.Name);
            //Storyboard.SetTargetProperty(animation, new PropertyPath(Expert_Button.Opacity));

            advancedImgGray.Visibility = Visibility.Visible;
            advancedFlavour.Visibility = Visibility.Visible;
        }

        private void Expert_MouseLeave(object sender, MouseEventArgs e)
        {

            advancedImgGray.Visibility = Visibility.Hidden;
            advancedFlavour.Visibility = Visibility.Hidden;
        }

        private void Intermediate_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            intermediateImgGray.Visibility = Visibility.Visible;
            intermediateFlavour.Visibility = Visibility.Visible;
        }

        private void Intermediate_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            intermediateImgGray.Visibility = Visibility.Hidden;
            intermediateFlavour.Visibility = Visibility.Hidden;
        }

        private void Beginner_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            beginnerImgGray.Visibility = Visibility.Visible;
            beginnerFlavour.Visibility = Visibility.Visible;
        }

        private void Beginner_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            beginnerImgGray.Visibility = Visibility.Hidden;
            beginnerFlavour.Visibility = Visibility.Hidden;
        }

        private void SkipButton_Click(object sender, RoutedEventArgs e)
        {
            SkillLevel.skillLevel = 1;
            this.NavigationService.Navigate(new Uri("./FrontPage.xaml", UriKind.Relative));
        }
    }
    #endregion
}
