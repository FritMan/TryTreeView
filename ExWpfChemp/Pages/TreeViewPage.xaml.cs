using ExWpfChemp.Data;
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
using static ExWpfChemp.Classes.Help;

namespace ExWpfChemp.Pages
{
    /// <summary>
    /// Логика взаимодействия для TreeViewPage.xaml
    /// </summary>
    public partial class TreeViewPage : Page
    {
        public TreeViewPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            employeeDataGrid.ItemsSource = Db.Employee.ToList();
        }

        private void AddEditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selected_sub = MainTreeView.SelectedItem as Subdivision;
            if (selected_sub != null) 
            {
                employeeDataGrid.ItemsSource = Db.Employee.Where(el => el.SubdivisionId == selected_sub.Id).ToList();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MainTreeView.ItemsSource = Db.Subdivision.Where(el => el.HeadId == null).ToList();
        }
    }
}
