using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1
{
    public static class GlobalVars
    {
        // 1 - Beginner
        // 2 - Intermediate
        // 3 - Expert

        public static int skillLevel { get; set; }

        public static string searchText { get; set; } = "Find a recipe";

        public static string defaultSearchText { get;} = "Find a recipe";


        public static string[] ingredients { get; set; }

        public static List<string> checklist { get; set; } = new List<string>();

    }
}
