﻿using System;
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
        List<Object> entities = new List<object>();
        public Game()
        {
            InitComponents();
        }

        private void InitComponents()
        {
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
            this.ResumeLayout(false);
            this.PerformLayout();
            Text = "TRex Game";
            ClientSize = new Size(800, 450);
            CenterToScreen();
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