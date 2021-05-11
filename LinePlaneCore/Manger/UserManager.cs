using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinePlaneCore.Manger
{
    static internal class UserManager
    {
        static internal bool AddUser(string login, string password, string email)
        {
            using (var DBContext = new LinePlaneContext())
            {
                bool UserAlreadyHave = false;

                User NewPeople = new User();
                NewPeople._Login = login;
                NewPeople._Password = password;
                NewPeople._Email = email;

                foreach (var x in DBContext.Users)
                {
                    if (x._Login == login) UserAlreadyHave = true;
                }

                if (!UserAlreadyHave)
                {
                    DBContext.Users.Add(NewPeople);
                    DBContext.SaveChanges();

                    SetUserID(DBContext.Users.Find(NewPeople)._Id);

                    return true;
                }
                 else return false;
            }
        }

        static internal bool SearchUser(string login, string password)
        {
            using (var DBContext = new LinePlaneContext())
            {
                foreach (var x in DBContext.Users)
                {
                    if (x._Login == login && x._Password == password)
                    {
                        SetUserID(x._Id);
                        return true;
                    }

                }
                SetUserID(null);
                return false;
            }
        }

        internal static void SetUserID(int? ID)
        {
            UserData.UserID = ID ?? 0;
        }

    }
}
