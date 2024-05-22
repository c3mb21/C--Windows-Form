using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stok_Takip
{
    public class Ürünler
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Fiyat { get; set; }
        public string Ülke { get; set; }
        public DateTime İşlem_Tarihi { get; set; }
        public string Notlar { get; set; }
    }
}
