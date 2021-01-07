using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRexRunnerGame
{
    abstract class State
    {
        protected TRex trex;

        public void SetContext(TRex trex)
        {
            this.trex = trex;
        }

        public abstract void Handle();
    }
}
