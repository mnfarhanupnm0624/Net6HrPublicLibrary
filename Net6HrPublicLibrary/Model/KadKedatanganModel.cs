using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6HrPublicLibrary.Model
{
    public class KadKedatanganModel
    {
        public string? RESULTSET { set; get; }
        public string? RESULTSET_TEXT { set; get; }
        public string? KAD_NOKERJA { set; get; }
        public string? KAD_NOKERJA_ENC { set; get; }
        public string? KAD_NOSIRI { set; get; }
        public DateTime KAD_TARIKHM { set; get; }
        public string? KAD_MASAM { set; get; }
        public DateTime KAD_TARIKHK { set; get; }
        public string? KAD_MASAK { set; get; }
        public string? KAD_INIT { set; get; }
        public string? KAD_ALASAN { set; get; }
        public string? KAD_COLORMASA { set; get; }
        public string? KAD_LOKASI { set; get; }
        public string? KAD_KKINI { set; get; }
        public string? KAD_PINDAH { set; get; }
        public DateTime KAD_TKHKKINI { set; get; }
        public string? PAPAR_TKHMULA { set; get; }
        public string? PAPAR_TKHMULA_OLD { set; get; }
        public string? PAPAR_TKHKELUAR { set; get; }
        public string? PAPAR_MASAMULA_OLD { set; get; }
        public string? PAPAR_MASAMULA { set; get; }
        public string? PAPAR_MASAKELUAR { set; get; }
        public string? PAPAR_HARI { set; get; }
        public string? PAPAR_4EDIT_TKHMULA { set; get; }
        public string? PAPAR_4EDIT_TKHKELUAR { set; get; }
        public string? PAPAR_4KEY_TKHMULA { set; get; }
        public string? KAD_KETERANGAN { set; get; }
        public string? KAD_KODCUTI { set; get; }
        public DateTime KAD_TARIKH { set; get; }
        public string? KAD_BARCODE { set; get; }
        public string? KAD_STATUSHADIR { set; get; }
        public string? KAD_SHIFT { set; get; }
        public string? KAD_LEWAT { set; get; }
        public string? KAD_CATATAN { set; get; }
        public string? KAD_LOKASI_KELUAR { set; get; }
        public string? KAD_KKINI_KELUAR { set; get; }
        public DateTime KAD_TKHKKINI_KELUAR { set; get; }
        public string? KAD_STATUS { set; get; }
        public string? KAD_PEGSOKONG { set; get; }
        public string? KAD_PEGLULUS { set; get; }
        public string? KAD_PEGPEMANTAU { set; get; }
        public string? KOD_KAMPUS { set; get; }
        public string? KOD_WEEKEND { set; get; }
        public string? KAD_KIRAOT { set; get; }
        public string? NO_PEKERJA { set; get; }
        public string? OPSYEN_STAF { set; get; }
        public DateTime TKH_MULAKUATKUASA { set; get; }
        public DateTime TKH_TAMATKUATKUASA { set; get; }
        public DateTime TKH_MULA { set; get; }
        public DateTime TKH_TAMAT { set; get; }
        public string? MASA_MULA_OLD { set; get; }
        public string? MASA_MULA { set; get; }
        public string? MASA_TAMAT { set; get; }

        //SPWK.JAD_JADUALSHIFT
        public string? JAD_NOKERJA { set; get; }
        public string? JAD_KAMPUS { set; get; }
        public string? JAD_FAKULTI { set; get; }
        public string? JAD_BAHAGIAN { set; get; }
        public string? JAD_KODSHIFT { set; get; }
        public DateTime JAD_TKHMULA { set; get; }
        public DateTime JAD_TKHAKHIR { set; get; }

        //SPWK.KOD_SHIFT
        public string? KOD_KODSHIFT { set; get; }
        public string? KOD_SHIFMULA { set; get; }
        public string? KOD_SHIFTAMAT { set; get; }
        public string? KOD_SHIFHARI { set; get; }
        public string? KOD_SABTU { set; get; }
        public string? KOD_SABTUTAMAT { set; get; }
        public string? KOD { set; get; }
        public string? CKOD { set; get; }
        public string? REMOTE_IPADD { set; get; }

        public bool CHECKBOX { get; set; }

        //SPWK.KAD_KEDATANGAN_SAHOT
        //public string? KAD_STATUS { set; get; }      //        VARCHAR2(1)    DEFAULT VALUE 'B'  REMARK B-BARU,L-LULUS,S-SEBAHAGIAN,P-PENUH
        public DateTime KAD_SHIF_DATEIN { set; get; }
        public string? KAD_SHIF_TIMEIN { set; get; }
        public DateTime KAD_SHIF_DATEOUT { set; get; }
        public string? KAD_SHIF_TIMEOUT { set; get; }
        public int KAD_MINITOT { set; get; }
        public int KAD_MINITOT_AMBIL { set; get; }
        public int KAD_MINITOT_GUNA { set; get; }
        public int KAD_LULUS_STAFFK { set; get; }
        public DateTime KAD_LULUS_TKH { set; get; }
        public int KAD_TELAH_GUNA { set; get; }
        public string? KAD_RUJUKAN_GUNA { set; get; }
        public string? NAMA { set; get; }
        public string? KOD_JAWATAN { set; get; }
        public string? KOD_JABATAN { set; get; }
        public string? KAD_STATUS_TEXT { set; get; }
    }
}
