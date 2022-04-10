using FPProjectStudentSuccess.Entities;
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

namespace FPProjectStudentSuccess
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : Window
    {
        List<Product> productsList = new List<Product>();
        List<Product> productFiltered = new List<Product>();
        List<Plataform> plataformList = new List<Plataform>();
        bool isClosed = false;
        public ProductView()
        {
            InitializeComponent();
            InitializeDataGrid();
            InitializeListBox();

            //Event Handlers
            btnMenu.Click += OpenAndCloseMenu;
            salesmenMenu.Click += OpenSalesmenPage;
            stockMenu.Click += OpenStockPage;
            employeeMenu.Click += OpenEmployeePage;
            logout.Click += Logout;
            txtSearchName.TextChanged += SearchByProduct;
            txtSearchPrice.TextChanged += SearchByPrice;
            lstboxConsoles.SelectionChanged += SelectedItem;

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
                productsList = ctx.Product.ToList<Product>();
                DataGridProducts.ItemsSource = productsList;
            }
        }

        private void InitializeListBox()
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                plataformList = ctx.Plataform.ToList<Plataform>();

                var consoleList = plataformList.Select(x => x.Name).Distinct();

                foreach(var c in consoleList)
                {
                    lstboxConsoles.Items.Add(c.Trim());
                }
            }
        }

        private void UpdateDataGrid()
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                productFiltered = ctx.Product.ToList<Product>();
                DataGridProducts.ItemsSource = productFiltered;
            }
        }

        private void SearchByProduct(object o, TextChangedEventArgs e)
        {
            string txtProduct = txtSearchName.Text.ToString().ToLower();
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                var product = productsList.Where(x => x.Name == txtProduct);
                productFiltered = product.ToList<Product>();
            }

            UpdateDataGrid();
        }

        private void SearchByPrice(object o, TextChangedEventArgs e)
        {
            decimal txtPrice = Convert.ToDecimal(txtSearchPrice.Text);
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                var price = productsList.Where(x => x.Price == txtPrice);
                productFiltered = price.ToList<Product>();
            }
            UpdateDataGrid();
        }

        private void SelectedItem(object o, SelectionChangedEventArgs e)
        {
            var selectedPlatform = lstboxConsoles.SelectedItems.OfType<string>();

            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                var plataformSelected = from p in productsList
                                        where p.Plataform == selectedPlatform
                                        select p;
                productFiltered = plataformSelected.ToList();
            }
            UpdateDataGrid();
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

        private void OpenSalesmenPage(object o, RoutedEventArgs rea)
        {
            SalesmenView wSalesmenView = new SalesmenView();
            wSalesmenView.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(ProductView))
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
                if (window.GetType() == typeof(ProductView))
                {
                    window.Close();
                }
            }
        }

        private void OpenEmployeePage(object o, RoutedEventArgs rea)
        {
            EmployeeView wEmployeeView = new EmployeeView();
            wEmployeeView.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(ProductView))
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
                if (window.GetType() == typeof(ProductView))
                {
                    window.Close();
                }
            }
        }
    }
}
