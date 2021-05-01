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
    internal static class Show_Ander_Strip
    {

        static internal UIElement Object
        {
            get;
            set;
        }

        internal static void Show_button_strip_menu(MainWindow _window)
        {
            if (Object == null) 
            {
                _window.understrip.Visibility = Visibility.Hidden;
                return;
            }

            bool Up_or_Top = false;
            double shape_widith=0;
            double shape_height = 0;

            try
            {
                shape_widith = (Object as Rectangle).Width;
                shape_height = (Object as Rectangle).Height;

                Up_or_Top = _window.canvas.ActualHeight - Canvas.GetTop(Object) - (Object as Rectangle).Height > _window.understrip.ActualHeight;
            }
            catch 
            {

                shape_widith = (Object as Ellipse).Width;
                shape_height = (Object as Ellipse).Height;

                Up_or_Top = _window.canvas.ActualHeight - Canvas.GetTop(Object) - (Object as Ellipse).Height > _window.understrip.ActualHeight;

            }
            finally
            {
                if (Up_or_Top == true)
                {
                    var my_margin = _window.understrip.Margin;
                    my_margin.Left= Canvas.GetLeft(Object) + shape_widith / 2;
                    my_margin.Top= Canvas.GetTop(Object) + shape_height / 2;
                    _window.understrip.Margin = my_margin;
                }
                else
                {
                    var my_margin = _window.understrip.Margin;
                    my_margin.Left = Canvas.GetLeft(Object) + shape_widith / 2;
                    my_margin.Top = Canvas.GetTop(Object) - shape_height / 2;
                    _window.understrip.Margin = my_margin;
                }

                _window.understrip.Visibility = Visibility.Visible;
            }

            //Object = null;

        } 

    }
}
