using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinePlaneCore.Logic
{
    internal class SwitchStateShapes
    {
        internal static void ChangeShapeState (System.Windows.Controls.Canvas obj, bool state)
        {
            for (int i = 0; i < obj.Children.Count; ++i)
            {
                var s = obj.Children[i];
                s.IsEnabled = state;
            }
        }
    }
}
