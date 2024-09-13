using Net6HrPublicLibrary.Model;
using Dapper;
using Net6HrPublicLibrary.PublicShared;
////using Oracle.ManagedDataAccess.Client;
///using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6HrPublicLibrary.PublicServices.Login
{
    public class LoginDBStafUPNM
    {
        static readonly string ConnSybaseUpnm = PublicConstant.ConnSybaseUpnmDbDs();
        static readonly string _encryptCode = PublicConstant.EncryptCode();

        static readonly string _VW_STAF_AKTIF =
           @" SELECT NO_PEKERJA AS NO_PEKERJA,
              nokp AS NO_KP,
              gelar_nama AS NAMA,
              kdjwthakiki AS KOD_JAWATAN_HAKIKI,
              jawatanhakiki AS JAWATAN_HAKIKI,
              kdjbtnhakiki AS KOD_JABATAN_HAKIKI,
              jabatanhakiki AS JABATAN_HAKIKI,
              kdjwtsemasa AS KOD_JAWATAN_SEMASA,
              jawatansemasa AS JAWATAN_SEMASA,
              kdjbtnsemasa AS KOD_JABATAN_SEMASA,
              jabatansemasa AS JABATAN_SEMASA,
              email AS EMAIL,
              handphone AS HANDPHONE,
              kodstatus AS KOD_STATUS
              FROM v630staf_apel where status='Aktif'; ";
        public static UserIdModel MtdGetApelCPengguna(string id)
        {
            string _sql = _VW_STAF_AKTIF;

            UserIdModel _return = new UserIdModel();
            _return.RESULTSET = "0";
            try
            {
                //                using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnMySQLHrUpnm))
                //                {
                //#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                //                    UserIdModel _returnNew = dbConn.QueryFirstOrDefault<UserIdModel>(_sql, new { ID_PENGGUNA = id });
                //#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                //                    if (_returnNew != null && _returnNew.RESULTSET == "2")
                //                    {
                //                        _return = _returnNew;
                //                    }
                //                }
                using (IDbConnection dbConn = new OdbcConnection(ConnSybaseUpnm))
                {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    UserIdModel _returnNew = dbConn.QueryFirstOrDefault<UserIdModel>(_sql, new { ID_PENGGUNA = id });
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    if (_returnNew != null && _returnNew.RESULTSET == "2")
                    {
                        _return = _returnNew;
                    }
                }
            }
            catch (Exception e)
            {
                var log = NLog.LogManager.GetCurrentClassLogger();
                log.Info("Public MtdGetApelCPengguna e ~ " + e);
            }
            return _return;
        }
        //static readonly string _VW_STAF_AKTIF =
        //    @" SELECT NO_BARCODE AS NOBARCODE, IC AS SPR_NOKP, NO_MATRIK AS NO_PEKERJA,
        //              NAMA, KURSUS AS KOD_KURSUS, KOD_KOLEJ AS KOD_KOLEJ, KOD_KAMPUS, KOD_FAKULTI as KOD_PTJ, 
        //              EMAIL, HANDPHONE, GAMBAR as PHOTO, NAMA_PENDEK as USERNAME,
        //              KOLEJ AS NAMA_KOLEJ, '1' as RESULTSET
        //         FROM SENARAI.VW_STUDENT_AKTIF_KESELURUHAN ";



        public static string SQL_GetStaffRecord(string _nokp)
        {
            string _sQL = _VW_STAF_AKTIF;
            _sQL += " WHERE ( IC = '" + _nokp + "') ";
            var log = NLog.LogManager.GetCurrentClassLogger();
            log.Info("SQL_GetStaffRecord  _sQL ~ " + _sQL);
            return _sQL;
        }

        public static ModelUserDTO MtdGetDataPelajarByNokp(string _nokp)
        {
            ModelUserDTO _return = new ModelUserDTO();
            _return.RESULTSET = "0";
            _return.RESULTSET_TEXT = "BEGIN GET STAF RECORD";
            //try
            //{
            //    string _sQl = SQL_GetStaffRecord(_nokp);
            //    //var log = NLog.LogManager.GetCurrentClassLogger();
            //    //log.Info("MtdGetDataPelajarByNokp _sQl ~ " + _sQl);

            //    using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnSyAkademik))
            //    {
            //        ModelUserDTO _data = dbConn.QueryFirstOrDefault<ModelUserDTO>(_sQl);
            //        //log.Info("MtdGetDataPelajarByNokp try catch _data.RESULTSET ~ " + _data.RESULTSET);
            //        if (_data != null && _data.RESULTSET == "1")
            //        {
            //            if (_data.USERNAME == null)
            //            {
            //                _data.USERNAME = (PublicConstant.SplitAyat(PublicConstant.MtdRemoveSpecialCharacter5space(_data.NAMA), " "))[0];
            //            }
            //            _return = _data;
            //            _return.HRSTAFFK = "0";
            //            //_return.PHOTOSTUDENT = MtdGetStudenBhoto(_return.GRK_NOKP);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    var log = NLog.LogManager.GetCurrentClassLogger();
            //    log.Info("MtdGetDataPelajarByNokp _nokp ~ " + _nokp);
            //    log.Info("MtdGetDataPelajarByNokp try catch ex.Message ~ " + ex.Message);
            //}
            return _return;
        }

        //public static ModelUserDTO MtdGetDataPelajarByNokp(string _nokp)
        //{
        //    ModelUserDTO _return = new ModelUserDTO();
        //    _return.RESULTSET = "0";
        //    _return.RESULTSET_TEXT = "BEGIN GET STAF RECORD";
        //    //try
        //    //{
        //    //    string _sQl = SQL_GetStaffRecord(_nokp);
        //    //    //var log = NLog.LogManager.GetCurrentClassLogger();
        //    //    //log.Info("MtdGetDataPelajarByNokp _sQl ~ " + _sQl);

        //    //    using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnSyAkademik))
        //    //    {
        //    //        ModelUserDTO _data = dbConn.QueryFirstOrDefault<ModelUserDTO>(_sQl);
        //    //        //log.Info("MtdGetDataPelajarByNokp try catch _data.RESULTSET ~ " + _data.RESULTSET);
        //    //        if (_data != null && _data.RESULTSET == "1")
        //    //        {
        //    //            if (_data.USERNAME == null)
        //    //            {
        //    //                _data.USERNAME = (PublicConstant.SplitAyat(PublicConstant.MtdRemoveSpecialCharacter5space(_data.NAMA), " "))[0];
        //    //            }
        //    //            _return = _data;
        //    //            _return.HRSTAFFK = "0";
        //    //            //_return.PHOTOSTUDENT = MtdGetStudenBhoto(_return.GRK_NOKP);
        //    //        }
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    var log = NLog.LogManager.GetCurrentClassLogger();
        //    //    log.Info("MtdGetDataPelajarByNokp _nokp ~ " + _nokp);
        //    //    log.Info("MtdGetDataPelajarByNokp try catch ex.Message ~ " + ex.Message);
        //    //}
        //    return _return;
        //}

        //public static ModelUserDTO MtdGetPhotoStudent(string _nokp)
        //{
        //ModelUserDTO _return = new ModelUserDTO();
        //_return.RESULTSET = "0";
        //_return.RESULTSET_TEXT = "BEGIN GET PHOTO STUDENT";
        //try
        //{
        //    using (var dbConn = new MySql.Data.MySqlClient.MySqlConnection(ConnSyAkademik))
        //    {
        //        ModelUserDTO _data = dbConn.QueryFirstOrDefault<ModelUserDTO>(SQL_GetStaffRecord(_nokp));
        //        if (_data != null && _data.RESULTSET == "1")
        //        {
        //            _return.PHOTO = _data.PHOTO;
        //            _return.RESULTSET = "1";
        //            _return.HRSTAFFK = "0";
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    var log = NLog.LogManager.GetCurrentClassLogger();
        //    log.Info("MtdGetDataPelajarByNokp try catch ex.Message ~ " + ex.Message);
        //}
        //return _return;
        //}


    }
}
