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
    /// Logique d'interaction pour Supprimer.xaml
    /// </summary>
    public partial class Supprimer : Window
    {
        public Supprimer(string admin)
        {
            InitializeComponent();
            Idadmin.Text = admin;
        }

        private void SuppressionCreateur_Click(object sender, RoutedEventArgs e)
        {
            informations1.Text = "";
            informations2.Text = "";
            UseSQL sql = new UseSQL();

            //On définit ici les variables utilisées pour lire les sorties de commandes et les afficher
            string id = ValueCreateur.Text;
            bool exist = false;
            sql.Requete("SELECT idClient FROM client;");
            while(sql.reader.Read())
            {
                if(sql.reader.GetString(0) == id)
                {
                    exist = true;
                }
            }
            sql.Close();
            if(exist == true)
            {
                sql.Requete("UPDATE client SET Createur= 0 WHERE idClient='"+ id +"';");
                sql.Close();
                sql.Requete("DELETE FROM recette WHERE idClient =;");
                sql.Close();
                informations1.Text = "Ce créateur est bien supprimé";
            }
            if(exist == false)
            {
                ValueCreateur.Text = "";
                informations1.Text = "Ce client Cooking est mal";
                informations2.Text = "identifié ou n'existe pas";
            }
        }

        private void SuppressionRecette_Click(object sender, RoutedEventArgs e)
        {
            informations3.Text = "";
            informations4.Text = "";
            UseSQL sql = new UseSQL();

            //On définit ici les variables utilisées pour lire les sorties de commandes et les afficher
            string nomR = ValueRecette.Text;
            bool exist = false;
            sql.Requete("SELECT nomRecette FROM recette;");
            while (sql.reader.Read())
            {
                if (sql.reader.GetString(0) == nomR)
                {
                    exist = true;
                }
            }
            sql.Close();
            if (exist == true)
            {
                sql.Requete("DELETE FROM compose WHERE nomRecette = '" + nomR + "';");
                sql.Close();
                sql.Requete("DELETE FROM recette WHERE nomRecette = '"+ nomR +"';");
                sql.Close();

                informations3.Text = "Cette recette est bien supprimée";
            }
            if (exist == false)
            {
                ValueRecette.Text = "";
                informations3.Text = "Cette recette est mal";
                informations4.Text = "identifiée ou n'existe pas";
            }

        }


        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin menuA = new MenuAdmin(Idadmin.Text);
            menuA.Show();
            this.Close();
        }

    }
}
