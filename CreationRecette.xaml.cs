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
    /// Logique d'interaction pour CreationRecette.xaml
    /// </summary>
    public partial class CreationRecette : Window
    {
        string nomRecetteEnCreation;
        string idC;
        public string[] categories { get; set; }



        public CreationRecette(string idClient)
        {
            InitializeComponent();
            this.idC = idClient;
            categories = new string[] { "entrée", "plat", "dessert" };

            DataContext = this;
        }



        private void Creation_Click(object sender, RoutedEventArgs e)
        {
            Informations1.Text = "";
            Informations2.Text = "";

            string nomRecette = Nomrecette.Text;
            string descriptif = description.Text;
            string typeRecette = ChoixCategorie.Text;
            int prix = 0;

            if (Prix.Text != "")
            {
                prix = Convert.ToInt32(Prix.Text);
            }

            UseSQL sql = new UseSQL();
            string CreateRecette = "INSERT INTO `fLaEo2rVWb`.`recette` (`nomRecette`,`typeRecette`,`descriptif`,`prix`,`photo`,`idClient`,`idAdmin`) VALUES(" +
                "'" + nomRecette + "', " +
                "'" + typeRecette + "', " +
                "'" + descriptif + "', "
                    + prix + ", " +
                  "'https://www.zupimages.net/up/20/19/z1jt.png'" + ", " +
                "'" + this.idC + "', " +
                "'admin'" +
                "); ";

            //On va tester si la recette peut être créée ou non
            if (nomRecette == "" | typeRecette == "" | descriptif == "")
            {
                Informations1.Text = "Il faut bien remplir tous les champs";
                Informations2.Text = "pour pouvoir créer une recette";
            }
            else
            {
                if (nomRecette.Length >= 40 | descriptif.Length >= 256)
                {
                    Informations1.Text = "Les informations entrées";
                    Informations2.Text = "sont trop longues";
                }
                else
                {
                    if (RecetteExist(nomRecette) == true)
                    {
                        Informations1.Text = "Le nom de cette recette";
                        Informations2.Text = "existe déjà";
                    }
                    else
                    {
                        if (prix < 10 | prix > 40)
                        {
                            Informations1.Text = "Les prix doit être compris";
                            Informations2.Text = "entre 10 et 40 Cook";
                        }
                        else
                        {
                            sql.Requete(CreateRecette);
                            sql.Close();
                            sql.Requete("UPDATE client SET Createur= 1 where idClient='" + this.idC + "';");
                            sql.Close();
                            nomRecetteEnCreation = nomRecette;

                            //Ouvre la page de sélection des ingrédients
                            ChoixIngredients CI = new ChoixIngredients(this.idC, nomRecetteEnCreation);
                            CI.Show();
                            this.Close();
                        }
                    }
                }
                
            }
        }

        private bool RecetteExist(string nomrecette)
        {
            UseSQL sql = new UseSQL();
            bool existe = true;
            sql.Requete("SELECT count(*) FROM recette where nomRecette = '" + nomrecette + "'");
            sql.reader.Read();
            int nb = sql.reader.GetInt32(0);
            if (nb >= 1)
            {
                existe = true;
            }
            else
            {
                if (nb < 1)
                {
                    existe = false;
                }
            }
            sql.Close();
            return existe;
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            EspaceCreateur espaceCrea = new EspaceCreateur(this.idC);
            espaceCrea.Show();
            this.Close();
        }
    }
}
