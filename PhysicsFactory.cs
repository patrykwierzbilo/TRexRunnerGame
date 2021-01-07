using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRexRunnerGame
{
    class PhysicsFactory
    {
        public IPhysics CreatePhysics(String type, IGraphics graphics, Game game)
        {
            if(type == "trex")
            {
                return new TRexPhysics();
            }
            else if(type == "obstacle")
            {
                return new ObstaclePhysics(graphics, game);
            }
            return null;
        }
    }
}
