namespace mycookbook.cc.MyCookBook.User.Views
{
    public class UserApiView
    {
        public int? id;
        public string emailAddress;
        public string name;
        public string profilePictureUrl;
        public string blurb;

        public UserApiView(int? id, string emailAddress, string name, string profilePictureUrl, string blurb)
        {
            this.id = id;
            this.emailAddress = emailAddress;
            this.name = name;
            this.profilePictureUrl = profilePictureUrl;
            this.blurb = blurb;
        }
    }
}