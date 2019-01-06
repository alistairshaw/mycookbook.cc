using System;
using System.Linq;
using mycookbook.cc.MyCookBook.Base;
using mycookbook.cc.MyCookBook.Base.Exceptions;
using mycookbook.cc.MyCookBook.Base.ValueObjects;
using mycookbook.cc.MyCookBook.User.Exceptions;
using mycookbook.cc.MyCookBook.User.Repository.Models;

namespace mycookbook.cc.MyCookBook.User.Repository {

    class SqlLiteUserRepository : IUserRepository
    {
        public User Register(User user, UserPassword password)
        {
            if (this.CheckForDuplicate(user)) throw new DuplicateUserException("User already exists");

            using (MyCookBookDb db = new MyCookBookDb())
            {
                UserModel userModel = user.DatabaseView();
                userModel.Password = password.ForDatabase();

                db.Users.Add(userModel);
                db.SaveChanges();

                var id = userModel.Id;

                return this.Find(id);
            }
        }

        private User Find(int? id)
        {
            if (id == null) throw new ArgumentNullException();

            using (MyCookBookDb db = new MyCookBookDb())
            {
                UserModel existingUser = db.Users.FirstOrDefault(u => u.Id == id);
                if (existingUser == null) throw new RecordNotFoundException();

                return UserFactory.FromDatabase(existingUser);
            }
        }

        private bool CheckForDuplicate(User user)
        {
            using (MyCookBookDb db = new MyCookBookDb())
            {
                UserModel existingUser = db.Users.FirstOrDefault(u => u.Email == user.GetEmailAddress().ToString());
                if (existingUser != null) return true;
            }

            return false;
        }
    }

}