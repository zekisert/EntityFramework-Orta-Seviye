using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Kategori k = new Kategori();
            k.Id = 4;
            k.KategoriAdi = "telefon";

            

            UrunContext db = new UrunContext();

            db.Kategoriler.Add(k);
            db.SaveChanges();

            Console.WriteLine("veri kayıt edildi");
            Console.ReadLine();




            //Kategori k = new Kategori();
            //k.Id = 4;
            //k.KategoriAdi = "beyaz eşya";

            //List<Kategori> kategoriler = new List<Kategori>()
            //{
            //    new Kategori(){Id=1,KategoriAdi="telefon"},
            //    new Kategori(){Id=1,KategoriAdi="bilgisayar"},
            //    new Kategori(){Id=1,KategoriAdi="tablet"}
            //};

            //kategoriler.Add(k);


        }
    }
}
