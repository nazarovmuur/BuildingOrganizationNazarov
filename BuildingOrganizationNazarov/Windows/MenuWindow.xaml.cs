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
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow ew = new EmployeeWindow();

            ew.ShowDialog();
            this.Close();
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow cw = new ClientWindow();

            cw.ShowDialog();
            this.Close();
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            ObjectWindow ow = new ObjectWindow();

            ow.ShowDialog();
            this.Close();
        }

        private void btnSale_Click(object sender, RoutedEventArgs e)
        {
            DealWindow dw = new DealWindow();

            dw.ShowDialog();
            this.Close();
        }
    }
}
