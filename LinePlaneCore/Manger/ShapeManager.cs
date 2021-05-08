using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LinePlaneCore.Manger
{
    static internal class ShapeManager
    {
        static internal (string, Point, string) SearchShape (string Name)
        {
            Point ShapeSize = new Point();
            string Type = null;
            string Image = null;
            int IdType = 0;

            using (var DBFurniture = new LinePlaneContext())
            {
                int IdFurniture = 0;

                foreach (var x in DBFurniture.Furnitures.Where(b=>b._FurnitureName==Name))
                {
                    IdFurniture = x._Id;
                    IdType = x._IdTipeFurniture;
                    Image = x._Picture;
                }

                foreach (var f in DBFurniture.TipeFurnitures.Where(n => n._Id == IdType))
                {
                    Type = f.FurnitureTipe;
                }

                foreach (var x in DBFurniture.Measurments.Where(v=> v._IdFurniture == IdFurniture))
                {
                    ShapeSize.X = x._Width;
                    ShapeSize.Y = x._Length;
                }

                return (Type, ShapeSize,Image);
            }
        }

    }
}
