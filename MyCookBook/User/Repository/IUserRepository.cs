using mycookbook.cc.MyCookBook.Base.ValueObjects;

namespace mycookbook.cc.MyCookBook.User.Repository {
    interface IUserRepository
    {
        User Register(User user, UserPassword password);
    }
}