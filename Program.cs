using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRexRunnerGame
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Game game = new Game();
            Application.EnableVisualStyles();
            Application.Run(game.view.GetView());
        }
    }
}
