using LouvOgRathApp.Shared.Entities;
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

namespace LouvOgRathApp.GUI
{
    /// <summary>
    /// Interaction logic for UcCases.xaml
    /// </summary>
    public partial class UcCases : UserControl
    {
        List<Case> cases;

        #region Window
        public UcCases(List<Case> cases)
        {
            InitializeComponent();
            this.cases = cases;
            dataGridCases.DataContext = cases;
        }
        #endregion

        #region Events
        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        #endregion

    }
}
