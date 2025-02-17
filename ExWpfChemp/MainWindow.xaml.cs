using ExWpfChemp.Data;
using ExWpfChemp.Pages;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace ExWpfChemp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            InitializeComponent();
            Db.Employee.Load();
            Db.Subdivision.Load();
            Db.Role.Load();
        }
        public void LoadData()
        {
            employeeDataGrid.ItemsSource = Db.Employee.ToList();
        }

        private void AddEditBtn_Click(object sender, RoutedEventArgs e)
        {
            var selected_emp = employeeDataGrid.SelectedItem as Employee;
            var selected_sub = MainTreeView.SelectedItem as Subdivision;


            if (selected_emp != null)
            {
                var tree_window = new EditTreeWindow(selected_emp.Id, selected_sub);
                tree_window.Owner = this;
                tree_window.ShowDialog();
            }
            else  if(selected_emp == null && selected_sub != null)
            {
                var tree_window = new EditTreeWindow(-1, selected_sub);
                tree_window.Owner = this;
                tree_window.ShowDialog();
            }
            LoadData();
        }

        private void MainTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selected_sub = MainTreeView.SelectedItem as Subdivision;
            if (selected_sub != null)
            {
                employeeDataGrid.ItemsSource = Db.Employee.Where(el => el.SubdivisionId == selected_sub.Id).ToList();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainTreeView.ItemsSource = Db.Subdivision.Where(el => el.HeadId == null).ToList();
        }
    }
}
