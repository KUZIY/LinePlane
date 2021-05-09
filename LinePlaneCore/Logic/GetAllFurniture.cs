using LinePlaneCore.Model;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace LinePlaneCore.Logic
{
    internal class GetAllFurniture
    {
        internal static ObservableCollection<FurnitureView> GetFurnitureOnCanvas(Canvas canvas)
        {
            ObservableCollection<FurnitureView> CanvasFurniture=new ();

            foreach (FrameworcElement x in canvas.Children)
            {

            }
        }
    }
}
