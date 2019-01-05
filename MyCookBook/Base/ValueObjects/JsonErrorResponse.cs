namespace mycookbook.cc.MyCookBook.Base.ValueObjects
{
    public class JsonErrorResponse
    {
        public string error;

        private JsonErrorResponse(string error)
        {
            this.error = error;
        }

        public static JsonErrorResponse FromMessage(string error)
        {
            return new JsonErrorResponse(error);
        }
    }
}