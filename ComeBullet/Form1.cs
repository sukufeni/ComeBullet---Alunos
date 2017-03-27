using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComeBullet
{
    public partial class Form1 : Form
    {
        Image[] figuras = { Properties.Resources.cheepcheep4, Properties.Resources.cheepcheep2, Properties.Resources.cheepcheep3, Properties.Resources.cheepcheep1 };
        Bullet red,green;
        Character personagem;
        ListaBola lista = new ListaBola();
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            carregaPeixePassaro();
            adicionaBolas();
        }

        private void carregaPeixePassaro()
        {
            int x = this.Size.Height / 6;
            int y = this.Size.Width / 4;
            personagem = new Character(x, y, this, figuras);
            personagem.move(x, y);
            personagem.setVelocidade(5);
        }
        private void adicionaBolas()
        {
            int x = this.Size.Height / 6;
            int y = this.Size.Width / 4;
            Random aleatorio = new Random();
            green = new Bullet(aleatorio.Next(this.Width - 50), aleatorio.Next(this.Height - 50), this, Properties.Resources.greenBullet, 1);
            for (int u=0; u <= 5; u++)
            {
                red = new Bullet(aleatorio.Next(this.Width - 50), aleatorio.Next(this.Height - 50), this, Properties.Resources.redBullet, 1);
                lista.insereFinal(red);
            }
        }
        private void Form1_DoubleClick(object sender, EventArgs e)
        {   

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        
        }
        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            carregaPeixePassaro();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            personagem.atualizarPos();
            lista.retiraItem(lista.busca(personagem));
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Up)://0
                    personagem.mudarDirecao(0);
                    break;
                case (Keys.Down)://2
                    personagem.mudarDirecao(2);
                    break;
                case (Keys.Left)://3
                    personagem.mudarDirecao(3);
                    break;
                case (Keys.Right)://4
                    personagem.mudarDirecao(1);
                    break;
            }
        }
    }
}
