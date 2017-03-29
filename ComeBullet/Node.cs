using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComeBullet
{
    class Node
    {
        public Bullet obj;
        public Node prox;
        public Lixo lixo;

        public Node(Bullet Obj, Node Prox)
        {
            this.obj = Obj;
            prox = Prox;
        }
        public Node()
        {
            obj = null;
            lixo = null;
            prox = null;
        }
    }
}