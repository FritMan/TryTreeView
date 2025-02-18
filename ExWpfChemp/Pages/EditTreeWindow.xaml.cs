using ExWpfChemp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для EditTreeWindow.xaml
    /// </summary>
    public partial class EditTreeWindow : Window
    {
        private Subdivision _sub;
        private int _Id;
        public EditTreeWindow(int id, Subdivision subdivision)
        {
            InitializeComponent();
            roleComboBox.ItemsSource = Db.Role.ToList();
            subdivisionComboBox.ItemsSource = Db.Subdivision.ToList();
            _Id = id;
            _sub = subdivision;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if((assistantComboBox.SelectedItem as Employee).Id != (headComboBox.SelectedItem as Employee).Id)
            {
                if (_Id == -1)
                {
                    Db.Employee.Add(grid1.DataContext as Employee);
                }
                Db.SaveChanges();
                this.Close();
            }
            else
            {
                    MessageBox.Show("Подчинённый и руководитель не могут быть одним сотрудником сразу!", "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {   
            grid1.IsEnabled = true;
        }

        private void subdivisionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(subdivisionComboBox.SelectedItem != null)
            {
                var selected = subdivisionComboBox.SelectedItem as Subdivision;
                loadEmployees(selected.Id);

            }
        }

        private void loadEmployees(int subId)
        {
            assistantComboBox.ItemsSource = Db.Employee.Where(el => el.SubdivisionId == subId).ToList();
            headComboBox.ItemsSource = Db.Employee.Where(el => el.SubdivisionId == subId).ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_Id == -1 && _sub != null)
            {
                grid1.DataContext = new Data.Employee() { BirthDate = DateTime.Now, Subdivision = _sub };
                loadEmployees(_sub.Id);
            }
            else
            {
                grid1.DataContext = Db.Employee.First(el => el.Id == _Id);
                loadEmployees((grid1.DataContext as Employee).SubdivisionId);
                grid1.IsEnabled = false;
            }
        }
    }
}
