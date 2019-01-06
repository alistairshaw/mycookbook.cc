using mycookbook.cc.MyCookBook.Base.ValueObjects;
using mycookbook.cc.MyCookBook.User.Aggregates;

namespace mycookbook.cc.MyCookBook.User.Repository {
    interface IUserRepository
    {
        AuthToken Register(User user, UserPassword password);

        AuthToken SignIn(EmailAddress email, string plainTextPassword);
    }
}