using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRexRunnerGame
{
    class ObstaclePhysics : IPhysics
    {
        int obstacleSpeed;
        Random rand = new Random();
        Game game;

        public ObstaclePhysics(IGraphics graphics, Game game)
        {
            this.game = game;
            obstacleSpeed = 10;
            int position = renderPosition(graphics.GetControl().Width);
            graphics.GetControl().Left = position;
        }

        int renderPosition(int width)
        {
            return game.viewWidthSize + rand.Next(300, 600) + (width * 10);
        }

        public void Update(IGraphics graphics)
        {
            PictureBox entity = graphics.GetControl();
            entity.Left -= obstacleSpeed;
            if (entity.Right < 0)
            {
                entity.Left = renderPosition(entity.Width);
                game.IncrementScore();
            }
            if (game.view.GetControls()["trex"].Bounds.IntersectsWith(entity.Bounds))
            {
                game.StopGame();
            }
        }

        public bool GetJumping()
        {
            throw new NotImplementedException();
        }

        public void SetJumping(bool val)
        {
            throw new NotImplementedException();
        }

        public void SetSpeed(int speed)
        {
            this.obstacleSpeed = speed;
        }
    }
}
