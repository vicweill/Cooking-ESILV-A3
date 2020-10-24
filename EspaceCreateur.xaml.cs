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
    /// Logique d'interaction pour EspaceCreateur.xaml
    /// </summary>
    public partial class EspaceCreateur : Window
    {
        public EspaceCreateur(string UserId)
        {
            InitializeComponent();
            IdCdR.Text += UserId;
            AfficherInfosCdR();
            var recettes = GetRecettesCdR();
            if (recettes.Count > 0)
            {
                ListeApercuRecettes.ItemsSource = recettes;
            }
        }

        private void AfficherInfosCdR()
        {
            string IdClient = IdCdR.Text;

            UseSQL sql = new UseSQL();
            sql.Requete("SELECT prenom, nom, soldePoint FROM client WHERE idClient ='"+ IdClient +"';");

            while (sql.reader.Read())
            {
                PrenomCdR.Text += sql.reader.GetString(0);
                NomCdR.Text += sql.reader.GetString(1);
                SoldeCdR.Text += sql.reader.GetInt32(2) + "©";
            }
            sql.Close();

            sql.Requete("SELECT count(nomRecette) FROM recette WHERE idClient ='" + IdClient + "';");

            while (sql.reader.Read())
            {
                NbRecettesCdR.Text += sql.reader.GetString(0);
            }
            sql.Close();

            sql.Requete("SELECT count(m.numCommande) FROM client c JOIN commande m ON (c.idClient = m.idClient) " +
                "JOIN contient t ON(t.numCommande = m.numCommande) " +
                "JOIN recette r ON(r.nomRecette = t.nomRecette) " +
                "WHERE c.idClient = '"+IdClient+"';");
            while (sql.reader.Read())
            {
                NbCommandesCdR.Text += sql.reader.GetString(0);
            }
            sql.Close();

        }

        private List<Recette> GetRecettesCdR()
        {
            List<Recette> listeR = new List<Recette>() { };
            UseSQL sql = new UseSQL();
            sql.Requete("SELECT * FROM recette WHERE idClient ='" + IdCdR.Text + "';");
            string nomrecette;
            string typerecette;
            string descriptif;
            string prix;
            string photo;
            string idclient;
            string idadmin;

            while (sql.reader.Read())
            {
                nomrecette = sql.reader.GetString(0);
                typerecette = sql.reader.GetString(1);
                descriptif = sql.reader.GetString(2);
                prix = sql.reader.GetString(3) + "©";
                photo = sql.reader.GetString(4);
                idclient = sql.reader.GetString(5);
                idadmin = sql.reader.GetString(6);

                listeR.Add(new Recette(nomrecette, typerecette, descriptif, prix, photo, idclient, idadmin));

            }
            sql.Close();
            return listeR;
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            EspaceClient menuC = new EspaceClient(IdCdR.Text);
            menuC.Show();
            this.Close();
        }

        private void AjouterRecette_Click(object sender, RoutedEventArgs e)
        {
            CreationRecette creationRecette = new CreationRecette(IdCdR.Text);
            creationRecette.Show();
            this.Close();
        }
    }
}
