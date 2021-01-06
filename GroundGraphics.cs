using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRexRunnerGame
{
    class GroundGraphics : IGraphics
    {
        PictureBox ground;
        public GroundGraphics()
        {
            ground = new PictureBox();
            ground.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            ground.Location = new System.Drawing.Point(0, 388);
            ground.Name = "Ground";
            ground.Size = new System.Drawing.Size(807, 63);
            ground.TabIndex = 0;
            ground.TabStop = false;
        }
        public PictureBox GetControl()
        {
            return ground;
        }

        public void SetControl(PictureBox pictureBox)
        {
            ground = pictureBox;
        }
    }
}
