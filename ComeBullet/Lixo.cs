using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComeBullet
{
    class Lixo
    {
        internal int racaoCriada = 0;
        internal string evento="";
        internal Lixo proximo;

        public Lixo()
        {
            this.proximo = this;
        }
        public void insereEvento(string evento)
        {
            this.evento = evento;
        }
        public void novaRacao()
        {
            this.racaoCriada++;
        }
    }
}
