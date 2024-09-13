using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6HrPublicLibrary.Model
{
    public class HrStaffMaklumatPeribadiModel
    {

        public string? RESULTSET { set; get; }
        public int STAF_PK { set; get; }
        public string? STAF_PK_ENC { set; get; }
        public int UMUR_PILIHAN_PENCEN_FK { set; get; }
        public DateTime? TKH_PENCEN { set; get; }
        public DateTime? TKH_MULA_JPA { set; get; }
        public DateTime? TKH_MULA_UTM { set; get; }
        public DateTime? TKH_LANTIKAN_TERKINI { set; get; }
        public DateTime? TKH_MULA_KONTRAK { set; get; }
        public DateTime? TKH_SAH_JAWATAN { set; get; }
        public DateTime? TKH_TAMAT_KONTRAK { set; get; }
        public string? GELARAN_PROFESSIONAL { set; get; }
        public string? NO_PEKERJA { set; get; }
        public string? NO_PEKERJA_ENC { set; get; }
        public string? TKH_HENTI { set; get; }
        public string? KOD_FAKULTI { set; get; }
        public string? KOD_PTJ { set; get; }
        public string? KOD_JAWATAN { set; get; }
        public string? KOD_PTJ_ASAL { set; get; }
        public string? KOD_JAWATAN_GILIRAN { set; get; }
        public string? TKH_KURSUS_BTN { set; get; }
        public string? STATUS_ASSTATK { set; get; }
        public string? STATUS_AKTIF { set; get; }
        public string? ASTARAFK { set; get; }
        public string? STATUS_BTN { set; get; }
        public DateTime? TKH_LAPOR_DIRI { set; get; }
        public string? NO_FAIL { set; get; }
        public string? KOD_JAWATAN_HAKIKI { set; get; }
        public string? PUSAT_KOS { set; get; }
        public string? KOD_PTJ_PENEMPATAN { set; get; }
        public DateTime? TKH_LANTIK_TETAP { set; get; }
        public DateTime? TKH_LANTIKAN_AKADEMIK { set; get; }

        //RUJUK KEPADA HR_MAKLUMAT_PERIBADI
        public int? MAKLUMAT_PERIBADI_PK { set; get; }
        public int? ALAMAT_TETAP_FK { set; get; }
        public int? ALAMAT_MENYURAT_FK { set; get; }
        public int? ALAMAT_PEJABAT_FK { set; get; }
        public string? AGAMA { set; get; }
        public int? BANGSA_FK { set; get; }
        public int? TARAF_JAWATAN_SUB_FK { set; get; }
        public int? GELARAN_PERIBADI_FK { set; get; }
        public string? KEWARGANEGARAAN { set; get; }
        public string? KOD_NEGERI_LAHIR { set; get; }
        public string? STATUS_KAHWIN { set; get; }
        public string? KOD_WARGANEGARA { set; get; }
        public DateTime? TKH_LAHIR { set; get; }
        public string? JANTINA { set; get; }
        public string? NO_KP_LAMA { set; get; }
        public string? NO_KP_BARU { set; get; }
        public string? NO_KP_BARU_ENC { set; get; }
        public string? TEMPAT_LAHIR { set; get; }
        public string? NAMA { set; get; }
        public string? WARNA_KP { set; get; }
        public string? NO_OKU { set; get; }
        public string? UMUR { set; get; }
        public string? EMAIL_RASMI { set; get; }
        public string? NO_BARCODE { set; get; }
        public string? NO_HP { set; get; }

        public string? PAPAR_TKHPENCEN { set; get; }
        public string? PAPAR_TKHLAHIR { set; get; }
        public string? PAPAR_TKHLANTIKTETAP { set; get; }
        public string? PAPAR_TKHSAHJAWATAN { set; get; }
        public string? PAPAR_TKHLANTIKANAKADEMIK { set; get; }
        public string? JAWATAN_KOD { set; get; }
        public string? JAWATAN_GRED { set; get; }
        public string? JAWATAN_KATEGORI { set; get; }
        public string? JAWATAN_KUMPULAN { set; get; }
        public string? JAWATAN_DESC { set; get; }
        public string? JAWATAN_BIDANG { set; get; }
        public string? JAWATAN_KLASIFIKASI { set; get; }
        public string? JAWATAN_KEPAKARAN { set; get; }
        public string? JAWATAN_AKADEMIK { set; get; }
        public string? TAHUN_ENC { set; get; }

        public string? TREK_DESC { set; get; }

        public string? FAKULTI_KOD { set; get; }
        public string? FAKULTI_DESC { set; get; }
        public string? FAKULTI_SINGKATAN { set; get; }
        public string? FAKULTI_PTJ { set; get; }
        public string? FAKULTI_PTJ_ASAL { set; get; }
        public string? KAMPUS_KOD { set; get; }
        public string? KAMPUS_DESC { set; get; }
        public string? LPPT_DATA { set; get; }
        public string? LPPT_SKOP { set; get; }
        public string? LPPT_SKOP_TEXT { set; get; }
        public string? LPPT_KLASIFIKASI { set; get; }
        public string? JENIS_JAWATAN { set; get; }

        public byte[] PHOTOSTAF { set; get; }
        public byte[] WEBSITESTAFF { set; get; }
    }
}
