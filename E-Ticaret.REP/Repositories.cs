using E_Ticaret.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaret.REP
{
    public class Repositories
    {
        public class KullaniciRepositories : BaseRepository<Kullanicilar> { }
        public class KategoriRepositories : BaseRepository<Kategoriler> { }
        public class AltKategoriRepositories : BaseRepository<AltKategori> { }
        public class UrunRepositories : BaseRepository<Urunler> { }
    }
}
