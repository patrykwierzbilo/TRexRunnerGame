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

        public void buildFullFeaturedProduct()
        {
            //this.builder.BuildPartA();
            //this.builder.BuildPartB();
            //this.builder.BuildPartC();
        }

    }
}
