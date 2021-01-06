using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRexRunnerGame
{
    class LevelMediator : IMediator
    {
        Game game;

        public LevelMediator(Game game)
        {
            this.game = game;
        }

        public void Notify(object sender, string ev)
        {
            if(ev == "First")
            {
                game.SetLevel(new FirstLevel(game));
            }
            if (ev == "Second")
            {
                game.SetLevel(new SecondLevel(game));
            }
        }
    }
}
