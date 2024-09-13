using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6HrPublicLibrary.Model
{
    public class TahapCapaianPage
    {
        public string? KOD_PERANAN { set; get; }
        public string? KOD_PERANAN_ENC { set; get; }
        public string? KOD_PTJ { set; get; }
        public string? PTJ_DESC { set; get; }
        public string? PERINGKAT_CAPAIAN { set; get; }
        public string? PERINGKAT_CAPAIAN_TXT { set; get; }
        public string? CAPAIAN_MULTI_PTJ { set; get; }

        //TAHAP_CAPAIAN    
        //KOD_PERANAN, KOD_FUNGSI, PERINGKAT_CAPAIAN, PENCIPTA_FK, TKH_CIPTA, KEMASKINI_FK, TKH_KEMASKINI, PENGHAPUS_FK, TKH_HAPUS, STATUS_AKTIF, TKH_MULA, TKH_TAMAT
        public string? KOD_FUNGSI { set; get; }
        public string? KOD_FUNGSI_ENC { set; get; }
        public string? STATUS_AKTIF { set; get; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TKH_MULA { set; get; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TKH_TAMAT { set; get; }

        //TAHAP_CAPAIAN_MULTIPTJ    TAHAPMULTIPTJ_PK, ID_PENGGUNA, KOD_PERANAN, MULTIPTJ, STATUS_AKTIF, TKH_MULA, TKH_TAMAT DATE
        public int TAHAPMULTIPTJ_PK { set; get; }
        public string? ID_PENGGUNA { set; get; }
        public string? MULTIPTJ { set; get; }
        public int KEMASKINI_FK { set; get; }
        public string? RESULTSET { set; get; }
    }
}
