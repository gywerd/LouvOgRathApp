using LouvOgRathApp.Shared.Entities;
using LouvOgRathApp.ServerSide.DataAccess;
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
using WeatherService;

namespace LouvOgRathApp.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        Window callWindow;
        public string User;
        NewCasePopUp newCase;
        UcCases ucCases;
        UcLawCases ucLawCases;
        UcMyCases ucMyCases;
        UcSummary ucSummary;
        UcSecretary ucSecretary;
        UcSolicitor ucSolicitor;
        private Repository repository;
        private WeatherAPI weatherAPI;
        List<Case> cases = new List<Case>();
        #endregion

        #region Window
        public MainWindow(object w, string user)
        {
            InitializeComponent();
            TestConnection();
            callWindow = (Window)w;
            User = user;
            cases = repository.GetAllCases();
            InvokeUserControls();
            weatherAPI = new WeatherAPI(labelWeather);
            weatherAPI.GetCityNameAsync();
        }

        #endregion

        #region Events
        /// <summary>
        /// Shows MessageBox with Copyright info 
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void MenuHelpAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("©2018 Daniel Giversen", "Om Louv & Rath", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        /// <summary>
        /// Closes this window, and returns to LoginPopUp
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void OnMenuFilesClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            callWindow.Show();
        }

        /// <summary>
        /// Opens a NewCasePopUp Window
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void OnMenuFilesNewCase_Click(object sender, RoutedEventArgs e)
        {
            newCase = new NewCasePopUp(this);
            newCase.Activate();
            this.Hide();
            newCase.Show();
        }

        private void OnMenuFilesNewClient_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Closes thos window, and returns to LoginPopUp
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">System.ComponentModel.CancelEventArgs</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            callWindow.Show();
        }

        #endregion

        #region Methods
        private void InvokeUserControls()
        {
            if (User == "Secretary")
            {
                userControlLeft.Content = ucCases = new UcCases(cases);
                userControlRight.Content = ucSecretary = new UcSecretary(); ;
            }
            else if (User == "Lawyer")
            {
                userControlLeft.Content = ucLawCases = new UcLawCases();
                userControlRight.Content = ucSolicitor = new UcSolicitor();
            }
            else
            {
                userControlLeft.Content = ucMyCases = new UcMyCases();
                userControlRight.Content = ucSummary = new UcSummary();
            }
        }
        private void TestConnection()
        {
            try
            {
                repository = new Repository();
                statusBar.Background = Brushes.Green;
                labelConnection.Content = "Forbundet til server";
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Unfortunately the connection to the database could not be established: " + $"{Environment.NewLine}{Environment.NewLine}{ex.Message}");
                statusBar.Background = Brushes.Red;
                labelConnection.Content = "Kunne ikke opnå forbindelse til serveren.";
            }
        }

        #endregion

    }
}
