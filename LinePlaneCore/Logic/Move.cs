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
        internal static Canvas canvas
        {
            set;
            get;
        }

        static internal UIElement dragObject
        {
            get;
            set;
        }

        static private bool FirstEnter = true;

        private static Point GetOffset(MouseEventArgs e)
        {
           

            Point ShapeOffset = e.GetPosition(canvas);
            ShapeOffset.X -= Canvas.GetLeft(dragObject);
            ShapeOffset.Y -= Canvas.GetTop(dragObject);

            return ShapeOffset;
        }

        static internal void ArgsClear()
        {
            if (dragObject != null)
            {
                dragObject.IsEnabled = true;
                dragObject.Opacity = 1;
            }
            dragObject = null;
            FirstEnter = true;
        }

        static internal void Move_shape(object sender, MouseEventArgs e)
        {
            if (dragObject == null)
                return;

            Point Offset = new Point();

            if (FirstEnter)
            {
                Offset = GetOffset(e);
                dragObject.Opacity = 0.7;
                FirstEnter = false;
            }

            var position = e.GetPosition(sender as IInputElement);
            Canvas.SetTop(dragObject, position.Y - Offset.Y - (dragObject as FrameworkElement).ActualHeight / 2);
            Canvas.SetLeft(dragObject, position.X - Offset.X - (dragObject as FrameworkElement).ActualWidth / 2);

        }

    }
}
