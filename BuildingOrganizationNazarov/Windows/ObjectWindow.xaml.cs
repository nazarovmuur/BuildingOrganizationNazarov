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
using BuildingOrganizationNazarov.Windows;


namespace BuildingOrganizationNazarov.Windows
{
    /// <summary>
    /// Логика взаимодействия для ObjectWindow.xaml
    /// </summary>
    public partial class ObjectWindow : Window
    {
        public ObjectWindow()
        {
            InitializeComponent();
            LV_Object.ItemsSource = AppData.Context.Object.ToList();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LV_Object.ItemsSource = AppData.Context.Object.Where(i => i.NameObject.Contains(txtSearch.Text)
                 || i.Street.Contains(txtSearch.Text) || i.City.CityName.Contains(txtSearch.Text)).ToList();
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {

            MenuWindow menuwindow = new MenuWindow();
            menuwindow.Show();
            this.Close();

        }

       
        
    }

}
