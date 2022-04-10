using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FPProjectStudentSuccess
{
    /// <summary>
    /// Interaction logic for AdminOverview.xaml
    /// </summary>
    public partial class AdminOverview : Page
    {
        bool isClosed = false;
        public AdminOverview()
        {
            InitializeComponent();
            btnMenu.Click += OpenAndCloseMenu;
        }

        private void OpenAndCloseMenu(object o, EventArgs ea)
        {
            if (isClosed)
            {
                Storyboard openMenu = (Storyboard)btnMenu.FindResource("OpenMenu");
                openMenu.Begin();
            }
            else
            {
                Storyboard closeMenu = (Storyboard)btnMenu.FindResource("CloseMenu");
                closeMenu.Begin();
            }

            isClosed = !isClosed;
        }
    }
}
