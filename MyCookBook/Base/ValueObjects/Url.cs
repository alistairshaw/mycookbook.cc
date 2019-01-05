namespace mycookbook.cc.MyCookBook.Base.ValueObjects
{
    public class Url
    {
        private string url;

        private Url(string url)
        {
            this.url = url;
        }

        public static Url ForProfilePicture(string filename)
        {
            return new Url("/xxx/" + filename);
        }

        public string value()
        {
            return this.url;
        }
    }
}