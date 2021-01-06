using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRexRunnerGame
{
    interface IGraphicsBuilder
    {
        void SetName(string name);
        void SetTabIndex(int index);
        void SetTabStop(bool tabStop);
        void SetBackColor();
        void SetSizeMode();
        void SetImage(Image image);
        void SetSize(Size size);
        Size GetSize(int x, int y);
        void SetLocation(Point point);
        Point GetPoint(int x, int y);
    }
}
