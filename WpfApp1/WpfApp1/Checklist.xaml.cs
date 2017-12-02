using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml;
using System.Windows.Xps.Packaging;

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

            disableClearandPrintWhenEmpty();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalVars.checklist.RemoveAt(checklistBox.Items.IndexOf(checklistBox.SelectedItem));
            checklistBox.Items.RemoveAt(checklistBox.Items.IndexOf(checklistBox.SelectedItem));

            disableClearandPrintWhenEmpty();
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

        public void disableClearandPrintWhenEmpty()
        {
            if (checklistBox.Items.IsEmpty)
            {
                clearButton.IsEnabled = false;
                printButton.IsEnabled = false;
                showEmptyMessage();
            }
            else
            {
                clearButton.IsEnabled = true;
                printButton.IsEnabled = true;
            }
        }

        public void showEmptyMessage()
        {
            EmptyMessage.Visibility = Visibility.Visible;
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            checklistBox.Items.Clear();
            clearButton.IsEnabled = false;
            printButton.IsEnabled = false;
            GlobalVars.checklist.Clear();
            showEmptyMessage();
        }

        private void invokePrint(object sender, RoutedEventArgs e)
        {
            // Create the print dialog object and set options
            PrintDialog pDialog = new PrintDialog();
            pDialog.PageRangeSelection = PageRangeSelection.AllPages;
            pDialog.UserPageRangeEnabled = true;

            // Display the dialog. This returns true if the user presses the Print button.
            Nullable<Boolean> print = pDialog.ShowDialog();
            if (print == true)
            {
                var printMessage = MessageBox.Show("Checklist sent to printer");
            }
        }
    }
}
