using E_Ticaret.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaret.REP
{
    static public class DBSingleTone
    {
        private static ETicaretEntities db;
        public static ETicaretEntities GetInstance()
        {
            if (db == null)
            {
                db = new ETicaretEntities();
            }
            return db;
        }
    }
}
