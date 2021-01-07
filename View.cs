using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRexRunnerGame
{
    class View : Form, IView
    {
        public View()
        {

        }

        public void AddControl(Entity entity)
        {
            this.Controls.Add((Control)entity.graphics.GetControl());
        }

        public void AddControl(Control control)
        {
            this.Controls.Add(control);
        }

        public void AddKeyUp(KeyEventHandler key)
        {
            this.KeyUp += key;
        }
        public void AddKeyDown(KeyEventHandler key)
        {
            this.KeyDown += key;
        }

        public void SetText(string text)
        {
            this.Text = text;
        }

        public void SetClientSize(Size size)
        {
            this.ClientSize = size;
        }

        public Control.ControlCollection GetControls()
        {
            return this.Controls;
        }

        public View GetView()
        {
            return this;
        }
    }
}
