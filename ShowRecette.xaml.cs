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
    /// Logique d'interaction pour ShowRecette.xaml
    /// </summary>
    public partial class ShowRecette : Window
    {
        public ShowRecette(string idClient, string nomRecette)
        {
            InitializeComponent();
            SaveId.Text = idClient;
            NomRecette.Text = nomRecette;
            Affiche(nomRecette);
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal menuP = new MenuPrincipal(SaveId.Text);
            menuP.Show();
            this.Close();
        }

        private void Affiche(string NomR)
        {
            UseSQL sql = new UseSQL();
            sql.Requete("SELECT typeRecette, descriptif, prix, photo FROM recette WHERE nomRecette ='" + NomR + "';");
            while(sql.reader.Read())
            {
                TypeRecette.Text = sql.reader.GetString(0);
                DescriptionRecette.Text = sql.reader.GetString(1);
                PrixRecette.Text = sql.reader.GetString(2) + " ©";
                Uri resourceUri1 = new Uri(sql.reader.GetString(3), UriKind.RelativeOrAbsolute);
                PhotoRecette.Source = new BitmapImage(resourceUri1);
            }
            sql.Close();

            sql.Requete("SELECT group_concat(nomProduit) FROM compose WHERE nomRecette ='" + NomR + "';");
            sql.reader.Read();
            IngredientsRecette.Text += sql.reader.GetString(0);
            sql.Close();
            //AfficheIng(NomR);
        }

        private void AfficheIng(string nomRecette)
        {
            UseSQL sql = new UseSQL();
            sql.Requete("SELECT group_concat(nomProduit) FROM compose WHERE nomRecette ='" + NomRecette + "';");
            while (sql.reader.Read())
            {
                IngredientsRecette.Text += sql.reader.GetString(0);
            }
            sql.Close();
        }
    }
}
