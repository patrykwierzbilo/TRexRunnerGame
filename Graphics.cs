using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRexRunnerGame
{
    class Graphics : IGraphics
    {
        public PictureBox control;

        public Graphics()
        {
            control = new PictureBox();
        }

        public PictureBox GetControl()
        {
            return control;
        }

        public void SetControl(PictureBox pictureBox)
        {
            control = pictureBox;
        }
    }
}
