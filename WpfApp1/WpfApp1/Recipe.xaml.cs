using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public partial class Recipe : Page
    {
        public Recipe()
        {
            InitializeComponent();
            expander1.Expanded += new RoutedEventHandler(expander);
            expander2.Expanded += new RoutedEventHandler(expander);
            expander3.Expanded += new RoutedEventHandler(expander);
            expander4.Expanded += new RoutedEventHandler(expander);
            expander5.Expanded += new RoutedEventHandler(expander);
        }

        private void expander(object sender, RoutedEventArgs e)
        {
            Expander caller = sender as Expander;
            foreach (UIElement element in expanderContainer.Children)
            {
                Expander expander = element as Expander;
                if (expander != null && expander != caller)
                {
                    expander.IsExpanded = false;
                }
            }
        }
        private TimeSpan TotalTime;
        private DispatcherTimer timerVideoTime;
        private DispatcherTimer eventTimer;

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
        bool supressSliderDrag = false;
        bool surpressTicker = false;
        bool surpressDragTicker = false;
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
                    if (!surpressTicker && !surpressDragTicker)
                    {
                        suppressValueChanged = true;
                        supressSliderDrag = false;
                        seekSlider.Value = Video.Position.TotalSeconds;
                    }
                }
            }
        }

        private void videoSeek(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!supressSliderDrag)
            {
                if (suppressValueChanged)
                {
                    suppressValueChanged = false;
                }
                else
                {
                    surpressTicker = true;
                    supressSliderDrag = true;
                    eventTimer = new DispatcherTimer();
                    eventTimer.Interval = TimeSpan.FromMilliseconds(200);
                    eventTimer.Tick += new EventHandler(stopSurpress);
                    eventTimer.Start();
                    Video.Position = TimeSpan.FromSeconds(seekSlider.Value);
                }
            }
        }
        private void dragSurpressTicker(object sender, MouseButtonEventArgs e)
        {
            supressSliderDrag = true;
            surpressDragTicker = true;
        }
        private void dragUnsurpressTicker(object sender, MouseButtonEventArgs e)
        {
            Video.Position = TimeSpan.FromSeconds(seekSlider.Value);
            supressSliderDrag = false;
            surpressDragTicker = false;
        }
        void stopSurpress(object sender, EventArgs e)
        {
            eventTimer.Stop();
            surpressTicker = false;
        }
        private void videoPlayerClose(object sender, EventArgs e)
        {
            timerVideoTime.Stop();
            seekSlider.Value = 0;
            Video.Stop();
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

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result = CustomMsgBox.Show("Add selected items to checklist?", "DigiCook", "Accept", "Cancel");

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                CheckBox[] withAlts = { checkbox4, checkbox6, checkbox8 };
                string[] withAltsContents = { checkboxLabel4.Content.ToString(), checkboxLabel6.Content.ToString(), checkboxLabel8.Content.ToString() };

                foreach (CheckBox current in Ingredients_Box.Items)
                {
                    if (current.IsChecked.GetValueOrDefault() == true)
                    {
                        if (!withAlts.Contains(current))
                        {
                            string selectionStr = "• " + current.Content.ToString();
                            GlobalVars.checklist.Add(selectionStr);
                            addToChecklist(GlobalVars.checklist);
                        }
                        else
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (current == withAlts[j])
                                {
                                    string selectionStr = "• " + withAltsContents[j];
                                    GlobalVars.checklist.Add(selectionStr);
                                    addToChecklist(GlobalVars.checklist);
                                }
                            }
                        }
                        current.IsChecked = false;
                    }
                }
            }

            addButton.IsEnabled = false;
        }

        private void altButton_Click(object sender, RoutedEventArgs e)
        {
            string[] orig = new string[] { "1 Small Green Bell Pepper, Diced", "1 lb Tomato Sauce", "2 Teaspoons Dried Basil" };
            string[] alts = new string[] { "2 Small Banana Pepper", "1 Bottle Ketchup", "1 Teaspoon Oregano" };
            Button[] altsButtons = { checkboxAlt4, checkboxAlt6, checkboxAlt8 };
            Label[] altLabels = { checkboxLabel4, checkboxLabel6, checkboxLabel8 };

            for (int i = 0; i < 3; i++)
            {
                if ((sender == altsButtons[i]) && (altLabels[i].Content.Equals(orig[i])))
                {
                    altLabels[i].Content = alts[i];
                }
                else if ((sender == altsButtons[i]) && (altLabels[i].Content.Equals(alts[i])))
                {
                    altLabels[i].Content = orig[i];
                }
            }
        }
        public void addToChecklist(List<string> checklist)
        {
            for (int i = 0; i < checklist.Count; i++)
            {
                List<float> dupInstances = new List<float>();

                string[] splits_i = checklist[i].Split(new[] { ' ' }, 3);
                string ingredient_i = splits_i[2];

                dupInstances.Add(float.Parse(splits_i[1]));

                for (int j = i + 1; j < checklist.Count; j++)
                {
                    string[] splits_j = checklist[j].Split(new[] { ' ' }, 3);
                    string ingredient_j = splits_j[2];

                    if (ingredient_i.Equals(ingredient_j))
                    {
                        dupInstances.Add(float.Parse(splits_j[1]));
                        checklist.RemoveAt(j);
                        j--;
                    }
                }

                if (dupInstances.Count > 1)
                {
                    string newStr = "• " + (dupInstances.Sum()) + " " + splits_i[2];
                    checklist[i] = newStr;
                }
                checklistButton.updateNumber(checklist.Count.ToString()); // Update cart number

            }
        }

        private void FinishClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("./FrontPage.xaml", UriKind.Relative));
        }

        private void checkbox_Click(object sender, EventArgs e)
        {
            bool somethingSelected = false;

            foreach (CheckBox item in Ingredients_Box.Items)
            {
                if (item.IsChecked.GetValueOrDefault() == true)
                {
                    somethingSelected = true;
                }
            }

            if (somethingSelected)
            {
                addButton.IsEnabled = true;
            }
            else
            {
                addButton.IsEnabled = false;
            }
        }

        private void addAllButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result = CustomMsgBox.Show("Add all items to checklist?", "DigiCook", "Accept", "Cancel");
            //bool result = CustomMsgBoxWPF.Show("Added item to checklist", "Accept", "Cancel");

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string[] contents = { checkbox1.Content.ToString(), checkbox2.Content.ToString(), checkbox3.Content.ToString(), checkboxLabel4.Content.ToString(),
                    checkbox5.Content.ToString(), checkboxLabel6.Content.ToString(), checkbox7.Content.ToString(), checkboxLabel8.Content.ToString(),
                    checkbox9.Content.ToString(), checkbox10.Content.ToString() };

                for (int i = 0; i < Ingredients_Box.Items.Count; i++)
                {
                    string selectionStr = "• " + contents[i];
                    GlobalVars.checklist.Add(selectionStr);
                    addToChecklist(GlobalVars.checklist);
                }
            }
        }


    }
}
