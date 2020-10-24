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
    /// Logique d'interaction pour ChoixIngredients.xaml
    /// </summary>
    public partial class ChoixIngredients : Window
    {
        string idC;
        string nomRecetteEnCreation;

        public string nomProduit { get; set; }
        public string unite { get; set; }
        List<Produit> mesProduits { get; set; }

        public ChoixIngredients(string idC, string nomRecetteEnCreation)
        {
            InitializeComponent();
            this.idC = idC;
            this.nomRecetteEnCreation = nomRecetteEnCreation;

            mesProduits = new List<Produit>();
            mesProduits = GetProduits();
            LVmesProduits.ItemsSource = mesProduits;

        }

        private List<Produit> GetProduits()
        {
            List<Produit> listeP = new List<Produit>() { };

            UseSQL sql = new UseSQL();
            sql.Requete("SELECT * FROM produit;");
            string nomProduit;
            string categorieProduit;
            int stockActuel;
            int stockMin;
            int stockMax;
            string unite;

            while (sql.reader.Read())
            {
                nomProduit = sql.reader.GetString(0);
                categorieProduit = sql.reader.GetString(1);
                stockActuel = sql.reader.GetInt32(2);
                stockMin = sql.reader.GetInt32(3);
                stockMax = sql.reader.GetInt32(4);
                unite = sql.reader.GetString(5);

                listeP.Add(new Produit(nomProduit, categorieProduit, stockActuel, stockMin, stockMax, unite));
            }
            sql.Close();
            return listeP;
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            UseSQL sql = new UseSQL();
            sql.Requete("SELECT nomRecette FROM recette;");
            sql.Close();
            sql.Requete("DELETE FROM compose WHERE nomRecette = '" + nomRecetteEnCreation + "';");
            sql.Close();
            sql.Requete("DELETE FROM recette WHERE nomRecette = '" + nomRecetteEnCreation + "';");
            sql.Close();
            
            
            sql.Requete("SELECT count(nomRecette) FROM recette WHERE idClient = '" + idC + "';");
            int NbRecettes = sql.reader.GetInt32(0);
            sql.Close();
            if(NbRecettes > 0)
            {
                CreationRecette CR = new CreationRecette(idC);
                CR.Show();
                this.Close();
            }
            else if(NbRecettes==0)
            {
                sql.Requete("UPDATE client SET Createur= 0 where idClient='" + idC + "';");
                sql.Close();
                CreationRecette CR = new CreationRecette(idC);
                CR.Show();
                this.Close();
            }
        }

        private void Creation_Click(object sender, RoutedEventArgs e)
        {
            EspaceCreateur EC = new EspaceCreateur(idC);
            EC.Show();
            this.Close();
        }

        private void Button_ValiderIngredient(object sender, RoutedEventArgs e)
        {
            List<Produit> ProduitSelected = new List<Produit>();
            ProduitSelected.Add(LVmesProduits.SelectedItem as Produit);

            int quantiteProdUse = Convert.ToInt32(TBquantite.Text);

            UseSQL sql = new UseSQL();
            sql.Requete("INSERT INTO `fLaEo2rVWb`.`compose` (`nomProduit`,`nomRecette`,`quantiteUtilisee`) VALUES('" + ProduitSelected[0].nomProduit + "', '" + nomRecetteEnCreation + "', '" + quantiteProdUse + "');");
            sql.Close();
            TBquantite.Text = "";
            info.Text = "Ingrédient validé !";
        }
    }
}
