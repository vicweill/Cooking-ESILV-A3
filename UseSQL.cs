using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

namespace ProjetBDD_WPF
{
    class UseSQL
    {
        public MySqlConnection connection;
        public MySqlDataReader reader;

        public UseSQL()
        {
            string connectionString = "SERVER=remotemysql.com;PORT=3306;DATABASE=fLaEo2rVWb;UID=fLaEo2rVWb;PASSWORD=q93ciuueiL;";
            connection = new MySqlConnection(connectionString);
        }

        public void Requete(string requete)
        {
            connection.Open();
            MySqlCommand commande = connection.CreateCommand();
            commande.CommandText = requete; //on va prendre la requête en entrée
            reader = commande.ExecuteReader();
        }

        public void Close()
        {
            reader.Close();
            connection.Close();
        }


    }
}
