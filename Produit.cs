using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_WPF
{
    class Produit
    {
		public string nomProduit { get; set; }
		public string categorieProduit { get; set; }
		public int stockActuel { get; set; }
		public int stockMin { get; set; }
		public int stockMax { get; set; }
		public string unite { get; set; }

		public Produit(string nomProduit, string categorieProduit, int stockActuel, int stockMin, int stockMax, string unite)
		{
			this.nomProduit = nomProduit;
			this.categorieProduit = categorieProduit;
			this.stockActuel = stockActuel;
			this.stockMin = stockMin;
			this.stockMax = stockMax;
			this.unite = unite;
		}
	}
}
