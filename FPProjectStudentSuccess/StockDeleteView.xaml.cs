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
    /// Interaction logic for StockDeleteView.xaml
    /// </summary>
    public partial class StockDeleteView : Window
    {
        List<Product> stockList = new List<Product>();
        List<Product> stockFilteredList = new List<Product>();
        bool isClosed = false;
        public StockDeleteView()
        {
            InitializeComponent();
            InitializeDataGrid();
            UpdateDataGrid();
            btnMenu.Click += OpenAndCloseMenu;
            productsMenu.Click += OpenProductPage;
            employeeMenu.Click += OpenDeleteEmployeePage;
            salesmenMenu.Click += OpenSalesmenPage;
            stockMenu.Click += OpenStockPage;
            btnDeleteProduct.Click += DeleteProduct;
            DataGridDeleteProduct.SelectionChanged += DeleteUserInfo;
            logout.Click += Logout;

            //Menu Item visibility
            productsMenu.Visibility = Visibility.Hidden;
            salesmenMenu.Visibility = Visibility.Hidden;
            stockMenu.Visibility = Visibility.Hidden;
            employeeMenu.Visibility = Visibility.Hidden;
            logout.Visibility = Visibility.Hidden;
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

        private void InitializeDataGrid()
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                stockList = ctx.Product.ToList<Product>();
                DataGridDeleteProduct.ItemsSource = stockList;
            }
        }

        private void UpdateDataGrid()
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                stockFilteredList = ctx.Product.ToList<Product>();
                DataGridDeleteProduct.ItemsSource = stockFilteredList;
            }
        }

        private void DeleteUserInfo(object o, EventArgs ea)
        {
            if (DataGridDeleteProduct.SelectedItem != null)
            {
                Product ProductToBeDeleted = (Product)DataGridDeleteProduct.SelectedItem;

                txtPrice.Text = ProductToBeDeleted.Price.ToString();
                txtProductName.Text = ProductToBeDeleted.Name.ToString();
                txtPublisher.Text = ProductToBeDeleted.Publisher.ToString();
                txtQuantity.Text = ProductToBeDeleted.Quantity.ToString();
                txtShelf.Text = ProductToBeDeleted.ShelfId.ToString();
                txtYear.Text = ProductToBeDeleted.Year.ToString();
                txtProductId.Text = ProductToBeDeleted.Id.ToString();
                cmbBoxPlatform.SelectedItem = ProductToBeDeleted.PlataformId.ToString();
            }
        }

        private void DeleteProduct(object o, EventArgs ea)
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                Product productToBeDeleted = ctx.Product.Where(x => x.Id == Convert.ToInt32(txtProductId.Text)).First();
                if (MessageBox.Show("Do you want to delete this Product?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ctx.Product.Remove(productToBeDeleted);
                    ctx.SaveChanges();
                    UpdateDataGrid();
                }
            }

            txtPrice.Text = "";
            txtProductName.Text = "";
            txtPublisher.Text = "";
            txtQuantity.Text = "";
            txtShelf.Text = "";
            txtYear.Text = "";
            txtProductId.Text = "";

            AdminOverview wAdminOverView = new AdminOverview();
            wAdminOverView.Show();

            foreach (Window Window in Application.Current.Windows)
            {
                if (Window.GetType() == typeof(StockDeleteView))
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
                if (window.GetType() == typeof(StockDeleteView))
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
                if (window.GetType() == typeof(StockDeleteView))
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
                if (window.GetType() == typeof(StockDeleteView))
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
                if (window.GetType() == typeof(StockDeleteView))
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
                if (window.GetType() == typeof(StockDeleteView))
                {
                    window.Close();
                }
            }
        }
    }
}
