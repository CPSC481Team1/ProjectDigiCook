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
    /// Interaction logic for Checklist.xaml
    /// </summary>
    public partial class Checklist : Page
    {

        public Checklist(Ingredients ing)
        {
            InitializeComponent();
            addToChecklist(GlobalVars.checklist);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            checklistBox.Items.RemoveAt
                (checklistBox.Items.IndexOf(checklistBox.SelectedItem));
        }

        private void checklistBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (checklistBox.SelectedIndex >= 0)
            {
                deleteButton.IsEnabled = true;
            }
            else
            {
                deleteButton.IsEnabled = false;
            }
        }

        public void addToChecklist(List<string> checklist)
        {
            foreach (string item in checklist)
            {
                checklistBox.Items.Add(item);
            }
        }
    }
}
