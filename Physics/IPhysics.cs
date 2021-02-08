using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRexRunnerGame
{
    interface IPhysics
    {
        void Update(IGraphics graphics);
        void SetJumping(bool val);
        bool GetJumping();
        void SetSpeed(int speed);
    }
}
