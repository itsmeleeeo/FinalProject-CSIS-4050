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
    /// Interaction logic for StockMenuView.xaml
    /// </summary>
    public partial class StockMenuView : Window
    {
        List<Product> stockList = new List<Product>();
        List<Product> stockFiltered = new List<Product>();
        bool isClosed = false;
        public StockMenuView()
        {
            InitializeComponent();
            InitizalizeDataGridStock();
            //Event Handlers
            btnMenu.Click += OpenAndCloseMenu;
            productsMenu.Click += OpenProductPage;
            salesmenMenu.Click += OpenSalesmenPage;
            employeeMenu.Click += OpenEmployeePage;
            logout.Click += Logout;
            txtSearch.TextChanged += SearchProduct;
            btnAddProduct.Click += AddProductStock;
            btnEditProduct.Click += EditProductStock;
            btnDeleteProduct.Click += DeleteProductStock;


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

        private void InitizalizeDataGridStock()
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                stockList = ctx.Product.ToList<Product>();
                DataGridStock.ItemsSource = stockList;
            }
        }

        private void UpdateDataGrid()
        {
            DataGridStock.ItemsSource = stockFiltered;
        }

        private void SearchProduct(object o, TextChangedEventArgs ea) 
        {
            string txtProduct = txtSearch.Text.ToString().ToLower();

            var stockSearch = from p in stockList
                              where p.Name.Contains(txtProduct) select p;
            stockFiltered = stockSearch.ToList();

            UpdateDataGrid();
        }

        private void AddProductStock(object o, RoutedEventArgs ea)
        {
            StockAddView wAddView = new StockAddView();
            wAddView.Show();

            foreach(Window window in Application.Current.Windows)
            {
                if(window.GetType() == typeof(StockMenuView))
                {
                    window.Close();
                }
            }
        }

        private void EditProductStock(object o, RoutedEventArgs ea)
        {
            StockEditView wEditView = new StockEditView();
            wEditView.Show();

            foreach(Window window in Application.Current.Windows)
            {
                if(window.GetType() == typeof(StockMenuView))
                {
                    window.Close();
                }
            }
        }

        private void DeleteProductStock(object o, RoutedEventArgs ea)
        {
            StockDeleteView wDeleteView = new StockDeleteView();
            wDeleteView.Show();

            foreach(Window window in Application.Current.Windows)
            {
                if(window.GetType() == typeof(StockMenuView))
                {
                    window.Close();
                }
            }
        }

        private void OpenProductPage(object o, RoutedEventArgs rea)
        {
            ProductView wProductView = new ProductView();
            wProductView.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(StockMenuView))
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
                if (window.GetType() == typeof(StockMenuView))
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
                if (window.GetType() == typeof(StockMenuView))
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
                if (window.GetType() == typeof(StockMenuView))
                {
                    window.Close();
                }
            }
        }
    }
}
