using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRexRunnerGame.Game
{
    class Game
    {
        private TRexRunnerGame.Game.Score.IMediator mediator;
        private IStrategy strategy;
        private Graphics.IGraphicsComponent graphics;
        private Input.IInputComponent input;
    }
}
