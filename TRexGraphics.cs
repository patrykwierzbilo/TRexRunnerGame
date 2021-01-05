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
        public Control GetControl()
        {
            PictureBox trex = new PictureBox();
            trex.Image = TRexRunnerGame.Properties.Resource.running;
            trex.Location = new System.Drawing.Point(60, 345);//prob 344
            trex.Name = "trex";
            trex.Size = new System.Drawing.Size(40, 43);
            trex.SizeMode = PictureBoxSizeMode.AutoSize;
            trex.TabIndex = 6;
            trex.TabStop = false;
            return trex;
        }
    }
}
