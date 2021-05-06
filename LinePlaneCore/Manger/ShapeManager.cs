using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinePlaneCore.Manger
{
    static internal class ShapeManager
    {
        static internal (string, Point) SearchShape (string Name)
        {
            Point ShapeSize = new Point();
            string Type = null;

            using (var DBFurniture = new LinePlaneContext())
            {
                int IdFurniture = 0;

                foreach (var x in DBFurniture.Furnitures.Where(b=>b._FurnitureName==Name))
                {
                    IdFurniture = x._Id;
                    Type = x._TipeFurniture.FurnitureTipe;
                }

                foreach (var x in DBFurniture.Measurments.Where(v=> v._IdFurniture == IdFurniture))
                {
                    ShapeSize.X = x._Width;
                    ShapeSize.Y = x._Length;
                }
                return (Type, ShapeSize);
            }
        }

    }
}
