using System;
using System.Collections.Generic;
using System.IO;

using MyPatchV3.DL;
using MyPatchV3.DL.Models;
using MyPatchV3.BL;

namespace MyPatchV3.DAL
{
    public class UserDAO
    {
        DL.MyPatchV3Database db = null;
        protected static UserDAO sharedInstance;

        static UserDAO()
        {
            sharedInstance = new UserDAO();
        }

        protected UserDAO()
        {
            // instantiate the database
            db = MyPatchV3.DL.MyPatchV3Database.SharedInstance;
        }

        public static User GetUserById(int id)
        {
            return sharedInstance.db.GetItem<User>(id);
        }

        public static IEnumerable<User> GetUsers()
        {
            return sharedInstance.db.GetItems<User>();
        }
    }
}

