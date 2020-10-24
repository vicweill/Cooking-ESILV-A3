using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_WPF
{
    class Panier
    {
        private string nomrecette;
        private string prix;
        private string photo;
        private string quantite;

        public Panier(string nomrecette, string prix, string photo, string quantite)
        {
            this.nomrecette = nomrecette;
            this.prix = prix;
            this.photo = photo;
            this.quantite = quantite;
        }

        public string NomRecette
        {
            get { return nomrecette; }
            set { nomrecette = value; }
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
        public string Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }
    }
}
