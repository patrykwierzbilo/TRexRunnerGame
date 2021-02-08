using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRexRunnerGame
{
    class TRex : Entity
    {
        State state;

        private TRex() { }
        private static TRex _instance;
        public static TRex GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TRex();
            }
            return _instance;
        }

        public void TransitionTo(State state)
        {
            this.state = state;
            this.state.SetContext(this);
            state.Handle();
        }
    }
}
