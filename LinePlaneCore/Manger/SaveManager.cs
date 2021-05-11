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
using LinePlaneCore.Logic;
using System.Windows.Media.Imaging;


namespace LinePlaneCore.Manger
{
    static internal class SaveManager
    {
        internal static ObservableCollection<SaveView> GetSaveList()
        {
            ObservableCollection<SaveView> Colection = new ObservableCollection<SaveView>();

            using (var DBContext = new LinePlaneContext())
            {

                foreach ( var x in DBContext.Conservations.Where(b=>b._IdUser== UserData.UserID))
                {
                    SaveView DbSave = new SaveView() { SaveName = x._SaveName };
                    Colection.Add(DbSave);
                }



            }
            return Colection;
        }

        internal static void SetSave (Canvas canvas, string SaveName)
        {
            using (var DBContext=new LinePlaneContext())
            {


                /*foreach( var x in DBContext.Conservations.Where(obj=>obj._SaveName==SaveName))
                {
                    SaveID = x._Id;
                }

                if (SaveID == null) return false;*/

                Conservations AddSave = new Conservations() { _Picture="asd" ,_IdUser = UserData.UserID, _SaveName = SaveName };

                DBContext.Conservations.Add(AddSave);
                DBContext.SaveChanges();

                int ConservationID = 0;

                foreach (var g in DBContext.Conservations.Where(obj => obj._SaveName == SaveName))
                {
                    ConservationID = g._Id;
                }

                foreach (FrameworkElement shape in canvas.Children)
                {
                    int FurnitureID = (int)shape.Tag;

                    if (FurnitureID == 0)
                    {
                        Wall AddWall = new() { _IdConservation = ConservationID, _X1 = ((Line)shape).X1, _Y1 = ((Line)shape).Y1, _X2 = ((Line)shape).X2, _Y2 = ((Line)shape).Y2 };
                        DBContext.Walls.Add(AddWall);
                        DBContext.SaveChanges();
                    }
                    else
                    {
                        Сoordinates coordinates = new() { _X = Canvas.GetLeft(shape), _Y = Canvas.GetTop(shape) };
                        DBContext.Сoordinates.Add(coordinates);
                        DBContext.SaveChanges();

                        int _IdСoordinates = DBContext.Сoordinates.OrderBy(Coord=>Coord._Id).Last()._Id;

                        Project AddSaveProject = new() { _IdConservation = ConservationID, _IdFurniture = FurnitureID, _IdСoordinates = _IdСoordinates};
                        DBContext.Projects.Add(AddSaveProject);
                        
                    }
                }

            }
        }

        internal static void LoadSave(ref Canvas canvas, string SaveName)
        {
            canvas.Children.Clear();
            using (var DBContext = new LinePlaneContext())
            {
                int SaveID = 0;
                
                foreach (var x in DBContext.Conservations.Where(obj => obj._SaveName == SaveName && obj._IdUser==UserData.UserID))
                {
                    SaveID = x._Id;
                }

                foreach (var x in DBContext.Walls.Where(obj => obj._IdConservation == SaveID))
                {
                    Point FirstPoint = new() { X = x._X1, Y = x._Y1 };
                    Point SecondPoint = new() { X = x._X2, Y = x._Y2 };

                    object a = new DrawWalls(ref canvas, FirstPoint, SecondPoint);
                }

                foreach (var x in DBContext.Projects.Where(obj => obj._IdConservation == SaveID))
                {

                    int FurnitureID = x._IdFurniture;
                    string TypeShape = string.Empty;
                    string LocalURIImage = string.Empty;
                    Point Size = new Point();
                    Point Margin = new();

                    using (var Context = new LinePlaneContext())
                    {

                        foreach (var Cord in Context.Сoordinates.Where(obj => obj._Id == x._IdСoordinates))
                        {
                            Margin.X = Cord._X;
                            Margin.Y = Cord._Y;
                        }

                        foreach (var h in Context.Furnitures.Where(obj => obj._Id == x._IdFurniture))
                        {
                            using (var SubContext = new LinePlaneContext())
                            {
                                foreach (var j in SubContext.TipeFurnitures.Where(obj => obj._Id == h._IdTipeFurniture))
                                {
                                    TypeShape = j.FurnitureTipe;
                                }

                                LocalURIImage = h._Link;

                                foreach (var j in SubContext.Measurments.Where(obj => obj._IdFurniture == h._Id))
                                {
                                    Size.X = j._Width;
                                    Size.Y = j._Length;
                                }
                            }
                        }

                        var Shape = new FrameworkElement();
                        BitmapImage Image = null;
                        var dir = AppDomain.CurrentDomain.BaseDirectory;
                        dir = dir.Remove(dir.IndexOf("\\bin\\Debug\\net5.0-windows")) + LocalURIImage;

                        try
                        {
                            Image = new BitmapImage(new Uri(dir, UriKind.RelativeOrAbsolute));
                        }
                        catch
                        {
                            Image = null;
                        }


                        if (TypeShape == null)
                        {
                            var Square = new Logic.SpawnShape.Draw_Square(30, 30);
                            Shape = Square.shape;
                        }

                        else
                        {
                            if (TypeShape.ToLower() == "square")
                            {
                                var Square = new Logic.SpawnShape.Draw_Square(Size.X, Size.Y, Margin, Image, FurnitureID);
                                Shape = Square.shape;
                            }
                            else if (TypeShape.ToLower() == "ellipse")
                            {
                                var Ellipse = new Logic.SpawnShape.Draw_Ellipse(Size.X, Size.Y, Margin, Image, FurnitureID);
                                Shape = Ellipse.shape;
                            }
                        }


                        canvas.Children.Add(Shape);
                    }
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

        internal static void DeleteSave(string SaveName)
        {
            LinePlaneContext m = new LinePlaneContext();
            int IdConservation = 0;
            foreach (var x in m.Conservations.Where(obj => obj._SaveName == SaveName))
            {
                IdConservation = x._Id;
            }
            LinePlaneContext db = new LinePlaneContext();

            var deleteWalls =
            from t in db.Walls
            where t._IdConservation == IdConservation
            select t;

            foreach (var t in deleteWalls)
            {
                db.Walls.Remove(t);
            }

            try
            {
                db.SaveChanges();
            }
            catch
            {
            }


            // foreach (var x in m.Projects.Where(obj => obj._IdConservation == IdConservation))
            // {
            // IdConservation = x._Id;
            //
            // var deleteСoordinates =
            // from t in db.Сoordinates
            // where t._Id == x._IdСoordinates
            // select t;
            //
            // foreach (var t in deleteСoordinates)
            // {
            // db.Сoordinates.Remove(t);
            //
            // }
            //
            // try
            // {
            // db.SaveChanges();
            // }
            // catch
            // {
            // }
            //
            // }
            //

            var deleteProject =
            from t in db.Projects
            where t._IdConservation == IdConservation
            select t;

            foreach (var t in deleteProject)
            {
                var deleteСoordinates =
                from q in db.Сoordinates
                where q._Id == t._IdСoordinates
                select q;

                foreach (var q in deleteСoordinates)
                {
                    db.Сoordinates.Remove(q);

                }

                try
                {
                    db.SaveChanges();
                }
                catch
                {
                }
                db.Projects.Remove(t);
            }

            try
            {
                db.SaveChanges();
            }
            catch
            {
            }

            var deleteConservation =
            from t in db.Conservations
            where t._Id == IdConservation
            select t;

            foreach (var t in deleteConservation)
            {
                db.Conservations.Remove(t);
            }

            try
            {
                db.SaveChanges();
            }
            catch
            {
            }
        }
    }
}
