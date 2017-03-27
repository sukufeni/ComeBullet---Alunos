using System.Windows.Forms;
using System.Drawing;
namespace ComeBullet
{
    class GameObject
    {
        /// <summary>
        /// Figura exibida. Deve ser um recurso do projeto.
        /// </summary>
        protected Image figura;

        /// <summary>
        /// PictureBox que exibe a figura do objeto
        /// </summary>
        protected PictureBox box;

        /// <summary>
        /// Posição x na tela
        /// </summary>
        protected int posX;

        /// <summary>
        /// Posição y na tela
        /// </summary>
        protected int posY;

            private void Init(int x = 0, int y = 0, Form f = null, Image fig = null)
            {
                this.figura = Properties.Resources.greenBullet;
                this.box = new PictureBox();
                this.box.SizeMode = PictureBoxSizeMode.AutoSize;
                if (fig != null) this.setFigura(fig);
                if (f != null) this.setBox(f);
                this.setPos(x, y);
            }

        public int retornaX()
        {
            return this.posX;
        }
        public int retornaY()
        {
            return this.posY;
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="x">Posição x</param>
        /// <param name="y">Posição y</param>
        /// <param name="f">Form/janela para mostrar o objeto</param>
        /// <param name="fig">Figura/recurso a ser mostrado</param>
        public GameObject(int x, int y, Form f, Image fig)
            {
                this.Init(x, y, f, fig);
            }

            public GameObject()
            {
                this.Init();
            }

            /// <summary>
            /// Coloca como invisível e apaga o objeto da memória
            /// </summary>
            public void apagar()
            {
                this.box.Visible = false;
                this.box.Dispose();
            }

        /// <summary>
        /// Associa o objeto a uma form/janela
        /// </summary>
        /// <param name="f"></param>
            public void setBox(Form f)
            {
                f.Controls.Add(this.box);
                this.box.Parent = f;
                this.box.Visible = true;
            }

        /// <summary>
        /// Altera a figura do objeto
        /// </summary>
        /// <param name="fig">Imagem/recurso a ser exibido</param>
            public void setFigura(Image fig)
            {
                this.figura = fig;
                this.box.Image = this.figura;
            }

        /// <summary>
        /// Altera a posição x,y do objeto
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
            public void setPos(int x, int y)
            {
                this.posX = x;
                this.posY = y;
                this.box.Location = new Point(this.posX, this.posY);
            }

        /// <summary>
        /// Desloca o objeto em x,y pixels da posição atual
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
            public void move(int x, int y)
            {
                this.posX += x;
                this.posY += y;
                this.box.Location = new Point(this.posX, this.posY);
            }

            private bool centroIgual(GameObject obj2)
            {
                int centro1x = this.box.Left + (this.box.Width / 2);
                int centro1y = this.box.Top + (this.box.Height / 2);

                int centro2x = obj2.box.Left + (obj2.box.Width / 2);
                int centro2y = obj2.box.Top + (obj2.box.Height / 2);

                if ((centro1x == centro2x) && (centro1y == centro2y)) return true;
                else return false;
            }

        /// <summary>
        /// Verifica se há sobreposição/colisão com outro objeto
        /// </summary>
        /// <param name="obj2">O outro objeto a ser verificado</param>
        /// <returns></returns>
            public bool sobreposicao(GameObject obj2)
            {
                int centro1x = this.box.Left + (this.box.Width / 2);
                int centro1y = this.box.Top + (this.box.Height / 2);

                int limiteX1 = obj2.box.Left;
                int limiteX2 = limiteX1 + obj2.box.Width;

                int limiteY1 = obj2.box.Top;
                int limiteY2 = limiteY1 + obj2.box.Height;

                if ((centro1x > limiteX1) && (centro1x < limiteX2)
                    &&
                    (centro1y > limiteY1) && (centro1y < limiteY2))
                    return true;
                else return false;
            }
        }
    }

