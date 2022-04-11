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
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Window
    {
        List<Users> usersList = new List<Users>();
        bool isClosed = false;
        public EmployeeView()
        {
            InitializeComponent();
            InitializeEmployeeDataGrid();

            btnMenu.Click += OpenAndCloseMenu;
            productsMenu.Click += OpenProductPage;
            salesmenMenu.Click += OpenSalesmenPage;
            stockMenu.Click += OpenStockPage;
            logout.Click += Logout;
            btnAddEmployee.Click += AddEmployeeView;
            btnEditEmployee.Click += EditEmployeeView;
            btnDeleteEmployee.Click += DeleteEmployeeView;

            //Menu Item visibility
            productsMenu.Visibility = Visibility.Hidden;
            salesmenMenu.Visibility = Visibility.Hidden;
            stockMenu.Visibility = Visibility.Hidden;
            employeeMenu.Visibility = Visibility.Hidden;
            logout.Visibility = Visibility.Hidden;
        }

        //Function responsible to open and close the menu sidebar
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
        private void InitializeEmployeeDataGrid()
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                usersList = ctx.Users.ToList<Users>();
                DataGridEmployee.ItemsSource = usersList;
            }
        }
        private void OpenProductPage(object o, RoutedEventArgs rea)
        {
            ProductView wProductView = new ProductView();
            wProductView.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(EmployeeView))
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
                if (window.GetType() == typeof(EmployeeView))
                {
                    window.Close();
                }
            }
        }

        private void AddEmployeeView(object o, RoutedEventArgs rea)
        {
            EmployeeAddView wAddEmployee = new EmployeeAddView();
            wAddEmployee.Show();

            foreach(Window window in Application.Current.Windows)
            {
                if(window.GetType() == typeof(EmployeeView))
                {
                    window.Close();
                }
            }
        }

        private void EditEmployeeView(object o, RoutedEventArgs rea)
        {
            EmployeeEditView wEditEmployee = new EmployeeEditView();
            wEditEmployee.Show();

            foreach(Window window in Application.Current.Windows)
            {
                if(window.GetType() == typeof(EmployeeView))
                {
                    window.Close();
                }
            }
        }

        private void DeleteEmployeeView(object o, RoutedEventArgs rea)
        {
            EmployeeDeleteView wDeleteEmployee = new EmployeeDeleteView();
            wDeleteEmployee.Show();

            foreach(Window window in Application.Current.Windows)
            {
                if(window.GetType() == typeof(EmployeeView))
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
                if (window.GetType() == typeof(EmployeeView))
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
                if (window.GetType() == typeof(EmployeeView))
                {
                    window.Close();
                }
            }
        }
    }
}
