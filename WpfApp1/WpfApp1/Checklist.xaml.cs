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

        public Checklist()
        {
            InitializeComponent();
            addToChecklist(GlobalVars.checklist);

            disableClearWhenEmpty();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalVars.checklist.RemoveAt(checklistBox.Items.IndexOf(checklistBox.SelectedItem));
            checklistBox.Items.RemoveAt(checklistBox.Items.IndexOf(checklistBox.SelectedItem));

            disableClearWhenEmpty();
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
            for (int i = 0; i < checklist.Count; i++)
            {
                int instances = 1;

                for (int j = i + 1; j < checklist.Count; j++)
                {
                    if (checklist[i] == checklist[j])
                    {
                        instances++;
                        checklist.RemoveAt(j);
                        j--;
                    }
                }

                if (instances > 1)
                {
                    string newStr = "• " + instances + " x " + checklist[i].Substring(2);
                    checklist[i] = newStr;
                }
            }

            foreach (string item in checklist)
            {
                ListBoxItem addition = new ListBoxItem();
                addition.Content = item;
                addition.HorizontalContentAlignment = HorizontalAlignment.Center;
                addition.FontSize = 30;
                checklistBox.Items.Add(addition);
            }
        }

        public void disableClearWhenEmpty()
        {
            if (checklistBox.Items.IsEmpty)
            {
                clearButton.IsEnabled = false;
            }
            else
            {
                clearButton.IsEnabled = true;
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            checklistBox.Items.Clear();
            clearButton.IsEnabled = false;
            GlobalVars.checklist.Clear();
        }
    }
}
