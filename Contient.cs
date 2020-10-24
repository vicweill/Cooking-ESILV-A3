using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_WPF
{
    class Contient
    {
        private string nomrecette;
        private int stock;
        private string unite;

        public Contient(string nomrecette, int stock, string unite)
        {
            this.nomrecette = nomrecette;
            this.stock = stock;
            this.unite = unite;
        }

        public string NomRecette
        {
            get { return nomrecette; }
            set { nomrecette = value; }
        }
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        public string Unite
        {
            get { return unite; }
            set { unite = value; }
        }

    }
}
