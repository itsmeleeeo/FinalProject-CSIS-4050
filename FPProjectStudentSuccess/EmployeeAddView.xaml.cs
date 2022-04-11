﻿using System;
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
    /// Interaction logic for EmployeeAddView.xaml
    /// </summary>
    public partial class EmployeeAddView : Window
    {
        List<Users> userList = new List<Users>();
        List<Users> userFilteredList = new List<Users>();
        bool isClosed = false;
        public EmployeeAddView()
        {
            InitializeComponent();
            InitializeDataGrid();
            InitializeComboBox();
            UpdateDataGrid();
            btnMenu.Click += OpenAndCloseMenu;
            productsMenu.Click += OpenProductPage;
            employeeMenu.Click += OpenAddEmployeePage;
            salesmenMenu.Click += OpenSalesmenPage;
            stockMenu.Click += OpenStockPage;
            logout.Click += Logout;
            btnAddUser.Click += AddUser;
            btnClean.Click += CleanUser;

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
                DataGridAddUser.ItemsSource = userList;
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

        private void UpdateDataGrid()
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                userFilteredList = ctx.Users.ToList<Users>();
                DataGridAddUser.ItemsSource = userFilteredList;
            }
        }

        private void AddUser(object o, EventArgs ea)
        {
            Users newEmployee = new Users();
            newEmployee.FirstName = txtFirstName.Text.ToString().ToLower();
            newEmployee.LastName = txtLastName.Text.ToString().ToLower();
            newEmployee.Email = txtEmail.Text.ToString().ToLower();
            newEmployee.Username = txtUsername.Text.ToString().ToLower();
            newEmployee.Password = txtPassword.Text.ToString().ToLower();
            string position = cmbBoxPosition.SelectedItem.ToString();

            if(position.Equals("Manager"))
            {
                newEmployee.IsAdmin = true;
            } else
            {
                newEmployee.IsAdmin = false;
            }

            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                ctx.Users.Add(newEmployee);
                ctx.SaveChanges();
            }

            UpdateDataGrid();

            MessageBox.Show("User Added");
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
            cmbBoxPosition.Text = "";
        }

        private void CleanUser(object o, EventArgs ea)
        {
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
            cmbBoxPosition.Text = "";
        }

        private void OpenProductPage(object o, RoutedEventArgs rea)
        {
            ProductView wProductView = new ProductView();
            wProductView.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(EmployeeAddView))
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
                if (window.GetType() == typeof(EmployeeAddView))
                {
                    window.Close();
                }
            }
        }

        private void OpenAddEmployeePage(object o, RoutedEventArgs rea)
        {
            EmployeeView wEmployeeView = new EmployeeView();
            wEmployeeView.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(EmployeeAddView))
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
                if (window.GetType() == typeof(EmployeeAddView))
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
                if (window.GetType() == typeof(EmployeeAddView))
                {
                    window.Close();
                }
            }
        }
    }
}
