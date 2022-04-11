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
    /// Interaction logic for StockAddView.xaml
    /// </summary>
    public partial class StockAddView : Window
    {
        List<Product> stockList = new List<Product>();
        List<Product> stockFilteredList = new List<Product>();
        List<Plataform> plataformList = new List<Plataform>();
        bool isClosed = false;
        public StockAddView()
        {
            //Initializing Components
            InitializeComponent();
            InitializeDataGrid();
            InitializePlataForm();
            UpdateDataGrid();

            //Event Handlers
            btnMenu.Click += OpenAndCloseMenu;
            productsMenu.Click += OpenProductPage;
            employeeMenu.Click += OpenAddEmployeePage;
            salesmenMenu.Click += OpenSalesmenPage;
            stockMenu.Click += OpenStockPage;
            btnAddProduct.Click += AddProduct;
            btnClean.Click += CleanProduct;
            cmbBoxPlatform.SelectionChanged += UpdateShelf;
            logout.Click += Logout;

            //Menu Item visibility
            productsMenu.Visibility = Visibility.Hidden;
            salesmenMenu.Visibility = Visibility.Hidden;
            stockMenu.Visibility = Visibility.Hidden;
            employeeMenu.Visibility = Visibility.Hidden;
            logout.Visibility = Visibility.Hidden;
        }

        //Initializing Datagrid where products will be displayed after.
        private void InitializeDataGrid()
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                stockList = ctx.Product.ToList<Product>();
                DataGridAddProduct.ItemsSource = stockList;
            }
        }
        
        private void InitializePlataForm()
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                var cmbPlataform = ctx.Plataform.Select(x => x.Name).Distinct();

                foreach(var c in cmbPlataform)
                {
                    ComboBoxItem cmbItem = new ComboBoxItem();
                    cmbItem.Content = c;
                    cmbBoxPlatform.Items.Add(cmbItem);
                }
            }
        }

        private void UpdateDataGrid()
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                stockFilteredList = ctx.Product.ToList<Product>();
                DataGridAddProduct.ItemsSource = stockFilteredList;
            }
        }

        private void UpdateShelf(object o ,EventArgs ea)
        {
            var plataform = cmbBoxPlatform.SelectedItem.ToString();
            if(plataform.Contains("PS4") || plataform.Contains("PS5"))
            {
                txtShelf.Text = "Blue";
            }

            if (plataform.Contains("Xbox Series X") || plataform.Contains("Xbox One"))
            {
                txtShelf.Text = "Green";
            }

            if (plataform.Contains("Nintendo Switch"))
            {
                txtShelf.Text = "Red";
            }

            if (plataform.Contains("PC"))
            {
                txtShelf.Text = "Gray";
            }

        }

        private void AddProduct(object o, EventArgs ea)
        {
            Product newProduct = new Product();
            Shelf newShelf = new Shelf();
            newProduct.Name = txtProductName.Text.ToString().ToLower();
            newProduct.Publisher = txtPublisher.Text.ToString().ToLower();
            newProduct.Quantity = Convert.ToInt32(txtQuantity.Text);
            newProduct.Year = Convert.ToInt32(txtYear.Text);
            newProduct.Price = Convert.ToDecimal(txtPrice.Text);
            var selectedPlataform = cmbBoxPlatform.SelectedValue.ToString();

            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                var getPlataform = ctx.Plataform.Where(x => x.Name == selectedPlataform).First();
                var getShelf = ctx.Shelf.Where(x => x.PlataformId == getPlataform.Id).FirstOrDefault();

                if(getShelf == null)
                {
                    newShelf.Color = txtShelf.Text;
                    newShelf.Capacity = 100;
                    newShelf.PlataformId = getPlataform.Id;

                    ctx.Shelf.Add(newShelf);
                    ctx.SaveChanges();
                }
                newProduct.PlataformId = getPlataform.Id;

                var shelfId = ctx.Shelf.Where(x => x.PlataformId == getPlataform.Id).First();
                newProduct.ShelfId = shelfId.Id;

                ctx.Product.Add(newProduct);
                ctx.SaveChanges();
            }

            UpdateDataGrid();
            txtPrice.Text = "";
            txtProductName.Text = "";
            txtPublisher.Text = "";
            txtQuantity.Text = "";
            txtYear.Text = "";

            MessageBox.Show("Product Added");

            AdminOverview wAdminOverView = new AdminOverview();
            wAdminOverView.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(StockAddView))
                {
                    window.Close();
                }
            }
        }

        private void CleanProduct(object o, EventArgs ea)
        {
            txtPrice.Text = "";
            txtProductName.Text = "";
            txtPublisher.Text = "";
            txtQuantity.Text = "";
            txtYear.Text = "";
            cmbBoxPlatform.SelectedItem = "";
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
                if (window.GetType() == typeof(StockAddView))
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
                if (window.GetType() == typeof(StockAddView))
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
                if (window.GetType() == typeof(StockAddView))
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
                if (window.GetType() == typeof(StockAddView))
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
                if (window.GetType() == typeof(StockAddView))
                {
                    window.Close();
                }
            }
        }
    }
}
