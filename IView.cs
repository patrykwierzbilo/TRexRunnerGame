using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Form;

namespace TRexRunnerGame
{
    interface IView
    {
        View GetView();
        Control.ControlCollection GetControls();
        void AddControl(Entity entity);
        void AddControl(Control control);
        void AddKeyUp(KeyEventHandler key);
        void AddKeyDown(KeyEventHandler key);
        void SetText(string text);
        void SetClientSize(Size size);
    }
}
