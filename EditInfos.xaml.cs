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
    /// Logique d'interaction pour EditInfos.xaml
    /// </summary>
    public partial class EditInfos : Window
    {
        public EditInfos(string UserId)
        {
            InitializeComponent();

            SaveId.Text = UserId;
            AfficherInfos();
        }

        private void AfficherInfos()
        {
            UseSQL sql = new UseSQL();
            sql.Requete("SELECT prenom, nom, idClient, numTel, ville, MDP FROM client WHERE idClient ='" + SaveId.Text + "';");
            while(sql.reader.Read())
            {
                EditPrenom.Text = sql.reader.GetString(0);
                EditNom.Text = sql.reader.GetString(1);
                EditId.Text = sql.reader.GetString(2);
                EditTelephone.Text = sql.reader.GetString(3);
                EditAdresse.Text = sql.reader.GetString(4);
                EditMDP.Text = sql.reader.GetString(5);
            }
            sql.Close();
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            EspaceClient EspaceC = new EspaceClient(EditId.Text);
            EspaceC.Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Infos1.Text = "";
            Infos2.Text = "";

            string prenom = EditPrenom.Text;
            string nom = EditNom.Text;
            string id = EditId.Text;
            string numTel = EditTelephone.Text;
            string ville = EditAdresse.Text;
            string mdp = EditMDP.Text;
            //Dans un 1er temps on va tester si toutes les cases sont bien remplies
            if (prenom == null | nom == null | numTel == null | numTel.Length != 10 | ville == null | id == null | mdp == null)
            {
                Infos1.Text = "Il faut bien remplir tous les champs";
                Infos2.Text = "pour pouvoir créer un compte";
            }
            else
            {   
                //Dans un 2nd temps on va tester si l'identifiant existe pas déjà
                if (prenom != null && nom != null && numTel != null && numTel.Length == 10 && ville != null && id != null && mdp != null)
                {
                    bool exist = IdExist(id);
                    if (exist == true)
                    {
                        Infos1.Text = "Cet identifiant est déjà utilisé";
                        Infos2.Text = "par un autre utilisateur de Cooking";
                    }
                    else
                    {
                        if (exist == false)
                        {
                            UseSQL sql = new UseSQL();
                            sql.Requete("UPDATE client SET prenom= '" + prenom + "' where idClient='" + SaveId.Text + "';");
                            sql.Close();
                            sql.Requete("UPDATE client SET nom= '" + nom + "' where idClient='" + SaveId.Text + "';");
                            sql.Close();
                            sql.Requete("UPDATE client SET idClient= '" + id + "' where idClient='" + SaveId.Text + "';");
                            sql.Close();
                            sql.Requete("UPDATE client SET numTel= '" + numTel + "' where idClient='" + SaveId.Text + "';");
                            sql.Close();
                            sql.Requete("UPDATE client SET ville= '" + ville + "' where idClient='" + SaveId.Text + "';");
                            sql.Close();
                            sql.Requete("UPDATE client SET MDP= '" + mdp + "' where idClient='" + SaveId.Text + "';");
                            sql.Close();

                            EspaceClient EspaceClient = new EspaceClient(SaveId.Text);
                            EspaceClient.Show();
                            this.Close();
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
            while(sql.reader.Read())
            {
                if(idTest == sql.reader.GetString(0) && idTest != SaveId.Text)
                {
                    exist = true;
                }
            }
            sql.Close();
            return exist;
        }
        
    }
}
