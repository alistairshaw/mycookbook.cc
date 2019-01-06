namespace mycookbook.cc.MyCookBook.User.Aggregates
{
    public class AuthToken
    {
        public string Token { get; }

        private AuthToken(string token)
        {
            Token = token;
        }

        public static AuthToken FromString(string token)
        {
            return new AuthToken(token);
        }
    }
}