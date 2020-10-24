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
    /// Logique d'interaction pour EspaceClient.xaml
    /// </summary>
    public partial class EspaceClient : Window
    {
        public EspaceClient(string UserId)
        {
            InitializeComponent();
            IdCdR.Text += UserId;
            AfficherInfosClient();
        }

        private void AfficherInfosClient()
        {
            string IdClient = IdCdR.Text;

            UseSQL sql1 = new UseSQL();
            sql1.Requete("SELECT prenom, nom, soldePoint FROM client WHERE idClient ='" + IdClient + "';");

            while (sql1.reader.Read())
            {
                PrenomClient.Text += sql1.reader.GetString(0);
                NomClient.Text += sql1.reader.GetString(1);
                TelClient.Text += sql1.reader.GetInt32(2) + "©";
            }
            sql1.Close();

            UseSQL sql2 = new UseSQL();
            sql2.Requete("SELECT count(numCommande) FROM commande WHERE idClient ='" + IdClient + "';");

            while (sql2.reader.Read())
            {
                NbCommandesClient.Text += sql2.reader.GetString(0);
            }
            sql2.Close();


        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal menuP = new MenuPrincipal(IdCdR.Text);
            menuP.Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditInfos PageEdit = new EditInfos(IdCdR.Text);
            PageEdit.Show();
            this.Close();
        }

        private void Createur_Click(object sender, RoutedEventArgs e)
        {
            EspaceCreateur CdR = new EspaceCreateur(IdCdR.Text);
            CdR.Show();
            this.Close();
        }
    }
}
