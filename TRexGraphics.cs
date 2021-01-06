using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRexRunnerGame
{
    class TRexGraphics : IGraphics
    {
        PictureBox trex;
        public TRexGraphics()
        {
            trex = new PictureBox();
            trex.Image = Properties.Resource.running;
            trex.Location = new System.Drawing.Point(60, 345);//prob 344
            trex.Name = "trex";
            trex.Size = new System.Drawing.Size(40, 43);
            trex.SizeMode = PictureBoxSizeMode.AutoSize;
            trex.TabIndex = 6;
            trex.TabStop = false;
        }

        public PictureBox GetControl()
        {
            return trex;
        }

        public void SetControl(PictureBox pictureBox)
        {
            trex = pictureBox;
        }
    }
}
