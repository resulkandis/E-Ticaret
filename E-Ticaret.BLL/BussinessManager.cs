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
                return GenelListe().Select(x => new KullaniciDTO { KullaniciAd = x.KullaniciAd, Yetki = x.Yetki,Email=x.Email,OlusturmaTarihi=(DateTime)x.OlusturmaTarihi }).ToList();
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
                return GenelListe().Select(x => new UrunDTO { UrunID = x.UrunID, UrunAd = x.UrunAd,AltKategoriAd=x.AltKategori.AltKategoriAd,Adet=(Int32)x.Adet,BirimFiyat=(decimal)x.BirimFiyat,Tutar=(decimal)x.Tutar,Resim=x.Resim }).ToList();
            }
        }
    }
}
