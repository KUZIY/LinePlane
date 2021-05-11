using LinePlaneCore.Model;
using LinePlaneCore.Model.Server;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace LinePlaneCore.Manger
{
    static internal class SaveManager
    {
        internal static ObservableCollection<SaveView> GetSaveList()
        {
            ObservableCollection<SaveView> Colection = new ObservableCollection<SaveView>();

            using (var DBContext = new LinePlaneContext())
            {

                /*foreach ( var x in DBContext.Conservations.Where(b=>b._IdUser== UserData.UserID))
                {
                    SaveView DbSave = new SaveView() { SaveName = x._FurnitureName };
                    Colection.Add(DbSave);
                }*/



            }
            return Colection;
        }

        internal static bool SetSave (Canvas canvas, string SaveName)
        {
            using (var DBContext=new LinePlaneContext())
            {


                /*foreach( var x in DBContext.Conservations.Where(obj=>obj._SaveName==SaveName))
                {
                    SaveID = x._Id;
                }

                if (SaveID == null) return false;*/

                Conservations AddSave = new Conservations() { _IdUser = UserData.UserID, _SaveName = SaveName };

                DBContext.Conservations.Add(AddSave);

                int ConservationID = DBContext.Conservations.Find(AddSave)._Id;

                foreach (FrameworkElement shape in canvas.Children)
                {
                    int FurnitureID = (int)shape.Tag;

                    if (FurnitureID == 0)
                    {
                        Wall AddWall = new() { _IdConservation = ConservationID, _X1 = ((Line)shape).X1, _Y1 = ((Line)shape).Y1, _X2 = ((Line)shape).X2, _Y2 = ((Line)shape).Y2 };
                        DBContext.Walls.Add(AddWall);
                    }
                    else
                    {
                        Сoordinates coordinates = new() { _X = Canvas.GetLeft(shape), _Y = Canvas.GetLeft(shape) };
                        DBContext.Сoordinates.Add(coordinates);
                        DBContext.SaveChanges();

                        Project AddSaveProject = new() { _IdConservation = ConservationID, _IdFurniture = FurnitureID, _IdСoordinates = DBContext.Сoordinates.Find(coordinates)._Id };
                        DBContext.Projects.Add(AddSaveProject);
                        DBContext.SaveChanges();
                    }
                }

            }
            return true;
        }

        internal static void LoadSave(ref Canvas canvas, string SaveName)
        {
            using (var DBContext = new LinePlaneContext())
            {
                int? SaveID = null;

                foreach (var x in DBContext.Conservations.Where(obj => obj._SaveName == SaveName))
                {
                    SaveID = x._Id;
                }

                if (SaveID == null) return;
                else
                {
                    //foreach
                }

            }
        }  

        internal static bool NewSave(ref ObservableCollection<SaveView> SaveList, string SaveName)
        {
            using (LinePlaneContext DBContext = new LinePlaneContext())
            {
                foreach (var x in DBContext.Conservations.Where(obj=>obj._SaveName == SaveName))
                {
                    return false;
                }
                SaveView NewSave = new SaveView() { SaveName = SaveName };
                SaveList.Add(NewSave);
                return true;
            }
        }

     //  internal static void DeleteSave(string SaveName)
     //  {
     //      var deleteOrderDetails =
     //          from details in db.OrderDetails
     //          where details.OrderID == 11000
     //          select details;
     //
     //      foreach (var detail in deleteOrderDetails)
     //      {
     //          db.OrderDetails.DeleteOnSubmit(detail);
     //      }
     //
     //      try
     //      {
     //          db.SubmitChanges();
     //      }
     //      catch (Exception e)
     //      {
     //          Console.WriteLine(e);
     //          // Provide for exceptions.
     //      }
     //  }
    }
}
