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
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            InitializeComponent();
            LV_Client.ItemsSource = AppData.Context.Client.ToList();
            cmbSort.SelectedIndex = 0;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LV_Client.ItemsSource = AppData.Context.Client.Where(i => i.Fname.Contains(txtSearch.Text)
                 || i.Patronymic.Contains(txtSearch.Text) || i.Lname.Contains(txtSearch.Text) || i.Email.Contains(txtSearch.Text)).ToList();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSort.SelectedIndex == 0)
            {
                LV_Client.ItemsSource = AppData.Context.Client.ToList();
            }
            if (cmbSort.SelectedIndex == 1)
            {
                LV_Client.ItemsSource = AppData.Context.Client.OrderBy(i => i.Fname).ToList();
            }
            if (cmbSort.SelectedIndex == 2)
            {
                LV_Client.ItemsSource = AppData.Context.Client.OrderBy(i => i.Lname).ToList();
            }

            if (cmbSort.SelectedIndex == 3)
            {
                LV_Client.ItemsSource = AppData.Context.Client.Where(i => i.IDGender == 1).ToList();
            }
            if (cmbSort.SelectedIndex == 4)
            {
                LV_Client.ItemsSource = AppData.Context.Client.Where(i => i.IDGender == 2).ToList();
            }
        }

        private void LV_Client_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                MessageBoxResult msbres = MessageBox.Show("Удалить клиента?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msbres == MessageBoxResult.No)
                {
                    return;
                }
                else
                {
                    if (LV_Client.SelectedItem is Client)
                    {
                        var client = LV_Client.SelectedItem as Client;
                        AppData.Context.Client.Remove(client);
                        AppData.Context.SaveChanges();
                        MessageBox.Show("Пользователь успешно удалён", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
                        LV_Client.ItemsSource = AppData.Context.Client.ToList();
                    }
                }
            }
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow ac = new AddClientWindow();
            ac.ShowDialog();
            this.Close();
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {

            MenuWindow menuwindow = new MenuWindow();
            menuwindow.Show();
            this.Close();

        }
    }
}
