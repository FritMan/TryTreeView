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
    /// Логика взаимодействия для EditTree.xaml
    /// </summary>
    public partial class EditTree : Page
    {
        private int _Id;
        public EditTree(int Id)
        {
            InitializeComponent();
            headComboBox.ItemsSource = Db.Employee.ToList();
            assistantComboBox.ItemsSource = Db.Employee.ToList();
            subdivisionComboBox.ItemsSource = Db.Subdivision.ToList();
            roleComboBox.ItemsSource = Db.Role.ToList();
            _Id = Id;

            if(_Id == -1)
            {
                grid1.DataContext = new Data.Employee() {BirthDate = DateTime.Now };
            }
            else
            {
                grid1.DataContext = Db.Employee.First(el => el.Id == _Id);
                grid1.IsEnabled = false;
            }
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if(_Id == -1)
            {
                Db.Employee.Add(grid1.DataContext as Employee);
            }
            Db.SaveChanges();
            NavigationService.Navigate(new TreeViewPage());
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            grid1.IsEnabled = true;
        }
    }
}
