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
        Random aleatorio = new Random();
        ListaBola lista = new ListaBola();
        ListaLixo lixo = new ListaLixo();
        int velocidade = 1;
        int bolinhas = 0;
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
            this.bolinhas = 0;
            this.velocidade = 1;
            int y = aleatorio.Next(30, 410);
            int x = aleatorio.Next(30, 160);
            personagem = new Character(x, y, this, figuras);
            personagem.move(x, y);
            personagem.setVelocidade(velocidade);
        }
        private void adicionaBolas()
        {
            red = new Bullet(aleatorio.Next(30, 620), aleatorio.Next(30, 460), this, Properties.Resources.redBullet, 1);
            for (int u=1; u <= 5; u++)
            {
                green = new Bullet(aleatorio.Next(30,620), aleatorio.Next(30, 460), this, Properties.Resources.greenBullet, 1);
                lista.insereFinal(green);
                lixo.insereOcorrencia("racao criada");
            }
            lista.insereFinal(red);
            lixo.insereOcorrencia("racao criada vermelha");
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
            adicionaBolas();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            personagem.atualizarPos();
            if (retiraRacao() == null || margem())
            {
                this.timer2.Stop();
                this.timer2.Enabled = false;
                MessageBox.Show("fim! bolinhas comidas: "+bolinhas);
            }
        }
        private bool margem()
        {
            if ((this.personagem.retornaY() > 675 || this.personagem.retornaX() > 1305 || this.personagem.retornaX() < -15) || this.personagem.retornaY() < -5)
            {
                personagem.apagar();
                while (lista.percorrerLista() != null)
                {
                    Bullet x = lista.percorrerLista();
                    x.apagar();
                    lista.retiraItem(x);
                }
                return true;
            }
            return false;
        }
        private Node retiraRacao()
        {
            Node aux = lista.retornaSentinela();
            while (aux.prox != null)
            {
                aux = aux.prox;
                if (personagem.sobreposicao(aux.obj))
                {
                    if(aux.obj.retornaX() == red.retornaX() && aux.obj.retornaY() == red.retornaY())
                    {
                        adicionaBolas();
                        personagem.setVelocidade(velocidade++);
                    }
                    else
                    {
                        aux.obj.apagar();
                        lista.retiraItem(aux.obj);
                        this.bolinhas++;
                    }
                }
            }
            return aux;
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
