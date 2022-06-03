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
using BuildingOrganizationNazarov.EF;
using BuildingOrganizationNazarov.Windows;

namespace BuildingOrganizationNazarov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(authFieldLog.Text))
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (string.IsNullOrWhiteSpace(authFieldPsw.Password))
            {
                MessageBox.Show("Введите пароль");
                return;
            }

            var authEmpl = AppData.Context.Employee.ToList().Where(i => i.Login == authFieldLog.Text && i.Password == authFieldPsw.Password && i.IDRole == 1).FirstOrDefault();
            if (authEmpl != null)
            {
                MenuWindow mw = new MenuWindow();
                mw.Show();
                this.Close();
            }
            else
            {

                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

        }
    }
}
