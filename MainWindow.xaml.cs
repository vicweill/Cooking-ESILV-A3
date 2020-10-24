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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using MySql.Data.MySqlClient;


namespace ProjetBDD_WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Import(object sender, RoutedEventArgs e)
        {

        }


        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            UseSQL sql = new UseSQL();
            sql.Requete("SELECT idClient, MDP FROM client;");
            bool test = false;
            string id;
            string mdp;
            while (sql.reader.Read())
            {
                id = sql.reader.GetString(0);
                if (id == this.Utilisateur.Text)
                {
                    mdp = sql.reader.GetString(1);
                    if (mdp == this.MotDePasse.Password)
                    {
                        test = true;
                        MenuPrincipal menuP = new MenuPrincipal(id);
                        menuP.Show();
                        this.Close();
                    }
                }
            }
            sql.Close();
            if (test == false)
            {
                sql.Requete("SELECT idAdmin, mdp_admin FROM admin;");
                while (sql.reader.Read())
                {
                    id = sql.reader.GetString(0);
                    if (id == this.Utilisateur.Text)
                    {
                        mdp = sql.reader.GetString(1);
                        if (mdp == this.MotDePasse.Password)
                        {
                            test = true;
                            MenuAdmin menuA = new MenuAdmin(id);
                            menuA.Show();
                            this.Close();
                        }
                    }
                }
                sql.Close();
                Infos.Content = "L'identifiant ou le mot de passe est erroné";
                Utilisateur.Text = "";
                MotDePasse.Password = "";
            }
            
        }

        private void Creer_Click(object sender, RoutedEventArgs e)
        {
            CreerCompte PageCrea = new CreerCompte();
            PageCrea.Show();
            this.Close();

        }
    }
}
