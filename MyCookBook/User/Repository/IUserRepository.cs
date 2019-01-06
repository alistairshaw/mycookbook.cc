using mycookbook.cc.MyCookBook.Base.ValueObjects;

namespace mycookbook.cc.MyCookBook.User.Repository {
    interface IUserRepository
    {
        Aggregates.AuthToken Register(User user, UserPassword password);

        Aggregates.AuthToken SignIn(EmailAddress email, string plainTextPassword);
    }
}