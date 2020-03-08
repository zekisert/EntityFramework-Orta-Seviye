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

        }

        private static void Liste_Ekle_Kategori()
        {
            Kategori k = new Kategori();
            k.Id = 4;
            k.KategoriAdi = "telefon";

            UrunContext db = new UrunContext();

            db.Kategoriler.Add(k);
            db.SaveChanges();

            Console.WriteLine("veri kayıt edildi");
        }

        private static void Liste_Ekle_Urun()
        {
            Urun urun = new Urun();
            urun.UrunAdi = "Samsung S4";
            urun.Fiyat = 2000;
            urun.StokAdeti = 10;
            urun.Satistami = true;

            UrunContext context = new UrunContext();
            context.Urunler.Add(urun);

            urun = new Urun();
            urun.UrunAdi = "Samsung S6";
            urun.Fiyat = 3000;
            urun.StokAdeti = 200;
            urun.Satistami = false;

            context.Urunler.Add(urun);

            context.SaveChanges();
        }

        private static void Liste_Ekle_Urun_()
        {
            Urun urun = new Urun();
            urun = new Urun();
            urun.UrunAdi = "Samsung S6";
            urun.Fiyat = 3000;
            urun.StokAdeti = 200;
            urun.Satistami = false;
            UrunContext context = new UrunContext();
            context.Urunler.Add(urun);

            context.SaveChanges();
        }

        public static void Liste_Ekle_List_Urun()
        {
            UrunContext context = new UrunContext();
            List<Urun> urunler = new List<Urun>()
            {
                new Urun(){UrunAdi="Samsung S4",Fiyat=2000,StokAdeti=100,Satistami=true},
                new Urun(){UrunAdi="Samsung S5",Fiyat=3000,StokAdeti=100,Satistami=true},
                new Urun(){UrunAdi="Samsung S6",Fiyat=4000,StokAdeti=100,Satistami=true},
                new Urun(){UrunAdi="Samsung S7",Fiyat=5000,StokAdeti=100,Satistami=true},
                new Urun(){UrunAdi="Samsung S8",Fiyat=6000,StokAdeti=100,Satistami=true},

            };

            foreach (var urun in urunler)
            {
                context.Urunler.Add(urun);
            }
            context.SaveChanges();
            Console.WriteLine("kayıt edildi.");
        }

        public static void Liste_Ekle_List_Kategori()
        {
            UrunContext context = new UrunContext();

            List<Kategori> kategoriler = context.Kategoriler.ToList();
            //var kategoriler = context.Kategoriler.ToList();
            //var kategoriler = context.Kategoriler.FirstOrDefault();
            //Console.WriteLine("kategori id : {0} kategori adı : {1}", kategoriler.id, kategoriler.KategoriAdi);
            foreach (var kategori in kategoriler)
            {
                Console.WriteLine("kategori id : {0} kategori adı : {1}", kategori.Id, kategori.KategoriAdi);
            }
        }

        public static void Bul()
        {
            UrunContext context = new UrunContext();
            var urunler = context.Urunler.ToList();
            foreach (var urun in urunler)
            {
                Console.WriteLine("urun adı : {0} urun fiyatı: {1} urun stok adeti: {2}", urun.UrunAdi, urun.Fiyat, urun.StokAdeti);
            }

            //var urun = context.Urunler.Find(5);
            //Console.WriteLine("urun adı : {0} urun fiyatı: {1} urun stok adeti: {2}", urun.UrunAdi, urun.Fiyat, urun.StokAdeti);

            Console.ReadLine();

        }









        private static void Updating()
        {
            UrunContext context = new UrunContext();
            var urun = context.Urunler.Find(1);
            Console.WriteLine("urun id : {0} urun adı : {1} fiyat : {2}", urun.Id, urun.UrunAdi, urun.Fiyat);
            urun.Fiyat *= 0.5;
            urun.UrunAdi = "Samsung S6";
            urun.StokAdeti += 100;
            context.SaveChanges();
            urun = context.Urunler.Find(1);
            Console.WriteLine("urun id : {0} urun adı : {1} fiyat : {2}", urun.Id, urun.UrunAdi, urun.Fiyat);
            Console.ReadLine();
        }

        private static void Updating_Two()
        {
            UrunContext context = new UrunContext();
            var urunler = context.Urunler.ToList();
            foreach (var urun in urunler)
            {
                Console.WriteLine("fiyat : {0}", urun.Fiyat);
            }
            Console.WriteLine("-------------------------------");

            foreach (var urun in urunler)
            {
                urun.Fiyat *= 1.25;
            }
            context.SaveChanges();
            urunler = context.Urunler.ToList();
            foreach (var urun in urunler)
            {
                Console.WriteLine("fiyat : {0}", urun.Fiyat);
            }
            Console.ReadLine();
        }

        private static void Deleting()
        {
            UrunContext context = new UrunContext();
            var urun = context.Urunler.Find(1);
            if (urun != null)
            {
                context.Urunler.Remove(urun);
            }
            context.SaveChanges();
            //var urunler = context.Urunler.ToList();
            foreach (var item in context.Urunler)
            {
                Console.WriteLine("urun id : {0} urun adı : {1}", item.Id, item.UrunAdi);
            }
            Console.ReadLine();
        }

        private static void DeletingAllItem()
        {
            UrunContext context = new UrunContext();
            var urunler = context.Urunler.ToList();
            foreach (var urun in urunler)
            {
                context.Urunler.Remove(urun);
            }
            context.SaveChanges();

            if (context.Urunler.Count() == 0)
            {
                Console.WriteLine("veritabanında ürün bulunamadı");
            }
            else
            {
                foreach (var item in context.Urunler)
                {
                    Console.WriteLine("urun id : {0} urun adı : {1}", item.Id, item.UrunAdi);

                }
            }

            Console.ReadLine();
        }

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
