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
        int clientSize;
        Game game;

        public ObstaclePhysics(IGraphics graphics, Game game)
        {
            this.game = game;
            clientSize = game.ClientSize.Width;
            obstacleSpeed = 10;
            int position = renderPosition(graphics.GetControl().Width);//clientSize + rand.Next(300, 600) + (graphics.GetControl().Width * 10);
            graphics.GetControl().Left = position;
        }

        int renderPosition(int width)
        {
            return clientSize + rand.Next(300, 600) + (width * 10);
        }

        public void Update(IGraphics graphics)
        {
            PictureBox entity = graphics.GetControl();
            entity.Left -= obstacleSpeed;
            if (entity.Left /*+ x.Width*/ < -120)
            {
                entity.Left = renderPosition(entity.Width);
                game.IncrementScore();
            }
            if (game.Controls["trex"].Bounds.IntersectsWith(entity.Bounds))
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
