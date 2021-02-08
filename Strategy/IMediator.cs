using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRexRunnerGame
{
    interface IMediator
    {
        void Notify(object sender, string ev);
    }
}
