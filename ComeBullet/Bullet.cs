using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace ComeBullet
{
    class Bullet: GameObject
    {
        /// <summary>
        /// Pontuação do bullet. Sugestão: positivo e negativo para diferenciar
        /// </summary>
        public int pontos;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="x">Posição inicial x</param>
        /// <param name="y">Posição inicial y</param>
        /// <param name="f">Formulário/janela de exibição</param>
        /// <param name="fig">Figura/recurso a ser exibido</param>
        /// <param name="p">Valor inicial em pontos</param>
        public Bullet(int x, int y, Form f, Image fig, int p): base(x,y,f,fig)
        {
            this.pontos = p;
        }
        public Bullet(): base()
        {
            
        }
        public Image retornaImagem()
        {
            return this.figura;
        }

    }
}
