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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Ingredients : Page
    {
        public Ingredients()
        {
            InitializeComponent();
        }

        private void ingredientslistBox_SelectionChanged(object sender, EventArgs e)
        {
            Label[] ingredientWithAlts = new Label[] { label4, label6, label8 };

            addButton.IsEnabled = true;
            skillsBox.SelectedIndex = -1;

            if (ingredientWithAlts.Contains(ingredientsBox.SelectedItem))   //instead of label6, we can make it select from a list (of labels?)
            {
                altButton.IsEnabled = true;
            }
            else
            {
                altButton.IsEnabled = false;
            }
        }
  
        private void skillsBox_SelectionChanged(object sender, EventArgs e)
        {
            ingredientsBox.SelectedIndex = -1;
            addButton.IsEnabled = false;
            altButton.IsEnabled = false;
        }
        
        private void start_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("./Recipe.xaml", UriKind.Relative));
        }

        private void Grid_MouseDown(object sender, EventArgs e)
        {
            if (ingredientsBox.IsMouseOver)
            {
                ingredientslistBox_SelectionChanged(sender, e);
            }
            else if (skillsBox.IsMouseOver)
            {
                skillsBox_SelectionChanged(sender, e);
            }
            else
            {
                skillsBox.SelectedIndex = -1;
                ingredientsBox.SelectedIndex = -1;
                addButton.IsEnabled = false;
                altButton.IsEnabled = false;
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result = CustomMsgBox.Show("Added item to checklist", "DigiCook", "Accept", "Cancel");
            //bool result = CustomMsgBoxWPF.Show("Added item to checklist", "Accept", "Cancel");

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Label selection = (Label)ingredientsBox.SelectedItem;
                string selectionStr = selection.Content.ToString();
                GlobalVars.checklist.Add(selectionStr);
            }
        }

        private void altButton_Click(object sender, RoutedEventArgs e)
        {
            List<Label> ingredientWithAlts = new List<Label> { label4, label6, label8 };
            string[] alts = new string[] { "2 Small Banana Pepper", "1 Bottle Ketchup", "1 Teaspoons Oregano" };

            int idx = ingredientWithAlts.IndexOf((Label)ingredientsBox.SelectedItem);

            System.Windows.Forms.DialogResult result = CustomMsgBox.Show("Alternative Ingredient:\n• " + alts[idx], "DigiCook", "Add Alternative", "Close");
            //bool result = CustomMsgBoxWPF.Show("Alternative Ingredient:\n• " + alts[idx], "Add Alternative", "Close");

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                GlobalVars.checklist.Add("• " + alts[idx]);
            }
        }
        private TimeSpan TotalTime;
        private DispatcherTimer timerVideoTime;
        private void openVideo(object sender, MouseButtonEventArgs e)
        {
            var source = ((Image)sender).Tag;
            var original = Video.Source;
            Video.Source = new Uri(source.ToString(), UriKind.Relative);
            VideoPlayer.IsOpen = true;
            Video.Play();
            play_button.Visibility = Visibility.Hidden;
            play_button.IsEnabled = false;
            pause_button.Visibility = Visibility.Visible;
            pause_button.IsEnabled = true;
            fullscreenclose_button.Visibility = Visibility.Hidden;
            fullscreenclose_button.IsEnabled = false;
            fullscreen_button.Visibility = Visibility.Visible;
            fullscreen_button.IsEnabled = true;
            paused = false;
        }
        private void videoOpened(object sender, RoutedEventArgs e)
        {
            TotalTime = Video.NaturalDuration.TimeSpan;
            seekSlider.Maximum = TotalTime.TotalSeconds;
            // Create a timer that will update the counters and the time slider
            timerVideoTime = new DispatcherTimer();
            timerVideoTime.Interval = TimeSpan.FromMilliseconds(100);
            timerVideoTime.Tick += new EventHandler(timerTick);
            timerVideoTime.Start();
        }
        bool suppressValueChanged = false;
        bool paused = false;
        void timerTick(object sender, EventArgs e)
        {
            if (paused)
            {
                return;
            }
            // Check if the movie finished calculate it's total time
            if (Video.NaturalDuration.TimeSpan.TotalSeconds > 0)
            {
                if (TotalTime.TotalSeconds > 0)
                {
                    // Updating time slider
                    suppressValueChanged = true;
                    seekSlider.Value = Video.Position.TotalSeconds;
                }
            }
        }

        private void videoSeek(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (suppressValueChanged)
            {
                suppressValueChanged = false;
            }
            else
            {
                Video.Position = TimeSpan.FromSeconds(seekSlider.Value);
            }
        }

        private void videoPlayerClose(object sender, EventArgs e)
        {
            seekSlider.Value = 0;
            Video.Stop();
            timerVideoTime.Stop();
            Video.Height = 333;
            Video.Width = 591;
        }

        private void playButton(object sender, MouseButtonEventArgs e)
        {
            Video.Play();
            Video.MouseLeftButtonUp += pauseButton;
            Video.MouseLeftButtonUp -= playButton;
            play_button.Visibility = Visibility.Hidden;
            play_button.IsEnabled = false;
            pause_button.Visibility = Visibility.Visible;
            pause_button.IsEnabled = true;
        }

        private void pauseButton(object sender, MouseButtonEventArgs e)
        {
            paused = false;
            Video.Pause();
            Video.MouseLeftButtonUp += playButton;
            Video.MouseLeftButtonUp -= pauseButton;
            pause_button.Visibility = Visibility.Hidden;
            pause_button.IsEnabled = false;
            play_button.Visibility = Visibility.Visible;
            play_button.IsEnabled = true;
        }

        private void videoEnded(object sender, RoutedEventArgs e)
        {
            Video.Stop();
            pause_button.Visibility = Visibility.Hidden;
            pause_button.IsEnabled = false;
            play_button.Visibility = Visibility.Visible;
            play_button.IsEnabled = true;
        }

        private void exitButton(object sender, MouseButtonEventArgs e)
        {
            VideoPlayer.IsOpen = false;
        }

        private void volumeButton(object sender, MouseButtonEventArgs e)
        {
        }

        private void fullscreenButton(object sender, MouseButtonEventArgs e)
        {
            Video.Height = 900;
            Video.Width = 1600;
            fullscreen_button.Visibility = Visibility.Hidden;
            fullscreen_button.IsEnabled = false;
            fullscreenclose_button.Visibility = Visibility.Visible;
            fullscreenclose_button.IsEnabled = true;
        }

        private void fullscreenButtonClose(object sender, MouseButtonEventArgs e)
        {
            Video.Height = 333;
            Video.Width = 591;
            fullscreenclose_button.Visibility = Visibility.Hidden;
            fullscreenclose_button.IsEnabled = false;
            fullscreen_button.Visibility = Visibility.Visible;
            fullscreen_button.IsEnabled = true;
        }
    }
}
