using FPProjectStudentSuccess.Entities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FPProjectStudentSuccess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            addAdmin();
            //EventHandlers
            btnLogin.Click += AdminLogin;
        }

        private void addAdmin()
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                var checkAdmin = ctx.Users.Where(x => x.Email.Equals("admin@gamedepot.ca")).FirstOrDefault();

                if (checkAdmin == null)
                {
                    Users admin = new Users();
                    admin.FirstName = "admin";
                    admin.LastName = "admin";
                    admin.Username = "admin";
                    admin.Password = "admin";
                    admin.IsAdmin = true;
                    admin.Email = "admin@gamedepot.ca";

                    ctx.Users.Add(admin);
                    ctx.SaveChanges();
                }
            }
        }

        private void AdminLogin(object sender, RoutedEventArgs rea)
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                string username = txtAdminLogin.Text.ToLower();
                string password = txtAdminPass.Text.ToLower();

                var login = ctx.Users.Where(x => x.Username.StartsWith(username)).FirstOrDefault();
                var pass = ctx.Users.Where(x => x.Password.StartsWith(password)).FirstOrDefault();

                if (username != login.Email && password != pass.Password)
                {
                    MessageBox.Show("The email or password is incorrect");
                }
                else if (login.Email == null || pass.Password == null)
                {
                    MessageBox.Show("Email or Password is empty");
                }
                else
                {
                    AdminOverview wAdminOverview = new AdminOverview();
                    wAdminOverview.Show();

                    foreach(Window window in Application.Current.Windows)
                    {
                        if(window.GetType() == typeof(MainWindow))
                        {
                            window.Close();
                        }
                    }
                }
            }
        }
    }
}
