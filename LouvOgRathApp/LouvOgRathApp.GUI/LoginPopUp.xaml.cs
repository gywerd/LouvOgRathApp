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
using System.Windows.Shapes;

namespace LouvOgRathApp.GUI
{
    /// <summary>
    /// Interaction logic for LoginPopUp.xaml
    /// </summary>
    public partial class LoginPopUp : Window
    {
        #region Window
        public LoginPopUp()
        {
            InitializeComponent();
        }
        #endregion

        #region Buttons
        private void BtnSecretary_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(this, "Secretary");
            main.Activate();
            this.Hide();
            main.Show();

        }

        private void BtnSolicitor_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(this, "Lawyer");
            main.Activate();
            this.Hide();
            main.Show();

        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(this, "Client");
            main.Activate();
            this.Hide();
            main.Show();

        }
        #endregion

        #region Events
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion

    }
}
