using mycookbook.cc.MyCookBook.Base.ValueObjects;

namespace mycookbook.cc.MyCookBook.User
{
    public class UserFactory
    {
        public static User FromRegistrationForm(string email, string name)
        {
            return new User(null, EmailAddress.FromString(email), name, null, "");
        }
    }
}