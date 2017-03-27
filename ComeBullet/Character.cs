using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ComeBullet
{
    class Character: GameObject
    {

        private int direcao;
        private int velocidade;
        private Image[] figuras;


        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="x">Posição inicial x</param>
        /// <param name="y">Posição inicial y</param>
        /// <param name="f">Formulário/janela de exibição</param>
        /// <param name="fig">Vetor com 4 figuras/recursos, na ordem: cima, direita, baixo, esquerda</param>
        public Character(int x, int y, Form f, Image[] fig) : base(x, y, f, fig[1])
        {
            this.figuras = fig;
            this.direcao = 1;
            this.velocidade = 1;
        }

        public int getVelocidade()
        {
            return velocidade;
        }   

        /// <summary>
        /// Altera velocidade do personagem, em 3*v pixels por frame
        /// </summary>
        /// <param name="v">Nova velocidade</param>
        public void setVelocidade(int v)
        {
            if (v > 0) this.velocidade = v; 
        }

        /// <summary>
        /// Retorna a direção do personagem:
        /// 0 - cima
        /// 1 - direita
        /// 2 - baixo
        /// 3 - esquerda
        /// </summary>
        /// <returns>0 - cima
        /// 1 - direita
        /// 2 - baixo
        /// 3 - esquerda</returns>
        public int getDirecao()
        {
            return direcao;
        }

        /// <summary>
        /// Muda a direção do personagem:
        /// 0 - cima
        /// 1 - direita
        /// 2 - baixo
        /// 3 - esquerda
        /// A figura também é alterada
        /// </summary>
        /// <returns>0 - cima
        /// 1 - direita
        /// 2 - baixo
        /// 3 - esquerda</returns>
        public void mudarDirecao(int d)
        {
            if(d>=0 && d <= 3)
            {
                this.direcao = d;
                this.setFigura(figuras[d]);
            }
        }

        public Character(): base() { }

        /// <summary>
        /// Atualiza a posição do personagem, de acordo com sua direção e velocidade
        /// </summary>
        public void atualizarPos()
        {
            switch (direcao)
            {
                case 0: setPos(this.posX, this.posY - 3 * this.velocidade);
                    break;
                case 1: setPos(this.posX + 3 * this.velocidade, this.posY);
                    break;
                case 2: setPos(this.posX, this.posY + 3 * this.velocidade);
                    break;
                case 3: setPos(this.posX - 3 * this.velocidade, this.posY);
                    break;
            }
        }
        
    }
}
