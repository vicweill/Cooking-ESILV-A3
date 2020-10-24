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
    /// Logique d'interaction pour ModeDemo.xaml
    /// </summary>
    public partial class ModeDemo : Window
    {
        string idA;

        public ModeDemo(string nomAdmin)
        {
            InitializeComponent();
            this.idA = nomAdmin;

            List<Createur> TotalCdR = GetCdR();
            ListeCrea.ItemsSource = TotalCdR;

            List<Produit> ProdMin = GetProduits(nomProd.Text);
            ListeProd.ItemsSource = ProdMin;

            Initialisation();
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin menuA = new MenuAdmin(this.idA);
            menuA.Show();
            this.Close();
        }

        private void Initialisation()
        {
            UseSQL sql = new UseSQL();
            sql.Requete("SELECT count(*) FROM client;");
            sql.reader.Read();
            nbclient.Text += sql.reader.GetInt32(0);
            sql.Close();

            sql.Requete("SELECT count(*) FROM client WHERE Createur = true;");
            sql.reader.Read();
            nbcrea.Text += sql.reader.GetInt32(0);
            sql.Close();

            sql.Requete("select count(*) from recette;");
            sql.reader.Read();
            nbrecettes.Text += sql.reader.GetInt32(0);
            sql.Close();
        }

        private List<Createur> GetCdR()
        {
            List<Createur> listeCdR = new List<Createur>() { };

            UseSQL sql = new UseSQL();
            sql.Requete("SELECT C.idClient, count(Con.nomRecette) FROM client C, commande Com , recette R, contient Con " +
                "WHERE Com.numCommande=Con.numCommande AND R.nomRecette= Con.nomRecette AND C.Createur= true AND R.idClient=C.idClient " +
                "GROUP BY C.idClient;");

            while (sql.reader.Read())
            {
                //string[] liste = new string[2];
                //liste[0] = sql.reader.GetString(0);
                //liste[1] = Convert.ToString(sql.reader.GetInt32(1));

                listeCdR.Add(new Createur(sql.reader.GetString(0), sql.reader.GetInt32(1)));
            }
            sql.Close();
            return listeCdR;
        }

        private List<Produit> GetProduits(string nomP)
        {
            List<Produit> listeP = new List<Produit>() { };

            UseSQL sql = new UseSQL();
            sql.Requete("SELECT * FROM produit WHERE stockActuel<(2*stockMin);");
            string nomProduit = nomP;
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

        private void Avancer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void validerNom_Click(object sender, RoutedEventArgs e)
        {
            List<Contient> testProd = GetEntry(nomProd.Text);
            ProduitsRecette.ItemsSource = testProd;
        }

        private List<Contient> GetEntry(string nomP)
        {
            List<Contient> listeP = new List<Contient>() { };
            ProdText.Text += nomP;
            UseSQL sql = new UseSQL();
            sql.Requete("SELECT r.nomRecette, p.stockActuel, p.unite FROM recette r " +
                "JOIN compose c ON c.nomRecette=r.nomRecette " +
                "JOIN produit p ON c.nomProduit=p.nomProduit " +
                "WHERE p.nomProduit = '" + nomP + "' " +
                "GROUP BY r.nomRecette;");
            string NomRecette;
            int Stock;
            string Unite;

            while (sql.reader.Read())
            {
                NomRecette = sql.reader.GetString(0);
                Stock = sql.reader.GetInt32(1);
                Unite = sql.reader.GetString(2);

                listeP.Add(new Contient(NomRecette, Stock, Unite));
            }
            sql.Close();
            return listeP;
        }
    }
}
