using Dapper;
using Net6HrPublicLibrary.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
////using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6HrPublicLibrary.PublicShared
{
    //public class TahapCapaianHelper
    //{
    //    static string ConnMySQLHrUpnm = System.Configuration.ConfigurationManager.ConnectionStrings["UpnmdbDS"].ConnectionString;
    //    static string _encryptCode = System.Configuration.ConfigurationManager.AppSettings["encryptCode"];

    //    private static string SQL_GET_TAHAP_CAPAIAN_MULTI_PERANAN(string kodFungsi)
    //    {
    //        return @" SELECT KOD_PERANAN, KOD_PTJ, PERINGKAT_CAPAIAN, PERINGKAT_CAPAIAN_TXT 
    //           FROM ( 
    //                SELECT C.KOD_PERANAN as KOD_PERANAN, B.KOD_PTJ as KOD_PTJ, D.PERINGKAT_CAPAIAN AS PERINGKAT_CAPAIAN, 
    //                DECODE(D.PERINGKAT_CAPAIAN,'1', 'A', '2', 'C', '3', 'F', '4', 'D', '5', 'E', '6', 'B','7','G','8','H','9','I','10','J','11','K','L') AS PERINGKAT_CAPAIAN_TXT  
    //                FROM PENGGUNA A, HR_STAF B, PERANAN_PENGGUNA C, TAHAP_CAPAIAN D 
    //                WHERE A.ID_PENGGUNA = :ID_PENGGUNA 
    //                  AND A.AKTIF_FLAG = 'Y' 
    //                  AND (A.STAF_FK = B.STAF_PK AND B.TKH_HAPUS IS NULL) 
    //                  AND (A.ID_PENGGUNA = C.ID_PENGGUNA AND C.TKH_HAPUS IS NULL) 
    //                  AND C.KOD_PERANAN = D.KOD_PERANAN 
    //                  AND D.KOD_FUNGSI LIKE '" + kodFungsi + "%' " +
    //                @"ORDER BY PERINGKAT_CAPAIAN ) 
    //          WHERE rownum = 1 ";
    //    }
    //    internal static TahapCapaianPage GetTahapCapaianStaf(string _idPengguna, string _kodFungsi)
    //    {
    //        using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
    //        {
    //            //var log = NLog.LogManager.GetCurrentClassLogger();
    //            //log.Info("GetTahapCapaianStaf  SQL ~ " + SQL_GET_TAHAP_CAPAIAN_MULTI_PERANAN(_kodFungsi));
    //            return dbConn.QueryFirstOrDefault<TahapCapaianPage>(SQL_GET_TAHAP_CAPAIAN_MULTI_PERANAN(_kodFungsi), new { ID_PENGGUNA = _idPengguna });
    //        }
    //    }

    //    private static string SQL_GET_TAHAP2019_CAPAIAN_MULTI_PERANAN(string kodFungsi, string _idPengguna)
    //    {
    //        return @" SELECT KOD_PERANAN, KOD_PTJ, PERINGKAT_CAPAIAN, PERINGKAT_CAPAIAN_TXT 
    //           FROM ( 
    //                SELECT C.KOD_PERANAN as KOD_PERANAN, B.KOD_PTJ as KOD_PTJ, D.PERINGKAT_CAPAIAN, 
    //                       D.PERINGKAT_CAPAIAN AS PERINGKAT_CAPAIAN_TXT  
    //                FROM PENGGUNA A, HR_STAF B, PERANAN_PENGGUNA C, TAHAP_CAPAIAN D 
    //                WHERE A.ID_PENGGUNA = '" + _idPengguna + "' " +
    //                @"  AND A.AKTIF_FLAG = 'Y' 
    //                  AND (A.STAF_FK = B.STAF_PK AND B.TKH_HAPUS IS NULL) 
    //                  AND (A.ID_PENGGUNA = C.ID_PENGGUNA AND C.TKH_HAPUS IS NULL) 
    //                  AND C.KOD_PERANAN = D.KOD_PERANAN 
    //                  AND D.KOD_FUNGSI LIKE '" + kodFungsi + "%' " +
    //                @"ORDER BY PERINGKAT_CAPAIAN ) 
    //          WHERE rownum = 1 ";
    //    }

    //    internal static TahapCapaianPage GetTahapCapaian2019Staf(string _idPengguna, string _kodFungsi)
    //    {
    //        using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
    //        {
    //            TahapCapaianPage _result = new TahapCapaianPage();
    //            //var log = NLog.LogManager.GetCurrentClassLogger();
    //            //log.Info(" " + _idPengguna + "<= ID GetTahapCapaian2019Staf  SQL ~ " + SQL_GET_TAHAP2019_CAPAIAN_MULTI_PERANAN(_kodFungsi, _idPengguna));
    //            _result = dbConn.QueryFirstOrDefault<TahapCapaianPage>(SQL_GET_TAHAP2019_CAPAIAN_MULTI_PERANAN(_kodFungsi, _idPengguna));
    //            if (_result != null)
    //            {
    //                //log.Info("GetTahapCapaian2019Staf  _table ~ " + _result.PERINGKAT_CAPAIAN + " ~ " + _result.KOD_PTJ + " ~ " + _result.KOD_PERANAN);
    //            }
    //            else
    //            {
    //                //log.Info("GetTahapCapaian2019Staf  _table ~ null ");
    //                _result = new TahapCapaianPage();
    //            }

    //            return _result;
    //        }
    //    }

    //    internal static string SQL_GET_TAHAP_CAPAIAN_PERANAN_MULTIPTJ =
    //        " SELECT KOD_PERANAN, KOD_PTJ, PERINGKAT_CAPAIAN  "
    //        + " FROM (  "
    //        + "      SELECT C.KOD_PERANAN as KOD_PERANAN, B.KOD_PTJ as KOD_PTJ, D.PERINGKAT_CAPAIAN  "
    //        + "      FROM PENGGUNA A, HR_STAF B, PERANAN_PENGGUNA C, TAHAP_CAPAIAN D  "
    //        + "      WHERE A.ID_PENGGUNA = :ID_PENGGUNA  "
    //        + "        AND A.AKTIF_FLAG = 'Y'  "
    //        + "        AND (A.STAF_FK = B.STAF_PK AND B.TKH_HAPUS IS NULL)  "
    //        + "        AND (A.ID_PENGGUNA = C.ID_PENGGUNA AND C.TKH_HAPUS IS NULL) "
    //        + "        AND (sysdate between C.TKH_MULA and C.TKH_TAMAT)  "
    //        + "        AND C.KOD_PERANAN = D.KOD_PERANAN ";
    //    internal static string SQL_GET_TAHAP_CAPAIAN_PERANAN_MULTIPTJ_WHERE =
    //          "        AND D.KOD_FUNGSI LIKE 'TAHAP%'  "
    //        + "    ORDER BY PERINGKAT_CAPAIAN ) "
    //        + " WHERE rownum = 1 ";

    //    internal static TahapCapaianPage GetTahapCapaianMultiPTJ(string _idPengguna, string _kodPeranan)
    //    {
    //        StringBuilder SQL_set = new StringBuilder();
    //        SQL_set.Append(SQL_GET_TAHAP_CAPAIAN_PERANAN_MULTIPTJ);
    //        SQL_set.Append(" AND D.KOD_PERANAN LIKE '" + _kodPeranan + "%'  ");
    //        SQL_set.Append(SQL_GET_TAHAP_CAPAIAN_PERANAN_MULTIPTJ_WHERE);

    //        using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
    //        {
    //            TahapCapaianPage _result = dbConn.QueryFirstOrDefault<TahapCapaianPage>(SQL_set.ToString(), new { ID_PENGGUNA = _idPengguna });
    //            if (_result != null)
    //            {
    //                _result.CAPAIAN_MULTI_PTJ = MtdGetDataCapaianMultiPtj(_idPengguna, _kodPeranan);
    //            }
    //            return _result;
    //        }
    //    }

    //    internal static string SQL_mtdGetDataCapaianMultiPtj =
    //        @"  SELECT MULTIPTJ as CAPAIAN_MULTI_PTJ
    //            FROM TAHAP_CAPAIAN_MULTIPTJ 
    //           WHERE ID_PENGGUNA = :ID_PENGGUNA
    //             AND KOD_PERANAN = :KOD_PERANAN 
    //             AND ( sysdate between TKH_MULA and TKH_TAMAT ) ";
    //    internal static string MtdGetDataCapaianMultiPtj(string _idPengguna, string _kodPeranan)
    //    {
    //        string multiPtj = "";
    //        using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
    //        {
    //            TahapCapaianPage _result = dbConn.QueryFirstOrDefault<TahapCapaianPage>(SQL_mtdGetDataCapaianMultiPtj, new { ID_PENGGUNA = _idPengguna, KOD_PERANAN = _kodPeranan });
    //            if (_result != null)
    //            {
    //                multiPtj = " '" + _result.CAPAIAN_MULTI_PTJ.Replace("~", "','") + "' ";
    //            }
    //            return multiPtj;
    //        }
    //    }

    //    internal static string GetTahapCapaianAppendMultiPtj(string fieldPtj, string fieldStafFk, int stafFk, TahapCapaianPage capaianPage)
    //    {
    //        String sbText = "";
    //        if (capaianPage.PERINGKAT_CAPAIAN_TXT != null && capaianPage.PERINGKAT_CAPAIAN_TXT == PublicConstant.CAPAIAN2016_SEMUA)
    //        {
    //            // Search All Faculty
    //        }
    //        else if (capaianPage.PERINGKAT_CAPAIAN_TXT != null && capaianPage.PERINGKAT_CAPAIAN_TXT == PublicConstant.CAPAIAN2016_KAMPUS)
    //        {
    //            sbText = " AND (UPPER(SUBSTR(" + fieldPtj + ",1,1))) LIKE '" + capaianPage.KOD_PTJ.Substring(0, 1) + "%'";
    //        }
    //        else if (capaianPage.PERINGKAT_CAPAIAN_TXT != null && capaianPage.PERINGKAT_CAPAIAN_TXT == PublicConstant.CAPAIAN2016_MULTI_KAMPUS)
    //        {
    //            sbText = (" AND (UPPER(SUBSTR(" + fieldPtj + ",1,3))) IN ('J" + capaianPage.KOD_PTJ.Substring(1, 2) + "', 'K" + capaianPage.KOD_PTJ.Substring(1, 2) + "') ");
    //        }
    //        else if (capaianPage.PERINGKAT_CAPAIAN_TXT != null && capaianPage.PERINGKAT_CAPAIAN_TXT == PublicConstant.CAPAIAN2016_PTJ)
    //        {
    //            sbText = (" AND (UPPER(SUBSTR(" + fieldPtj + ",1,3))) = '" + capaianPage.KOD_PTJ.Substring(0, 3) + "%'");
    //        }
    //        else if (capaianPage.PERINGKAT_CAPAIAN_TXT != null && capaianPage.PERINGKAT_CAPAIAN_TXT == PublicConstant.CAPAIAN2016_MULTI_PTJ)
    //        {
    //            sbText = (" AND (UPPER(SUBSTR(" + fieldPtj + ",1,3))) IN (" + capaianPage.CAPAIAN_MULTI_PTJ + ") ");
    //        }
    //        else if (capaianPage.PERINGKAT_CAPAIAN_TXT != null && capaianPage.PERINGKAT_CAPAIAN_TXT == PublicConstant.CAPAIAN2016_JAB)
    //        {
    //            sbText = (" AND (UPPER(SUBSTR(" + fieldPtj + ",1,5))) = '" + capaianPage.KOD_PTJ.Substring(0, 5) + "%'");
    //        }
    //        else if (capaianPage.PERINGKAT_CAPAIAN_TXT != null && capaianPage.PERINGKAT_CAPAIAN_TXT == PublicConstant.CAPAIAN2016_MULTI_JAB)
    //        {
    //            sbText = (" AND (UPPER(SUBSTR(" + fieldPtj + ",1,5))) IN (" + capaianPage.KOD_PTJ.Substring(0, 5) + ") ");
    //        }
    //        else if (capaianPage.PERINGKAT_CAPAIAN_TXT != null && capaianPage.PERINGKAT_CAPAIAN_TXT == PublicConstant.CAPAIAN2016_UNIT)
    //        {
    //            sbText = (" AND (UPPER(SUBSTR(" + fieldPtj + ",1,7))) = " + capaianPage.KOD_PTJ.Substring(0, 7) + " ");
    //        }
    //        else
    //        {
    //            sbText = (" AND " + fieldStafFk + " = " + stafFk);
    //        }
    //        return sbText;
    //    }

    //    internal static string SQL_mtdGetDataRekodOneMultiPtj(string _kodPeranan)
    //    {
    //        return @"  SELECT KOD_PERANAN, KOD_PTJ, PERINGKAT_CAPAIAN, CAPAIAN_MULTI_PTJ  
    //                     FROM (  
    //                          SELECT C.KOD_PERANAN as KOD_PERANAN, B.KOD_PTJ as KOD_PTJ, D.PERINGKAT_CAPAIAN, E.MULTIPTJ AS CAPAIAN_MULTI_PTJ
    //                          FROM PENGGUNA A, HR_STAF B, PERANAN_PENGGUNA C, TAHAP_CAPAIAN D, TAHAP_CAPAIAN_MULTIPTJ E  
    //                          WHERE A.ID_PENGGUNA = :ID_PENGGUNA  
    //                            AND A.AKTIF_FLAG = 'Y'  
    //                            AND (A.STAF_FK = B.STAF_PK AND B.TKH_HAPUS IS NULL)  
    //                            AND (A.ID_PENGGUNA = C.ID_PENGGUNA AND C.TKH_HAPUS IS NULL) 
    //                            AND (sysdate between C.TKH_MULA and C.TKH_TAMAT)  
    //                            AND C.KOD_PERANAN = D.KOD_PERANAN 
    //                            AND D.KOD_PERANAN LIKE '" + _kodPeranan + @"%'  
    //                            AND D.PERINGKAT_CAPAIAN IN ('C','E','G','I','K')  
    //                            AND (A.ID_PENGGUNA = E.ID_PENGGUNA AND D.KOD_PERANAN = E.KOD_PERANAN)
    //                        ORDER BY PERINGKAT_CAPAIAN ) 
    //                    WHERE rownum = 1 ";
    //    }

    //    public static TahapCapaianPage MtdGetDataRekodMultiPtj(string _idPengguna, string _kodPeranan)
    //    {
    //        using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
    //        {
    //            TahapCapaianPage _result = dbConn.QueryFirstOrDefault<TahapCapaianPage>(SQL_mtdGetDataRekodOneMultiPtj(_kodPeranan), new { ID_PENGGUNA = _idPengguna });
    //            if (_result != null)
    //            {
    //                string _text = _result.CAPAIAN_MULTI_PTJ;
    //                _result.CAPAIAN_MULTI_PTJ = " '" + _text.Replace("~", "','") + "' ";
    //            }
    //            return _result;
    //        }
    //    }

    //    public static string MtdGetDataRekodMultiPtjString(string _idPengguna, string _kodPeranan)
    //    {
    //        string _returnData = "";
    //        using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
    //        {
    //            TahapCapaianPage _result = dbConn.QueryFirstOrDefault<TahapCapaianPage>(SQL_mtdGetDataRekodOneMultiPtj(_kodPeranan), new { ID_PENGGUNA = _idPengguna });
    //            if (_result != null)
    //            {
    //                _returnData = _result.CAPAIAN_MULTI_PTJ;
    //            }
    //        }
    //        return _returnData;
    //    }

    //}
}
