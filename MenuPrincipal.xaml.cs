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
    /// Logique d'interaction pour MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        public MenuPrincipal(string interId)
        {
            InitializeComponent();
            var recettes = GetRecettes();
            if (recettes.Count > 0)
            {
                affichageRecette.ItemsSource = recettes;
            }
            Sauvegarde_Id.Text = interId;
        }

        //On va créer une List qui contient des tableaux
        //Dans chaque tableau on retrouve un nom de recette et une quantité
        //rangés au même index et initialisés à Qtite=0
        List<string[]> listePanier = new List<string[]>();

        private List<Recette> GetRecettes()
        {
            List<Recette> listeR = new List<Recette>() { };

            UseSQL sql = new UseSQL();
            sql.Requete("SELECT * FROM recette;");
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
                this.listePanier.Add(new string[] {nomrecette,"0"});
            }
            sql.Close();
            return listeR;
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            MainWindow PageAccueil = new MainWindow();
            PageAccueil.Show();
            this.Close();
        }


        private void Commande_Click(object sender, RoutedEventArgs e)
        {
            ValiderCommande Commande = new ValiderCommande(Sauvegarde_Id.Text, this.listePanier);
            Commande.Show();
            this.Close();
        }

        private void Infos_Click(object sender, RoutedEventArgs e)
        {
            List<Recette> Recettes = new List<Recette>();
            Recettes.Add(affichageRecette.SelectedItem as Recette);
            ShowRecette affichage = new ShowRecette(Sauvegarde_Id.Text, Recettes[0].NomRecette);
            affichage.Show();
            this.Close();
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            //on va mettre une quantité entre 1 et 9 à la recette associée
            List<Recette> Panier = new List<Recette>();
            Panier.Add(affichageRecette.SelectedItem as Recette);

            if (Panier[0].NomRecette != null)
            {
                int index = FindIndex(this.listePanier, Panier[0].NomRecette);
                int QuantitePanier = Convert.ToInt32(this.listePanier[index][1]);
                if (QuantitePanier < 9)
                {
                    QuantitePanier++;
                    this.listePanier[index][1] = Convert.ToString(QuantitePanier);
                }
                Quantite.Text = Convert.ToString(QuantitePanier);
            }
        }

        private int FindIndex(List<string[]> RecettesPanier, string TestNom)
        {
            int index = 0;
            int i = 0;
            foreach (string[] couple in RecettesPanier)
            {
                //on regarde si à l'index i le nom de la recette est le même qu'en entrée
                if (RecettesPanier[i][0] == TestNom)
                {
                    index = i;
                }
                i++;
            }
            return index;
        }

        private void Retirer_Click(object sender, RoutedEventArgs e)
        {
            //on va mettre une quantité entre 1 et 9 à la recette associée
            List<Recette> Panier = new List<Recette>();
            Panier.Add(affichageRecette.SelectedItem as Recette);

            if(Panier[0].NomRecette != null)
            {
                int index = FindIndex(this.listePanier, Panier[0].NomRecette);
                int QuantitePanier = Convert.ToInt32(this.listePanier[index][1]);
                if (QuantitePanier > 0)
                {
                    QuantitePanier--;
                    this.listePanier[index][1] = Convert.ToString(QuantitePanier);
                }
                Quantite.Text = Convert.ToString(QuantitePanier);
            }           
        }

        private void Creation_Click(object sender, RoutedEventArgs e)
        {
            EspaceClient CdR = new EspaceClient(Sauvegarde_Id.Text);
            CdR.Show();
            this.Close();
        }
    }
}
