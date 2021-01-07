using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TRexRunnerGame
{
    class Game : Form
    {
        Timer gameTimer;
        ILevelStrategy level;
        Score score;
        ScoreGraphics scoreGraphics;
        bool isGameOver = false;
        TRex trex;
        Entity ground;
        Entity littleCactus;
        Entity largeCactus;

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
            trex = TRex.GetInstance();
            trex.graphics = g;
            trex.physics = new TRexPhysics();
            AddControl(trex);

            director.BuildGround();
            g = new Graphics();
            g.control = builder.GetProduct();
            ground = new Entity();
            ground.graphics = g;
            AddControl(ground);


            director.BuildLittleCactus();
            g = new Graphics();
            g.control = builder.GetProduct();
            littleCactus = new Entity();
            littleCactus.graphics = g;
            littleCactus.physics = new ObstaclePhysics(littleCactus.graphics, this);
            AddControl(littleCactus);

            director.BuildLargeCactus();
            g = new Graphics();
            g.control = builder.GetProduct();
            largeCactus = new Entity();
            largeCactus.graphics = g;
            largeCactus.physics = new ObstaclePhysics(largeCactus.graphics, this);
            AddControl(largeCactus);

            //score
            scoreGraphics = new ScoreGraphics();
            this.Controls.Add((Control)scoreGraphics.GetControl());

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
            score = new Score(this);
            scoreGraphics.GetControl().Text = "Score: " + score.GetScore();
            isGameOver = false;

            trex.TransitionTo(new RunningState());
            trex.physics = new TRexPhysics();
            littleCactus.physics = new ObstaclePhysics(littleCactus.graphics, this);
            largeCactus.physics = new ObstaclePhysics(largeCactus.graphics, this);

            //level = new FirstLevel(this);
            gameTimer.Start();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            trex.physics.Update(trex.graphics);
            littleCactus.physics.Update(littleCactus.graphics);
            largeCactus.physics.Update(largeCactus.graphics);

            if (level != null)
            {
                level.IncreaseDifficultyLevel();
            }
        }
        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && trex.physics.GetJumping() == false)
            {
                trex.physics.SetJumping(true);
            }
        }
        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (trex.physics.GetJumping() == true)
            {
                trex.physics.SetJumping(false);
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

        public void IncreaseObstacleSpeed()
        {
            littleCactus.physics.SetSpeed(15);
            largeCactus.physics.SetSpeed(15);
            //obstacleSpeed = 15;
        }
        public void IncreaseMaxObstacleSpeed()
        {
            littleCactus.physics.SetSpeed(20);
            largeCactus.physics.SetSpeed(20);
            //obstacleSpeed = 20;
        }
        public void SetLevel(ILevelStrategy level)
        {
            this.level = level;
        }

        public void IncrementScore()
        {
            score.Increment();
            scoreGraphics.GetControl().Text = "Score: " + score.GetScore();
        }

        public void StopGame()
        {
            gameTimer.Stop();
            trex.TransitionTo(new DeathState());
            //TODO with state pattern
            //this.Controls["trex"].Image = Properties.Resource.dead;
            scoreGraphics.GetControl().Text += " Press R to restart the game!";
            isGameOver = true;
        }
    }
}
