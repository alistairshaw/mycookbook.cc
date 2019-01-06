using System;
using System.Linq;
using mycookbook.cc.MyCookBook.Base;
using mycookbook.cc.MyCookBook.Base.Exceptions;
using mycookbook.cc.MyCookBook.Base.ValueObjects;
using mycookbook.cc.MyCookBook.User.Aggregates;
using mycookbook.cc.MyCookBook.User.Exceptions;
using mycookbook.cc.MyCookBook.User.Repository.Models;

namespace mycookbook.cc.MyCookBook.User.Repository
{

    class SqlLiteUserRepository : IUserRepository
    {
        public AuthToken Register(User user, UserPassword password)
        {
            if (this.CheckForDuplicate(user)) throw new DuplicateUserException("User already exists");

            using (MyCookBookDb db = new MyCookBookDb())
            {
                UserModel userModel = user.DatabaseView();
                userModel.Password = password.ForDatabase();

                db.Users.Add(userModel);
                db.SaveChanges();

                var id = userModel.Id.GetValueOrDefault();

                return this.GenerateAuthToken(id);
            }
        }

        public AuthToken SignIn(EmailAddress email, string plainTextPassword)
        {
            using (MyCookBookDb db = new MyCookBookDb())
            {
                UserModel existingUser = db.Users.FirstOrDefault(u => u.Email == email.ToString());
                if (existingUser == null || !UserPassword.Compare(existingUser.Password, plainTextPassword))
                    throw new RecordNotFoundException();

                int id = existingUser.Id.GetValueOrDefault();
                if (id == default(int)) throw new RecordNotFoundException();

                return this.GenerateAuthToken(id);
            }
        }

        private AuthToken GenerateAuthToken(int userId)
        {
            using (MyCookBookDb db = new MyCookBookDb())
            {
                var userTokenModel = new UserTokenModel();
                userTokenModel.UserId = userId;
                userTokenModel.Token = UserPassword.RandomToken();
                userTokenModel.Created = MyDateTime.Now().ForDatabase();
                userTokenModel.Expires = MyDateTime.Now().AddHours(2).ForDatabase();

                // delete all previous tokens
                db.UserTokens.RemoveRange(db.UserTokens.Where(t => t.UserId == userId));
                db.SaveChanges();

                db.UserTokens.Add(userTokenModel);
                db.SaveChanges();

                return AuthToken.FromString(userTokenModel.Token);
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