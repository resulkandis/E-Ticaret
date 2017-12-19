using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaret.BLL.DTO_s
{
    public class KullaniciDTO
    {
        public string KullaniciAd { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Yetki { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
    }
    public class KategoriDTO
    {
        public int KategoriID { get; set; }
        public string KategoriAd { get; set; }
    }
    public class AltKategoriDTO
    {
        public int AltKategoriID { get; set; }
        public string KategoriAd { get; set; }
        public string AltKategoriAd { get; set; }
    }
    public class UrunDTO
    {
        public int UrunID { get; set; }
        public string AltKategoriAd { get; set; }
        public string UrunAd { get; set; }
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
        public bool TanitimUrunu { get; set; }
        public bool GununUrunu { get; set; }

    }
    public class SepetDTO
    {
        public int SepetID { get; set; }
        public string KullaniciAd { get; set; }
        public string UrunAd { get; set; }
        public decimal Fiyat { get; set; }
        public int Adet { get; set; }
        public decimal Tutar { get; set; }

    }
}
