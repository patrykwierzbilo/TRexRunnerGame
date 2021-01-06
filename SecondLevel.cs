using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRexRunnerGame
{
    class SecondLevel : ILevelStrategy
    {
        Game game;

        public SecondLevel(Game game)
        {
            this.game = game;
        }

        public void IncreaseDifficultyLevel()
        {
            game.IncreaseMaxObstacleSpeed();
        }
    }
}
