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
using MySql.Data.MySqlClient;

namespace ProjetBDD_WPF
{
    /// <summary>
    /// Logique d'interaction pour MenuAdmin.xaml
    /// </summary>
    public partial class MenuAdmin : Window
    {
        public MenuAdmin(string AdminId)
        {
            InitializeComponent();
            IdAdmin.Text = AdminId;

            CreateurSemaine();
            TopRecettesSemaine();
            CreateurOr();
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void CreateurSemaine()
        {
            UseSQL sql = new UseSQL();
            string phrase = "SELECT c.idClient FROM client c JOIN commande m ON (c.idClient = m.idClient) " +
                "JOIN contient t ON(t.numCommande = m.numCommande) " +
                "JOIN recette r ON(r.nomRecette = t.nomRecette) " +
                "WHERE m.dateCommande " +
                "BETWEEN(now() - INTERVAL 1 week) AND now() " +
                "GROUP BY c.idClient " +
                "ORDER BY count(m.numCommande) desc limit 1;";
            sql.Requete(phrase);
            int i = 0;
            while (sql.reader.Read() && i<1)
            {
                CdRSemaine.Text += sql.reader.GetString(0);
                i++;
            }
            sql.Close();
        }

        

        private List<string> TrouverRecettesSemaine()
        {
            List<string> liste = new List<string>();
            string recette;
            UseSQL sql = new UseSQL();
            sql.Requete("SELECT r.nomRecette FROM client c JOIN commande m ON (c.idClient = m.idClient) " +
                "JOIN contient t ON(t.numCommande = m.numCommande) " +
                "JOIN recette r ON(r.nomRecette = t.nomRecette) " +
                "WHERE m.dateCommande " +
                "BETWEEN(now() - INTERVAL 1 week) AND now() " +
                "GROUP BY r.nomRecette " +
                "ORDER BY count(m.numCommande) DESC LIMIT 5;");
            while (sql.reader.Read())
            {
                recette = sql.reader.GetString(0);
                liste.Add(recette);
            }
            sql.Close();
            return liste;
        }

        private void TopRecettesSemaine()
        {
            List<string> liste = new List<string> { };
            liste = TrouverRecettesSemaine();
            int n = liste.Count();
            if (n >= 1)
            {
                Recette1.Text += liste[0];
                if (n >= 2)
                {
                    Recette2.Text += liste[1];
                    if (n >= 3)
                    {
                        Recette3.Text += liste[2];
                        if (n >= 4)
                        {
                            Recette4.Text += liste[3];
                            if (n >= 5)
                            {
                                Recette5.Text += liste[4];

                            }
                        }
                    }
                }
            }
        }

        private void CreateurOr()
        {
            UseSQL sql = new UseSQL();
            string phrase = "SELECT c.idClient FROM client c JOIN commande m ON (c.idClient = m.idClient) " +
                "JOIN contient t ON(t.numCommande = m.numCommande) " +
                "JOIN recette r ON(r.nomRecette = t.nomRecette) " +
                "WHERE m.dateCommande " +
                "BETWEEN (2020/04/15) AND now() " +
                "GROUP BY c.idClient " +
                "ORDER BY count(m.numCommande) desc limit 1;";
            sql.Requete(phrase);
            string id = "";
            while (sql.reader.Read())
            {
                id += sql.reader.GetString(0);
                CdRor.Text += sql.reader.GetString(0);
                Top5photos(id);
            }
            sql.Close();

        }


        private List<string> TrouverTop5photos(string id)
        {
            List<string> liste = new List<string>();
            string recette;
            UseSQL sql = new UseSQL();
            sql.Requete("SELECT r.photo FROM recette r JOIN contient t ON r.nomRecette = t.nomRecette " +
                "JOIN commande m ON t.numCommande = m.numCommande " +
                "JOIN client c ON c.idClient = m.idClient " +
                "WHERE c.idClient = '" + id + "' GROUP BY photo " +
                "ORDER BY count(m.numCommande) desc limit 5;");
            while (sql.reader.Read())
            {
                recette = sql.reader.GetString(0);
                liste.Add(recette);
            }
            sql.Close();
            return liste;
        }

        private void Top5photos(string id)
        {
            string idOr = id;
            List<string> liste = new List<string>();
            liste = TrouverTop5photos(idOr);
            int n = liste.Count();
            if (n >= 1)
            {
                Uri resourceUri1 = new Uri(liste[0], UriKind.RelativeOrAbsolute);
                R1.Source = new BitmapImage(resourceUri1);
                if (n >= 2)
                {
                    Uri resourceUri2 = new Uri(liste[1], UriKind.RelativeOrAbsolute);
                    R2.Source = new BitmapImage(resourceUri2);
                    if (n >= 3)
                    {
                        Uri resourceUri3 = new Uri(liste[2], UriKind.RelativeOrAbsolute);
                        R3.Source = new BitmapImage(resourceUri3);
                        if (n >= 4)
                        {
                            Uri resourceUri4 = new Uri(liste[3], UriKind.RelativeOrAbsolute);
                            R4.Source = new BitmapImage(resourceUri4);
                            if (n >= 5)
                            {
                                Uri resourceUri5 = new Uri(liste[4], UriKind.RelativeOrAbsolute);
                                R5.Source = new BitmapImage(resourceUri5);
                            }
                        }
                    }
                }
            }
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            Supprimer del = new Supprimer(IdAdmin.Text);
            del.Show();
            this.Close();
        }

        private void Gerer_Click(object sender, RoutedEventArgs e)
        {
            AjoutPhoto photo = new AjoutPhoto(IdAdmin.Text);
            photo.Show();
            this.Close();
        }


        private void Demo_Click(object sender, RoutedEventArgs e)
        {
            ModeDemo modeD = new ModeDemo(IdAdmin.Text);
            modeD.Show();
            this.Close();
        }
    }
}
