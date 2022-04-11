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
    /// Interaction logic for EmployeeDeleteView.xaml
    /// </summary>
    public partial class EmployeeDeleteView : Window
    {
        List<Users> userList = new List<Users>();
        List<Users> userFilteredList = new List<Users>();
        bool isClosed = false;
        public EmployeeDeleteView()
        {
            InitializeComponent();
            InitializeDataGrid();
            UpdateDataGrid();
            btnMenu.Click += OpenAndCloseMenu;
            productsMenu.Click += OpenProductPage;
            employeeMenu.Click += OpenDeleteEmployeePage;
            salesmenMenu.Click += OpenSalesmenPage;
            stockMenu.Click += OpenStockPage;
            btnDeleteUser.Click += DeleteUser;
            DataGridDeleteUser.SelectionChanged += DeleteUserInfo;
            logout.Click += Logout;

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
                DataGridDeleteUser.ItemsSource = userList;
            }
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

        private void UpdateDataGrid()
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                userFilteredList = ctx.Users.ToList<Users>();
                DataGridDeleteUser.ItemsSource = userFilteredList;
            }
        }

        private void DeleteUserInfo(object o, EventArgs ea)
        {
            if(DataGridDeleteUser.SelectedItem != null)
            {
                Users userToBeDeleted = (Users)DataGridDeleteUser.SelectedItem;

                txtEmail.Text = userToBeDeleted.Email.ToString();
                txtFirstName.Text = userToBeDeleted.FirstName.ToString();
                txtLastName.Text = userToBeDeleted.LastName.ToString();
                txtPassword.Text = userToBeDeleted.Password.ToString();
                txtUsername.Text = userToBeDeleted.Username.ToString();
                txtUserId.Text = userToBeDeleted.Id.ToString();
                cmbBoxPosition.SelectedItem = userToBeDeleted.IsAdmin.ToString();
            }
        }

        private void DeleteUser(object o, EventArgs ea)
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                Users userToBeDeleted = ctx.Users.Where(x => x.Id == Convert.ToInt32(txtUserId.Text)).First();
                if(MessageBox.Show("Do you want to delete this user?", "Confirmation",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ctx.Users.Remove(userToBeDeleted);
                    ctx.SaveChanges();
                    UpdateDataGrid();
                }
            }

            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtUserId.Text = "";
            txtUsername.Text = "";

            EmployeeView wAEmployeeView = new EmployeeView();
            wAEmployeeView.Show();

            foreach (Window Window in Application.Current.Windows)
            {
                if(Window.GetType() == typeof(EmployeeDeleteView))
                {
                    Window.Close();
                }
            }
        }

        private void OpenProductPage(object o, RoutedEventArgs rea)
        {
            ProductView wProductView = new ProductView();
            wProductView.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(EmployeeDeleteView))
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
                if (window.GetType() == typeof(EmployeeDeleteView))
                {
                    window.Close();
                }
            }
        }

        private void OpenDeleteEmployeePage(object o, RoutedEventArgs rea)
        {
            EmployeeView wEmployeeView = new EmployeeView();
            wEmployeeView.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(EmployeeDeleteView))
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
                if (window.GetType() == typeof(EmployeeDeleteView))
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
                if (window.GetType() == typeof(EmployeeDeleteView))
                {
                    window.Close();
                }
            }
        }
    }
}
