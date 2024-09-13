using Dapper;
//using Dapper;
////using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net6HrPublicLibrary.PublicShared;

namespace Net6HrPublicLibrary.PublicServices.Public
{
//    public class PublicOracleServices
//    {
//        static readonly string ConnMySQLHrUpnm = PublicConstant.ConnMySQLUpnmDbDs();
//        static readonly string ConnOraRujuk = PublicConstant.ConnOraRujuk();
//        static readonly string ConnOraSmu = PublicConstant.ConnUpnmDbSmu();
//        static string _encryptCode = PublicConstant.New2022EncryptCode();

//        public static string MtdGetHrNoRujukan(string kod)
//        {
//            string _kod = kod.ToUpper();
//            string _year = DateTime.Now.Year.ToString();
//            string _noRujukan = _kod + "/" + _year + "/";
//            ParameterHrModel _semak = MtdGetHrNoRujukanSemakSediada(_kod, _year);
//            if (_semak != null)
//            {
//                int _no = _semak.Nombor + 1;
//                _noRujukan = _noRujukan + _no.ToString("00000");
//                int _update = MtdGetHrNoRujukanUpdate(kod, _year, _no);
//            }
//            else
//            {
//                int _no = 1;
//                _noRujukan = _noRujukan + _no.ToString("00000");
//                int _insert = MtdGetHrNoRujukanInsert(kod, _year, _no);
//            }
//            return _noRujukan;
//        }
//        public static string MtdGetHrNoRujukan6digit(string kod)
//        {
//            string _kod = kod.ToUpper();
//            string _year = DateTime.Now.Year.ToString();
//            string _noRujukan = _kod + "/" + _year + "/";
//            ParameterHrModel _semak = MtdGetHrNoRujukanSemakSediada(_kod, _year);
//            if (_semak != null)
//            {
//                int _no = _semak.Nombor + 1;
//                _noRujukan = _noRujukan + _no.ToString("000000");
//                int _update = MtdGetHrNoRujukanUpdate(kod, _year, _no);
//            }
//            else
//            {
//                int _no = 1;
//                _noRujukan = _noRujukan + _no.ToString("000000");
//                int _insert = MtdGetHrNoRujukanInsert(kod, _year, _no);
//            }
//            return _noRujukan;
//        }

//        private static ParameterHrModel MtdGetHrNoRujukanSemakSediada(string kod, string year)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnOraRujuk))
//            {
//                return dbConn.QueryFirstOrDefault<ParameterHrModel>(PublicSql.SQLGetHrNoRujukanSemakSediada(), new { KOD = kod, TAHUN = year });
//            }
//        }

//        public static HrAlamatModel MtdGetHrAlamatByPk(int _alamatFk)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.QueryFirstOrDefault<HrAlamatModel>(PublicSql.SQLGetHrAlamatByPk(), new { ALAMAT_PK = _alamatFk });
//            }
//        }

//        public static IEnumerable<ParameterHrModel> MtdGetCajKlinikList(int _klinikFk)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SQLGetCajKlinikList(), new { KLINIK_FK = _klinikFk });
//            }
//        }

//        private static int MtdGetHrNoRujukanUpdate(string kod, string year, int no)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnOraRujuk))
//            {
//                return dbConn.Execute(PublicSql.SQLGetHrNoRujukanUpdate(), new { KOD = kod, TAHUN = year, NOMBOR = no });
//            }
//        }

//        private static int MtdGetHrNoRujukanInsert(string kod, string year, int no)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnOraRujuk))
//            {
//                return dbConn.Execute(PublicSql.SQLGetHrNoRujukanInsert(), new { KOD = kod, TAHUN = year, NOMBOR = no });
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListSmuParameterKeyKodByKumpulan(int _kumpulan)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.ListSmuParameterKeyKodByKumpulan(), new { KUMPULAN_FK = _kumpulan });
//            }
//        }
//        public static IEnumerable<ParameterHrModel> ListAdmParameterKeyKodByKumpulan(int _kumpulan)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.ListAdmParameterKeyKodByKumpulan(), new { KUMPULAN_FK = _kumpulan });
//            }
//        }
//        public static IEnumerable<ParameterHrModel> ListSmuParameterEnglishWithCode(int _kumpulan, string _kod)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.GetSmuParameterEnglishByKumpulanFk(), new { KUMPULAN_FK = _kumpulan });
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListTarafJawatan()
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.GetTarafJawatanSub());
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ItemListSmuParameterEnglish(int _kumpulan)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.GetSmuParameterEnglishByKumpulanFk(), new { KUMPULAN_FK = _kumpulan });
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListOfLogCategory(int _category)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SqlListOfLogCategory(_category));
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListOfSubCategory()
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SqlListOfSubCategory());
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListCountryAll()
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SqlNegaraList());
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListAgamaAll()
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SqlAgamaList());
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListBangsaAll()
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SqlBangsaList());
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListBangsaAllEnglish()
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SqlBangsaListEnglish());
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListJawatanAll()
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SqlJawatanList());
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListNegeriAll()
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SqlNegeriList());
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListFakulti2018()
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SqlFakultiList());
//            }
//        }
//        public static IEnumerable<ParameterHrModel> ListFakultiAll()
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SqlFakultiList());
//            }
//        }
//        public static IEnumerable<ParameterHrModel> ListFakultiByCampus(string _kodKampus)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SqlListFakultiByCampus(), new { KODKAMPUS = _kodKampus });
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ItemListPerananPengguna(string _kod)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SQLItemListPerananPengguna(_kod));
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListBandarByNegeri(string kod)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.getSqlBandarByKodNegeri(kod));
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListHrUnitByKodFakulti(string kod)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.getSqlListHrUnitByKodFakulti(kod));
//            }
//        }

//        public static HrStaffMaklumatPeribadiModel MtdGetHrStafMaklumatByNoKP(string NO_KP)
//        {
//            HrStaffMaklumatPeribadiModel _returnRecord = new HrStaffMaklumatPeribadiModel()
//            {
//                NO_KP_BARU = NO_KP
//            };
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                HrStaffMaklumatPeribadiModel _returnData = dbConn.QueryFirstOrDefault<HrStaffMaklumatPeribadiModel>(PublicSql.MtdGetHrStafMaklumatByNoKP(), new { NO_KP_BARU = NO_KP });
//                if (_returnData != null)
//                {
//                    _returnRecord = MtdGetAddRequireFIeld(_returnData);
//                }
//            }
//            return _returnRecord;
//        }

//        public static HrStaffMaklumatPeribadiModel MtdGetHrStafMaklumatByNoPekerja(string _nopekerja)
//        {
//            //var log = NLog.LogManager.GetCurrentClassLogger();
//            //log.Info("MtdGetHrStafMaklumatByNoPekerja MULA ~ " + _nopekerja );
//            HrStaffMaklumatPeribadiModel _returnRecord = new HrStaffMaklumatPeribadiModel()
//            {
//                NO_PEKERJA = _nopekerja,
//                NO_PEKERJA_ENC = EncryptHr.NewEncrypt(_nopekerja, _encryptCode)
//            };
//            //log.Info("MtdGetHrStafMaklumatByNoPekerja ConnMySQLHrUpnm ~ " + ConnMySQLHrUpnm);
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                HrStaffMaklumatPeribadiModel _returnData = dbConn.QueryFirstOrDefault<HrStaffMaklumatPeribadiModel>(PublicSql.MtdGetHrStafMaklumatByNoPekerja(), new { NO_PEKERJA = _nopekerja });
//                //log.Info("MtdGetHrStafMaklumatByNoPekerja _returnData.RESULTSET ~ " + _returnData.RESULTSET);
//                if (_returnData != null)
//                {
//                    _returnRecord = MtdGetAddRequireFIeld(_returnData);
//                }
//            }
//            return _returnRecord;
//        }

//        public static IEnumerable<SmisKadAsasModel> MtdGetStafYangDiselia(string NO_PEKERJA)
//        {
//            var log = NLog.LogManager.GetCurrentClassLogger();
//            IEnumerable<SmisKadAsasModel> _data = new List<SmisKadAsasModel>();
//            try
//            {
//                using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnOraSmu))
//                {
//                    IEnumerable<SmisKadAsasModel> _data2 = dbConn.Query<SmisKadAsasModel>(PublicSql.SQL_MtdGetStafYangDiselia(NO_PEKERJA));
//                    if (_data2 != null)
//                    {
//                        _data = _data2;
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                log.Info(NO_PEKERJA + " MtdGetStafYangDiselia e ~ " + e);
//            }
//            return _data;
//        }

//        public static HrStaffMaklumatPeribadiModel MtdGetHrStafMaklumatByStafFk(int _stafFk)
//        {
//            HrStaffMaklumatPeribadiModel _returnRecord = new HrStaffMaklumatPeribadiModel()
//            {
//                STAF_PK = _stafFk,
//                STAF_PK_ENC = EncryptHr.NewEncrypt(_stafFk.ToString(), _encryptCode)
//            };
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                HrStaffMaklumatPeribadiModel _returnData = dbConn.QueryFirstOrDefault<HrStaffMaklumatPeribadiModel>(PublicSql.MtdGetHrStafMaklumatByStafFk(_stafFk), new { STAF_PK = _stafFk });
//                if (_returnData != null)
//                {
//                    _returnRecord = MtdGetAddRequireFIeld(_returnData);
//                }
//            }
//            return _returnRecord;
//        }

//        private static HrStaffMaklumatPeribadiModel MtdGetAddRequireFIeld(HrStaffMaklumatPeribadiModel _returnData)
//        {
//            string _jawat = _returnData.JAWATAN_DESC;
//            _returnData.STAF_PK_ENC = EncryptHr.NewEncrypt(_returnData.STAF_PK.ToString(), _encryptCode);
//#pragma warning disable CS8604 // Possible null reference argument.
//            _returnData.NO_PEKERJA_ENC = EncryptHr.NewEncrypt(_returnData.NO_PEKERJA, _encryptCode);
//            _returnData.NO_KP_BARU_ENC = EncryptHr.NewEncrypt(_returnData.NO_KP_BARU, _encryptCode);
//            _returnData.JAWATAN_DESC = MtdGetSplitAyat(_jawat, 0);
//            _returnData.JAWATAN_AKADEMIK = MtdGetSplitAyat(_jawat, 1);
//            _returnData.JAWATAN_GRED = MtdGetSplitAyat(_jawat, 2);
//#pragma warning restore CS8604 // Possible null reference argument.
//            return _returnData;
//        }

//        public static string MtdGetSplitAyat(string _ayat, int _lokasi)
//        {
//            string _return = "";
//            if (_ayat != null)
//            {
//                string[] _ayat01 = PublicConstant.SplitAyat(_ayat, "~");
//                _return = _ayat01[_lokasi];
//            }
//            return _return;
//        }

//        public static IEnumerable<ParameterHrModel> ListKodEssential()
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SqlListKodEssential());
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListVerifierEssential(string _kod)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SqlListApprovalStructureByCode(_kod));
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListApprovalStructureStafFkByCodeJabatan(string _kod, string _kodFakulti)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SqlListApprovalStructureStafFkByCodeJabatan(_kod, _kodFakulti));
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListApprovalStructureStafFkPPTPByCodeJabatan(string _kodFakulti)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SqlListApprovalStructureStafFkPPTPByJabatan(_kodFakulti));
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListPegawaiPsmByKod(string kod)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                if (kod != null)
//                {
//                    return dbConn.Query<ParameterHrModel>(PublicSql.ListPegawaiPsmByKod(), new { KOD_PTJ = kod });
//                }
//                else
//                {
//                    return dbConn.Query<ParameterHrModel>(PublicSql.ListPegawaiPsmAll());
//                }
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListPegawaiPsmAll()
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.ListPegawaiPsmAll());
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListHrParameterBangsa()
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.GetHrParameterBangsa());
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ItemListHrParameter(int _kumpulan)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.GetHrParameterByKumpulanFk(), new { KUMPULAN_FK = _kumpulan });
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ItemListHrParameterEnglish(int _kumpulan)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.GetHrParameterEnglishByKumpulanFk(), new { KUMPULAN_FK = _kumpulan });
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ItemListPemilihanTrack()
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.GetHrParameterByKumpulanFk(), new { KUMPULAN_FK = 614 });
//            }
//        }
//        public static IEnumerable<ParameterHrModel> ListBahagianAll(string fakulti)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SqlBahagianList(fakulti));
//            }
//        }
//        public static IEnumerable<ParameterHrModel> ListTahunAll()
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.SqlTahunList());
//            }
//        }

//        public static HrStaffMaklumatPeribadiModel MtdGetBasicHrStafMaklumatByStafFk(int _stafFk)
//        {
//            HrStaffMaklumatPeribadiModel _returnRecord = new HrStaffMaklumatPeribadiModel()
//            {
//                STAF_PK = _stafFk,
//                STAF_PK_ENC = EncryptHr.NewEncrypt(_stafFk.ToString(), _encryptCode)
//            };
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                HrStaffMaklumatPeribadiModel _returnData = dbConn.QueryFirstOrDefault<HrStaffMaklumatPeribadiModel>(PublicSql.MtdGetBasicHrStafMaklumatByStafFk(), new { STAF_PK = _stafFk });
//                if (_returnData != null)
//                {
//                    _returnRecord = MtdGetAddRequireFIeld(_returnData);
//                }
//            }
//            return _returnRecord;
//        }

//        public static HrStaffMaklumatPeribadiModel MtdGetBasicHrStafMaklumatByNoKP(string NO_KP)
//        {
//            HrStaffMaklumatPeribadiModel _returnRecord = new HrStaffMaklumatPeribadiModel()
//            {
//                NO_KP_BARU = NO_KP,
//                NO_KP_BARU_ENC = EncryptHr.NewEncrypt(NO_KP, _encryptCode)
//            };
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                HrStaffMaklumatPeribadiModel _returnData = dbConn.QueryFirstOrDefault<HrStaffMaklumatPeribadiModel>(PublicSql.MtdGetBasicHrStafMaklumatByNoKP(), new { NO_KP_BARU = NO_KP });
//                if (_returnData != null)
//                {
//                    _returnRecord = MtdGetAddRequireFIeld(_returnData);
//                }
//            }
//            return _returnRecord;
//        }

//        public static HrStaffMaklumatPeribadiModel MtdGetMaklumatPeribadiByNokp(string NO_KP)
//        {
//            HrStaffMaklumatPeribadiModel _returnRecord = new HrStaffMaklumatPeribadiModel()
//            {
//                RESULTSET = "0",
//                NO_KP_BARU = NO_KP,
//                NO_KP_BARU_ENC = EncryptHr.NewEncrypt(NO_KP, _encryptCode)
//            };
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                HrStaffMaklumatPeribadiModel _returnData = dbConn.QueryFirstOrDefault<HrStaffMaklumatPeribadiModel>(PublicSql.SqlGetMaklumatPeribadiByNokp(), new { NO_KP_BARU = NO_KP });
//                if (_returnData != null)
//                {
//#pragma warning disable CS8604 // Possible null reference argument.
//                    _returnData.NO_KP_BARU_ENC = EncryptHr.NewEncrypt(_returnData.NO_KP_BARU, _encryptCode);
//#pragma warning restore CS8604 // Possible null reference argument.
//                    _returnRecord = _returnData;
//                    _returnRecord.RESULTSET = "1";
//                }
//            }
//            return _returnRecord;
//        }

//        public static HrStaffMaklumatPeribadiModel MtdGetBasicHrStafMaklumatByNoPekerja(string _nopekerja)
//        {
//            HrStaffMaklumatPeribadiModel _returnRecord = new HrStaffMaklumatPeribadiModel()
//            {
//                NO_PEKERJA = _nopekerja,
//                NO_PEKERJA_ENC = EncryptHr.NewEncrypt(_nopekerja, _encryptCode)
//            };
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                HrStaffMaklumatPeribadiModel _returnData = dbConn.QueryFirstOrDefault<HrStaffMaklumatPeribadiModel>(PublicSql.MtdGetBasicHrStafMaklumatByNoPekerja(), new { NO_PEKERJA = _nopekerja });
//                if (_returnData != null)
//                {
//                    _returnRecord = MtdGetAddRequireFIeld(_returnData);
//                }
//            }
//            return _returnRecord;
//        }


//        public static KadKedatanganModel MtdGetNoKerjaCutiSokongLulus(string noPekerjaPemohon)
//        {
//            KadKedatanganModel _returnRecord = new KadKedatanganModel()
//            {
//                KAD_NOKERJA = noPekerjaPemohon,
//                KAD_NOKERJA_ENC = EncryptHr.NewEncrypt(noPekerjaPemohon, _encryptCode),
//                KAD_PEGSOKONG = "TIADA",
//                KAD_PEGLULUS = "TIADA",
//                RESULTSET = "0"
//            };
//            try
//            {
//                using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnOraSmu))
//                {
//                    KadKedatanganModel _returnData = dbConn.QueryFirstOrDefault<KadKedatanganModel>(PublicSql.SQL_GetNoKerjaCutiSokongLulus(), new { KAD_NOKERJA = noPekerjaPemohon });
//                    if (_returnData != null)
//                    {
//                        _returnRecord = _returnData;
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                var log = NLog.LogManager.GetCurrentClassLogger();
//                log.Info("NoPekerjaPemohon-" + noPekerjaPemohon + " MtdGetNoKerjaCutiSokongLulus e ~ " + e);
//            }
//            return _returnRecord;
//        }

//        public static int MtdGetBilStafAktifFakulti(string _kodFakulti)
//        {
//            int _bilReturn = 0;
//            try
//            {
//                using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//                {
//                    int _returnData = dbConn.QueryFirstOrDefault<int>(PublicSql.SQL_GetBilStafAktifFakulti(_kodFakulti));
//                    if (_returnData > 0)
//                    {
//                        _bilReturn = _returnData;
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                var log = NLog.LogManager.GetCurrentClassLogger();
//                log.Info("_kodFakulti-" + _kodFakulti + " MtdGetBilStafAktifFakulti e ~ " + e);
//            }
//            return _bilReturn;
//        }

//        public static int MtdGetBilStafAkademikPPP(string _kod)
//        {
//            int _bilReturn = 0;
//            try
//            {
//                using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//                {
//                    int _returnData = dbConn.QueryFirstOrDefault<int>(PublicSql.SQL_GetBilStafAkademikPPP(_kod));
//                    if (_returnData > 0)
//                    {
//                        _bilReturn = _returnData;
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                var log = NLog.LogManager.GetCurrentClassLogger();
//                log.Info("_kod-" + _kod + " MtdGetBilStafAkademikPPP e ~ " + e);
//            }
//            return _bilReturn;
//        }

//        public static IEnumerable<StatistikFakultiUmumModel> MtdGetStaffBreakdownStatistik(string _kod)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<StatistikFakultiUmumModel>(PublicSql.Sql_GetStaffBreakdownStatistik(_kod));
//            }
//        }

//        public static string MtdGetHrKlinikNoRujukan(string kod)
//        {
//            string _kod = kod.ToUpper();
//            string _year = DateTime.Now.Year.ToString();
//            string _noRujukan = _kod + "/" + _year + "/";
//            ParameterHrModel _semak = MtdGetHrKlinikNoRujukanSemakSediada(_kod, _year);
//            if (_semak != null)
//            {
//                int _no = _semak.Nombor + 1;
//                _noRujukan = _noRujukan + _no.ToString("0000000000");
//                int _update = MtdGetHrKlinikNoRujukanUpdate(kod, _year, _no);
//            }
//            else
//            {
//                int _no = 1;
//                _noRujukan = _noRujukan + _no.ToString("0000000000");
//                int _insert = MtdGetHrKlinikNoRujukanInsert(kod, _year, _no);
//            }
//            return _noRujukan;
//        }
//        private static ParameterHrModel MtdGetHrKlinikNoRujukanSemakSediada(string kod, string year)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnOraRujuk))
//            {
//                return dbConn.QueryFirstOrDefault<ParameterHrModel>(PublicSql.SQLGetHrKlinikNoRujukanSemakSediada(), new { KOD = kod, TAHUN = year });
//            }
//        }
//        private static int MtdGetHrKlinikNoRujukanUpdate(string kod, string year, int no)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnOraRujuk))
//            {
//                return dbConn.Execute(PublicSql.SQLGetHrKlinikNoRujukanUpdate(), new { KOD = kod, TAHUN = year, NOMBOR = no });
//            }
//        }
//        private static int MtdGetHrKlinikNoRujukanInsert(string kod, string year, int no)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnOraRujuk))
//            {
//                return dbConn.Execute(PublicSql.SQLGetHrKlinikNoRujukanInsert(), new { KOD = kod, TAHUN = year, NOMBOR = no });
//            }
//        }

//        public static IEnumerable<ParameterHrModel> ListHrmsKodCuti()
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnOraSmu))
//            {
//                return dbConn.Query<ParameterHrModel>(PublicSql.ListHrmsKodCuti());
//            }
//        }

//        public static IEnumerable<HrStaffMaklumatPeribadiModel> MtdGetListStaffJabatan(string _userPTJ, string _noPekerja, string _nama, string _fakultiKod, string _bahagianKod)
//        {
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<HrStaffMaklumatPeribadiModel>(PublicSql.MtdGetListStaffJabatan(_userPTJ, _noPekerja, _nama, _fakultiKod, _bahagianKod));
//            }
//        }

//        public static IEnumerable<HrStaffMaklumatPeribadiModel> MtdGetCarianStaffListSearch(string? _kampus, string? _fakulti, string? _jabatan, string _unit, string? _jawatan, string? _nopekerja, string? _nokp, string? _nama, string _userPtj)
//        {
//            List<HrStaffMaklumatPeribadiModel> list = null;
//            try
//            {
//                using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//                {
//                    IEnumerable<HrStaffMaklumatPeribadiModel> _getList = dbConn.Query<HrStaffMaklumatPeribadiModel>(PublicSql.MtdGetCarianStaffListSearch(_kampus, _fakulti, _jabatan, _unit, _jawatan, _nopekerja, _nokp, _nama, _userPtj));
//                    if (_getList != null)
//                    {
//                        foreach (HrStaffMaklumatPeribadiModel _elem in _getList)
//                        {
//                            string _jawat = _elem.JAWATAN_DESC;
//                            if (_jawat != null && _jawat.Length > 5)
//                            {
//                                _elem.JAWATAN_DESC = MtdGetSplitAyat(_jawat, 0);
//                                _elem.JAWATAN_AKADEMIK = MtdGetSplitAyat(_jawat, 1);
//                                _elem.JAWATAN_GRED = MtdGetSplitAyat(_jawat, 2);
//                            }
//                        }
//                        list = _getList.ToList();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                var log = NLog.LogManager.GetCurrentClassLogger();
//                log.Info("Publc MtdGetCarianStaffListSearch _kampus~" + _kampus + " _fakulti~" + _fakulti + " _jabatan~" + _jabatan + " _unit~" + _unit + " _jawatan~" + _jawatan + " _nopekerja~" + _nopekerja + " _nokp~" + _nokp + " _nama~" + _nama + " _userPtj~" + _userPtj);
//                log.Info("Publc MtdGetCarianStaffListSearch try catch ex.Message ~ " + ex.Message);
//            }

//            return list;
//        }

//    }
}
