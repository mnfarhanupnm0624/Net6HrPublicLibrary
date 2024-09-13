using Dapper;
using Net6HrPublicLibrary.Model;
using Net6HrPublicLibrary.PublicShared;
////using Oracle.ManagedDataAccess.Client;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6HrPublicLibrary.PublicServices.Login
{
//    public class LoginDBLibrary
//    {

//        //using var MySqlconnection = PublicConstant.MySql.Data.MySqlClient.MySqlConnection();
//        //public static readonly MySqlconnection = PublicConstant.MySql.Data.MySqlClient.MySqlConnection();
//        //MySqlconnection.Open();
//        //using var command = new MySqlCommand("SELECT field FROM table;", connection);
//        //using var reader = command.ExecuteReader();
//        //while (reader.Read())
//        //Console.WriteLine(reader.GetString(0));

//        static readonly string ConnMySQLHrUpnm = PublicConstant.ConnMySQLUpnmDbDs();

//        public static UserIdModel MtdGetApelCPengguna(string id)
//        {
//            var _sql = @"SELECT A.ID_PENGGUNA, A.KOD_PERANAN, A.KATALALUAN, A.STAF_FK, A.NAMA, NVL(A.EMAIL, 'null@email') as EMAIL, 
//                                  A.TKH_UBAH_KATALALUAN, A.TKH_LUPUT_KATALALUAN, A.TKH_LUPUT_ID, A.BIL_GAGAL_LOGIN, A.KLINIK_FK,
//                                  AKTIF_FLAG, PENGGUNA_BARU_FLAG, '2' as RESULTSET, A.PASSWORD, B.NO_PEKERJA as NO_PEKERJA, B.KOD_PTJ,
//                                  (SELECT S.NO_KP_BARU FROM HR_MAKLUMAT_PERIBADI S WHERE S.MAKLUMAT_PERIBADI_PK = B.MAKLUMAT_PERIBADI_FK) as KAD_PENGENALAN,
//                                  'null' AS SPR_NOKP
//                             FROM PENGGUNA A, HR_STAF B 
//                            WHERE A.ID_PENGGUNA = :ID_PENGGUNA 
//                              AND A.STAF_FK = B.STAF_PK(+) ";

//            UserIdModel _return = new UserIdModel();
//            _return.RESULTSET = "0";
//            try
//            {
//                using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//                {
//                    UserIdModel _returnNew = dbConn.QueryFirstOrDefault<UserIdModel>(_sql, new { ID_PENGGUNA = id });
//                    if (_returnNew != null && _returnNew.RESULTSET == "2")
//                    {
//                        _return = _returnNew;
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                var log = NLog.LogManager.GetCurrentClassLogger();
//                log.Info("Public MtdGetApelCPengguna e ~ " + e);
//            }
//            return _return;
//        }
//        public static UserIdModel MtdGetApelCPenggunaByNoPekerja(string id)
//        {
//            var _sql = @"SELECT A.ID_PENGGUNA, A.KOD_PERANAN, A.KATALALUAN, A.STAF_FK, A.NAMA, A.EMAIL, 
//                                  A.TKH_UBAH_KATALALUAN, A.TKH_LUPUT_KATALALUAN, A.TKH_LUPUT_ID, A.BIL_GAGAL_LOGIN, 
//                                  AKTIF_FLAG, PENGGUNA_BARU_FLAG, '2' as RESULTSET, A.PASSWORD,
//                                  (SELECT S.NO_KP_BARU FROM HR_MAKLUMAT_PERIBADI S WHERE S.MAKLUMAT_PERIBADI_PK = B.MAKLUMAT_PERIBADI_FK) as KAD_PENGENALAN,
//                                  B.NO_PEKERJA as NO_PEKERJA, B.KOD_PTJ
//                             FROM HR_STAF B, PENGGUNA A  
//                            WHERE B.NO_PEKERJA = :NO_PEKERJA 
//                              AND B.STAF_PK = A.STAF_FK AND ROWNUM = 1 ";
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.QueryFirstOrDefault<UserIdModel>(_sql, new { NO_PEKERJA = id });
//            }
//        }

//        public static UserIdModel MtdGetPengguna(string id)
//        {
//            var _sql = @"SELECT A.ID_PENGGUNA, A.KOD_PERANAN, A.KATALALUAN, A.NAMA, A.EMAIL,
//                                   A.TKH_UBAH_KATALALUAN, A.TKH_LUPUT_KATALALUAN, A.TKH_LUPUT_ID, A.PASSWORD,
//                                   A.BIL_GAGAL_LOGIN, A.AKTIF_FLAG, A.PENGGUNA_BARU_FLAG, A.STAF_FK,
//                                   (SELECT S.NO_KP_BARU FROM HR_STAF B, HR_MAKLUMAT_PERIBADI S 
//                                     WHERE B.STAF_PK = A.STAF_FK AND S.MAKLUMAT_PERIBADI_PK = B.MAKLUMAT_PERIBADI_FK) as KAD_PENGENALAN,
//                                  '1' as RESULTSET
//                             FROM PENGGUNA A 
//                            WHERE A.ID_PENGGUNA = :ID_PENGGUNA ";
//            UserIdModel _result = new UserIdModel();
//            _result.RESULTSET = "0";
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                UserIdModel _hasil = dbConn.QueryFirstOrDefault<UserIdModel>(_sql, new { ID_PENGGUNA = id });
//                if (_hasil != null) _result = _hasil;
//            }
//            return _result;
//        }

//        public static string MtdGetPenggunaByNoPekerja(string _noPekerja)
//        {
//            string _returnString = "";
//            var _sql = @"SELECT A.ID_PENGGUNA, A.KOD_PERANAN, A.KATALALUAN, A.STAF_FK, A.NAMA, A.EMAIL, 
//                                  A.TKH_UBAH_KATALALUAN, A.TKH_LUPUT_KATALALUAN, A.TKH_LUPUT_ID, A.BIL_GAGAL_LOGIN, 
//                                  AKTIF_FLAG, PENGGUNA_BARU_FLAG, '2' as RESULTSET, A.PASSWORD,
//                                  (SELECT S.NO_KP_BARU FROM HR_MAKLUMAT_PERIBADI S WHERE S.MAKLUMAT_PERIBADI_PK = B.MAKLUMAT_PERIBADI_FK) as KAD_PENGENALAN,
//                                  B.NO_PEKERJA as NO_PEKERJA, B.KOD_PTJ
//                             FROM HR_STAF B, PENGGUNA A  
//                            WHERE B.NO_PEKERJA = :NO_PEKERJA 
//                              AND B.STAF_PK = A.STAF_FK 
//                              AND ROWNUM = 1 ";
//            UserIdModel _result = new UserIdModel();
//            _result.RESULTSET = "0";
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                UserIdModel _hasil = dbConn.QueryFirstOrDefault<UserIdModel>(_sql, new { NO_PEKERJA = _noPekerja });
//                if (_hasil != null)
//                {
//                    _returnString = _hasil.ID_PENGGUNA ?? "";
//                }
//            }
//            return _returnString;
//        }

//        public static string MtdSemakUserFromMyUtmDecrypt(string _key)
//        {
//            string _returnString = "";
//            var _sql = @"SELECT ACADEMIC.DECRYPT(HEXTORAW(:KOD)) AS USER_GROUP FROM DUAL";
//            UserIdModel _result = new UserIdModel();
//            _result.RESULTSET = "0";
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                UserIdModel _hasil = dbConn.QueryFirstOrDefault<UserIdModel>(_sql, new { KOD = _key });
//                if (_hasil != null)
//                {
//                    _returnString = _hasil.USER_GROUP;
//                }
//            }
//#pragma warning disable CS8603 // Possible null reference return.
//            return _returnString;
//#pragma warning restore CS8603 // Possible null reference return.
//        }

//        public static int MtdGetPenggunaSimpan(UserIdModel pengguna)
//        {
//            //var _sql = @"UPDATE PENGGUNA 
//            //                SET KATALALUAN = :KATALALUAN, TKH_UBAH_KATALALUAN = SYSDATE,
//            //                    TKH_LUPUT_KATALALUAN = :TKH_LUPUT_KATALALUAN
//            //                WHERE ID_PENGGUNA = :ID_PENGGUNA ";
//            /* PERUBAHAN BAGI DOT.NET FIELD PASSWORD INSTED OF KATALALUAN */
//            var _sql = @"UPDATE PENGGUNA 
//                            SET PASSWORD = :KATALALUAN, TKH_UBAH_KATALALUAN = SYSDATE,
//                                TKH_LUPUT_KATALALUAN = :TKH_LUPUT_KATALALUAN
//                            WHERE ID_PENGGUNA = :ID_PENGGUNA ";
//            int _data = 0;
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                _data = dbConn.Execute(_sql, pengguna);
//            }
//            return _data;
//        }

//        public static int MtdUpdatePasswordPengguna(UserIdModel _pengguna)
//        {
//            var _sql = @"UPDATE PENGGUNA 
//                            SET PASSWORD = :KATALALUAN, TKH_UBAH_KATALALUAN = SYSDATE
//                            WHERE ID_PENGGUNA = :ID_PENGGUNA ";
//            int _data = 0;
//            try
//            {
//                using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//                {
//                    _data = dbConn.Execute(_sql, _pengguna);
//                }
//            }
//            catch (Exception e)
//            {
//                var log = NLog.LogManager.GetCurrentClassLogger();
//                log.Info("LoginDbLibrary MtdUpdatePasswordPengguna e ~ " + e);
//            }
//            return _data;
//        }

//        public static UserIdModel MtdDecryptFromTableAcad(UserIdModel _data)
//        {
//            string _sql = "SELECT HR.DECRYPT(HEXTORAW(:ENC_FROM_DASHBOARD)) AS ARRAY_FROM_ENC, " +
//                            "     '2' as RESULTSET FROM DUAL ";
//            UserIdModel _result = new UserIdModel();
//            _result.RESULTSET = "0";
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                UserIdModel _hasil = dbConn.QueryFirstOrDefault<UserIdModel>(_sql, _data);
//                if (_hasil != null) _result = _hasil;
//            }
//            return _result;
//        }

//        public static IEnumerable<string> MtdGetFunctions(string userName)
//        {
//            var _sql = @"SELECT distinct(B.KOD_FUNGSI) 
//                           FROM PERANAN_PENGGUNA A, PERANAN_FUNGSI  B 
//                          WHERE A.ID_PENGGUNA = :ID_PENGGUNA
//                            AND A.KOD_PERANAN = B.KOD_PERANAN 
//                            AND (B.KOD_FUNGSI like 'HM95%' OR B.KOD_FUNGSI = 'DEVELOPER') 
//                            AND (sysdate between A.TKH_MULA and A.TKH_TAMAT)
//                            AND A.TKH_HAPUS is null
//                             ORDER BY KOD_FUNGSI ";
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<string>(_sql, new { ID_PENGGUNA = userName });
//            }
//        }

//        public static IEnumerable<string> MtdGetFunctions(string userName, string kod)
//        {
//            var _sql = @"SELECT distinct(B.KOD_FUNGSI) 
//                               FROM PERANAN_PENGGUNA A, PERANAN_FUNGSI  B 
//                              WHERE A.ID_PENGGUNA = '" + userName + @"' AND A.TKH_HAPUS is null
//                                AND (sysdate between A.TKH_MULA and A.TKH_TAMAT) 
//                                AND A.KOD_PERANAN = B.KOD_PERANAN 
//                                AND (B.KOD_FUNGSI like '" + kod + @"%' OR B.KOD_FUNGSI = 'DEVELOPER') 
//                                AND (sysdate between B.TKH_MULA and B.TKH_TAMAT)
//                                AND A.TKH_HAPUS is null
//                                 ORDER BY KOD_FUNGSI ";
//            var log = NLog.LogManager.GetCurrentClassLogger();
//            log.Info("MtdGetFunctions  _sql ~ " + _sql);
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                return dbConn.Query<string>(_sql);
//            }
//        }

//        public static ModelUserDTO MtdGetPhotoStaf(ModelUserDTO photo)
//        {
//            var _sql = "SELECT GAMBAR as PHOTO, '2' as RESULTSET FROM HR_GAMBAR WHERE NO_PEKERJA2 = :NO_PEKERJA ";
//            ModelUserDTO _result = new();
//            _result.RESULTSET = "0";
//            using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
//            {
//                ModelUserDTO _hasil = dbConn.QueryFirstOrDefault<ModelUserDTO>(_sql, new { NO_PEKERJA = photo.NO_PEKERJA });
//                if (_hasil != null && _hasil.RESULTSET == "2")
//                {
//                    _result = _hasil;
//                    _result.RESULTSET = "2";
//                }
//            }
//            return _result;
//        }

//        //public static bool MtdGetCheckApprovalStructure(string _stafFk, string _kod)
//        //{
//        //string _sql = @"  SELECT APPROVAL_STRUCTURE_PK AS Nombor, '1' AS Tahun
//        //                            FROM HR_APPROVAL_STRUCTURE
//        //                            WHERE KOD_APPROVAL = :KOD_APPROVAL
//        //                              AND STAF_FK = :STAF_FK
//        //                              AND TKH_HAPUS IS NULL
//        //                              AND SYSDATE BETWEEN TKH_MULA AND TKH_TAMAT ";
//        //bool _result = false;
//        //using (/*var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm)*/)
//        //{
//        //    ParameterHrModel _hasil = dbConn.QueryFirstOrDefault<ParameterHrModel>(_sql, new { KOD_APPROVAL = _kod, STAF_FK = _stafFk });
//        //    if (_hasil != null && _hasil.Tahun == "1")
//        //    {
//        //        _result = true;
//        //    }
//        //}
//        //return _result;
//        //}

//    }
}

