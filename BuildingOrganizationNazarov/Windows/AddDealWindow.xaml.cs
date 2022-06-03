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
using BuildingOrganizationNazarov;
using BuildingOrganizationNazarov.EF;
namespace BuildingOrganizationNazarov.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddDealWindow.xaml
    /// </summary>
    public partial class AddDealWindow : Window
    {
        private List<Team> teams = new List<Team>();
        private List<City> cities = new List<City>();

        public AddDealWindow()
        {
            InitializeComponent();
            LV_Client.ItemsSource = AppData.Context.Client.ToList();

            teams = AppData.Context.Team.ToList();
            teams.Insert(0, new Team { NameTeam = "Выберите бригаду" });
            cmbBrigada.ItemsSource = teams;
            cmbBrigada.DisplayMemberPath = "NameTeam";
            cmbBrigada.SelectedIndex = 0;

            cities = AppData.Context.City.ToList();
            cities.Insert(0, new City { CityName = "Выберите город" });
            cmbCity.ItemsSource = cities;
            cmbCity.DisplayMemberPath = "CityName";
            cmbCity.SelectedIndex = 0;

        }

        private void txtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!int.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void txtPrice_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void btnAddNewSale_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBrigada.SelectedIndex == 0)
            {
                MessageBox.Show("Выберите бригаду");
                return;
            }
            if (cmbCity.SelectedIndex == 0)
            {
                MessageBox.Show("Выберите город");
                return;
            }
            if (SaleDate.SelectedDate is null)
            {
                MessageBox.Show("Выберите дату сделки");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Введите цену");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtObject.Text))
            {
                MessageBox.Show("Введите название объекта");
                return;

            }
            if (string.IsNullOrWhiteSpace(txtStreet.Text))
            {
                MessageBox.Show("Введите название улицы");
                return;
            }


            int idClient;
            if (LV_Client.SelectedItem is null)
            {
                MessageBox.Show("Выберите клиента");
                return;
            }
            else
            {
                var thisClient = LV_Client.SelectedItem as EF.Client;
                idClient = thisClient.ID;
            }

            int idDeal;

            if (ReturnDate.SelectedDate is null)
            {
                var thisDeal = AppData.Context.Deal.Add(new Deal
                {
                    IDTeam = cmbBrigada.SelectedIndex,
                    DateSale = SaleDate.SelectedDate.Value,
                    DateEnd = null,
                    Cost = Convert.ToDecimal(txtPrice.Text),
                    IDClient = idClient
                });
                idDeal = thisDeal.ID;

                AppData.Context.Object.Add(new EF.Object
                {
                    NameObject = txtObject.Text,
                    Street = txtStreet.Text,
                    IDDeal = idDeal,
                    DateStart = SaleDate.SelectedDate.Value,
                    DateEnd = null,
                    IDCity = cmbCity.SelectedIndex
                });
            }
            else
            {
                var thisDeal = AppData.Context.Deal.Add(new Deal
                {
                    IDTeam = cmbBrigada.SelectedIndex,
                    DateSale = SaleDate.SelectedDate.Value,
                    DateEnd = ReturnDate.SelectedDate.Value,
                    Cost = Convert.ToDecimal(txtPrice.Text),
                    IDClient = idClient
                });
                idDeal = thisDeal.ID;

                AppData.Context.Object.Add(new EF.Object
                {
                    NameObject = txtObject.Text,
                    Street = txtStreet.Text,
                    IDDeal = idDeal,
                    DateStart = SaleDate.SelectedDate.Value,
                    DateEnd = ReturnDate.SelectedDate.Value,
                    IDCity = cmbCity.SelectedIndex
                });
            }




            AppData.Context.SaveChanges();
            MessageBox.Show("Сделка и объект добавлены");
            DealWindow dw = new DealWindow();
            dw.Show();
            this.Close();
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            DealWindow dealWindow = new DealWindow();
            dealWindow.Show();
            this.Close();
        }


    }
}
