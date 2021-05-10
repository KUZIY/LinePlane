using LinePlaneCore.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace LinePlaneCore.Logic
{
    internal class GetAllFurniture
    {
        internal static ObservableCollection<FurnitureView> GetFurnitureOnCanvas(Canvas canvas)
        {
            ObservableCollection<FurnitureView> CanvasFurniture = new();

            foreach (System.Windows.FrameworkElement x in canvas.Children)
            {
                using (var DBContext = new LinePlaneContext())
                {
                    if ((int)x.Tag != 0)
                    {
                        foreach (var o in DBContext.Furnitures.Where(obj=> obj._Id == (int)x.Tag))     
                        {
                            

                            FurnitureView NewObj = new () { nameFurniture = o._FurnitureName, furnitureURI = o._Link, price = o._Price };
                           if (CanvasFurniture.Contains(NewObj))
                            {
                                int index = CanvasFurniture.IndexOf(NewObj);
                                CanvasFurniture[index].amount++;
                                CanvasFurniture[index].price = o._Price;
                            }
                           else CanvasFurniture.Add(NewObj);
                        }
                    }
                }
            }

            return CanvasFurniture;
        }
    }
}
