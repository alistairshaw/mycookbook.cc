using System;
using mycookbook.cc.MyCookBook.Base.ValueObjects;
using mycookbook.cc.MyCookBook.User.Aggregates;
using mycookbook.cc.MyCookBook.User.Repository.Models;

namespace mycookbook.cc.MyCookBook.User
{
    public class UserFactory
    {
        public static User FromRegistrationForm(string email, string name)
        {
            return new User(null, EmailAddress.FromString(email), name, null, "");
        }

        internal static User FromDatabase(UserModel existingUser)
        {
            return new User(
                existingUser.Id, 
                EmailAddress.FromString(existingUser.Email),
                existingUser.Name,
                existingUser.ProfilePicture == null ? null : new ProfilePicture(existingUser.ProfilePicture),
                existingUser.Blurb
            );
        }
    }
}