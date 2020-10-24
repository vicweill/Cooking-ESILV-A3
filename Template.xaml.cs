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

namespace ProjetBDD_WPF
{
    /// <summary>
    /// Logique d'interaction pour Template.xaml
    /// </summary>
    public partial class Template : Window
    {
        public Template()
        {
            InitializeComponent();
        }

            private void Retour_Click(object sender, RoutedEventArgs e)
        {
            MainWindow menuP = new MainWindow();
            this.Close();
            menuP.Show();
        }

        private void Creation_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
