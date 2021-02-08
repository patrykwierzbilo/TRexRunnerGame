using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRexRunnerGame
{
    class TRexPhysics : IPhysics
    {
        int jumpSpeed;
        int force;
        bool jumping = false;

        public TRexPhysics()
        {
            force = 12;
            jumpSpeed = 0;
            jumping = false;
        }

        public bool GetJumping()
        {
            return jumping;
        }

        public void SetJumping(bool val)
        {
            jumping = val;
        }

        public void Update(IGraphics graphics)
        {
            graphics.GetControl().Top += jumpSpeed;

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

            if (graphics.GetControl().Top > 344 && jumping == false)
            {
                force = 12;
                graphics.GetControl().Top = 345;
                jumpSpeed = 0;
            }
        }

        public void SetSpeed(int speed)
        {
            throw new NotImplementedException();
        }
    }
}
