using System.Threading.Tasks;
using mycookbook.cc.MyCookBook.Base.ValueObjects;
using mycookbook.cc.MyCookBook.User.Aggregates;
using mycookbook.cc.MyCookBook.User.Views;

namespace mycookbook.cc.MyCookBook.User.Repository {
    public interface IUserRepository
    {
        AuthResult Register(User user, UserPassword password);

        AuthResult SignIn(EmailAddress email, string plainTextPassword);

        Task<User> Authenticate(string user, string password);

        void SignOut(int userId);
    }

    public struct AuthResult
    {
        public UserApiView User;
        public AuthToken AuthToken;

        public AuthResult(User user, AuthToken token)
        {
            User = user.ApiView();
            AuthToken = token;
        }
    };
}