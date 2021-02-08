using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRexRunnerGame
{
    class Entity
    {
        public IGraphics graphics;
        public IPhysics physics;

        Control getControl()
        {
            return graphics.GetControl();
        }

        void Update()
        {
            physics.Update(graphics);
        }
    }
}