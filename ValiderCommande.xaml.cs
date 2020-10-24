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
    /// Logique d'interaction pour ValiderCommande.xaml
    /// </summary>
    public partial class ValiderCommande : Window
    {
        List<string[]> listePanier = new List<string[]>();
        int valPrixTotal = 0;

        public ValiderCommande(string UserId, List<string[]> Panier)
        {
            InitializeComponent();

            this.listePanier = Panier;

            var commande = GetCommande(listePanier);
            if (commande.Count > 0)
            {
                affichageCommande.ItemsSource = commande;
            }
            IdClient.Text = UserId;
            AffichageSoldeCdR();
            AffichagePrixTotal();
        }

        private void AffichageSoldeCdR()
        {
            UseSQL sql = new UseSQL();
            sql.Requete("SELECT Createur, soldePoint FROM client WHERE idClient = '" + IdClient.Text + "' ");
            sql.reader.Read();
            if(sql.reader.GetBoolean(0)==true)
            {
                Solde.Text = "Votre solde de points : " + sql.reader.GetString(1);
            }
            sql.Close();
        }

        private void AffichagePrixTotal()
        {
            PrixTotal.Text += this.valPrixTotal + "©";
        }

        private List<Panier> GetCommande(List<string[]> Panier)
        {
            List<Panier> commande = new List<Panier>();
            UseSQL sql = new UseSQL();

            int i = 0;
            int val;
            string RecetteCommande;
            int prixU;
            string nomrecette;
            string prixfinal;
            string photo;
            string quantite;

            foreach (string[] couple in Panier)
            {
                //On va parcourir tous les éléments où la quantité est supérieure à 0
                //Puis on prend le nom et on va ensuite pouvoir calculer le prix
                //et on affiche tout

                val = Convert.ToInt32(Panier[i][1]);
                
                if (val != 0)
                {
                    RecetteCommande = Panier[i][0];

                    sql.Requete("SELECT nomRecette, prix, photo FROM recette WHERE nomRecette = '" + RecetteCommande + "';");
                    while (sql.reader.Read())
                    {
                        nomrecette = sql.reader.GetString(0);
                        prixU = Convert.ToInt32(sql.reader.GetString(1))*val;
                        prixfinal = Convert.ToString(prixU) + "©";
                        this.valPrixTotal += prixU;
                        photo = sql.reader.GetString(2);
                        quantite = "Quantité : " + Panier[i][1];

                        commande.Add(new Panier(nomrecette, prixfinal, photo, quantite));
                    }
                    sql.Close();
                }
                i++;         
            }           
            return commande;
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal menuP = new MenuPrincipal(IdClient.Text);
            menuP.Show();
            this.Close();
        }

        private void Commander_Click(object sender, RoutedEventArgs e)
        {
            UseSQL sql = new UseSQL();
            DateTime CommandTime = DateTime.Now;
            string dateCommande = "";
            for(int index = 0; index <= 9; index++)
            {
                dateCommande += Convert.ToString(CommandTime.Date)[index];
            }
            string numCommande = "";
            numCommande += CommandTime.Year;
            numCommande += CommandTime.Month;
            numCommande += CommandTime.Day;
            numCommande += CommandTime.Hour;
            numCommande += CommandTime.Minute;
            Console.WriteLine("\n\n\n\n\nNUMERO DE COMMANDE : " + numCommande + "\n\n\n\n\n");
            sql.Requete("INSERT INTO `fLaEo2rVWb`.`commande` (`numCommande`,`dateCommande`,`idClient`) VALUES ('" + numCommande + "',now(),'" + IdClient.Text + "');");
            sql.Close();

            int i = 0;
            int j = 0;
            int NewStock = 0;
            int val;

            foreach (string[] couple in this.listePanier)
            {
                val = Convert.ToInt32(this.listePanier[i][1]);
                //on va prendre le nombre de fois où la recette est dans le panier
                if (val != 0)
                {
                    while(val>0)
                    {
                        j = 0;
                        //jusqu'à l'épuisement d'une recette dans le panier
                        //on va voir combien de fois elle a été commandée
                        //et update le solde du créateur et éventuellement
                        //le prix d'une recette
                        if (NbCommandes(this.listePanier[i][0]) < 10)
                        {
                            //on prend le solde de base du créateur
                            sql.Requete("SELECT soldePoint FROM client WHERE idClient = '" + IdClient.Text + "';");
                            sql.reader.Read();
                            //+2 points cook pour sa recette
                            int solde = sql.reader.GetInt32(0) + 2;
                            sql.Close();

                            sql.Requete("UPDATE client SET soldePoint= '" + solde + "' where idClient='" + IdClient.Text + "';");
                            sql.reader.Read();
                            sql.Close();
                            //Le solde est update
                        }

                        if (NbCommandes(this.listePanier[i][0]) == 10)
                        {
                            //On va monter le prix de la commande de 2 points cook supplémentaires
                            sql.Requete("SELECT prix FROM recette WHERE nomRecette = '" + this.listePanier[i][0] + "';");
                            sql.reader.Read();
                            int prix = sql.reader.GetInt32(0) + 2;
                            sql.Close();

                            sql.Requete("UPDATE recette SET prix= '" + prix + "' WHERE nomRecette = '" + this.listePanier[i][0] + "';");
                            sql.reader.Read();
                            sql.Close();

                            //---------------------------------------------------

                            //on prend le solde de base du créateur
                            sql.Requete("SELECT soldePoint FROM client WHERE idClient = '" + IdClient.Text + "';");
                            sql.reader.Read();
                            //+2 points cook pour sa recette
                            int solde = sql.reader.GetInt32(0) + 2;
                            sql.Close();

                            sql.Requete("UPDATE client SET soldePoint= '" + solde + "' where idClient='" + IdClient.Text + "';");
                            sql.reader.Read();
                            sql.Close();
                            //Le solde est update
                        }

                        if (NbCommandes(this.listePanier[i][0]) < 50)
                        {
                            //on prend le solde de base du créateur
                            sql.Requete("SELECT soldePoint FROM client WHERE idClient = '" + IdClient.Text + "';");
                            sql.reader.Read();
                            //+2 points cook pour sa recette
                            int solde = sql.reader.GetInt32(0) + 2;
                            sql.Close();

                            sql.Requete("UPDATE client SET soldePoint= '" + solde + "' WHERE idClient='" + IdClient.Text + "';");
                            sql.reader.Read();
                            sql.Close();
                            //Le solde est update
                        }

                        if (NbCommandes(this.listePanier[i][0]) == 50)
                        {
                            //On va monter le prix de la commande de 3 points cook supplémentaires
                            sql.Requete("SELECT prix FROM recette WHERE nomRecette = '" + this.listePanier[i][0] + "';");
                            sql.reader.Read();
                            int prix = sql.reader.GetInt32(0) + 3;
                            sql.Close();

                            sql.Requete("UPDATE recette SET prix= '" + prix + "' WHERE nomRecette = '" + this.listePanier[i][0] + "';");
                            sql.reader.Read();
                            sql.Close();

                            //---------------------------------------------------

                            //on prend le solde de base du créateur
                            sql.Requete("SELECT soldePoint FROM client WHERE idClient = '" + IdClient.Text + "';");
                            sql.reader.Read();
                            //+5 points cook pour sa recette
                            int solde = sql.reader.GetInt32(0) + 5;
                            sql.Close();

                            sql.Requete("UPDATE client SET soldePoint= '" + solde + "' WHERE idClient='" + IdClient.Text + "';");
                            sql.reader.Read();
                            sql.Close();
                            //Le solde est update
                        }

                        if (NbCommandes(this.listePanier[i][0]) > 50)
                        {
                            //on prend le solde de base du créateur
                            sql.Requete("SELECT soldePoint FROM client WHERE idClient = '" + IdClient.Text + "';");
                            sql.reader.Read();
                            //+5 points cook pour sa recette
                            int solde = sql.reader.GetInt32(0) + 5;
                            sql.Close();

                            sql.Requete("UPDATE client SET soldePoint= '" + solde + "' where idClient='" + IdClient.Text + "';");
                            sql.reader.Read();
                            sql.Close();
                            //Le solde est update
                        }


                        List<string[]> ProduitsQuantites = CalculQuantite(this.listePanier[i][0]);
                        foreach (string[] duo in ProduitsQuantites)
                        {
                            sql.Requete("SELECT stockActuel FROM produit WHERE nomProduit = '" + ProduitsQuantites[j][0] +"';");
                            sql.reader.Read();
                            NewStock = sql.reader.GetInt32(0);
                            sql.Close();
                            //on a attrapé le stock actuel
                            //on veut maintenant trouver la quantite utilisee
                            //dans la recette pour soustraire

                            sql.Requete("SELECT quantiteUtilisee FROM compose WHERE nomRecette = '" + this.listePanier[i][0] + "';");
                            sql.reader.Read();
                            NewStock -= sql.reader.GetInt32(0);
                            sql.Close();

                            sql.Requete("UPDATE produit SET stockActuel= "+ NewStock + " WHERE nomProduit = '" + ProduitsQuantites[j][0] + "';");
                            sql.reader.Read();
                            sql.Close();
                            j++;
                        }
                        val--;
                    }
                }
                sql.Close();
                i++;
            }

            ConfirmationCommande suite = new ConfirmationCommande(IdClient.Text);
            suite.Show();
            this.Close();
        }

        private List<string[]> CalculQuantite(string nomRecette)
        {
            List<string[]> quantites = new List<string[]>();
            
            UseSQL sql = new UseSQL();
            sql.Requete("SELECT nomProduit, stockActuel FROM produit NATURAL JOIN compose WHERE nomRecette = '"+nomRecette+"';");
            while(sql.reader.Read())
            {
                string[] couple = new string[2];
                couple[0] = sql.reader.GetString(0);
                couple[1] = sql.reader.GetString(1);
                quantites.Add(couple);
            }
            sql.Close();
            //pour chaque ingrédient de la recette on va mettre son
            //nom et sa quantité actuelle dans la liste
            return quantites;
        }

        private int NbCommandes(string nomrecette)
        {
            //on va regarder le nombre de fois où une recette à été commandée
            int nb = 0;
            UseSQL sql = new UseSQL();
            sql.Requete("SELECT count(numCommande) FROM contient WHERE nomRecette = '" + nomrecette + "';");
            sql.reader.Read();
            nb = sql.reader.GetInt32(0);
            sql.Close();
            return nb;
        }

        
    }

    
    
}
