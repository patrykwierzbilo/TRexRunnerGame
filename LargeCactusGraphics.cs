using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRexRunnerGame
{
    class LargeCactusGraphics : IGraphics
    {
        PictureBox largeCactus;
        public LargeCactusGraphics()
        {
            largeCactus = new PictureBox();
            largeCactus.Image = Properties.Resource.largeCactus;
            largeCactus.Location = new System.Drawing.Point(636, 347);
            largeCactus.Name = "largeCactus";
            largeCactus.Size = new System.Drawing.Size(32, 33);
            largeCactus.SizeMode = PictureBoxSizeMode.AutoSize;
            largeCactus.TabIndex = 3;
            largeCactus.TabStop = false;
        }
        public PictureBox GetControl()
        {
            return largeCactus;
        }

        void IGraphics.SetControl(PictureBox pictureBox)
        {
            largeCactus = pictureBox;
        }
    }
}
