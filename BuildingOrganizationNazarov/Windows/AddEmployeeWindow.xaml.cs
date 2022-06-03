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
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        private List<Role> roles = new List<Role>();
        private List<Gender> genders = new List<Gender>();
        Employee newEmpl = new Employee();
        public bool isEdit;
        public AddEmployeeWindow()
        {
            InitializeComponent();
            isEdit = false;
            //тут происходит писваиванию combobox'y значений ролей из бд - названий, а как 0 индекс combobox'a идёт заглушка через Insert
            roles = AppData.Context.Role.ToList();
            roles.Insert(0, new Role { NameRole = "Выберите роль" });
            //тут удаляем роль менеджера из списка ролей
            roles.Remove(roles.ElementAt(1));
            cmbRole.ItemsSource = roles;
            cmbRole.DisplayMemberPath = "NameRole";
            cmbRole.SelectedIndex = 0;

            genders = AppData.Context.Gender.ToList();
            genders.Insert(0, new Gender { GenderName = "Выберите пол" });
            cmbGender.ItemsSource = genders;
            cmbGender.DisplayMemberPath = "GenderName";
            cmbGender.SelectedIndex = 0;


        }
        public AddEmployeeWindow(Employee empl)
        {
            InitializeComponent();
            isEdit = true;
            btnAddNew.Content = "Изменить";
            roles = AppData.Context.Role.ToList();
            newEmpl = empl;
            //тут удаляем роль менеджера из списка ролей
            roles.Remove(roles.ElementAt(0));
            cmbRole.ItemsSource = roles;
            cmbRole.DisplayMemberPath = "NameRole";
            cmbRole.SelectedIndex = newEmpl.IDRole;

            genders = AppData.Context.Gender.ToList();

            cmbGender.ItemsSource = genders;
            cmbGender.DisplayMemberPath = "GenderName";
            cmbGender.SelectedIndex = newEmpl.IDGender - 1;

            txtFname.Text = newEmpl.Fname;
            txtLname.Text = newEmpl.Lname;
            txtMname.Text = newEmpl.Patronymic;
            txtPhone.Text = newEmpl.Phone;
            txtEmail.Text = newEmpl.Phone;
            DpBirthday.SelectedDate = newEmpl.Birthday;
            tbTitle.Text = "Изменение сотрудника";
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

        private void txtPhone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }



        private void btnAddNew_Click_1(object sender, RoutedEventArgs e)
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
                txtMname.Text = null;
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




            if (isEdit == true)
            {
                newEmpl.Fname = txtFname.Text;
                newEmpl.Lname = txtLname.Text;
                newEmpl.Patronymic = txtMname.Text;
                newEmpl.Phone = txtPhone.Text;
                newEmpl.Email = txtEmail.Text;
                newEmpl.IDGender = cmbGender.SelectedIndex + 1;
                newEmpl.IDRole = cmbRole.SelectedIndex + 2;

                MessageBox.Show("Пользователь изменен");
            }



            else
            {
                if (cmbRole.SelectedIndex == 0)
                {
                    MessageBox.Show("Выберите роль");
                    return;
                }
                if (cmbGender.SelectedIndex == 0)
                {
                    MessageBox.Show("Выберите пол");
                    return;
                }

                AppData.Context.Employee.Add(new Employee
                {
                    Fname = txtFname.Text,
                    Lname = txtLname.Text,
                    Patronymic = txtMname.Text,
                    IDGender = cmbGender.SelectedIndex,
                    Email = txtEmail.Text,

                    Phone = txtPhone.Text,
                    IDRole = cmbRole.SelectedIndex,
                    Birthday = DpBirthday.SelectedDate.Value
                });
                MessageBox.Show("Пользователь добавлен");
            }
            AppData.Context.SaveChanges();

            EmployeeWindow ew = new EmployeeWindow();
            ew.Show();
            this.Close();

        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.Show();
            this.Close();
        }
    }
}
