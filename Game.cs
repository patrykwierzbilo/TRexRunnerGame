using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Entity ground = new Entity();
            ground.graphics = new GroundGraphics();
            AddControl(ground);
            Entity trex = new Entity();
            trex.graphics = new TRexGraphics();
            AddControl(trex);
            Entity lc = new Entity();
            lc.graphics = new LittleCactusGraphics();
            AddControl(lc);
            Entity bc = new Entity();
            bc.graphics = new LargeCactusGraphics();
            AddControl(bc);
            Entity score = new Entity();
            score.graphics = new ScoreGraphics();
            AddControl(score);
            //timer

            //((ISupportInitialize)(ground.graphics.GetControl())).BeginInit();
            //((ISupportInitialize)(bc.graphics.GetControl())).BeginInit();
            //((ISupportInitialize)(lc.graphics.GetControl())).BeginInit();
            //((ISupportInitialize)(trex.graphics.GetControl())).BeginInit();
            gameTimer = new Timer();
            gameTimer.Interval = 20;
            gameTimer.Tick += new System.EventHandler(this.GameTimerEvent);

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyIsUp);
            
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

        }
        private void keyIsDown(object sender, KeyEventArgs e)
        {

        }
        private void keyIsUp(object sender, KeyEventArgs e)
        {

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
