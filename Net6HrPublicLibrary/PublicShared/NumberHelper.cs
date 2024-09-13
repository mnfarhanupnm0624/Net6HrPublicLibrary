using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6HrPublicLibrary.PublicShared
{
    public class NumberHelper
    {
        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        public static int ToIntiger(string value)
        {
            int _data = 0;
            if (value != null && value != "")
            {
                if (value.All(char.IsNumber)) _data = Convert.ToInt32(value);
            }
            return _data;
        }

        public static double ToDouble(string value)
        {
            double _data = 0;
            if (value != null && value != "")
            {
                if (value.All(char.IsNumber)) _data = Convert.ToDouble(value);
            }
            return _data;
        }


        public static string ToFormat(double _double, string _fornmat)
        {
            return _double.ToString(_fornmat);
        }

        public static string FormatInteger(int _number, string _format)
        {
            return _number.ToString(_format);
        }

        public static string MtdBezaTahun(DateTime? _tarikh, int _bezaTahun)
        {
            string _data = "true";
            int _tahun = MtdGetBezaTahunInt(_tarikh);
            if (_tahun < _bezaTahun) _data = "tahunKurang";
            return _data;
        }

        public static int MtdGetBezaTahunInt(DateTime? _tarikh)
        {
            int _tahun = 0;
            if (_tarikh != null)
            {
                DateTime _tarikhnya = (DateTime)_tarikh;
                DateTime _now = DateTime.Now;
                _tahun = (_now.Year - _tarikhnya.Year - 1) +
                         (((_now.Month > _tarikhnya.Month) || ((_now.Month == _tarikhnya.Month) && (_now.Day >= _tarikhnya.Day))) ? 1 : 0);
            }
            return _tahun;
        }

    }
}
