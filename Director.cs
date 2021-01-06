using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRexRunnerGame
{
    class Director
    {
        private IGraphicsBuilder builder;

        public IGraphicsBuilder Builder
        {
            set { builder = value; }
        }

        public void BuildTRex()
        {
            builder.SetName("trex");
            builder.SetLocation(builder.GetPoint(60, 345));//prob 344
            builder.SetImage(Properties.Resource.running);
            builder.SetSize(builder.GetSize(40, 43));
            builder.SetSizeMode();
            builder.SetTabIndex(6);
            builder.SetTabStop(false);
        }

        public void BuildGround()
        {
            builder.SetName("ground");
            builder.SetLocation(builder.GetPoint(0, 388));
            builder.SetBackColor();
            builder.SetSize(builder.GetSize(807, 63));
            builder.SetTabIndex(0);
            builder.SetTabStop(false);
        }

        public void BuildLittleCactus()
        {
            builder.SetName("littleCactus");
            builder.SetLocation(builder.GetPoint(425, 355));
            builder.SetImage(Properties.Resource.littleCactus);
            builder.SetSize(builder.GetSize(23, 46));
            builder.SetSizeMode();
            builder.SetTabIndex(1);
            builder.SetTabStop(false);
        }

        public void BuildLargeCactus()
        {
            builder.SetName("largeCactus");
            builder.SetLocation(builder.GetPoint(636, 347));
            builder.SetImage(Properties.Resource.largeCactus);
            builder.SetSize(builder.GetSize(32, 33));
            builder.SetSizeMode();
            builder.SetTabIndex(3);
            builder.SetTabStop(false);
        }
    }
}
