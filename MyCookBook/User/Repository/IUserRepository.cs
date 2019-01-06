using System.Threading.Tasks;
using mycookbook.cc.MyCookBook.Base.ValueObjects;
using mycookbook.cc.MyCookBook.User.Aggregates;

namespace mycookbook.cc.MyCookBook.User.Repository {
    public interface IUserRepository
    {
        AuthToken Register(User user, UserPassword password);

        AuthToken SignIn(EmailAddress email, string plainTextPassword);

        Task<User> Authenticate(string user, string password);

        void SignOut(int userId);
    }
}