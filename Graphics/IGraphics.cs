using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRexRunnerGame
{
    interface IGraphics
    {
        PictureBox GetControl();
        void SetControl(PictureBox pictureBox);
    }
}
