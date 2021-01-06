using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TRexRunnerGame
{
    class GraphicsBuilder : IGraphicsBuilder
    {
        private PictureBox control;

        public GraphicsBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this.control = new PictureBox();
        }

        void IGraphicsBuilder.SetName(string name)
        {
            control.Name = name;
        }

        void IGraphicsBuilder.SetTabIndex(int index)
        {
            control.TabIndex = index;
        }

        void IGraphicsBuilder.SetTabStop(bool tabStop)
        {
            control.TabStop = tabStop;
        }

        void IGraphicsBuilder.SetBackColor()
        {
            control.BackColor = SystemColors.ActiveCaptionText;
        }

        void IGraphicsBuilder.SetSizeMode()
        {
            control.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        void IGraphicsBuilder.SetImage(Image image)
        {
            control.Image = image;
        }

        void IGraphicsBuilder.SetSize(Size size)
        {
            control.Size = size;
        }

        Size IGraphicsBuilder.GetSize(int x, int y)
        {
            return new Size(x, y);
        }

        void IGraphicsBuilder.SetLocation(Point point)
        {
            control.Location = point;
        }

        Point IGraphicsBuilder.GetPoint(int x, int y)
        {
            return new Point(x, y);
        }

        public PictureBox GetProduct()
        {
            PictureBox result = this.control;

            this.Reset();

            return result;
        }
    }
}
