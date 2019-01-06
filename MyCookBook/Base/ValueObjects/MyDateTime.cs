using System;

namespace mycookbook.cc.MyCookBook.Base.ValueObjects
{
    class MyDateTime
    {
        private DateTime dateTime;

        private MyDateTime(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public static MyDateTime Now()
        {
            return new MyDateTime(DateTime.Now);
        }

        public MyDateTime AddHours(int hoursToAdd)
        {
            var newDateTime = this.dateTime;
            return new MyDateTime(newDateTime.AddHours(hoursToAdd));
        }

        public string ForDatabase()
        {
            return this.dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}