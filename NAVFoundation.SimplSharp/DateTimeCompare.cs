using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;

namespace NAVFoundation.SimplSharp {

    public class DateTimeCompare {

        public const short InFuture = -1;
        public const short InPresent = 0;
        public const short InPast = 1;
        public const short DateTimeCompareError = -2;

        public static short CompareWithDateTimeNow(string date, string time) {

            if (string.IsNullOrEmpty(date)) {
                throw new ArgumentNullException("date");
            }

            if (string.IsNullOrEmpty(time)) {
                throw new ArgumentNullException("time");
            }

            try
            {

                var dateElements = date.Split('/');
                if (dateElements == null) throw new ArgumentNullException("dateElements");

                var timeElements = time.Split(':');
                if (timeElements == null) throw new ArgumentNullException("timeElements");

                var day = int.Parse(dateElements[0]);
                var month = int.Parse(dateElements[1]);
                var year = int.Parse(dateElements[2]);

                var hour = int.Parse(timeElements[0]);
                var minute = int.Parse(timeElements[1]);
                var second = int.Parse(timeElements[2]);

                var dateTimeNow = DateTime.Now;
                var dateTimeCompare = new DateTime(year, month, day, hour, minute, second);
                
                var result = DateTime.Compare(dateTimeNow, dateTimeCompare);

                return (short) result;
            }
            catch (Exception e)
            {
                ErrorLog.Error("Exception in NAVFoundation.SimplSharp.DateTimeCompare.CompareWithDateTimeNow : {0}", e.Message);
                return DateTimeCompareError;
            }

        }

        private static string GetDateTimeCompareResult(int result)
        {
            switch (result)
            {
                case InFuture:
                    return "InFuture";
                case InPresent:
                    return "InPresent";
                case InPast:
                    return "InPast";
            }

            return "";
        }
    }

}