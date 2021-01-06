using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRexRunnerGame
{
    class ScoreGraphics : IGraphics
    {
        Label scoreText;
        public ScoreGraphics()
        {
            scoreText = new Label();
            scoreText.AutoSize = true;
            scoreText.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, 
                                                    System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            scoreText.Location = new System.Drawing.Point(45, 31);
            scoreText.Name = "scoreText";
            scoreText.Size = new System.Drawing.Size(135, 33);
            scoreText.TabIndex = 5;
            scoreText.Text = "Score: 0";
        }

        public Control GetControl()
        {
            return scoreText;
        }
    }
}
