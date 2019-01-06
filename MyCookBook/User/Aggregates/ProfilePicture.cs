using mycookbook.cc.MyCookBook.Base.ValueObjects;

namespace mycookbook.cc.MyCookBook.User.Aggregates
{
    public class ProfilePicture
    {
        private string filename;

        public ProfilePicture(string filename)
        {
            this.filename = filename;    
        }

        public string GetFilename()
        {
            return this.filename;
        }

        public Url GetUrl()
        {
            return Url.ForProfilePicture(this.filename);
        }
    }
}