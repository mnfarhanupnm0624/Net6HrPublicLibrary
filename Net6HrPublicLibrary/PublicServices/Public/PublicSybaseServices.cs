using Dapper;
using System.Data;
using System.Data.Odbc;
////using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Net6HrPublicLibrary.PublicShared;
using Net6HrPublicLibrary.PublicServices.Public;
using Net6HrPublicLibrary.Model;

namespace Net6HrPublicLibrary.PublicServices.Public
{
    public class PublicSybaseServices
    {
        static readonly string ConnSybaseHrUpnm = PublicConstant.ConnSybaseUpnmDbDs();
        //static readonly string ConnSybaseHrUpnm = PublicConstant.ConnSybaseHrUpnm();
        //static readonly string ConnOraSmu = PublicConstant.ConnUpnmDbSmu();
        static string _encryptCode = PublicConstant.EncryptCode();

        public static string MtdGetHrNoRujukan(string kod)
        {
            string _kod = kod.ToUpper();
            string _year = DateTime.Now.Year.ToString();
            string _noRujukan = _kod + "/" + _year + "/";
            ParameterHrModel _semak = MtdGetHrNoRujukanSemakSediada(_kod, _year);
            if (_semak != null)
            {
                int _no = _semak.Nombor + 1;
                _noRujukan = _noRujukan + _no.ToString("00000");
                int _update = MtdGetHrNoRujukanUpdate(kod, _year, _no);
            }
            else
            {
                int _no = 1;
                _noRujukan = _noRujukan + _no.ToString("00000");
                int _insert = MtdGetHrNoRujukanInsert(kod, _year, _no);
            }
            return _noRujukan;
        }
        public static string MtdGetHrNoRujukan6digit(string kod)
        {
            string _kod = kod.ToUpper();
            string _year = DateTime.Now.Year.ToString();
            string _noRujukan = _kod + "/" + _year + "/";
            ParameterHrModel _semak = MtdGetHrNoRujukanSemakSediada(_kod, _year);
            if (_semak != null)
            {
                int _no = _semak.Nombor + 1;
                _noRujukan = _noRujukan + _no.ToString("000000");
                int _update = MtdGetHrNoRujukanUpdate(kod, _year, _no);
            }
            else
            {
                int _no = 1;
                _noRujukan = _noRujukan + _no.ToString("000000");
                int _insert = MtdGetHrNoRujukanInsert(kod, _year, _no);
            }
            return _noRujukan;
        }
        private static ParameterHrModel MtdPindahParameter(ParameterHrModel row)
        {
            return new ParameterHrModel()
            {
                Key = row.Key,
                ViewField = row.ViewField
            };
        }
        private static ParameterHrModel MtdPindahParameterWithKey(ParameterHrModel row)
        {
            return new ParameterHrModel()
            {
                Key = row.Key,
                ViewField = row.Key + " - " + row.ViewField
            };
        }
        private static ParameterHrModel MtdGetHrNoRujukanSemakSediada(string kod, string year)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.QueryFirstOrDefault<ParameterHrModel>(PublicHrSybaseSql.SQLGetHrNoRujukanSemakSediada(), new { KOD = kod, TAHUN = year });
            }
        }

        public static HrAlamatModel MtdGetHrAlamatByPk(int _alamatFk)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.QueryFirstOrDefault<HrAlamatModel>(PublicHrSybaseSql.SQLGetHrAlamatByPk(), new { ALAMAT_PK = _alamatFk });
            }
        }

        public static IEnumerable<ParameterHrModel> MtdGetCajKlinikList(int _klinikFk)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SQLGetCajKlinikList(), new { KLINIK_FK = _klinikFk });
            }
        }

        private static int MtdGetHrNoRujukanUpdate(string kod, string year, int no)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Execute(PublicHrSybaseSql.SQLGetHrNoRujukanUpdate(), new { KOD = kod, TAHUN = year, NOMBOR = no });
            }
        }

        private static int MtdGetHrNoRujukanInsert(string kod, string year, int no)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Execute(PublicHrSybaseSql.SQLGetHrNoRujukanInsert(), new { KOD = kod, TAHUN = year, NOMBOR = no });
            }
        }

        public static IEnumerable<ParameterHrModel> ListSmuParameterKeyKodByKumpulan(int _kumpulan)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.ListSmuParameterKeyKodByKumpulan(), new { KUMPULAN_FK = _kumpulan });
            }
        }
        public static IEnumerable<ParameterHrModel> ListAdmParameterKeyKodByKumpulan(int _kumpulan)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.ListAdmParameterKeyKodByKumpulan(), new { KUMPULAN_FK = _kumpulan });
            }
        }
        public static IEnumerable<ParameterHrModel> ListSmuParameterEnglishWithCode(int _kumpulan, string _kod)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.GetSmuParameterEnglishByKumpulanFk(), new { KUMPULAN_FK = _kumpulan });
            }
        }

        public static IEnumerable<ParameterHrModel> ListTarafJawatan()
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.GetTarafJawatanSub());
            }
        }

        public static IEnumerable<ParameterHrModel> ItemListSmuParameterEnglish(int _kumpulan)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.GetSmuParameterEnglishByKumpulanFk(), new { KUMPULAN_FK = _kumpulan });
            }
        }

        public static IEnumerable<ParameterHrModel> ListOfLogCategory(int _category)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SqlListOfLogCategory(_category));
            }
        }

        public static IEnumerable<ParameterHrModel> ListOfSubCategory()
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SqlListOfSubCategory());
            }
        }

        public static IEnumerable<ParameterHrModel> ListCountryAll()
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SqlNegaraList());
            }
        }

        public static IEnumerable<ParameterHrModel> ListAgamaAll()
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SqlAgamaList());
            }
        }

        public static IEnumerable<ParameterHrModel> ListBangsaAll()
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SqlBangsaList());
            }
        }

        public static IEnumerable<ParameterHrModel> ListBangsaAllEnglish()
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SqlBangsaListEnglish());
            }
        }

        public static IEnumerable<ParameterHrModel> ListJawatanAll()
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SqlJawatanList());
            }
        }

        public static IEnumerable<ParameterHrModel> ListNegeriAll()
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SqlNegeriList());
            }
        }

        public static IEnumerable<ParameterHrModel> ListFakulti2018()
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SqlFakultiList());
            }
        }
        public static IEnumerable<ParameterHrModel> ListFakultiAll()
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SqlFakultiList());
            }
        }
        public static IEnumerable<ParameterHrModel> ListFakultiByCampus(string _kodKampus)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SqlListFakultiByCampus(), new { KODKAMPUS = _kodKampus });
            }
        }

        public static IEnumerable<ParameterHrModel> ItemListPerananPengguna(string _kod)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SQLItemListPerananPengguna(_kod));
            }
        }

        public static IEnumerable<ParameterHrModel> ListBandarByNegeri(string kod)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.getSqlBandarByKodNegeri(kod));
            }
        }

        public static IEnumerable<ParameterHrModel> ListHrUnitByKodFakulti(string kod)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.getSqlListHrUnitByKodFakulti(kod));
            }
        }

        public static HrStaffMaklumatPeribadiModel MtdGetHrStafMaklumatByNoKP(string NO_KP)
        {
            HrStaffMaklumatPeribadiModel _returnRecord = new HrStaffMaklumatPeribadiModel()
            {
                NO_KP_BARU = NO_KP
            };
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                HrStaffMaklumatPeribadiModel _returnData = dbConn.QueryFirstOrDefault<HrStaffMaklumatPeribadiModel>(PublicHrSybaseSql.MtdGetHrStafMaklumatByNoKP(), new { NO_KP_BARU = NO_KP });
                if (_returnData != null)
                {
                    _returnRecord = MtdGetAddRequireFIeld(_returnData);
                }
            }
            return _returnRecord;
        }

        public static HrStaffMaklumatPeribadiModel MtdGetHrStafMaklumatByNoPekerja(string _nopekerja)
        {
            var log = NLog.LogManager.GetCurrentClassLogger();
            //log.Info("MtdGetHrStafMaklumatByNoPekerja MULA ~ " + _nopekerja );
            HrStaffMaklumatPeribadiModel _returnRecord = new HrStaffMaklumatPeribadiModel()
            {
                NO_PEKERJA = _nopekerja,
                //NO_PEKERJA_ENC = EncryptHr.NewEncrypt(_nopekerja, _encryptCode)
            };
            //log.Info("MtdGetHrStafMaklumatByNoPekerja ConnSybaseHrUpnm ~ " + ConnSybaseHrUpnm);
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                HrStaffMaklumatPeribadiModel _returnData = dbConn.QueryFirstOrDefault<HrStaffMaklumatPeribadiModel>(PublicHrSybaseSql.MtdGetHrStafMaklumatByNoPekerja(), new { NO_PEKERJA = _nopekerja });
                //log.Info("MtdGetHrStafMaklumatByNoPekerja _returnData.RESULTSET ~ " + _returnData.RESULTSET);
                if (_returnData != null)
                {
                    _returnRecord = MtdGetAddRequireFIeld(_returnData);
                }
            }
            return _returnRecord;
        }

        //public static IEnumerable<SmisKadAsasModel> MtdGetStafYangDiselia(string NO_PEKERJA)
        //{
        //    var log = NLog.LogManager.GetCurrentClassLogger();
        //    IEnumerable<SmisKadAsasModel> _data = new List<SmisKadAsasModel>();
        //    try
        //    {
        //        using (var dbConn = new OdbcConnection(ConnOraSmu))
        //        {
        //            IEnumerable<SmisKadAsasModel> _data2 = dbConn.Query<SmisKadAsasModel>(PublicHrSybaseSql.SQL_MtdGetStafYangDiselia(NO_PEKERJA));
        //            if (_data2 != null)
        //            {
        //                _data = _data2;
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        log.Info(NO_PEKERJA + " MtdGetStafYangDiselia e ~ " + e);
        //    }
        //    return _data;
        //}

        public static HrStaffMaklumatPeribadiModel MtdGetHrStafMaklumatByStafFk(int _stafFk)
        {
            HrStaffMaklumatPeribadiModel _returnRecord = new HrStaffMaklumatPeribadiModel()
            {
                STAF_PK = _stafFk,
                STAF_PK_ENC = EncryptHr.EncryptString(_stafFk.ToString(), _encryptCode)
            };
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                HrStaffMaklumatPeribadiModel _returnData = dbConn.QueryFirstOrDefault<HrStaffMaklumatPeribadiModel>(PublicHrSybaseSql.MtdGetHrStafMaklumatByStafFk(_stafFk), new { STAF_PK = _stafFk });
                if (_returnData != null)
                {
                    _returnRecord = MtdGetAddRequireFIeld(_returnData);
                }
            }
            return _returnRecord;
        }

        private static HrStaffMaklumatPeribadiModel MtdGetAddRequireFIeld(HrStaffMaklumatPeribadiModel _returnData)
        {
            string _jawat = _returnData.JAWATAN_DESC;
            _returnData.STAF_PK_ENC = EncryptHr.EncryptString(_returnData.STAF_PK.ToString(), _encryptCode);
#pragma warning disable CS8604 // Possible null reference argument.
            _returnData.NO_PEKERJA_ENC = EncryptHr.EncryptString(_returnData.NO_PEKERJA, _encryptCode);
            _returnData.NO_KP_BARU_ENC = EncryptHr.EncryptString(_returnData.NO_KP_BARU, _encryptCode);
            _returnData.JAWATAN_DESC = MtdGetSplitAyat(_jawat, 0);
            _returnData.JAWATAN_AKADEMIK = MtdGetSplitAyat(_jawat, 1);
            _returnData.JAWATAN_GRED = MtdGetSplitAyat(_jawat, 2);
#pragma warning restore CS8604 // Possible null reference argument.
            return _returnData;
        }

        public static string MtdGetSplitAyat(string _ayat, int _lokasi)
        {
            string _return = "";
            if (_ayat != null)
            {
                string[] _ayat01 = PublicConstant.SplitAyat(_ayat, "~");
                _return = _ayat01[_lokasi];
            }
            return _return;
        }

        public static IEnumerable<ParameterHrModel> ListKodEssential()
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SqlListKodEssential());
            }
        }

        public static IEnumerable<ParameterHrModel> ListVerifierEssential(string _kod)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SqlListApprovalStructureByCode(_kod));
            }
        }

        public static IEnumerable<ParameterHrModel> ListApprovalStructureStafFkByCodeJabatan(string _kod, string _kodFakulti)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SqlListApprovalStructureStafFkByCodeJabatan(_kod, _kodFakulti));
            }
        }

        public static IEnumerable<ParameterHrModel> ListApprovalStructureStafFkPPTPByCodeJabatan(string _kodFakulti)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SqlListApprovalStructureStafFkPPTPByJabatan(_kodFakulti));
            }
        }

        public static IEnumerable<ParameterHrModel> ListPegawaiPsmByKod(string kod)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                if (kod != null)
                {
                    return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.ListPegawaiPsmByKod(), new { KOD_PTJ = kod });
                }
                else
                {
                    return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.ListPegawaiPsmAll());
                }
            }
        }

        public static IEnumerable<ParameterHrModel> ListPegawaiPsmAll()
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.ListPegawaiPsmAll());
            }
        }

        public static IEnumerable<ParameterHrModel> ListHrParameterBangsa()
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.GetHrParameterBangsa());
            }
        }

        public static IEnumerable<ParameterHrModel> ItemListHrParameter(int _kumpulan)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.GetHrParameterByKumpulanFk(), new { KUMPULAN_FK = _kumpulan });
            }
        }

        public static IEnumerable<ParameterHrModel> ItemListHrParameterEnglish(int _kumpulan)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.GetHrParameterEnglishByKumpulanFk(), new { KUMPULAN_FK = _kumpulan });
            }
        }

        public static IEnumerable<ParameterHrModel> ItemListPemilihanTrack()
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.GetHrParameterByKumpulanFk(), new { KUMPULAN_FK = 614 });
            }
        }
        public static IEnumerable<ParameterHrModel> ListBahagianAll(string fakulti)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SqlBahagianList(fakulti));
            }
        }
        public static IEnumerable<ParameterHrModel> ListTahunAll()
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.SqlTahunList());
            }
        }

        public static HrStaffMaklumatPeribadiModel MtdGetBasicHrStafMaklumatByStafFk(int _stafFk)
        {
            HrStaffMaklumatPeribadiModel _returnRecord = new HrStaffMaklumatPeribadiModel()
            {
                STAF_PK = _stafFk,
                STAF_PK_ENC = EncryptHr.EncryptString(_stafFk.ToString(), _encryptCode)
            };
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                HrStaffMaklumatPeribadiModel _returnData = dbConn.QueryFirstOrDefault<HrStaffMaklumatPeribadiModel>(PublicHrSybaseSql.MtdGetBasicHrStafMaklumatByStafFk(), new { STAF_PK = _stafFk });
                if (_returnData != null)
                {
                    _returnRecord = MtdGetAddRequireFIeld(_returnData);
                }
            }
            return _returnRecord;
        }

        public static HrStaffMaklumatPeribadiModel MtdGetBasicHrStafMaklumatByNoKP(string NO_KP)
        {
            HrStaffMaklumatPeribadiModel _returnRecord = new HrStaffMaklumatPeribadiModel()
            {
                NO_KP_BARU = NO_KP,
                NO_KP_BARU_ENC = EncryptHr.EncryptString(NO_KP, _encryptCode)
            };
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                HrStaffMaklumatPeribadiModel _returnData = dbConn.QueryFirstOrDefault<HrStaffMaklumatPeribadiModel>(PublicHrSybaseSql.MtdGetBasicHrStafMaklumatByNoKP(), new { NO_KP_BARU = NO_KP });
                if (_returnData != null)
                {
                    _returnRecord = MtdGetAddRequireFIeld(_returnData);
                }
            }
            return _returnRecord;
        }

        public static HrStaffMaklumatPeribadiModel MtdGetMaklumatPeribadiByNokp(string NO_KP)
        {
            HrStaffMaklumatPeribadiModel _returnRecord = new HrStaffMaklumatPeribadiModel()
            {
                RESULTSET = "0",
                NO_KP_BARU = NO_KP,
                NO_KP_BARU_ENC = EncryptHr.EncryptString(NO_KP, _encryptCode)
            };
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                HrStaffMaklumatPeribadiModel _returnData = dbConn.QueryFirstOrDefault<HrStaffMaklumatPeribadiModel>(PublicHrSybaseSql.SqlGetMaklumatPeribadiByNokp(), new { NO_KP_BARU = NO_KP });
                if (_returnData != null)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    _returnData.NO_KP_BARU_ENC = EncryptHr.EncryptString(_returnData.NO_KP_BARU, _encryptCode);
#pragma warning restore CS8604 // Possible null reference argument.
                    _returnRecord = _returnData;
                    _returnRecord.RESULTSET = "1";
                }
            }
            return _returnRecord;
        }

        public static HrStaffMaklumatPeribadiModel MtdGetBasicHrStafMaklumatByNoPekerja(string _nopekerja)
        {
            HrStaffMaklumatPeribadiModel _returnRecord = new HrStaffMaklumatPeribadiModel()
            {
                NO_PEKERJA = _nopekerja,
                NO_PEKERJA_ENC = EncryptHr.EncryptString(_nopekerja, _encryptCode)
            };
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                HrStaffMaklumatPeribadiModel _returnData = dbConn.QueryFirstOrDefault<HrStaffMaklumatPeribadiModel>(PublicHrSybaseSql.MtdGetBasicHrStafMaklumatByNoPekerja(), new { NO_PEKERJA = _nopekerja });
                if (_returnData != null)
                {
                    _returnRecord = MtdGetAddRequireFIeld(_returnData);
                }
            }
            return _returnRecord;
        }


        //public static KadKedatanganModel MtdGetNoKerjaCutiSokongLulus(string noPekerjaPemohon)
        //{
        //    KadKedatanganModel _returnRecord = new KadKedatanganModel()
        //    {
        //        KAD_NOKERJA = noPekerjaPemohon,
        //        KAD_NOKERJA_ENC = EncryptHr.EncryptString(noPekerjaPemohon, _encryptCode),
        //        KAD_PEGSOKONG = "TIADA",
        //        KAD_PEGLULUS = "TIADA",
        //        RESULTSET = "0"
        //    };
        //    try
        //    {
        //        using (var dbConn = new OdbcConnection(ConnOraSmu))
        //        {
        //            KadKedatanganModel _returnData = dbConn.QueryFirstOrDefault<KadKedatanganModel>(PublicHrSybaseSql.SQL_GetNoKerjaCutiSokongLulus(), new { KAD_NOKERJA = noPekerjaPemohon });
        //            if (_returnData != null)
        //            {
        //                _returnRecord = _returnData;
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        var log = NLog.LogManager.GetCurrentClassLogger();
        //        log.Info("NoPekerjaPemohon-" + noPekerjaPemohon + " MtdGetNoKerjaCutiSokongLulus e ~ " + e);
        //    }
        //    return _returnRecord;
        //}

        public static int MtdGetBilStafAktifFakulti(string _kodFakulti)
        {
            int _bilReturn = 0;
            try
            {
                using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
                {
                    int _returnData = dbConn.QueryFirstOrDefault<int>(PublicHrSybaseSql.SQL_GetBilStafAktifFakulti(_kodFakulti));
                    if (_returnData > 0)
                    {
                        _bilReturn = _returnData;
                    }
                }
            }
            catch (Exception e)
            {
                var log = NLog.LogManager.GetCurrentClassLogger();
                log.Info("_kodFakulti-" + _kodFakulti + " MtdGetBilStafAktifFakulti e ~ " + e);
            }
            return _bilReturn;
        }

        public static int MtdGetBilStafAkademikPPP(string _kod)
        {
            int _bilReturn = 0;
            try
            {
                using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
                {
                    int _returnData = dbConn.QueryFirstOrDefault<int>(PublicHrSybaseSql.SQL_GetBilStafAkademikPPP(_kod));
                    if (_returnData > 0)
                    {
                        _bilReturn = _returnData;
                    }
                }
            }
            catch (Exception e)
            {
                var log = NLog.LogManager.GetCurrentClassLogger();
                log.Info("_kod-" + _kod + " MtdGetBilStafAkademikPPP e ~ " + e);
            }
            return _bilReturn;
        }

        public static IEnumerable<StatistikFakultiUmumModel> MtdGetStaffBreakdownStatistik(string _kod)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<StatistikFakultiUmumModel>(PublicHrSybaseSql.Sql_GetStaffBreakdownStatistik(_kod));
            }
        }

        //public static string MtdGetHrKlinikNoRujukan(string kod)
        //{
        //    string _kod = kod.ToUpper();
        //    string _year = DateTime.Now.Year.ToString();
        //    string _noRujukan = _kod + "/" + _year + "/";
        //    ParameterHrModel _semak = MtdGetHrKlinikNoRujukanSemakSediada(_kod, _year);
        //    if (_semak != null)
        //    {
        //        int _no = _semak.Nombor + 1;
        //        _noRujukan = _noRujukan + _no.ToString("0000000000");
        //        int _update = MtdGetHrKlinikNoRujukanUpdate(kod, _year, _no);
        //    }
        //    else
        //    {
        //        int _no = 1;
        //        _noRujukan = _noRujukan + _no.ToString("0000000000");
        //        int _insert = MtdGetHrKlinikNoRujukanInsert(kod, _year, _no);
        //    }
        //    return _noRujukan;
        //}
        //private static ParameterHrModel MtdGetHrKlinikNoRujukanSemakSediada(string kod, string year)
        //{
        //    using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
        //    {
        //        return dbConn.QueryFirstOrDefault<ParameterHrModel>(PublicHrSybaseSql.SQLGetHrKlinikNoRujukanSemakSediada(), new { KOD = kod, TAHUN = year });
        //    }
        //}
        //private static int MtdGetHrKlinikNoRujukanUpdate(string kod, string year, int no)
        //{
        //    using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
        //    {
        //        return dbConn.Execute(PublicHrSybaseSql.SQLGetHrKlinikNoRujukanUpdate(), new { KOD = kod, TAHUN = year, NOMBOR = no });
        //    }
        //}
        //private static int MtdGetHrKlinikNoRujukanInsert(string kod, string year, int no)
        //{
        //    using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
        //    {
        //        return dbConn.Execute(PublicHrSybaseSql.SQLGetHrKlinikNoRujukanInsert(), new { KOD = kod, TAHUN = year, NOMBOR = no });
        //    }
        //}

        //public static IEnumerable<ParameterHrModel> ListHrmsKodCuti()
        //{
        //    using (var dbConn = new OdbcConnection(ConnOraSmu))
        //    {
        //        return dbConn.Query<ParameterHrModel>(PublicHrSybaseSql.ListHrmsKodCuti());
        //    }
        //}

        public static IEnumerable<HrStaffMaklumatPeribadiModel> MtdGetListStaffJabatan(string _userPTJ, string _noPekerja, string _nama, string _fakultiKod, string _bahagianKod)
        {
            using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
            {
                return dbConn.Query<HrStaffMaklumatPeribadiModel>(PublicHrSybaseSql.MtdGetListStaffJabatan(_userPTJ, _noPekerja, _nama, _fakultiKod, _bahagianKod));
            }
        }

        public static IEnumerable<HrStaffMaklumatPeribadiModel> MtdGetCarianStaffListSearch(string? _kampus, string? _fakulti, string? _jabatan, string _unit, string? _jawatan, string? _nopekerja, string? _nokp, string? _nama, string _userPtj)
        {
            List<HrStaffMaklumatPeribadiModel> list = null;
            try
            {
                using (var dbConn = new OdbcConnection(ConnSybaseHrUpnm))
                {
                    IEnumerable<HrStaffMaklumatPeribadiModel> _getList = dbConn.Query<HrStaffMaklumatPeribadiModel>(PublicHrSybaseSql.MtdGetCarianStaffListSearch(_kampus, _fakulti, _jabatan, _unit, _jawatan, _nopekerja, _nokp, _nama, _userPtj));
                    if (_getList != null)
                    {
                        foreach (HrStaffMaklumatPeribadiModel _elem in _getList)
                        {
                            string _jawat = _elem.JAWATAN_DESC;
                            if (_jawat != null && _jawat.Length > 5)
                            {
                                _elem.JAWATAN_DESC = MtdGetSplitAyat(_jawat, 0);
                                _elem.JAWATAN_AKADEMIK = MtdGetSplitAyat(_jawat, 1);
                                _elem.JAWATAN_GRED = MtdGetSplitAyat(_jawat, 2);
                            }
                        }
                        list = _getList.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                var log = NLog.LogManager.GetCurrentClassLogger();
                log.Info("Publc MtdGetCarianStaffListSearch _kampus~" + _kampus + " _fakulti~" + _fakulti + " _jabatan~" + _jabatan + " _unit~" + _unit + " _jawatan~" + _jawatan + " _nopekerja~" + _nopekerja + " _nokp~" + _nokp + " _nama~" + _nama + " _userPtj~" + _userPtj);
                log.Info("Publc MtdGetCarianStaffListSearch try catch ex.Message ~ " + ex.Message);
            }

            return list;
        }

    }
}
