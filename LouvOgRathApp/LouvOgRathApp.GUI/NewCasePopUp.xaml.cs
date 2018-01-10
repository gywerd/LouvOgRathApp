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
    /// Interaction logic for NewCasePopUp.xaml
    /// </summary>
    public partial class NewCasePopUp : Window
    {
        Window callWindow;
        public NewCasePopUp(object w)
        {
            InitializeComponent();
            callWindow = (Window)w;
        }

        #region Events
        private void BtnNewClient_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Code, that saves client to DB
        }

        private void BtnSaveCase_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Code, that saves case to DB
            this.Close();
            callWindow.Show();
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxSubject_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            callWindow.Show();
        }
        #endregion

    }
}
