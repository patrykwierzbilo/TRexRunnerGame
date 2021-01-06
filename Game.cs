using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TRexRunnerGame
{
    class Game : Form
    {
        private IContainer components = null;
        List<Object> entities = new List<object>();
        Timer gameTimer;
        bool jumping = false;
        int jumpSpeed = 10;
        int force = 12;
        int score = 0;
        int obstacleSpeed = 10;
        Random rand = new Random();
        int position;
        bool isGameOver = false;
        public Game()
        {
            InitComponents();
            GameReset();
        }

        private void InitComponents()
        {
            this.SuspendLayout();//prob out

            var director = new Director();
            var builder = new GraphicsBuilder();
            director.Builder = builder;

            director.BuildTRex();
            Graphics g = new Graphics();
            g.control = builder.GetProduct();
            Entity trex = new Entity();
            trex.graphics = (IGraphics)g;
            AddControl(trex);

            director.BuildGround();
            //g = new Graphics();
            g.control = builder.GetProduct();
            Entity ground = new Entity();
            ground.graphics = (IGraphics)g;
            AddControl(ground);


            director.BuildLittleCactus();
            //g = new Graphics();
            g.control = builder.GetProduct();
            Entity lc = new Entity();
            lc.graphics = (IGraphics)g;
            AddControl(lc);

            director.BuildLargeCactus();
            //g = new Graphics();
            g.control = builder.GetProduct();
            Entity bc = new Entity();
            bc.graphics = (IGraphics)g;
            AddControl(bc);
            //Entity score = new Entity();
            //score.graphics = new ScoreGraphics();
            //AddControl(score);
            //timer

            gameTimer = new Timer();
            gameTimer.Interval = 20;
            gameTimer.Tick += new System.EventHandler(this.GameTimerEvent);

            this.KeyDown += new KeyEventHandler(this.keyIsDown);
            this.KeyUp += new KeyEventHandler(this.keyIsUp);
            
            this.SuspendLayout();//need check

            this.ResumeLayout(false);
            this.PerformLayout();
            Text = "TRex Game";
            ClientSize = new Size(800, 450);
            CenterToScreen();
        }

        private void GameReset()
        {
            force = 12;
            jumpSpeed = 0;
            jumping = false;
            score = 0;
            obstacleSpeed = 10;
            //scoreText.Text = "Score: " + score;
            //trex.Image = Properties.Resources.running;
            isGameOver = false;
            //trex.Top = 272;//Ground.Top - trex.Height;
            
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Name.EndsWith("Cactus"))
                {
                    position = this.ClientSize.Width + rand.Next(300, 600) + (x.Width * 10);
                    x.Left = position;
                }
            }

            gameTimer.Start();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            this.Controls["trex"].Top += jumpSpeed;
            //this.Controls["scoreText"].Text = "Score: " + score;

            if (jumping == true && force < 0)
            {
                jumping = false;
            }

            if (jumping == true)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }

            if (this.Controls["trex"].Top > 344 && jumping == false)
            {
                force = 12;
                this.Controls["trex"].Top = 345;
                jumpSpeed = 0;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Name.EndsWith("Cactus"))
                {
                    x.Left -= obstacleSpeed;
                    if (x.Left /*+ x.Width*/ < -120)
                    {
                        x.Left = this.ClientSize.Width + rand.Next(200, 500);
                        score++;
                    }

                    if (this.Controls["trex"].Bounds.IntersectsWith(x.Bounds))
                    {
                        gameTimer.Stop();
                        //TODO with state pattern
                        //this.Controls["trex"].Image = Properties.Resource.dead;
                        //this.Controls["scoreText"].Text += " Press R to restart the game!";
                        isGameOver = true;
                    }
                }
            }

            if (score > 10)
            {
                obstacleSpeed = 15;
            }
        }
        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
        }
        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (jumping == true)
            {
                jumping = false;
            }

            if (e.KeyCode == Keys.R && isGameOver == true)
            {
                GameReset();
            }
        }
        void AddControl(Entity entity)
        {
            this.Controls.Add((Control)entity.graphics.GetControl());
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Game());
        }
    }
}
