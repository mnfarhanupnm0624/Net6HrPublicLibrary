using Microsoft.AspNetCore.Mvc.Rendering;
using Net6HrPublicLibrary.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6HrPublicLibrary.PublicShared
{
    public class PublicConstant
    {
        //Constants to represent Access Right Level on Record Level
        public static int CAPAIAN_SEMUA = 1;
        public static int CAPAIAN_PTJ = 2;
        public static int CAPAIAN_DIRISENDIRI = 3;
        public static int CAPAIAN_UNIT = 4;
        public static int CAPAIAN_SUB_UNIT = 5;
        public static int CAPAIAN_KAMPUS = 6;
        public static int CAPAIAN_MULTI_PTJ = 8;
        public static int CAPAIAN_CROSS_KAMPUS = 9;

        public static string CAPAIAN2016_SEMUA = "A";
        public static string CAPAIAN2016_UNIVERSITI = "B";
        public static string CAPAIAN2016_MULTI_UNIVERSITI = "C";
        public static string CAPAIAN2016_KAMPUS = "D";
        public static string CAPAIAN2016_MULTI_KAMPUS = "E";
        public static string CAPAIAN2016_PTJ = "F";
        public static string CAPAIAN2016_MULTI_PTJ = "G";
        public static string CAPAIAN2016_JAB = "H";
        public static string CAPAIAN2016_MULTI_JAB = "I";
        public static string CAPAIAN2016_UNIT = "J";
        public static string CAPAIAN2016_MULTI_UNIT = "K";
        public static string CAPAIAN2016_DIRISENDIRI = "L";

        public static string EncryptCode()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            return config["MySetting:EncryptCode"];
        }

        //public static string ConnOraRujuk()
        //{
        //    var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        //    return config["MySetting:UpnmdbRujuk"];
        //}

        public static string ConnSybaseRujuk()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            return config["MySetting:UpnmdbRujuk"];
        }
        //public static string ConnMySQLUpnmDbDs()
        //{
        //    var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        //    //string _userEnc = config["MySetting:UpnmdbDSUser"];
        //    //string _user = EncryptHr.DecryptString4url(_userEnc, "admSmis");
        //    //string _pawdEnc = config["MySetting:UpnmdbDSPawd"];
        //    //string _pawd = EncryptHr.DecryptString4url(_pawdEnc, "admSmis");
        //    //string _ipAddEnc = config["MySetting:UtmdbIPAdd"];
        //    //string _ipAdd = EncryptHr.DecryptString4url(_ipAddEnc, "admSmis");
        //    //string _serviceEnc = config["MySetting:UtmdbService"];
        //    //string _service = EncryptHr.DecryptString4url(_serviceEnc, "admSmis");
        //    //string _text = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + _ipAdd + @")(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + _service + @")));User Id=" + _user + ";Password=" + _pawd;


        //    string _text = config["ConnectionStrings:UPNMDBMYSQL"];
        //    return _text;
        //}

        public static string ConnSybaseUpnmDbDs()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            /*
            string _userEnc = config["MySetting:UpnmdbDSUser"];
            string _user = EncryptHr.DecryptString4url(_userEnc, "admSmis");
            string _pawdEnc = config["MySetting:UpnmdbDSPawd"];
            string _pawd = EncryptHr.DecryptString4url(_pawdEnc, "admSmis");
            string _ipAddEnc = config["MySetting:UtmdbIPAdd"];
            string _ipAdd = EncryptHr.DecryptString4url(_ipAddEnc, "admSmis");
            string _serviceEnc = config["MySetting:UtmdbService"];
            string _service = EncryptHr.DecryptString4url(_serviceEnc, "admSmis");
            string _text = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + _ipAdd + @")(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + _service + @")));User Id=" + _user + ";Password=" + _pawd;
            */

            string _text = config["MySetting:SybaseUpnmdbDSDev"];
            return _text;
        }

        //public static string ConnUpnmDbAkademik()
        //{
        //    var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        //    string _userEnc = config["MySetting:UpnmdbAkaUser"];
        //    string _user = EncryptHr.DecryptString4url(_userEnc, "admSmis");
        //    string _pawdEnc = config["MySetting:UpnmdbAkaPawd"];
        //    string _pawd = EncryptHr.DecryptString4url(_pawdEnc, "admSmis");
        //    string _text = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=161.139.21.35)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=SMUTM)));User Id=" + _user + ";Password=" + _pawd;
        //    return _text;
        //}

        //public static string ConnUpnmDbSmu()
        //{
        //    var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        //    string _userEnc = config["MySetting:UpnmdbSmuUser"];
        //    string _user = EncryptHr.DecryptString4url(_userEnc, "admSmis");
        //    string _pawdEnc = config["MySetting:UpnmdbSmuPawd"];
        //    string _pawd = EncryptHr.DecryptString4url(_pawdEnc, "admSmis");
        //    string _text = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=161.139.21.35)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=SMU)));User Id=" + _user + ";Password=" + _pawd;
        //    return _text;
        //}

        public static string MtdRIChar(string fileName)
        {
            string _data = fileName.Replace("'", "");
            _data = _data.Replace("--", "");
            _data = _data.Replace(";", "");
            _data = _data.Replace("=", "");
            _data = _data.Replace("<", "");
            _data = _data.Replace("[", "");
            _data = _data.Replace("{", "");
            return _data;
        }

        public static string MtdRemoveSpecialCharacter(string fileName)
        {
            string _data = fileName.Replace("/", "");
            _data = _data.Replace("&", "");
            _data = _data.Replace("+", "");
            _data = _data.Replace("%", "");
            _data = _data.Replace("#", "");
            _data = _data.Replace("$", "");
            _data = _data.Replace("!", "");
            _data = _data.Replace("'", "");
            _data = _data.Replace("\"", "");
            _data = _data.Replace("\\", "");
            _data = _data.Replace("<", "");
            _data = _data.Replace(">", "");
            _data = _data.Replace("{", "");
            _data = _data.Replace("}", "");
            _data = _data.Replace("[", "");
            _data = _data.Replace("]", "");
            _data = _data.Replace("(", "");
            _data = _data.Replace(")", "");
            _data = _data.Replace("|", "");
            _data = _data.Replace("?", "");
            _data = _data.Replace(":", "");
            _data = _data.Replace(";", "");
            _data = _data.Replace(",", "");
            _data = _data.Replace(" ", "");
            return _data;
        }
        public static string MtdRemoveSpecialCharacter5space(string fileName)
        {
            string _data = fileName.Replace("/", "");
            _data = _data.Replace("&", "");
            _data = _data.Replace("+", "");
            _data = _data.Replace("%", "");
            _data = _data.Replace("#", "");
            _data = _data.Replace("$", "");
            _data = _data.Replace("!", "");
            _data = _data.Replace("'", "");
            _data = _data.Replace("\"", "");
            _data = _data.Replace("\\", "");
            _data = _data.Replace("<", "");
            _data = _data.Replace(">", "");
            _data = _data.Replace("{", "");
            _data = _data.Replace("}", "");
            _data = _data.Replace("[", "");
            _data = _data.Replace("]", "");
            _data = _data.Replace("(", "");
            _data = _data.Replace(")", "");
            _data = _data.Replace("|", "");
            _data = _data.Replace("?", "");
            _data = _data.Replace(":", "");
            _data = _data.Replace(";", "");
            _data = _data.Replace(",", "");
            return _data;
        }

        //public static string MtdRemoveSpecialCharacter5space(string fileName)
        //{
        //    string _data = fileName.Replace("/", "");
        //    _data = _data.Replace("&", "");
        //    _data = _data.Replace("+", "");
        //    _data = _data.Replace("%", "");
        //    _data = _data.Replace("#", "");
        //    _data = _data.Replace("$", "");
        //    _data = _data.Replace("!", "");
        //    _data = _data.Replace("'", "");
        //    _data = _data.Replace("\"", "");
        //    _data = _data.Replace("\\", "");
        //    _data = _data.Replace("<", "");
        //    _data = _data.Replace(">", "");
        //    _data = _data.Replace("{", "");
        //    _data = _data.Replace("}", "");
        //    _data = _data.Replace("[", "");
        //    _data = _data.Replace("]", "");
        //    _data = _data.Replace("(", "");
        //    _data = _data.Replace(")", "");
        //    _data = _data.Replace("|", "");
        //    _data = _data.Replace("?", "");
        //    _data = _data.Replace(":", "");
        //    _data = _data.Replace(";", "");
        //    _data = _data.Replace(",", "");
        //    return _data;
        //}

        public static string[] SplitAyat(string text01, string _splitBy)
        {
            string[] stringSeparators = new string[] { _splitBy };
            string[] result;
            result = text01.Split(stringSeparators, StringSplitOptions.None);
            return result;
        }

        public static string MtdRefomateTime(string _time)
        {
            string[] _text = SplitAyat(_time, ":");
            string _hour = _text[0].Length == 1 ? ("0" + _text[0]) : _text[0];
            string _mint = _text[1].Length == 1 ? ("0" + _text[1]) : _text[1];
            return (_hour + ":" + _mint);
        }


        public static List<ParameterHrModel> ItemListHPhoneCode = new List<ParameterHrModel>()
        {
            new ParameterHrModel { ViewField = "010", Key = "+6010" },
            new ParameterHrModel { ViewField = "011", Key = "+6011" },
            new ParameterHrModel { ViewField = "012", Key = "+6012" },
            new ParameterHrModel { ViewField = "013", Key = "+6013" },
            new ParameterHrModel { ViewField = "014", Key = "+6014" },
            new ParameterHrModel { ViewField = "015", Key = "+6015" },
            new ParameterHrModel { ViewField = "016", Key = "+6016" },
            new ParameterHrModel { ViewField = "017", Key = "+6017" },
            new ParameterHrModel { ViewField = "018", Key = "+6018" },
            new ParameterHrModel { ViewField = "019", Key = "+6019" }
        };

        public static List<ParameterHrModel> ItemListVisitorPurpose = new List<ParameterHrModel>()
        {
            new ParameterHrModel { ViewField = "OFFICIAL BUSINESS ONLY", Key = "4637" },
            new ParameterHrModel { ViewField = "OTHERS", Key = "4640" }
        };
        //new ParameterHrModel { ViewField = "PERSONAL AFFAIRS", Key = "4638" },
        //new ParameterHrModel { ViewField = "PARENTS/RELATIVES VISITING STUDENTS/STAFFS ON CAMPUS", Key = "4639" },

        public static List<ParameterHrModel> ItemListVisitorType = new List<ParameterHrModel>()
        {
            new ParameterHrModel { ViewField = "VISITOR", Key = "4641" },
            new ParameterHrModel { ViewField = "CONTRACT WORKER", Key = "4642" }
        };

        public static List<ParameterHrModel> ItemJenisPerkhidmatan = new List<ParameterHrModel>()
        {
            new ParameterHrModel { ViewField = "A - Akademik Profesional", Key = "A" },
            new ParameterHrModel { ViewField = "B - Akademik bukan Profesional", Key = "B" },
            new ParameterHrModel { ViewField = "C - Pengawai Am Profesional", Key = "C" },
            new ParameterHrModel { ViewField = "D - Pengawai Am bukan Profesional", Key = "D" },
            new ParameterHrModel { ViewField = "E - Kakitangan Sokongan", Key = "E" },
            new ParameterHrModel { ViewField = "F - Profesional", Key = "F" }
        };

        public static List<ParameterHrModel> ItemListKampus = new List<ParameterHrModel>()
        {
            //new ParameterHrModel { ViewField = "Johor Bahru", Key = "J" },
            new ParameterHrModel { ViewField = "Sungai Besi", Key = "S" },
            //new ParameterHrModel { ViewField = "Pagoh", Key = "P" }
        };

        public static string? GetLastItem(string? _text)
        {
            string _last = "";
            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (_text != null)
            {
                string[] _array = SplitAyat(_text.ToString(), ".");
                _last = _array[_array.Length - 1].ToLower();
            }
            #pragma warning restore CS8602 // Dereference of a possibly null reference.
            return _last;
        }
    }
}
