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
    /// Logique d'interaction pour AjoutPhoto.xaml
    /// </summary>
    public partial class AjoutPhoto : Window
    {
        public AjoutPhoto(string admin)
        {
            InitializeComponent();
            var recettes = GetRecettesCdR();
            if (recettes.Count > 0)
            {
                ListeApercuRecettes.ItemsSource = recettes;
            }
            IdAdmin.Text = admin;
        }


        private List<Recette> GetRecettesCdR()
        {
            List<Recette> listeR = new List<Recette>() { };
            UseSQL sql = new UseSQL();
            sql.Requete("SELECT * FROM recette WHERE photo ='https://www.zupimages.net/up/20/19/z1jt.png';");
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

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            information.Text = "";
            UseSQL sql = new UseSQL();

            //On va tester si le nom entré existe parmi toutes les recettes qui n'ont pas encore de photo
            sql.Requete("SELECT nomRecette FROM recette WHERE photo ='https://www.zupimages.net/up/20/19/z1jt.png';");
            bool exist = false;
            while (sql.reader.Read())
            {
                if (sql.reader.GetString(0) == ValueNom.Text)
                {
                    exist = true;
                }
            }
            sql.Close();
            //Si le nom n'existe pas, on renvoie un message d'erreur
            if (exist == false)
            {
                information.Text = "Ce nom de recette est introuvable";
                ValueNom.Text = "";
                ValueLien.Text = "";
            }
            //Si le nom est le bon, on update la photo et on donne un message de succès
            if (exist == true)
            {
                sql.Requete("UPDATE recette SET photo= '' WHERE photo ='https://www.zupimages.net/up/20/19/z1jt.png' AND nomRecette = '" + ValueNom.Text + "';");
                sql.Close();
                information.Text = "La photo a bien été modifiée";
            }
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin menuA = new MenuAdmin(IdAdmin.Text);
            menuA.Show();
            this.Close();
        }
    }
}
