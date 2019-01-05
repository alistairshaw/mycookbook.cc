using System;

namespace mycookbook.cc.MyCookBook.Base.ValueObjects
{
    public class EmailAddress
    {
        private string email;

        private EmailAddress(string email)
        {
            this.email = email;
        }

        public static EmailAddress FromString(string email)
        {
            if (!EmailAddress.IsValidEmail(email)) throw new System.ArgumentException("Invalid email address");
            return new EmailAddress(email);
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public override string ToString()
        {
            return this.email;
        }
    }
}

