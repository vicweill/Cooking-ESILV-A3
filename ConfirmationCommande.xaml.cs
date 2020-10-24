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
    /// Logique d'interaction pour ConfirmationCommande.xaml
    /// </summary>
    public partial class ConfirmationCommande : Window
    {
        public ConfirmationCommande(string IdClient)
        {
            InitializeComponent();
            NomClient.Text = IdClient;
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal menuP = new MenuPrincipal(NomClient.Text);
            menuP.Show();
            this.Close();
        }
    }
}
