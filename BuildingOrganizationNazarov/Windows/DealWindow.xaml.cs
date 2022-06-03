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
    /// Логика взаимодействия для DealWindow.xaml
    /// </summary>
    public partial class DealWindow : Window
    {
        public DealWindow()
        {
            InitializeComponent();
            LV_Deal.ItemsSource = AppData.Context.Deal.ToList();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LV_Deal.ItemsSource = AppData.Context.Deal.Where(i => i.Team.NameTeam.Contains(txtSearch.Text)).ToList();
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            AddDealWindow adw = new AddDealWindow();
            adw.ShowDialog();
            this.Close();
        }


        private void btBack_Click_1(object sender, RoutedEventArgs e)
        {

            MenuWindow menuwindow = new MenuWindow();
            menuwindow.Show();
            this.Close();

        }
    }
}
