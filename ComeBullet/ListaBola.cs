using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComeBullet
{
    class ListaBola
    {
        Node sentinela;

        internal Node Sentinela { get => this.sentinela; set => this.sentinela = value; }

        public ListaBola()
        { 
            Node x = new Node();
            Sentinela = x;
        }
        public void insereFinal(Bullet obj)
        {
            Node aux = sentinela;
            while (aux.prox != null)
            {
                aux = aux.prox;
            }
            Node novo = new Node(obj, null);
            aux.prox = novo;
        }

        public Bullet percorrerLista()
        {
            Node aux = Sentinela;
            while (aux.prox != null)
            {
                aux = aux.prox;
                return aux.obj;
            }
            return null;
        }
        public Node retornaSentinela()
        {
            return Sentinela;
        }
        public Bullet retiraItem(Bullet item)
        {
            Node aux = sentinela;
            while (aux.prox != null)
            {
                Node aux2 = aux;
                aux = aux.prox;
                if (aux.obj == item)
                {
                    aux2.prox = aux.prox;
                    aux.prox = null;
                    return aux.obj;
                }
            }
            return null;
        }
    }
}