using LinePlaneCore.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
                int? SaveID = null;

                foreach( var x in DBContext.Conservations.Where(obj=>obj._FurnitureName==SaveName))
                {
                    SaveID = x._Id;
                }

                if (SaveID == null) return false;
                else
                {
                    //foreach
                }

            }
            return true;
        }

        internal static void LoadSave(ref Canvas canvas, string SaveName)
        {
            using (var DBContext = new LinePlaneContext())
            {
                int? SaveID = null;

                foreach (var x in DBContext.Conservations.Where(obj => obj._FurnitureName == SaveName))
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
                foreach (var x in DBContext.Conservations.Where(obj=>obj._FurnitureName==SaveName))
                {
                    return false;
                }
                SaveView NewSave = new SaveView() { SaveName = SaveName };
                SaveList.Add(NewSave);
                return true;
            }
        }
    }
}
