using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6HrPublicLibrary.PublicServices.Public
{
    internal class PublicHrSybaseSql
    {
        public static string SqlAgamaList()
        {
            return @"SELECT PARAM_PK, KOD as Key, NAMA_PARAMETER as ViewField  
                       FROM HR_PARAMETER 
                      WHERE KUMPULAN_FK = 5 AND TKH_HAPUS is null Order By Key ";
        }

        public static string SqlNegaraList()
        {
            return @"SELECT KOD_NEGARA as Key, DESKRIPSI as ViewField 
                       FROM ADM_NEGARA 
                      WHERE TKH_HAPUS is null AND AKTIF = 'Y' Order By ViewField ";
        }

        public static string SqlBangsaList()
        {
            return @"SELECT PARAM_PK as Key, KOD, NAMA_PARAMETER as ViewField  
                       FROM HR_PARAMETER 
                      WHERE KUMPULAN_FK = 4 AND TKH_HAPUS is null 
                        AND KOD_KESETARAAN is not null Order By Key";
        }

        internal static string SqlBangsaListEnglish()
        {
            return @"SELECT PARAM_PK as Key, KOD, NAMA_PARAMETER_EN as ViewField  
                       FROM HR_PARAMETER 
                      WHERE KUMPULAN_FK = 4 AND TKH_HAPUS is null 
                        AND KOD_KESETARAAN is not null Order By Key";
        }

        public static string SqlJawatanList()
        {
            return @"SELECT A.KOD_JAWATAN as Key, A.KOD_JAWATAN || ' - ' || B.DESKRIPSI as ViewField 
                       FROM HR_KOD_JAWATAN A, HR_KOD_JENIS_JAWATAN B 
                      WHERE A.KOD_JENIS_JAWATAN = B.KOD_JENIS_JAWATAN  
                        AND A.KOD_KLASIFIKASI = B.KOD_KLASIFIKASI 
                        AND A.TKH_HAPUS is null  ORDER BY Key ";
        }

        public static string SqlNegeriList()
        {
            return @"SELECT KOD_NEGERI as Key, DESKRIPSI as ViewField 
                       FROM ADM_NEGERI 
                      WHERE TKH_HAPUS IS NULL 
                        AND (KOD_MYMOHES_NEGERI IS NOT NULL AND KOD_MYMOHES_NEGERI != '-1')  
                      ORDER BY Key ";
        }

        internal static string SQLGetHrNoRujukanInsert()
        {
            return @" INSERT INTO HR_NO_RUJUKAN 
                                 (KOD, TAHUN, NOMBOR, TKH_CIPTA)  
                          VALUES (:KOD, :TAHUN, :NOMBOR, SYSDATE) ";
        }

        internal static string SQLGetHrNoRujukanUpdate()
        {
            return @" UPDATE HR_NO_RUJUKAN 
                         SET NOMBOR = :NOMBOR
                       WHERE KOD = :KOD AND TAHUN = :TAHUN";
        }

        internal static string SQLGetHrNoRujukanSemakSediada()
        {
            return @"SELECT KOD as Key, TAHUN as Tahun, NOMBOR as Nombor 
                       FROM HR_NO_RUJUKAN 
                      WHERE KOD = :KOD AND TAHUN = :TAHUN ";
        }

        internal static string SQLGetHrKlinikNoRujukanSemakSediada()
        {
            return @"SELECT KOD as Key, TAHUN as Tahun, NOMBOR as Nombor 
                       FROM HR_KLINIK_NORUJUKAN 
                      WHERE KOD = :KOD AND TAHUN = :TAHUN ";
        }
        internal static string SQLGetHrKlinikNoRujukanUpdate()
        {
            return @" UPDATE HR_KLINIK_NORUJUKAN 
                         SET NOMBOR = :NOMBOR
                       WHERE KOD = :KOD AND TAHUN = :TAHUN";
        }
        internal static string SQLGetHrKlinikNoRujukanInsert()
        {
            return @" INSERT INTO HR_KLINIK_NORUJUKAN 
                                 (KOD, TAHUN, NOMBOR, TKH_CIPTA)  
                          VALUES (:KOD, :TAHUN, :NOMBOR, SYSDATE) ";
        }

        internal static string SQLGetCajKlinikList()
        {
            return @"  SELECT JENIS_RAWATAN as ViewField, CAJ_FK || '~~' || CAJ as KEY
                         FROM HR_KEMUDAHAN_KLINIK
                        WHERE KLINIK_FK = :KLINIK_FK 
                          AND TKH_HAPUS IS NULL AND CAJ_FK IS NOT NULL";
            //return @"  SELECT NAMA_PARAMETER as ViewField, PARAM_PK as KEY
            //             FROM HR_PARAMETER
            //            WHERE KUMPULAN_FK = 276 AND PARAM_PK != 1020
            //            ORDER BY NAMA_PARAMETER ";
        }

        internal static string SqlListOfLogCategory(int _category)
        {
            return @"  SELECT KATEGORITUGAS_PK as Key, DESKRIPSI as ViewField 
                         FROM ELOG_KATEGORI_TUGAS 
                        WHERE TKH_HAPUS IS NULL AND KATEGORI_FK = " + _category + "   ORDER BY SUSUNAN ";
        }

        internal static string SQLGetHrAlamatByPk()
        {
            return @"  SELECT  A.ALAMAT_PK , A.SAMBUNGAN, A.POSKOD, A.NO_TEL1, A.NO_TEL2, A.NO_TEL_BIMBIT, A.NO_TEL_PEJABAT, A.NO_TELEKS, 
                               A.FAKS, A.FAKS2, A.EMAIL_RASMI, A.EMAIL_KEDUA, A.EMAIL_KETIGA, A.LAMAN_WEB, A.ALAMAT1, A.ALAMAT2, A.ALAMAT3, 
                               A.TKH_CIPTA, A.TKH_HAPUS, A.KOD_NEGERI, A.KOD_DAERAH, A.KOD_BANDAR, A.KOD_NEGARA, A.TEL_TEMP, A.ALAMAT, A.NO_SINGKAT,
                               '1' AS RESULTSET,
                               (SELECT D.DESKRIPSI FROM ADM_DAERAH D WHERE D.KOD_DAERAH = A.KOD_DAERAH) AS DAERAH_TEXT,
                               (SELECT E.DESKRIPSI FROM ADM_NEGERI E WHERE E.KOD_NEGERI = A.KOD_NEGERI) AS NEGERI_TEXT
                        FROM HR_ALAMAT A
                        WHERE A.ALAMAT_PK = :ALAMAT_PK ";
        }

        internal static string ListAdmParameterKeyKodByKumpulan()
        {
            return @" SELECT KOD as Key, NAMA_PARAMETER_EN as ViewField 
                        FROM ADM_PARAMETER WHERE KUMPULAN_FK = :KUMPULAN_FK AND AKTIF = 'Y' 
                        ORDER BY KOD ";
        }

        internal static string GetTarafJawatanSub()
        {
            return @"  SELECT TARAF_JAWATAN_SUB_PK as Key, DESKRIPSI as ViewField 
                         FROM HR_TARAF_JAWATAN_SUB ";
        }

        internal static string SqlListOfSubCategory()
        {
            return @"  SELECT KATEGORILOG_PK as Key, DESKRIPSI as ViewField 
                         FROM ELOG_KATEGORI 
                        WHERE KATEGORILOG_PK > 1 AND TKH_HAPUS IS NULL ORDER BY SUSUNAN ";
        }

        public static string SqlFakultiList()
        {
            return @"SELECT KOD_FAKULTI as Key, KOD_FAKULTI || ' - ' ||DESKRIPSI as ViewField 
                       FROM HR_FAKULTI 
                      WHERE TKH_HAPUS IS NULL AND STATUS_AKTIF = 'Y' AND STATUS_ADASTAF = 'Y' 
                      ORDER BY key ";
        }
        internal static string SqlListFakultiByCampus()
        {
            return @"SELECT KOD_FAKULTI as Key, KOD_FAKULTI || ' - ' ||DESKRIPSI as ViewField 
                       FROM HR_FAKULTI 
                      WHERE  SUBSTR(KOD_FAKULTI,1,1) = :KODKAMPUS
                        AND TKH_HAPUS IS NULL AND STATUS_AKTIF = 'Y' AND STATUS_ADASTAF = 'Y' 
                      ORDER BY key ";
        }


        public static string SqlListKodEssential()
        {
            return @" SELECT PARAM_PK as Key, NAMA_PARAMETER as ViewField 
                        FROM SMU_PARAMETER WHERE KUMPULAN_FK = 503 AND AKTIF = 'Y' ";
        }

        public static string getSqlBandarByKodNegeri(string kod)
        {
            if (kod != "")
            {
                return " SELECT KOD_BANDAR as Key, DESKRIPSI as ViewField " +
                    "  FROM ADM_BANDAR " +
                    " WHERE KOD_NEGERI = '" + kod + "' AND TKH_HAPUS is null " +
                    " ORDER BY ViewField ";
            }
            else
            {
                return " SELECT KOD_BANDAR as Key, DESKRIPSI as ViewField " +
                    "  FROM ADM_BANDAR " +
                    " WHERE TKH_HAPUS is null " +
                    " ORDER BY ViewField ";
            }
        }

        internal static string SQLItemListPerananPengguna(string _kod)
        {
            return @"  SELECT KOD_PERANAN as Key,  KOD_PERANAN || ' - ' || NAMA_PERANAN as ViewField
                         FROM PERANAN
                        WHERE KOD_PERANAN LIKE '" + _kod + "%' ";
        }

        internal static string getSqlListHrUnitByKodFakulti(string kod)
        {
            if (kod != "")
            {
                return " SELECT KOD_UNIT as Key, KOD_UNIT || ' - ' || DESKRIPSI as ViewField " +
                    "  FROM HR_UNIT " +
                    " WHERE KOD_FAKULTI = '" + kod + "' AND TKH_HAPUS is null " +
                    " ORDER BY Key ";
            }
            else
            {
                return " SELECT KOD_UNIT as Key, DESKRIPSI as ViewField " +
                    "  FROM HR_UNIT " +
                    " WHERE TKH_HAPUS is null " +
                    " ORDER BY ViewField ";
            }
        }

        internal static string SqlGetHrStafMaklumat_basic =
            @"SELECT A.STAF_PK, A.UMUR_PILIHAN_PENCEN_FK, A.TKH_PENCEN, TO_CHAR(A.TKH_PENCEN,'DD-MON-YYYY') AS PAPAR_TKHPENCEN, 
                            A.TKH_MULA_JPA, A.TKH_MULA_UTM, A.TKH_LANTIKAN_TERKINI, A.TKH_MULA_KONTRAK, A.TKH_TAMAT_KONTRAK,
                            A.TKH_SAH_JAWATAN, TO_CHAR(A.TKH_SAH_JAWATAN,'DD-MON-YYYY') AS PAPAR_TKHSAHJAWATAN,  
                            A.GELARAN_PROFESSIONAL, A.NO_PEKERJA, A.TKH_HENTI, A.KOD_PTJ, A.KOD_JAWATAN, 
                            A.KOD_PTJ_ASAL, A.KOD_JAWATAN_GILIRAN, A.TKH_KURSUS_BTN, A.STATUS_ASSTATK, 
                            A.STATUS_AKTIF, A.ASTARAFK, A.STATUS_BTN, A.TKH_LAPOR_DIRI, A.NO_FAIL,
                            A.KOD_JAWATAN_HAKIKI, A.PUSAT_KOS, A.KOD_PTJ_PENEMPATAN, 
                            A.TKH_LANTIK_TETAP, TO_CHAR(A.TKH_LANTIK_TETAP,'DD-MON-YYYY') AS PAPAR_TKHLANTIKTETAP,
                            A.TKH_LANTIKAN_AKADEMIK, TO_CHAR(A.TKH_LANTIKAN_AKADEMIK,'dd/MM/yyyy') AS PAPAR_TKHLANTIKANAKADEMIK,
                            A.TARAF_JAWATAN_SUB_FK, 
                            B.MAKLUMAT_PERIBADI_PK, B.ALAMAT_TETAP_FK, B.ALAMAT_MENYURAT_FK, B.ALAMAT_PEJABAT_FK, 
                            B.AGAMA, B.BANGSA_FK, B.KEWARGANEGARAAN, B.KOD_NEGERI_LAHIR, B.STATUS_KAHWIN, 
                            B.KOD_WARGANEGARA, B.JANTINA, B.NO_KP_LAMA, B.NO_KP_BARU, B.TEMPAT_LAHIR, 
                            TRIM(B.NAMA) as NAMA, B.WARNA_KP, B.NO_OKU, B.TKH_MATI, 
                            B.TKH_LAHIR, TO_CHAR(B.TKH_LAHIR,'DD-MON-YYYY') AS PAPAR_TKHLAHIR, 
                            SUBSTR(A.KOD_PTJ,1,1) AS KAMPUS_KOD, SUBSTR(A.KOD_PTJ,0,3) AS KOD_FAKULTI,
                            DECODE (SUBSTR(A.KOD_PTJ,1,1), 'P','PAGOH','K','KUALA LUMPUR','J','JOHOR BAHRU',SUBSTR(A.KOD_PTJ,1,1)) AS KAMPUS_DESC,
                            (SELECT (E.DESKRIPSI || '~' || D.AKADEMIK || '~' || D.KOD_GRED_JAWATAN) FROM HR_KOD_JAWATAN D, HR_KOD_JENIS_JAWATAN E 
                               WHERE D.KOD_JAWATAN = A.KOD_JAWATAN 
                               AND (D.KOD_JENIS_JAWATAN = E.KOD_JENIS_JAWATAN(+) 
                               AND  D.KOD_KLASIFIKASI = E.KOD_KLASIFIKASI(+))) AS JAWATAN_DESC,
                            (SELECT F.DESKRIPSI  FROM HR_FAKULTI F 
                              WHERE  F.KOD_FAKULTI = SUBSTR(A.KOD_PTJ,0,3)) AS FAKULTI_DESC,
                            (SELECT G.GAMBAR FROM HR_GAMBAR G WHERE G.MAKLUMAT_PERIBADI_FK = A.MAKLUMAT_PERIBADI_FK AND ROWNUM = 1) AS PHOTOSTAF,
                            (SELECT Z.LPPT_SKOP || '~' || Y.KOD_KUMPULAN_LPPT || '~' || DECODE(Z.LPPT_SKOP,1,'SAINS TEKNIKAL','SAINS SOSIAL') AS SKOP_TEXT
                               FROM HR_LPPT_KLASIFIKASI Z, HR_LPPT_KUMPULAN_STAF Y
                              WHERE Z.STAF_FK = A.STAF_PK AND Z.STATUS_AKTIF = 'Y'
                                AND SYSDATE BETWEEN Z.TKH_MULA AND Z.TKH_TAMAT
                                AND Z.KOD_KLASIFIKASI = Y.KUMPULAN_STAF_PK AND ROWNUM = 1) AS LPPT_DATA, '2' AS RESULTSET, 
                            (SELECT EMAIL_RASMI FROM HR_ALAMAT WHERE ALAMAT_PK = B.ALAMAT_PEJABAT_FK) as EMAIL_RASMI,
                            (SELECT NO_TEL_BIMBIT FROM HR_ALAMAT WHERE ALAMAT_PK = B.ALAMAT_MENYURAT_FK) as NO_HP
                       FROM HR_STAF A, HR_MAKLUMAT_PERIBADI B ";

        internal static string MtdGetHrStafMaklumatByNoKP()
        {
            return SqlGetHrStafMaklumat_basic + @"
                      WHERE A.MAKLUMAT_PERIBADI_FK = B.MAKLUMAT_PERIBADI_PK 
                        AND B.NO_KP_BARU = :NO_KP_BARU ";
        }

        internal static string MtdGetHrStafMaklumatByNoPekerja()
        {
            return SqlGetHrStafMaklumat_basic + @"
                      WHERE A.NO_PEKERJA = :NO_PEKERJA 
                        AND A.MAKLUMAT_PERIBADI_FK = B.MAKLUMAT_PERIBADI_PK ";
        }

        internal static string MtdGetHrStafMaklumatByStafFk(int stafFk)
        {
            return SqlGetHrStafMaklumat_basic + @"
                      WHERE A.STAF_PK = :STAF_PK 
                        AND A.MAKLUMAT_PERIBADI_FK = B.MAKLUMAT_PERIBADI_PK ";
        }

        internal static string GetHrParameterByKumpulanFk()
        {
            return @"SELECT PARAM_PK as Key, NAMA_PARAMETER as ViewField  
                       FROM HR_PARAMETER 
                      WHERE KUMPULAN_FK = :KUMPULAN_FK AND TKH_HAPUS is null Order By Key ";
        }

        internal static string GetHrParameterEnglishByKumpulanFk()
        {
            return @"SELECT PARAM_PK as Key, NAMA_PARAMETER_EN as ViewField  
                       FROM HR_PARAMETER 
                      WHERE KUMPULAN_FK = :KUMPULAN_FK AND TKH_HAPUS is null Order By Key ";
        }

        internal static string GetHrParameterBangsa()
        {
            return @"SELECT PARAM_PK as Key, NAMA_PARAMETER as ViewField  
                       FROM HR_PARAMETER 
                      WHERE KUMPULAN_FK = 4 AND LENGTH(KOD) = 1 AND TKH_HAPUS is null Order By KOD ";
        }

        internal static string ListPegawaiPsmAll()
        {
            return @" SELECT  B.STAF_FK as Key,  C.KOD_JAWATAN || ' - ' || TRIM(D.NAMA) as ViewField 
                            FROM PERANAN_PENGGUNA A, PENGGUNA B, HR_STAF C, HR_MAKLUMAT_PERIBADI D
                            WHERE A.KOD_PERANAN = 'HK01' AND A.TKH_HAPUS IS NULL
                              AND A.ID_PENGGUNA = B.ID_PENGGUNA
                              AND B.STAF_FK = C.STAF_PK AND C.NO_PEKERJA IS NOT NULL
                              AND C.MAKLUMAT_PERIBADI_FK = D.MAKLUMAT_PERIBADI_PK
                            ORDER BY ViewField ";
        }

        internal static string SqlListApprovalStructureByCode(string kod)
        {
            return @" SELECT B.NO_PEKERJA as Key, KOD_FAKULTI || ' - ' || TRIM(C.NAMA) as ViewField  
                        FROM HR_APPROVAL_STRUCTURE A, HR_STAF B, HR_MAKLUMAT_PERIBADI C
                       WHERE A.KOD_APPROVAL = '" + kod + @"' AND A.TKH_HAPUS is null 
                         AND SYSDATE BETWEEN A.TKH_MULA AND A.TKH_TAMAT
                         AND A.STAF_FK = B.STAF_PK AND B.MAKLUMAT_PERIBADI_FK = C.MAKLUMAT_PERIBADI_PK
                       ORDER BY ViewField";
        }

        internal static string SqlListApprovalStructureStafFkByCodeJabatan(string _kod, string _kodFakulti)
        {
            return @" SELECT A.STAF_FK as Key, KOD_FAKULTI || ' - ' || TRIM(C.NAMA) as ViewField  
                        FROM HR_APPROVAL_STRUCTURE A, HR_STAF B, HR_MAKLUMAT_PERIBADI C
                       WHERE A.KOD_APPROVAL = '" + _kod + @"' 
                         AND A.KOD_FAKULTI = '" + _kodFakulti + @"'
                         AND A.TKH_HAPUS is null 
                         AND SYSDATE BETWEEN A.TKH_MULA AND A.TKH_TAMAT
                         AND A.STAF_FK = B.STAF_PK AND B.MAKLUMAT_PERIBADI_FK = C.MAKLUMAT_PERIBADI_PK
                       ORDER BY ViewField ";
        }

        internal static string SqlListApprovalStructureStafFkPPTPByJabatan(string _kodFakulti)
        {
            return @" SELECT A.STAF_FK as Key, KOD_FAKULTI || ' - ' || TRIM(C.NAMA) as ViewField  
                        FROM HR_APPROVAL_STRUCTURE A, HR_STAF B, HR_MAKLUMAT_PERIBADI C
                       WHERE A.KOD_APPROVAL in ('06001','06002')  
                         AND A.KOD_FAKULTI = '" + _kodFakulti + @"'
                         AND A.TKH_HAPUS is null 
                         AND SYSDATE BETWEEN A.TKH_MULA AND A.TKH_TAMAT
                         AND A.STAF_FK = B.STAF_PK AND B.MAKLUMAT_PERIBADI_FK = C.MAKLUMAT_PERIBADI_PK
                       ORDER BY ViewField ";
        }

        internal static string ListPegawaiPsmByKod()
        {
            return " SELECT B.STAF_FK as Key,  C.KOD_JAWATAN || ' - ' || TRIM(D.NAMA) as ViewField " +
                   "   FROM PERANAN_PENGGUNA A, PENGGUNA B, HR_STAF C, HR_MAKLUMAT_PERIBADI D " +
                   "   WHERE A.KOD_PERANAN = 'HK01' AND A.TKH_HAPUS IS NULL " +
                   "     AND A.ID_PENGGUNA = B.ID_PENGGUNA " +
                   "     AND B.STAF_FK = C.STAF_PK AND C.NO_PEKERJA IS NOT NULL " +
                   "     AND SUBSTR(C.KOD_PTJ,0,3) = :KOD_PTJ " +
                   "     AND C.MAKLUMAT_PERIBADI_FK = D.MAKLUMAT_PERIBADI_PK " +
                   "   ORDER BY ViewField ";
        }

        internal static string SqlBahagianList(string fakulti)
        {
            if (fakulti != null && fakulti != "")
            {
                return " SELECT KOD_JABATAN AS KEY, KOD_JABATAN || '-' || DESKRIPSI AS VIEWFIELD " +
                       "   FROM HR_JABATAN " +
                       "  WHERE KOD_FAKULTI = '" + fakulti + "' AND TKH_HAPUS IS NULL " +
                       "  ORDER BY KEY";
            }
            else
            {
                return " SELECT KOD_JABATAN AS KEY, KOD_JABATAN || '-' || DESKRIPSI AS VIEWFIELD " +
                       "   FROM HR_JABATAN " +
                       "  WHERE TKH_HAPUS IS NULL " +
                       "  ORDER BY KEY";
            }
        }

        internal static string GetSmuParameterEnglishByKumpulanFk()
        {
            return @" SELECT PARAM_PK as Key, NAMA_PARAMETER_EN as ViewField 
                        FROM SMU_PARAMETER WHERE KUMPULAN_FK = :KUMPULAN_FK AND AKTIF = 'Y' 
                        ORDER BY NAMA_PARAMETER_EN ";
        }

        internal static string GetSmuParameterEnglishByKumpulanFkWithCode()
        {
            return @" SELECT PARAM_PK as Key, NAMA_PARAMETER_EN as ViewField 
                        FROM SMU_PARAMETER WHERE KUMPULAN_FK = :KUMPULAN_FK AND KOD = :KOD AND AKTIF = 'Y' 
                        ORDER BY NAMA_PARAMETER_EN ";
        }

        internal static string ListSmuParameterKeyKodByKumpulan()
        {
            return @" SELECT KOD as Key, NAMA_PARAMETER_EN as ViewField 
                        FROM SMU_PARAMETER WHERE KUMPULAN_FK = :KUMPULAN_FK AND AKTIF = 'Y' 
                        ORDER BY NAMA_PARAMETER_EN ";
        }

        public static string SqlTahunList()
        {
            return @"SELECT TAHUN as Key, TAHUN as ViewField 
                       FROM HR_DCP_KUOTA 
                      WHERE TKH_HAPUS is null Order By ViewField desc ";
            //return @"SELECT DCP_KUOTA_PK AS Key, TAHUN AS ViewField 
            //           FROM HR_DCP_KUOTA  
            //          WHERE TKH_HAPUS IS NULL ORDER BY TAHUN";
        }

        internal static string SqlGetBasicHrStafMaklumat =
            @"SELECT A.STAF_PK, A.NO_PEKERJA, A.KOD_PTJ, A.KOD_JAWATAN, A.STATUS_AKTIF,
                            B.MAKLUMAT_PERIBADI_PK,  B.AGAMA, B.BANGSA_FK,  B.KOD_WARGANEGARA, B.JANTINA, 
                            B.NO_KP_LAMA, B.NO_KP_BARU, TRIM(B.NAMA) as NAMA, 
                            SUBSTR(A.KOD_PTJ,1,1) AS KAMPUS_KOD,
                            DECODE (SUBSTR(A.KOD_PTJ,1,1), 'P','PAGOH','K','KUALA LUMPUR','J','JOHOR BAHRU',SUBSTR(A.KOD_PTJ,1,1)) AS KAMPUS_DESC,
                            (SELECT (E.DESKRIPSI || '~' || D.AKADEMIK || '~' || D.KOD_GRED_JAWATAN)  FROM HR_KOD_JAWATAN D, HR_KOD_JENIS_JAWATAN E 
                               WHERE D.KOD_JAWATAN = A.KOD_JAWATAN 
                               AND (D.KOD_JENIS_JAWATAN = E.KOD_JENIS_JAWATAN(+) 
                               AND  D.KOD_KLASIFIKASI = E.KOD_KLASIFIKASI(+))) AS JAWATAN_DESC,
                            (SELECT F.DESKRIPSI  FROM HR_FAKULTI F 
                              WHERE  F.KOD_FAKULTI = SUBSTR(A.KOD_PTJ,0,3)) AS FAKULTI_DESC,
                            (SELECT G.GAMBAR FROM HR_GAMBAR G WHERE G.MAKLUMAT_PERIBADI_FK = A.MAKLUMAT_PERIBADI_FK AND ROWNUM = 1) AS PHOTOSTAF,
                            (SELECT EMAIL_RASMI FROM HR_ALAMAT WHERE ALAMAT_PK = B.ALAMAT_PEJABAT_FK) as EMAIL_RASMI,
                            (SELECT NO_TEL_BIMBIT FROM HR_ALAMAT WHERE ALAMAT_PK = B.ALAMAT_MENYURAT_FK) as NO_HP, 
                            '2' AS RESULTSET
                       FROM HR_STAF A, HR_MAKLUMAT_PERIBADI B ";
        internal static string MtdGetBasicHrStafMaklumatByStafFk()
        {
            return SqlGetBasicHrStafMaklumat + @"
                      WHERE A.STAF_PK = :STAF_PK 
                        AND A.MAKLUMAT_PERIBADI_FK = B.MAKLUMAT_PERIBADI_PK ";
        }

        internal static string MtdGetBasicHrStafMaklumatByNoKP()
        {
            return SqlGetBasicHrStafMaklumat + @"
                      WHERE A.MAKLUMAT_PERIBADI_FK = B.MAKLUMAT_PERIBADI_PK 
                        AND B.NO_KP_BARU = :NO_KP_BARU ";
        }

        internal static string MtdGetBasicHrStafMaklumatByNoPekerja()
        {
            return SqlGetBasicHrStafMaklumat + @"
                      WHERE A.NO_PEKERJA = :NO_PEKERJA 
                        AND A.MAKLUMAT_PERIBADI_FK = B.MAKLUMAT_PERIBADI_PK ";
        }

        internal static string SqlGetMaklumatPeribadiByNokp()
        {
            return @"SELECT MAKLUMAT_PERIBADI_PK, AGAMA, BANGSA_FK, KEWARGANEGARAAN, KOD_NEGERI_LAHIR, STATUS_KAHWIN, KOD_WARGANEGARA, 
                     TKH_LAHIR,JANTINA, NO_KP_LAMA, NO_KP_BARU, NO_PASPORT, NO_TENTERA, NO_POLIS,NAMA, WARNA_KP, PEMASTAUTIN
                 FROM HR_MAKLUMAT_PERIBADI WHERE NO_KP_BARU = :NO_KP_BARU ";
        }

        internal static string SQL_GetNoKerjaCutiSokongLulus()
        {
            return @"SELECT SPWK.KAD_ASAS.KAD_NOKERJA, SPWK.KAD_ASAS.KAD_PEGSOKONG, SPWK.KAD_ASAS.KAD_PEGLULUS, 
                            '1' AS RESULTSET
                       FROM SPWK.KAD_ASAS 
			          WHERE SPWK.KAD_ASAS.KAD_NOKERJA = :KAD_NOKERJA ";
        }

        internal static string SQL_GetBilStafAktifFakulti(string _kodFakulti)
        {
            string _sQl = @" SELECT count(*) AS BIL
                               FROM HRFIN.HR_STAF A, HRFIN.HR_MAKLUMAT_PERIBADI B
                              WHERE A.TKH_HAPUS IS NULL
                                AND A.STATUS_AKTIF = 'Y'
                                AND A.STATUS_ASSTATK < '45'
                                AND A.STATUS_ASSTATK NOT IN ('9X', ' ', '09', '32', '34')
                                AND A.MAKLUMAT_PERIBADI_FK = B.MAKLUMAT_PERIBADI_PK ";
            if (_kodFakulti != null && _kodFakulti.Length > 2)
            {
                _sQl += " AND SUBSTR(A.KOD_PTJ,1,3) = '" + _kodFakulti + "'  ";
            }
            return _sQl;
        }

        internal static string SQL_GetBilStafAkademikPPP(string _kod)
        {
            string _sQl = @" SELECT COUNT(*) AS BIL
                                FROM HR_STAF B, HR_MAKLUMAT_PERIBADI C, HR_KOD_JAWATAN D
                                    WHERE B.TKH_HAPUS IS NULL
                                      AND B.STATUS_AKTIF = 'Y'
                                      AND B.STATUS_ASSTATK < '45'
                                      AND B.STATUS_ASSTATK NOT IN ('9X', ' ', '09', '32', '34')
                                      AND B.MAKLUMAT_PERIBADI_FK = C.MAKLUMAT_PERIBADI_PK
                                      AND B.KOD_JAWATAN = D.KOD_JAWATAN ";
            if (_kod != null && _kod != "")
            {
                _sQl += "  AND D.AKADEMIK = '" + _kod + "'  ";
            }
            return _sQl;
        }

        internal static string Sql_GetStaffBreakdownStatistik(string _kod)
        {
            string _sQl = @"   SELECT KOD_GRED_JAWATAN as KOD_PTJ, COUNT(*) AS BIL01
                                 FROM HRFIN.HR_STAF B, HRFIN.HR_MAKLUMAT_PERIBADI C, HR_KOD_JAWATAN D
                                WHERE B.TKH_HAPUS IS NULL
                                  AND B.STATUS_AKTIF = 'Y'
                                  AND B.STATUS_ASSTATK < '45'
                                  AND B.STATUS_ASSTATK NOT IN ('9X', ' ', '09', '32', '34')
                                  AND B.MAKLUMAT_PERIBADI_FK = C.MAKLUMAT_PERIBADI_PK
                                  AND B.KOD_JAWATAN = D.KOD_JAWATAN ";
            if (_kod != null && _kod != "")
            {
                _sQl += "  AND D.AKADEMIK = '" + _kod + "'  ";
            }
            _sQl += @"   GROUP BY KOD_GRED_JAWATAN
                         ORDER BY KOD_GRED_JAWATAN DESC  ";
            return _sQl;
        }

        internal static string ListHrmsKodCuti()
        {
            return @"  SELECT 'C' || KOD_KODCUTI as Key, KOD_DESCCUTI  as ViewField 
                         FROM HRMS.KOD_CUTI ";
        }

        internal static string MtdGetListStaffJabatan(string _userPTJ, string _noPekerja, string _nama, string _fakultiKod, string _bahagianKod)
        {
            string _SQL = SqlGetBasicHrStafMaklumat +
                @" WHERE A.TKH_HAPUS IS NULL 
                     AND A.STATUS_AKTIF = 'Y'
                     AND A.STATUS_ASSTATK < '45'
                     AND A.STATUS_ASSTATK NOT IN ('9X', ' ', '09', '32', '34')  ";
            bool _ok = true;
            if (_userPTJ != null && _userPTJ == "ALL")
            {
                _ok = false;
            }
            else if (_userPTJ != null && _userPTJ.Length == 3)
            {
                _SQL += " AND SUBSTR(A.KOD_PTJ,0,3) = '" + _userPTJ + "' ";
            }
            else if (_userPTJ != null && _userPTJ.Length == 5)
            {
                _SQL += " AND SUBSTR(A.KOD_PTJ,0,5) = '" + _userPTJ + "' ";
            }
            else
            {
                _SQL += " AND A.KOD_PTJ = '" + _userPTJ + "' ";
            }
            if (_ok)
            {
                if (_fakultiKod != null && _fakultiKod.Length == 3)
                {
                    _SQL += " AND SUBSTR(A.KOD_PTJ,0,3) = '" + _fakultiKod + "' ";
                }
                else if (_fakultiKod != null && _fakultiKod.Length == 5)
                {
                    _SQL += " AND SUBSTR(A.KOD_PTJ,0,5) = '" + _fakultiKod + "' ";
                }
                else if (_userPTJ == null || _userPTJ == "" || _userPTJ.Length == 0)
                {
                    _SQL += " AND A.KOD_PTJ = '" + _fakultiKod + "' ";
                }
            }

            if (_bahagianKod != null && _bahagianKod.Length > 0)
            {
                _SQL += " AND SUBSTR(A.KOD_PTJ,0,5) = '" + _bahagianKod + "' ";
            }
            if (_noPekerja != null && _noPekerja.Length > 0)
            {
                _SQL += " AND A.NO_PEKERJA like '%" + _noPekerja + "%' ";
            }
            _SQL += " AND A.MAKLUMAT_PERIBADI_FK = B.MAKLUMAT_PERIBADI_PK  ";
            if (_nama != null && _nama.Length > 0)
            {
                _SQL += "  AND UPPER(B.NAMA) like '%" + _nama + "%'  ";
            }
            // _kodExtra >>> keperluan lain sekiranya perlu
            _SQL += " ORDER BY B.NAMA  ";
            //var log = NLog.LogManager.GetCurrentClassLogger();
            //log.Info("MtdGetListStaffJabatan  _SQL ~ " + _SQL);
            return _SQL;
        }

        internal static string MtdGetCarianStaffListSearch(string? _kampus, string? _fakultiKod, string? _bahagianKod, string _unit, string? _jawatan, string? _noPekerja, string? _nokp, string? _nama, string? _userPTJ)
        {
            string _SQL = SqlGetBasicHrStafMaklumat +
                @" WHERE A.TKH_HAPUS IS NULL 
                     AND A.STATUS_AKTIF = 'Y'
                     AND A.STATUS_ASSTATK < '45'
                     AND A.STATUS_ASSTATK NOT IN ('9X', ' ', '09', '32', '34')  ";
            if (_userPTJ != null && _userPTJ == "ALL")
            {
            }
            else if (_userPTJ != null && _userPTJ.Length == 3)
            {
                _SQL += " AND SUBSTR(A.KOD_PTJ,0,3) = '" + _userPTJ + "' ";
            }
            else if (_userPTJ != null && _userPTJ.Length == 5)
            {
                _SQL += " AND SUBSTR(A.KOD_PTJ,0,5) = '" + _userPTJ + "' ";
            }
            else
            {
                _SQL += " AND A.KOD_PTJ = '" + _userPTJ + "' ";
            }

            if (_kampus != null && _kampus.Length > 0)
            {
                _SQL += " AND SUBSTR(A.KOD_PTJ,0,1) = '" + _kampus + "' ";
            }
            if (_fakultiKod != null && _fakultiKod.Length > 0)
            {
                _SQL += " AND SUBSTR(A.KOD_PTJ,0,3) = '" + _fakultiKod + "' ";
            }
            if (_bahagianKod != null && _bahagianKod.Length > 0)
            {
                _SQL += " AND SUBSTR(A.KOD_PTJ,0,5) = '" + _bahagianKod + "' ";
            }
            if (_unit != null && _unit.Length > 0)
            {
                _SQL += " AND SUBSTR(A.KOD_PTJ,0,7) = '" + _unit + "' ";
            }

            if (_jawatan != null && _jawatan.Length > 0)
            {
                _SQL += " AND UPPER(A.KOD_JAWATAN) like '%" + _jawatan + "%'  ";
            }

            if (_noPekerja != null && _noPekerja.Length > 0)
            {
                _SQL += " AND A.NO_PEKERJA like '%" + _noPekerja + "%' ";
            }
            _SQL += " AND A.MAKLUMAT_PERIBADI_FK = B.MAKLUMAT_PERIBADI_PK  ";
            if (_nama != null && _nama.Length > 0)
            {
                _SQL += "  AND UPPER(B.NAMA) like '%" + _nama + "%'  ";
            }
            if (_nokp != null && _nokp.Length > 5)
            {
                _SQL += "  AND UPPER(B.NO_KP_BARU) like '%" + _nama + "%'  ";
            }
            _SQL += " ORDER BY B.NAMA  ";
            //var log = NLog.LogManager.GetCurrentClassLogger();
            //log.Info("MtdGetListStaffJabatan  _SQL ~ " + _SQL);
            return _SQL;
        }

        static string _spwkKadAsas =
            @" SELECT KAD_NOKERJA, KAD_BARCODE, KAD_STATUSHADIR, KAD_SHIFT, KAD_LEWAT, KAD_CATATAN, 
                            KAD_KKINI, KAD_TKHKKINI, KAD_STATUS, KAD_PEGSOKONG, KAD_PEGLULUS, KAD_PEGPEMANTAU,
                            '1' AS RESULTSET 
                    FROM SPWK.KAD_ASAS ";
        internal static string SQL_MtdGetStafYangDiselia(string NO_PEKERJA)
        {
            string _sQl = _spwkKadAsas +
                "  WHERE (KAD_PEGSOKONG = '" + NO_PEKERJA + @"' 
                      OR KAD_PEGLULUS = '" + NO_PEKERJA + @"' 
                      OR KAD_PEGPEMANTAU = '" + NO_PEKERJA + @"' )  ";

            return _sQl;
        }

    }
}
