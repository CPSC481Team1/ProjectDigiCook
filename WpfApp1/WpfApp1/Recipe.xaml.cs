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
            expander6.Expanded += new RoutedEventHandler(expander);
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
        private void openVideo(object sender, MouseButtonEventArgs e)
        {
            var source = ((Image)sender).Tag;
            var original = Video.Source;
            Video.Source = new Uri(source.ToString(), UriKind.Relative);
            VideoPlayer.IsOpen = true;
        }

        private void playButton(object sender, MouseButtonEventArgs e)
        {
            var currentState = GetMediaState(Video);
            if(currentState == MediaState.Pause)
            {
                Video.Play();
            }
            else if(currentState == MediaState.Play)
            {
                Video.Pause();
            }
            else
            {
                
            }
            
        }

        private MediaState GetMediaState(MediaElement myMedia)
        {
            FieldInfo hlp = typeof(MediaElement).GetField("_helper", BindingFlags.NonPublic | BindingFlags.Instance);
            object helperObject = hlp.GetValue(myMedia);
            FieldInfo stateField = helperObject.GetType().GetField("_currentState", BindingFlags.NonPublic | BindingFlags.Instance);
            MediaState state = (MediaState)stateField.GetValue(helperObject);
            return state;
        }

        private void volumeButton(object sender, MouseButtonEventArgs e)
        {
        }

        private void fullscreenButton(object sender, MouseButtonEventArgs e)
        {
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void volume_button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
