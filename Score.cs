using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRexRunnerGame
{
    class Score
    {
        int score;
        IMediator mediator;

        public Score(Game game)
        {
            score = 0;
            mediator = new LevelMediator(game);
        }

        public void Increment()
        {
            score++;
            if (score > 3)
            {
                mediator.Notify(this, "First");
            }
            if (score > 8)
            {
                mediator.Notify(this, "Second");
            }
        }

        public int GetScore()
        {
            return score;
        }

    }
}
