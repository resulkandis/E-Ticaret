using E_Ticaret.BLL.DTO_s;
using E_Ticaret.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static E_Ticaret.REP.Repositories;

namespace E_Ticaret.BLL
{
    public class BussinessManager
    {
        public class KullaniciManager : KullaniciRepositories
        {
            public KullaniciDTO Denetle(string KullaniciAd, string Sifre)
            {
                Kullanicilar kullanicilar = null;
                kullanicilar = Bul(KullaniciAd);

                if (kullanicilar != null)
                {
                    if (kullanicilar.Sifre == Sifre)
                    {
                        KullaniciDTO kullaniciDto = new KullaniciDTO();
                        kullaniciDto.KullaniciAd = kullanicilar.KullaniciAd;
                        kullaniciDto.Yetki = kullanicilar.Yetki;
                        return kullaniciDto;
                    }
                    else return null;
                }
                else return null;
            }
            public List<KullaniciDTO> KullaniciListe()
            {
                return GenelListe().Select(x => new KullaniciDTO { KullaniciAd = x.KullaniciAd,Ad=x.Ad,Soyad=x.Soyad ,Yetki = x.Yetki,Telefon=x.Telefon,Email=x.Email,Adres=x.Adres,OlusturmaTarihi=(DateTime)x.OlusturmaTarihi }).ToList();
            }
        }
        public class KategoriManager : KategoriRepositories
        {
            public List<KategoriDTO> KategoriListe()
            {
                return GenelListe().Select(x => new KategoriDTO { KategoriID = x.KategoriID, KategoriAd = x.KategoriAd}).ToList();
            }
        }
        public class AltKategoriManager : AltKategoriRepositories
        {
            public List<AltKategoriDTO> AltKategoriListe()
            {
                return GenelListe().Select(x => new AltKategoriDTO { AltKategoriID = x.AltKategoriID, AltKategoriAd = x.AltKategoriAd,KategoriAd=x.Kategoriler.KategoriAd }).ToList();
            }
        }
        public class UrunManager : UrunRepositories
        {
            public List<UrunDTO> UrunListe()
            {
                return GenelListe().Select(x => new UrunDTO { UrunID = x.UrunID, UrunAd = x.UrunAd,AltKategoriAd=x.AltKategori.AltKategoriAd,Fiyat=(decimal)x.Fiyat,Aciklama=x.Aciklama,Resim=x.Resim,TanitimUrunu=(bool)x.TanitimUrunu,GununUrunu=(bool)x.GununUrunu }).ToList();
            }
        }
        public class SepetManager : SepetRepositories
        {
            public List<SepetDTO> SepetListe()
            {
                return GenelListe().Select(x => new SepetDTO {SepetID=x.SepetID,KullaniciAd=x.KullaniciAd,UrunAd=x.Urunler.UrunAd,Fiyat=(decimal)x.Urunler.Fiyat,Adet=(Int32)x.Adet,Tutar=(decimal)x.Tutar}).ToList();
            }
        }
    }
}
