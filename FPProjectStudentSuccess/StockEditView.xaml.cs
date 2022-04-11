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
    /// Interaction logic for StockEditView.xaml
    /// </summary>
    public partial class StockEditView : Window
    {
        List<Product> stockList = new List<Product>();
        List<Product> stockFilteredList = new List<Product>();
        bool isClosed = false;
        public StockEditView()
        {
            InitializeComponent();
            InitializeDataGrid();
            UpdateDataGrid();
            btnMenu.Click += OpenAndCloseMenu;
            productsMenu.Click += OpenProductPage;
            employeeMenu.Click += OpenEditEmployeePage;
            salesmenMenu.Click += OpenSalesmenPage;
            stockMenu.Click += OpenStockPage;
            btnUpdateProduct.Click += EditSelectedProduct;
            btnClean.Click += CleanProduct;
            DataGridEditProduct.SelectionChanged += UpdateProductInfo;
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
                stockList = ctx.Product.ToList<Product>();
                DataGridEditProduct.ItemsSource = stockList;
            }
        }
        private void UpdateDataGrid()
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                stockFilteredList = ctx.Product.ToList<Product>();
                DataGridEditProduct.ItemsSource = stockFilteredList;
            }
        }
        private void UpdateProductInfo(object o, EventArgs ea)
        {
            if (DataGridEditProduct.SelectedItem != null)
            {
                Product selectedProduct = (Product)DataGridEditProduct.SelectedItem;
                txtPrice.Text = selectedProduct.Price.ToString();
                txtProductId.Text = selectedProduct.Id.ToString();
                txtProductName.Text = selectedProduct.Name.ToString();
                txtPublisher.Text = selectedProduct.Publisher.ToString();
                txtQuantity.Text = selectedProduct.Quantity.ToString();
                txtYear.Text = selectedProduct.Year.ToString();
                txtShelf.Text = selectedProduct.ShelfId.ToString();
                cmbBoxPlatform.SelectedItem = selectedProduct.PlataformId.ToString();
            }
        }

        private void EditSelectedProduct(object o, EventArgs ea)
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                Product updateProduct = ctx.Product.Where(x => x.Id == Convert.ToInt32(txtProductId.Text)).First();
                updateProduct.Publisher = txtPublisher.Text.ToString();
                updateProduct.Quantity = Convert.ToInt32(txtQuantity.Text.ToString());
                updateProduct.Year = Convert.ToInt32(txtYear.Text.ToString());
                updateProduct.Price = Convert.ToDecimal(txtPrice.Text.ToString());

                ctx.Product.Update(updateProduct);
                ctx.SaveChanges();
            }

            UpdateDataGrid();
            MessageBox.Show("Product Updated");
            txtPublisher.Text = "";
            txtQuantity.Text = "";
            txtYear.Text = "";
            txtPrice.Text = "";

            AdminOverview wAdminOverView = new AdminOverview();
            wAdminOverView.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(StockEditView))
                {
                    window.Close();
                }
            }
        }

        private void CleanProduct(object o, EventArgs ea)
        {
            txtPublisher.Text = "";
            txtQuantity.Text = "";
            txtYear.Text = "";
            txtPrice.Text = "";
            txtProductName.Text = "";
            txtShelf.Text = "";
            txtProductId.Text = "";
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
                if (window.GetType() == typeof(StockEditView))
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
                if (window.GetType() == typeof(StockEditView))
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
                if (window.GetType() == typeof(StockEditView))
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
                if (window.GetType() == typeof(StockEditView))
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
                if (window.GetType() == typeof(StockEditView))
                {
                    window.Close();
                }
            }
        }
    }
}
