using System;

namespace Utility.Helpers
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// gets persian date and converts it to gregorian date
        /// </summary>
        /// <param name="persianDate"></param>
        /// <returns></returns>
        public static DateTime GetGregorianDateTime(this string persianDate)
        {
            var dt = new DateTime();
            if (!string.IsNullOrEmpty(persianDate))
            {
                var array = persianDate.Split('/');
                var year = int.Parse(ConvertDigitsToLatin(array[0]));
                var month = int.Parse(ConvertDigitsToLatin(array[1]));
                var day = int.Parse(ConvertDigitsToLatin(array[2]));

                var now = DateTime.Now;
                var pc = new System.Globalization.PersianCalendar();
                dt = pc.ToDateTime(year, month, day, now.Hour, now.Minute, now.Second, now.Millisecond);
            }
            return dt;
        }

        public static string ConvertDigitsToLatin(this string s)
        {
            var sb = new System.Text.StringBuilder();
            foreach (var character in s)
            {
                switch (character)
                {
                    //Persian digits
                    case '\u06f0':
                        sb.Append('0');
                        break;
                    case '\u06f1':
                        sb.Append('1');
                        break;
                    case '\u06f2':
                        sb.Append('2');
                        break;
                    case '\u06f3':
                        sb.Append('3');
                        break;
                    case '\u06f4':
                        sb.Append('4');
                        break;
                    case '\u06f5':
                        sb.Append('5');
                        break;
                    case '\u06f6':
                        sb.Append('6');
                        break;
                    case '\u06f7':
                        sb.Append('7');
                        break;
                    case '\u06f8':
                        sb.Append('8');
                        break;
                    case '\u06f9':
                        sb.Append('9');
                        break;

                    //Arabic digits    
                    case '\u0660':
                        sb.Append('0');
                        break;
                    case '\u0661':
                        sb.Append('1');
                        break;
                    case '\u0662':
                        sb.Append('2');
                        break;
                    case '\u0663':
                        sb.Append('3');
                        break;
                    case '\u0664':
                        sb.Append('4');
                        break;
                    case '\u0665':
                        sb.Append('5');
                        break;
                    case '\u0666':
                        sb.Append('6');
                        break;
                    case '\u0667':
                        sb.Append('7');
                        break;
                    case '\u0668':
                        sb.Append('8');
                        break;
                    case '\u0669':
                        sb.Append('9');
                        break;
                    default:
                        sb.Append(character);
                        break;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// gets gregorian date and converts it to persian date
        /// </summary>
        /// <param name="gregorianDate"></param>
        /// <returns></returns>
        public static string GetPersianDateTime(this DateTime gregorianDate)
        {
            var pc = new System.Globalization.PersianCalendar();
            var year = pc.GetYear(gregorianDate);
            var month = pc.GetMonth(gregorianDate);
            var day = pc.GetDayOfMonth(gregorianDate);
            var dt = year + "/" + month + "/" + day;
            return dt;
        }
        public static string GetDate(this DateTime oDateTime)
        {
            string currentCulture = CultureHelper.GetCurrentCulture();
            int todayDayNumber = DateTime.Now.Day;
            if (currentCulture == "en-US")
            {
                string[] monthList = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
                if (oDateTime.Day == todayDayNumber)
                {
                    return "Today";// Read from resource
                }
                if (oDateTime.Day == todayDayNumber - 1)
                {
                    return "Yesterday";// Read from resource
                }
                return oDateTime.Day + " " + monthList[oDateTime.Month - 1] + " " + oDateTime.Year;
            }

            if (currentCulture == "fa-IR")
            {
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                if (oDateTime.Day == todayDayNumber)
                {
                    return "امروز";// Read from resource
                }
                if (oDateTime.Day == todayDayNumber - 1)
                {
                    return "دیروز";// Read from resource
                }
                return pc.GetDayOfMonth(oDateTime) + " " + PersianMonthsName[pc.GetMonth(oDateTime) - 1] + " " + pc.GetYear(oDateTime);
            }

            if (currentCulture == "ar")
            {
                System.Globalization.HijriCalendar ac = new System.Globalization.HijriCalendar();
                int todayDay = DateTime.Now.Day;
                if (oDateTime.Day == todayDay)
                {
                    return "امروز";// Read from resource
                }
                if (oDateTime.Day == todayDay - 1)
                {
                    return "دیروز";// Read from resource
                }
                return ac.GetDayOfMonth(oDateTime) + " " +
                       PersianMonthsName[ac.GetMonth(oDateTime) - 1] + " " + ac.GetYear(oDateTime);
            }
            return "culture is not defined";
        }

        public static string GetTime(this DateTime oDateTime)
        {
            string currentCulture = CultureHelper.GetCurrentCulture();
            if (currentCulture == "en-US")
            {
                return oDateTime.Hour + " : " + oDateTime.Minute;
            }
            if (currentCulture == "fa-IR")
            {
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                return pc.GetHour(oDateTime) + " : " + pc.GetMinute(oDateTime);
            }
            if (currentCulture == "ar")
            {
                System.Globalization.HijriCalendar ac = new System.Globalization.HijriCalendar();
                return ac.GetHour(oDateTime) + " : " + ac.GetMinute(oDateTime);
            }
            return "culture is not define";
        }
        public static string GetDateTime(this DateTime oDateTime)
        {
            string currentCulture = CultureHelper.GetCurrentCulture();
            if (currentCulture == "fa-IR")
            {
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                string year = pc.GetYear(oDateTime).ToString().PadLeft(4, '0');
                string month = pc.GetMonth(oDateTime).ToString().PadLeft(2, '0');
                string day = pc.GetDayOfMonth(oDateTime).ToString().PadLeft(2, '0');
                return $"{year}/{month}/{day}";
            }
            return "culture is not defined";
        }
        public static DateTime GetDateTime(this string value)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            string[] dateArray = value.Split('/');
            DateTime dt = new DateTime(int.
            Parse(dateArray[0]), int.Parse(dateArray[1]), int.Parse(dateArray[2]), pc);
            return dt;
        }

        public static string GetPersianDayOfWeek(this string value)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            string[] dateArray = value.Split('/');
            DateTime dt = new DateTime(int.
                Parse(dateArray[0]), int.Parse(dateArray[1]), int.Parse(dateArray[2]), pc);
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return "شنبه";
                case DayOfWeek.Sunday:
                    return "یک شنبه";
                case DayOfWeek.Monday:
                    return "دو شنبه";
                case DayOfWeek.Tuesday:
                    return "سه شنبه";
                case DayOfWeek.Wednesday:
                    return "چهار شنبه";
                case DayOfWeek.Thursday:
                    return "پنج شنبه";
                case DayOfWeek.Friday:
                    return "جمعه";
                default:
                    return "نا شناخته";
            }
        }

        private static readonly string[] PersianMonthsName =
        {
            "فروردین", "اردیبهشت", "خرداد", "تیر",
            "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"
        };

        public static string GetPersianMonthName(this DateTime oDateTime)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            try
            {
                return PersianMonthsName[pc.GetMonth(oDateTime) - 1];
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static int GetPersianDay(this DateTime oDateTime)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            try
            {
                return pc.GetDayOfMonth(oDateTime);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static int GetPersianYear(this DateTime oDateTime)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            try
            {
                return pc.GetYear(oDateTime);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
