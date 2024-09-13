using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Net6HrPublicLibrary.PublicShared
{
    public class DateHelper
    {
        public static bool IsDate(String date)
        {
            try
            {
                if (date == "1/1/0001 12:00:00 AM")
                {
                    return false;
                }
                else
                {
                    DateTime dt = DateTime.Parse(date);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static DateTime ToDate(string _date, string _format)
        {
            //DateTime myDate = DateTime.ParseExact("2009-05-08 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff",
            //                           System.Globalization.CultureInfo.InvariantCulture);

            return DateTime.ParseExact(_date, _format, System.Globalization.CultureInfo.InvariantCulture);
        }

        public static string FormatDateDMY(DateTime? _tarikh)
        {
            string tkh = "";
            if (_tarikh != null)
            {
                tkh = _tarikh.ToString();
                DateTime dtByUser = DateTime.Parse(tkh).Date;
                tkh = dtByUser.ToString("dd/MM/yyyy");
            }
            return tkh;
        }

        public static string FormatDateDMYhhmmss()
        {
            string tkh = "";
            DateTime dtByUser = DateTime.Now;
            tkh = dtByUser.ToString("dd/MM/yyyy HH:mm:ss");
            return tkh;
        }

        public static int MtdGetTotalDays(DateTime _day01, DateTime _day02)
        {
            int _bilReturn = 0;
            #pragma warning disable CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (_day01 != null && _day02 != null)
            {
                TimeSpan t = _day01 - _day02;
                _bilReturn = (int)t.TotalDays;

            }
            #pragma warning restore CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
            return _bilReturn;
        }

        public static string FormatDateDMonY(DateTime? _tarikh)
        {
            string tkh = "";
            if (_tarikh != null)
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                tkh = _tarikh.ToString();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
                DateTime dtByUser = DateTime.Parse(tkh).Date;
#pragma warning restore CS8604 // Possible null reference argument.
                tkh = dtByUser.ToString("dd-MMM-yyyy");
            }
            return tkh;
        }

        public static string FormatDateDMYhm(DateTime? _tarikh)
        {
            string tkh = "";
            if (_tarikh != null)
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                tkh = _tarikh.ToString();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
                DateTime dtByUser = DateTime.Parse(tkh);
#pragma warning restore CS8604 // Possible null reference argument.
                tkh = dtByUser.ToString("dd/MM/yyyy HH:mm");
            }
            return tkh;
        }

        public static string FormatDateDMYhhmm()
        {
            string tkh = "";
            DateTime dtByUser = DateTime.Now;
            tkh = dtByUser.ToString("dd/MM/yyyy HH:mm");
            return tkh;
        }

        public static string FormatFromDateGetHm(DateTime? _tarikh)
        {
            string tkh = "";
            if (_tarikh != null)
            {
                //tkh = _tarikh.ToString();
#pragma warning disable CS8604 // Possible null reference argument.
                DateTime dtByUser = DateTime.Parse(_tarikh.ToString()).Date;
#pragma warning restore CS8604 // Possible null reference argument.
                tkh = dtByUser.ToString("HH:mm");
            }
            return tkh;
        }

        public static string FormatGetCurrentHm()
        {
            string _time = DateTime.Now.ToString("H:m");
            return _time;
        }

        public static string GetEndMonthDate(string _tarikh, string _format)
        {
            DateTime _date = ToDate(_tarikh, _format).AddMonths(1).AddDays(-1);
            return _date.ToString("dd/mm/yyyy");
        }

        public static DateTime GetEndMonthDate(DateTime _tarikh)
        {
            return _tarikh.AddMonths(1).AddDays(-1);
        }

        public static string GetCurrentDate()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }

        public static string GetCurrentTimeHMS()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        public static string GetCurrentTimeHM()
        {
            return DateTime.Now.ToString("HH:mm");
        }


        public static string CurrentSemakFormatDateYMD()
        {
            string tkh = "";
            DateTime dtByUser = DateTime.Now;
            tkh = dtByUser.ToString("yyyy-MM-dd");
            return tkh;
        }

        public static string FormatDateYMD(DateTime? _tarikh)
        {
            string tkh = "";
            if (_tarikh != null)
            {
                tkh = _tarikh.ToString();
                DateTime dtByUser = DateTime.Parse(tkh).Date;
                tkh = dtByUser.ToString("yyyy-MM-dd");
            }
            return tkh;
        }
        public static string FormatDateYMDKey(DateTime? _tarikh)
        {
            string tkh = "";
            if (_tarikh != null)
            {
                tkh = _tarikh.ToString();
                DateTime dtByUser = DateTime.Parse(tkh).Date;
                tkh = dtByUser.ToString("yyyyMMdd");
            }
            return tkh;
        }
        public static string FormatDateYMDHMKey(DateTime? _tarikh)
        {
            string tkh = "";
            if (_tarikh != null)
            {
                tkh = _tarikh.ToString();
                DateTime dtByUser = DateTime.Parse(tkh).Date;
                tkh = dtByUser.ToString("yyyy-MM-dd HH:mm:ss");
            }
            return tkh;
        }

        public static string MtdGetUmur(DateTime? _tkhLahir)
        {
            string _returnData = "- Tahun";
            if (_tkhLahir != null)
            {
                DateTime dob = Convert.ToDateTime(_tkhLahir.ToString());
                _returnData = CalculateYourAge(dob);
                //int age = CalculateAge(dob);
            }
            return _returnData;
        }

        public static string CalculateYourAge(DateTime _dob)
        {
            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(_dob).Ticks).Year - 1;
            DateTime PastYearDate = _dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
            int Hours = Now.Subtract(PastYearDate).Hours;
            int Minutes = Now.Subtract(PastYearDate).Minutes;
            int Seconds = Now.Subtract(PastYearDate).Seconds;
            return String.Format("{0} Tahun {1} Bulan", Years, Months);
            //return String.Format("Age: {0} Year(s) {1} Month(s) {2} Day(s) {3} Hour(s) {4} Second(s)",
            //Years, Months, Days, Hours, Seconds);
        }

        public static int GetCurrentYear()
        {
            return DateTime.Now.Year;
        }

        public static int CalculateAge(DateTime _dob)
        {
            int age = 0;
            age = DateTime.Now.Year - _dob.Year;
            if (DateTime.Now.DayOfYear < _dob.DayOfYear)
                age = age - 1;

            return age;
        }
        public static int CalculateAgeMonth(DateTime _dob)
        {
            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(_dob).Ticks).Year - 1;
            DateTime PastYearDate = _dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now)
                {
                    Months = i - 1;
                    break;
                }
            }
            return Months;
        }

        public static string GetYearFromDate(DateTime? _tarikhnya)
        {
            DateTime _tarikh = _tarikhnya ?? DateTime.Now;
            return _tarikh.ToString("yyyy");
        }

        public static string GetYMDFromShortDate(string _tarikh)
        {
            string _hari = _tarikh.Substring(0, 2);
            string _bulan = GetMonthNo(_tarikh.Substring(3, 3));
            string _tahun = GetLast(_tarikh, 4);
            return (_tahun + "-" + _bulan + "-" + _hari);
        }

        public static string HariBm(DateTime dateIn)
        {
            string _hari = "";
            int _no = (int)dateIn.DayOfWeek;
            if (_no == 0) _hari = "Ahad";
            if (_no == 1) _hari = "Isnin";
            if (_no == 2) _hari = "Selasa";
            if (_no == 3) _hari = "Rabu";
            if (_no == 4) _hari = "Khamis";
            if (_no == 5) _hari = "Jumaat";
            if (_no == 6) _hari = "Sabtu";
            return _hari;
        }

        public static string GetLast(string _source, int tail_length)
        {
            if (tail_length >= _source.Length) return _source;
            return _source.Substring(_source.Length - tail_length);
        }
        public static string GetMonthNo(string _shortMonth)
        {
            _shortMonth = _shortMonth.ToUpper();
            string _month = "01";
            if (_shortMonth == "FEB")
            {
                _month = "02";
            }
            else if (_shortMonth == "MAR" || _shortMonth == "MAC")
            {
                _month = "03";
            }
            else if (_shortMonth == "APR")
            {
                _month = "04";
            }
            else if (_shortMonth == "MAY" || _shortMonth == "MEI")
            {
                _month = "05";
            }
            else if (_shortMonth == "JUN")
            {
                _month = "06";
            }
            else if (_shortMonth == "JUL")
            {
                _month = "07";
            }
            else if (_shortMonth == "AUG" || _shortMonth == "OGO")
            {
                _month = "08";
            }
            else if (_shortMonth == "SEP")
            {
                _month = "09";
            }
            else if (_shortMonth == "OCT" || _shortMonth == "OKT")
            {
                _month = "10";
            }
            else if (_shortMonth == "NOV")
            {
                _month = "11";
            }
            else if (_shortMonth == "DEC" || _shortMonth == "DIS")
            {
                _month = "12";
            }
            return _month;
        }
        public static string GetNo2ShortMonth(string _monthNo)
        {
            string _shortMonth = "Jan";
            if (_monthNo == "02")
            {
                _shortMonth = "Feb";
            }
            else if (_monthNo == "03")
            {
                _shortMonth = "Mar";
            }
            else if (_monthNo == "04")
            {
                _shortMonth = "Apr";
            }
            else if (_monthNo == "05")
            {
                _shortMonth = "May";
            }
            else if (_monthNo == "06")
            {
                _shortMonth = "Jun";
            }
            else if (_monthNo == "07")
            {
                _shortMonth = "Jul";
            }
            else if (_monthNo == "08")
            {
                _shortMonth = "Aug";
            }
            else if (_monthNo == "09")
            {
                _shortMonth = "Sep";
            }
            else if (_monthNo == "10")
            {
                _shortMonth = "Oct";
            }
            else if (_monthNo == "11")
            {
                _shortMonth = "Nov";
            }
            else if (_monthNo == "12")
            {
                _shortMonth = "Dec";
            }
            return _shortMonth;
        }

        public static string MtdGetFormatTime(string _time)
        {
            string[] _text = PublicConstant.SplitAyat(_time, ":");
            string _hh = MtdGetFormat2dijit(_text[0]);
            string _mm = MtdGetFormat2dijit(_text[1]);
            return (_hh + ":" + _mm);
        }
        public static string MtdGetFormat2dijit(string _value)
        {
            string _return = _value;
            if (_value.Length == 1)
            {
                _return = "0" + _value;
            }
            return _return;
        }

//        public static int MtdGetTotalDays(DateTime _day01, DateTime _day02)
//        {
//            int _bilReturn = 0;
//#pragma warning disable CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
//            if (_day01 != null && _day02 != null)
//            {
//                TimeSpan t = _day01 - _day02;
//                _bilReturn = (int)t.TotalDays;

//            }
//#pragma warning restore CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
//            return _bilReturn;
//        }
        public static int MtdGetTotalMinutes(DateTime _day01, DateTime _day02)
        {
            int _bilReturn = 0;
#pragma warning disable CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (_day01 != null && _day02 != null)
            {
                TimeSpan t = _day01 - _day02;
                _bilReturn = (int)t.TotalMinutes;

            }
#pragma warning restore CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
            return _bilReturn;
        }



    }
}
