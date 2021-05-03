using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LinePlaneCore
{
    internal static class SearchDBClass
    {
        static internal (double, double) Search_in_DB(string RoomName, string FurnitureName)
        {
            int RoomId = 1;
            int NameId = 0;
            int MainID = 0;


            using (LinePlaneContext F_Name_BD = new LinePlaneContext())
            {


         //     foreach (var x in F_Name_BD.Rooms.Where(x => x._NameRoom.ToLower().Trim() == RoomName.ToLower().Trim()))
         //     {
         //         RoomId = x._Id;
         //     }
         //
         //
         //     foreach (var x in F_Name_BD.TipeFurnitures.Where(x => x.FurnitureTipeName.ToLower().Trim() == FurnitureName.ToLower().Trim()))
         //     {
         //         NameId = x._Id;
         //     }
         //
         //     foreach (var x in F_Name_BD.Furnitures.Where(x => x._IdRoom == RoomId && x._IdTipeFurniture==NameId))
         //     {
         //
         //             MainID = x._Id;
         //
         //     }
         //
         //     using (LinePlaneContext F_BD = new LinePlaneContext())
         //     {
         //         foreach (var x in F_BD.Measurments.Where(x => x._IdFurniture == MainID))
         //         {
         //             return (Convert.ToDouble(x._Length), Convert.ToDouble(x._Width));
         //         }
         //     }



                return (0, 0);
            }
        }

    }
}
