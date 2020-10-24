using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_WPF
{
    public class Recette
    {

        private string nomrecette;
        private string typerecette;
        private string descriptif;
        private string prix;
        private string photo;
        private string idclient;
        private string idadmin;

        public Recette SelectRecette { get; set; }

        public Recette(string nomrecette, string typerecette, string descriptif, string prix, string photo, string idclient, string idadmin)
        {
            this.nomrecette = nomrecette;
            this.typerecette = typerecette;
            this.descriptif = descriptif;
            this.prix = prix;
            this.photo = photo;
            this.idclient = idclient;
            this.idadmin = idadmin;
        }

        public string NomRecette
        {
            get { return nomrecette; }
            set { nomrecette = value; }
        }
        public string TypeRecette
        {
            get { return typerecette; }
            set { typerecette = value; }
        }
        public string Descriptif
        {
            get { return descriptif; }
            set { descriptif = value; }
        }
        public string Prix
        {
            get { return prix; }
            set { prix = value; }
        }
        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }
        public string IdClient
        {
            get { return IdClient; }
            set { IdClient = value; }
        }
        public string IdAdmin
        {
            get { return IdAdmin; }
            set { IdAdmin = value; }
        }




    }
}
