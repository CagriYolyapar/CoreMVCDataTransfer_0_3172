using CoreMVCDataTransfer_0.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCDataTransfer_0.Controllers
{
    public class HomeController : Controller
    {
       
      

       //Bütün Data Transfer yapıları ilkel tipler ile calısmaya uygundur... Her ne kadar kompleks tiplere destek verseler de kompleks tipler ile kullanılmaları kesinlikle saglıklı degildir...

        //Eger siz MOdel gönderme yöntemiyle veri göndermiyorsanız o verinin karsılanmasına gerek yoktur...Zaten isteseniz de karsılayamazsınız...

        //ViewBag : Sadece Controller'iniz icerisindeki Action'dan View'iniza veri gönderme görevini uygular...

        //ViewData : Action'dan View'a veri gönderir lakin verileri object tipte tutar...

        //TempData : Diger Data Transfer yapılarına ek olarak  aynı zamanda ACtion'dan ACtion'a da veri gönderebilen bir Data Transfer yapınızdır...Lakin bu temporary bir data'dir(normal tek kullanımlıktır)... 

        public IActionResult Index()
        {

            //ViewBag ile veri gönderme...

            //ViewBag verilerinizi dinamik bir şekilde tutar...Yani her türlü veriyi tutabilir...

            ViewBag.SayiVerisi = 12;

            //Egitmen egt = new Egitmen()
            //{
            //    Isim = "Cagri",
            //    SoyIsim = "Yolyapar"
            //};

            //ViewBag.Egitmen = egt; // bu tarz yapıların kompleks tipleri ile kullanılmaması gerekmektedir...

            return View();
            
        }

        public IActionResult ViewDataUsage()
        {
            /*
             * Key Value(Dictionary)
              34 Istanbul
              6   Ankara



            Istanbul
            Ankara
             
             
             */

            //ViewData verileri object tipinde tutar...Bu yüzden her türlü veriyi tutabilir...

            ViewData["SayiVerisi"] = 12;


            ViewData["Egitmen"] = new Egitmen()
            {
                Isim = "Cagri",
                SoyIsim = "Yolyapar"
            };

            return View();
        }

        public IActionResult TempDataUsage()
        {
            //TempData verileri object tipinde tutar...

            //TempData olusturuldugu alanda istenildigi gibi kullanılabilir kullanım sınırı yoktur...
            TempData["sayi"] = 100;
            int sayi = Convert.ToInt32(TempData["sayi"]);   //Burada da kullanırsak yine kullandık sayılır
            int sayi2 = Convert.ToInt32(TempData["sayi"]);   //Burada da kullanırsak yine kullandık sayılır
            TempData.Keep("sayi"); //Bu sekilde ilgili TempData'nın ömrünü bir kullanımlık uzatmıs oluruz...
            return View();
        }

        public IActionResult DenemeAction()
        {
            //TempData Action'dan ACtion'a veri gönderebilir...Tabii ki onun tek kullanımlık oldugunu unutmamak lazım...
            int sayi = Convert.ToInt32(TempData["sayi"]);
            return View();
        }
    }
}
