using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TRexRunnerGame
{
    class Game
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
        public int viewWidthSize;
        public IView view = new View();

        public Game()
        {
            InitComponents();
            GameReset();
        }

        private void InitComponents()
        {
            var director = new Director();
            var builder = new GraphicsBuilder();
            director.Builder = builder;
            PhysicsFactory physicsFactory = new PhysicsFactory();

            director.BuildTRex();
            Graphics g = new Graphics();
            g.control = builder.GetProduct();
            trex = TRex.GetInstance();
            trex.graphics = g;
            trex.physics = physicsFactory.CreatePhysics("trex", trex.graphics, this);
            view.AddControl(trex);

            director.BuildGround();
            g = new Graphics();
            g.control = builder.GetProduct();
            ground = new Entity();
            ground.graphics = g;
            view.AddControl(ground);

            director.BuildLittleCactus();
            g = new Graphics();
            g.control = builder.GetProduct();
            littleCactus = new Entity();
            littleCactus.graphics = g;
            littleCactus.physics = physicsFactory.CreatePhysics("obstacle", littleCactus.graphics, this);
            view.AddControl(littleCactus);

            director.BuildLargeCactus();
            g = new Graphics();
            g.control = builder.GetProduct();
            largeCactus = new Entity();
            largeCactus.graphics = g;
            largeCactus.physics = physicsFactory.CreatePhysics("obstacle", largeCactus.graphics, this);
            view.AddControl(largeCactus);

            //score
            scoreGraphics = new ScoreGraphics();
            view.AddControl(scoreGraphics.GetControl());

            //timer
            gameTimer = new Timer();
            gameTimer.Interval = 20;
            gameTimer.Tick += new EventHandler(this.GameTimerEvent);

            view.AddKeyDown(new KeyEventHandler(this.keyIsDown));
            view.AddKeyUp(new KeyEventHandler(this.keyIsUp));
            view.SetText("TRex Game");
            viewWidthSize = 800;
            view.SetClientSize(new Size(800, 450));
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
        
        public void IncreaseObstacleSpeed()
        {
            littleCactus.physics.SetSpeed(15);
            largeCactus.physics.SetSpeed(15);
        }
        public void IncreaseMaxObstacleSpeed()
        {
            littleCactus.physics.SetSpeed(20);
            largeCactus.physics.SetSpeed(20);
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
            scoreGraphics.GetControl().Text += " Press R to restart the game!";
            isGameOver = true;
        }
    }
}
