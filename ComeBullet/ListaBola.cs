using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComeBullet
{
    class ListaBola
    {
        Node sentinela,ultimo;

        internal Node Sentinela { get => this.sentinela; set => this.sentinela = value; }

        public ListaBola()
        { 
            Node x = new Node();
            Sentinela = x;
            ultimo = sentinela;
        }
        public void insereFinal(Bullet obj)
        {
            if(Sentinela == null)
            {
                Node aux = new Node(obj, null);
                Sentinela.prox = aux;
                ultimo = aux;
            }
            else
            {
                Node aux = Sentinela;
                while (aux.prox != null)
                {
                    aux = aux.prox;
                }
                Node novo = new Node(obj, null);
                aux.prox = novo;
                ultimo = aux;
            }
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
        public Node retiraItem(Node item)
        {
            Node aux = this.Sentinela;
                while(aux.prox != null)
                {
                    if(item != null)
                    {
                        if (aux.prox.obj == item.obj)
                        {
                            Node aux2 = aux.prox;
                            aux.prox = aux2.prox;
                            aux2.obj.apagar();
                            aux2.prox = null;
                            return aux;
                        }
                        else
                        {
                            aux = aux.prox;
                        }   
                    }
                    else return null;
                }
            return aux;
        }
        public Node busca(Character item)
        {
            Node aux = new Node(sentinela.obj, null);
            aux = sentinela.prox;
            if(aux == this.ultimo)
            {

            }
            else
            {
                while (aux.prox != null)
                {
                    if (item.sobreposicao(aux.obj))
                    {
                        return aux;
                    }
                    aux = aux.prox;
                }
                return null;
            }
        }
    }
}