namespace mycookbook.cc.MyCookBook.User.Aggregates
{
    public class AuthToken
    {
        public string User { get; }
        public string Password { get; }

        private AuthToken(string user, string password)
        {
            Password = password;
            User = user;
        }

        public static AuthToken FromToken(string token, int userId)
        {
            return new AuthToken(userId.ToString(), token);
        }
    }
}