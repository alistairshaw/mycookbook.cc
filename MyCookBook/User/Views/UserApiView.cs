namespace mycookbook.cc.MyCookBook.User.Views
{
    public class UserApiView
    {
        public int? Id;
        public string EmailAddress;
        public string Name;
        public string ProfilePictureUrl;
        public string Blurb;

        public UserApiView(int? id, string emailAddress, string name, string profilePictureUrl, string blurb)
        {
            Id = id;
            EmailAddress = emailAddress;
            Name = name;
            ProfilePictureUrl = profilePictureUrl;
            Blurb = blurb;
        }
    }
}