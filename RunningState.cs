using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRexRunnerGame
{
    class RunningState : State
    {
        public override void Handle()
        {
            trex.graphics.GetControl().Image = Properties.Resource.running;
        }
    }
}
