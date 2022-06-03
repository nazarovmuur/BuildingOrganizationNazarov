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
using System.Windows.Shapes;
using BuildingOrganizationNazarov.EF;
namespace BuildingOrganizationNazarov.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow()
        {
            InitializeComponent();
            LV_Employee.ItemsSource = AppData.Context.Employee.ToList();
            cmbSort.SelectedIndex = 0;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LV_Employee.ItemsSource = AppData.Context.Employee.Where(i => i.Fname.Contains(txtSearch.Text)
                  || i.Patronymic.Contains(txtSearch.Text) || i.Lname.Contains(txtSearch.Text) || i.Email.Contains(txtSearch.Text)).ToList();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSort.SelectedIndex == 0)
            {
                LV_Employee.ItemsSource = AppData.Context.Employee.ToList();
            }
            if (cmbSort.SelectedIndex == 1)
            {
                LV_Employee.ItemsSource = AppData.Context.Employee.OrderBy(i => i.Fname).ToList();
            }
            if (cmbSort.SelectedIndex == 2)
            {
                LV_Employee.ItemsSource = AppData.Context.Employee.OrderBy(i => i.Lname).ToList();
            }

            if (cmbSort.SelectedIndex == 3)
            {
                LV_Employee.ItemsSource = AppData.Context.Employee.Where(i => i.IDGender == 1).ToList();
            }
            if (cmbSort.SelectedIndex == 4)
            {
                LV_Employee.ItemsSource = AppData.Context.Employee.Where(i => i.IDGender == 2).ToList();
            }



        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow aw = new AddEmployeeWindow();
            aw.ShowDialog();
            this.Close();
        }

        private void LV_Employee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LV_Employee.SelectedItem is Employee)
            {
                var empl = LV_Employee.SelectedItem as Employee;
                AddEmployeeWindow aew = new AddEmployeeWindow(empl);
                aew.ShowDialog();
                this.Close();
            }
        }

        private void LV_Employee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                MessageBoxResult msbres = MessageBox.Show("Удалить сотрудника?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msbres == MessageBoxResult.No)
                {
                    return;
                }
                else
                {
                    if (LV_Employee.SelectedItem is Employee)
                    {
                        var empl = LV_Employee.SelectedItem as Employee;
                        AppData.Context.Employee.Remove(empl);
                        AppData.Context.SaveChanges();
                        MessageBox.Show("Пользователь успешно удалён", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
                        LV_Employee.ItemsSource = AppData.Context.Employee.ToList();
                    }
                }
            }
        }

        private void btnBrigada_Click(object sender, RoutedEventArgs e)
        {
            if (LV_Employee.SelectedItem is Employee)
            {
                var empl = LV_Employee.SelectedItem as Employee;
                AddTeamEmployeeWindow aew = new AddTeamEmployeeWindow(empl);
                aew.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите сотрудника");
                return;
            }
        }

        private void btnBrigadaList_Click(object sender, RoutedEventArgs e)
        {
            TeamWindow tw = new TeamWindow();
            tw.ShowDialog();
        }



        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuwindow = new MenuWindow();
            menuwindow.Show();
            this.Close();
        }
    }
}
