using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRexRunnerGame
{
    class FirstLevel : ILevelStrategy
    {
        Game game;

        public FirstLevel(Game game)
        {
            this.game = game;
        }
        public void IncreaseDifficultyLevel()
        {
            game.IncreaseObstacleSpeed();
        }
    }
}
