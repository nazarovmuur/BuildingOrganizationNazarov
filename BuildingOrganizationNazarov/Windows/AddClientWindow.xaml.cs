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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        private List<Gender> genders = new List<Gender>();
        public AddClientWindow()
        {
            InitializeComponent();
            genders = AppData.Context.Gender.ToList();
            genders.Insert(0, new Gender { GenderName = "Выберите пол" });
            cmbGender.ItemsSource = genders;
            cmbGender.DisplayMemberPath = "GenderName";
            cmbGender.SelectedIndex = 0;

        }

        private void txtLname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Handled != "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ".IndexOf(e.Text) < 0)
            {
                e.Handled = true;
            }
        }

        private void txtFname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Handled != "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ".IndexOf(e.Text) < 0)
            {
                e.Handled = true;
            }
        }

        private void txtMname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Handled != "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ".IndexOf(e.Text) < 0)
            {
                e.Handled = true;
            }
        }

        private void txtEmail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(e.Handled != "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ".IndexOf(e.Text) < 0))
            {
                e.Handled = true;
            }
        }

        private void txtEmail_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!int.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void dpBirthday_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!int.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void txtPassport_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!int.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLname.Text))
            {
                MessageBox.Show("Введите фамилию");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFname.Text))
            {
                MessageBox.Show("Введите имя");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMname.Text))
            {
                MessageBox.Show("Введите отчество");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Введите email");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Введите телефон");
                return;
            }

            if (dpBirthday.SelectedDate is null)
            {
                MessageBox.Show("Выберите дату");
                return;
            }

            if (cmbGender.SelectedIndex == 0)
            {
                MessageBox.Show("Выберите пол");
                return;
            }


            AppData.Context.Client.Add(new Client
            {
                Fname = txtFname.Text,
                Lname = txtLname.Text,
                Patronymic = txtMname.Text,
                IDGender = cmbGender.SelectedIndex,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Birthday = dpBirthday.SelectedDate.Value
            });
            AppData.Context.SaveChanges();
            MessageBox.Show("Клиент добавлен");
            ClientWindow cw = new ClientWindow();
            cw.Show();
            this.Close();
        }

        private void txtPhone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow clientWindow = new ClientWindow();
            clientWindow.Show();
            this.Close();
        }
    }
}
