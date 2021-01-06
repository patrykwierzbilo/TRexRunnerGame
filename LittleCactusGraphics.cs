using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRexRunnerGame
{
    class LittleCactusGraphics : IGraphics
    {
        PictureBox littleCactus;
        public LittleCactusGraphics()
        {
            littleCactus = new PictureBox();
            littleCactus.Image = Properties.Resource.littleCactus;
            littleCactus.Location = new System.Drawing.Point(425, 355);
            littleCactus.Name = "littleCactus";
            littleCactus.Size = new System.Drawing.Size(23, 46);
            littleCactus.SizeMode = PictureBoxSizeMode.AutoSize;
            littleCactus.TabIndex = 1;
            littleCactus.TabStop = false;
        }
        public PictureBox GetControl()
        {
            return littleCactus;
        }

        public void SetControl(PictureBox pictureBox)
        {
            littleCactus = pictureBox;
        }
    }
}
