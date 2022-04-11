using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FPProjectStudentSuccess.Entities;

namespace FPProjectStudentSuccess
{
    /// <summary>
    /// Interaction logic for EmployeeEditView.xaml
    /// </summary>
    public partial class EmployeeEditView : Window
    {
        List<Users> userList = new List<Users>();
        List<Users> userFilteredList = new List<Users>();
        bool isClosed = false;
        public EmployeeEditView()
        {
            InitializeComponent();
            InitializeDataGrid();
            UpdateDataGrid();
            InitializeComboBox();

            btnMenu.Click += OpenAndCloseMenu;
            productsMenu.Click += OpenProductPage;
            employeeMenu.Click += OpenEditEmployeePage;
            salesmenMenu.Click += OpenSalesmenPage;
            stockMenu.Click += OpenStockPage;
            logout.Click += Logout;
            btnUpdateUser.Click += EditSelectedUser;
            btnClean.Click += CleanEdit;
            DataGridEditUser.SelectionChanged += UpdateUserInfo;

            //Menu Item visibility
            productsMenu.Visibility = Visibility.Hidden;
            salesmenMenu.Visibility = Visibility.Hidden;
            stockMenu.Visibility = Visibility.Hidden;
            employeeMenu.Visibility = Visibility.Hidden;
            logout.Visibility = Visibility.Hidden;
        }

        private void InitializeDataGrid()
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                userList = ctx.Users.ToList<Users>();
                DataGridEditUser.ItemsSource = userList;
            }
        }

        private void UpdateDataGrid()
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                userFilteredList = ctx.Users.ToList<Users>();
                DataGridEditUser.ItemsSource = userFilteredList;
            }
        }

        private void CleanEdit(object o, EventArgs ea)
        {
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtUserId.Text = "";
            txtUsername.Text = "";
        }

        private void UpdateUserInfo(object o, EventArgs ea)
        {
            if(DataGridEditUser.SelectedItem != null)
            {
                Users selectedUser = (Users)DataGridEditUser.SelectedItem;
                txtEmail.Text = selectedUser.Email.ToString();
                txtFirstName.Text = selectedUser.FirstName.ToString();
                txtLastName.Text = selectedUser.LastName.ToString();
                txtPassword.Text = selectedUser.Password.ToString();
                txtUsername.Text = selectedUser.Username.ToString();
                txtUserId.Text = selectedUser.Id.ToString();
                cmbBoxPosition.SelectedItem = selectedUser.IsAdmin.ToString();
            }
        }

        private void EditSelectedUser(object o, EventArgs ea)
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                Users updateUser = ctx.Users.Where(x => x.Id == Convert.ToInt32(txtUserId.Text)).First(); 
                updateUser.FirstName = txtFirstName.Text.ToString();
                updateUser.LastName = txtLastName.Text.ToString();
                updateUser.Email = txtEmail.Text.ToString();
                updateUser.Password = txtPassword.Text.ToString();
                updateUser.Username = txtUsername.Text.ToString(); 
                string position = cmbBoxPosition.SelectedItem.ToString();

                if (position.Equals("Manager"))
                {
                    updateUser.IsAdmin = true;
                }
                else
                {
                    updateUser.IsAdmin = false;
                }

                ctx.Users.Update(updateUser);
                ctx.SaveChanges();
            }

            UpdateDataGrid();
            MessageBox.Show("User Updated");
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtUserId.Text = "";
            txtUsername.Text = "";

            EmployeeView wAEmployeeView = new EmployeeView();
            wAEmployeeView.Show();

            foreach(Window window in Application.Current.Windows)
            {
                if(window.GetType() == typeof(EmployeeEditView))
                {
                    window.Close();
                }
            }
        }

        private void InitializeComboBox()
        {
            cmbBoxPosition.Items.Add("Manager");
            cmbBoxPosition.Items.Add("Sales Representative");
        }

        private void OpenAndCloseMenu(object o, RoutedEventArgs rea)
        {
            if (isClosed)
            {
                Storyboard openMenu = (Storyboard)btnMenu.FindResource("OpenMenu");
                openMenu.Begin();
                productsMenu.Visibility = Visibility.Hidden;
                salesmenMenu.Visibility = Visibility.Hidden;
                stockMenu.Visibility = Visibility.Hidden;
                employeeMenu.Visibility = Visibility.Hidden;
                logout.Visibility = Visibility.Hidden;
            }
            else
            {
                Storyboard closeMenu = (Storyboard)btnMenu.FindResource("CloseMenu");
                closeMenu.Begin();
                productsMenu.Visibility = Visibility.Visible;
                salesmenMenu.Visibility = Visibility.Visible;
                stockMenu.Visibility = Visibility.Visible;
                employeeMenu.Visibility = Visibility.Visible;
                logout.Visibility = Visibility.Visible;

            }

            isClosed = !isClosed;
        }

        private void OpenProductPage(object o, RoutedEventArgs rea)
        {
            ProductView wProductView = new ProductView();
            wProductView.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(EmployeeEditView))
                {
                    window.Close();
                }
            }
        }

        private void OpenSalesmenPage(object o, RoutedEventArgs rea)
        {
            SalesmenView wSalesmenView = new SalesmenView();
            wSalesmenView.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(EmployeeEditView))
                {
                    window.Close();
                }
            }
        }

        private void OpenEditEmployeePage(object o, RoutedEventArgs rea)
        {
            EmployeeView wEmployeeView = new EmployeeView();
            wEmployeeView.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(EmployeeEditView))
                {
                    window.Close();
                }
            }
        }

        private void OpenStockPage(object o, RoutedEventArgs rea)
        {
            StockMenuView wstockMenuView = new StockMenuView();
            wstockMenuView.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(EmployeeEditView))
                {
                    window.Close();
                }
            }
        }

        private void Logout(object o, RoutedEventArgs rea)
        {
            MainWindow wMainWindow = new MainWindow();
            wMainWindow.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(EmployeeEditView))
                {
                    window.Close();
                }
            }
        }
    }
}
