using System.Linq;
using mycookbook.cc.MyCookBook.Base;
using mycookbook.cc.MyCookBook.Base.ValueObjects;
using mycookbook.cc.MyCookBook.User.Exceptions;

namespace mycookbook.cc.MyCookBook.User.Repository {

    class SqlLiteUserRepository : IUserRepository
    {
        public User Register(User user, UserPassword password)
        {
            if (this.CheckForDuplicate(user)) throw new DuplicateUserException("User already exists");

            using (MyCookBookDb db = new MyCookBookDb())
            {
                UserModel userView = user.DatabaseView();
                userView.Password = password.ForDatabase();

                db.Users.Add(userView);
                db.SaveChanges();
            }

            return user;
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