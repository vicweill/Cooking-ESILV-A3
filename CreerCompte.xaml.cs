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
using System.IO;
using MySql.Data.MySqlClient;

namespace ProjetBDD_WPF
{
    /// <summary>
    /// Logique d'interaction pour CreerCompte.xaml
    /// </summary>
    public partial class CreerCompte : Window
    {
        public CreerCompte()
        {
            InitializeComponent();
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            MainWindow menuP = new MainWindow();
            menuP.Show();
            this.Close();
        }
        

        private void Creation_Click(object sender, RoutedEventArgs e)
        {
            Informations1.Text = "";
            Informations2.Text = "";

            UseSQL sql = new UseSQL();

            //On définit ici les variables utilisées pour lire les sorties de commandes et les afficher
            string prenom = Prenom.Text;
            string nom = Nom.Text;
            string numTel = Telephone.Text;
            string ville = Ville.Text;
            string id = IdCooking.Text;
            string mdp = MDP.Text;

            string phrase = "INSERT INTO `fLaEo2rVWb`.`client` (`idClient`,`nom`,`prenom`,`numTel`,`ville`,`MDP`,`Createur`,`soldePoint`) VALUES(" +
                "'" + id + "', " +
                "'" + nom + "', " +
                "'" + prenom + "', " +
                "'" + numTel + "', " +
                "'" + ville + "', " +
                "'" + mdp + "', " +
                "0, " +
                "0); ";

            

            //On va tester si le compte peut être créé ou non
            if (prenom == null | nom == null | numTel == null | numTel.Length != 10 | ville == null | id == null | mdp == null)
            { 
                Informations1.Text = "Il faut bien remplir tous les champs";
                Informations2.Text = "pour pouvoir créer un compte";
            }

            else
            {
                bool exist = IdExist(id);
                if (exist == true)
                {
                    Informations1.Text = "Cet identifiant est déjà utilisé";
                    Informations2.Text = "par un autre utilisateur de Cooking";
                }
                else
                {
                    if(exist == false)
                    {
                        if (prenom != null && nom != null && numTel != null && numTel.Length == 10 && ville != null && id != null && mdp != null)
                        {
                            sql.Requete(phrase);
                            sql.Close();

                            //On ouvre à nouveau la page de connection
                            //On affiche que le compte est bien créé ?
                            MainWindow menuP = new MainWindow();
                            this.Close();
                            menuP.Show();
                        }
                    }       
                }   
            }

        }

        private bool IdExist(string idTest)
        {
            UseSQL sql = new UseSQL();
            bool exist = false;
            sql.Requete("SELECT idClient FROM client;");
            while (sql.reader.Read())
            {
                if (idTest == sql.reader.GetString(0))
                {
                    exist = true;
                }
            }
            sql.Close();
            return exist;
        }

    }
}
