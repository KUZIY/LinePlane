using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
namespace LinePlaneCore
{
    static internal class Move
    {
        static internal UIElement dragObject
        {
            get;
            set;
        }
        static internal Point Offset 
        { 
            get;
            set;

        }

        static internal void ArgsClear()
        {
            dragObject = null;
            Offset = new Point(0, 0);
        }

        static internal void Move_shape(object sender, MouseEventArgs e)
        {
            if (dragObject == null)
                return;

            var position = e.GetPosition(sender as IInputElement);
            Canvas.SetTop(dragObject, position.Y - Offset.Y);
            Canvas.SetLeft(dragObject, position.X - Offset.X);

        }

    }
}
