using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_WPF
{
    class Createur
    {
        private string idcrea;
        private int nbcommmandes;

        public Createur(string idcrea, int nbcommmandes)
        {
            this.idcrea = idcrea;
            this.nbcommmandes = nbcommmandes;
        }

        public string IdCrea
        {
            get { return idcrea; }
            set { idcrea = value; }
        }
        public int NbCommandes
        {
            get { return nbcommmandes; }
            set { nbcommmandes = value; }
        }

    }
}
