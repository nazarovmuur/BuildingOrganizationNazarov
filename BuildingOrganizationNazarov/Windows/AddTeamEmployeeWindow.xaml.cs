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
    /// Логика взаимодействия для AddTeamEmployeeWindow.xaml
    /// </summary>
    public partial class AddTeamEmployeeWindow : Window
    {
        private List<Team> teams = new List<Team>();
        Employee emply = new Employee();
        public AddTeamEmployeeWindow(Employee empl)
        {
            InitializeComponent();
            teams = AppData.Context.Team.ToList();
            teams.Insert(0, new Team { NameTeam = "Выберите бригаду" });
            cmbBrigada.ItemsSource = teams;
            cmbBrigada.DisplayMemberPath = "NameTeam";
            cmbBrigada.SelectedIndex = 0;
            emply = empl;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBrigada.SelectedIndex == 0)
            {
                MessageBox.Show("Выберите бригаду");
                return;
            }

            AppData.Context.TeamEmployee.Add(new TeamEmployee
            {
                IDTeam = cmbBrigada.SelectedIndex,
                IDEmployee = emply.ID
            });

            AppData.Context.SaveChanges();
            MessageBox.Show("Работник добавлен в бригаду");
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

