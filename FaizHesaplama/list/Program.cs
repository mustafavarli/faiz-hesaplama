using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
class Program{
    static void Main(string[]args){
string dosyayolu = Path.Combine(Environment.CurrentDirectory,"faizhesaplari.txt");
Console.WriteLine("📁Çalışılan Klasör"+Environment.CurrentDirectory+"\n");
if(File.Exists(dosyayolu)){
    Console.WriteLine("Önceki Kayıtlar. \n");
    string []eskikayitlar = File.ReadAllLines(dosyayolu);
    foreach(string satir in eskikayitlar){
        Console.WriteLine(satir);

    }
    Console.WriteLine("\n=================\n");

} else {
    Console.WriteLine("Kayıtlı Veri Bulunamadı.");

}

            Console.WriteLine("Faiz Hesaplama Uygulamasına Hoşgeldiniz!!!");
            Console.Write("Ana Para Miktarını Giriniz: ");
            double anapara = Convert.ToDouble(Console.ReadLine());
            Console.Write("Faiz Miktarını Giriniz: ");
                        double faiz = Convert.ToDouble(Console.ReadLine())/100;
                        Console.Write("Kaç Yıl Olacak: ");
                                    double yil = Convert.ToDouble(Console.ReadLine());
           Console.WriteLine("Hangi Faiz Tipini Kullanacaksınız: ")       ;
           Console.Write("1-Basit Faiz , 2-Bileşik Faiz ") ;
       double toplamdeger = 0;
       string faiztipi = "";
           Console.Write("Seçiminizi Giriniz: ");
           int secim = Convert.ToInt32(Console.ReadLine());
           if(secim==1){
            Console.WriteLine("Faiz Tipiniz Basit Faiz Hesaplanıyor...");
            Console.WriteLine($"Sonucunuz: ");
            toplamdeger= anapara*(1+faiz*yil);
faiztipi="Basit Faiz";
           }else if (secim==2)  {
            Console.WriteLine("Yılda Kaç Kez Faiz Uygulanıyor: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Faiz Tipiniz Bileşik Faiz Hesaplanıyor...");
            Console.WriteLine($"Sonucunuz: ");
            toplamdeger=anapara*Math.Pow((1+faiz/n),n * yil );
            faiztipi ="Bileşik Faiz";

           }              else {
            Console.WriteLine("Hatalı Seçim");
return;
           }
           double kazanilanfaiz= toplamdeger - anapara;
           Console.WriteLine($"Toplam Para(Faiz Dahil): {toplamdeger:F2}");
           Console.WriteLine($"Kazanılan Faiz: {kazanilanfaiz:F2}");
           Console.WriteLine($"Faiz Tipi: {faiztipi}");
int kayitnumarasi = 1;
if(File.Exists(dosyayolu)){
    string[]satirlar = File.ReadAllLines(dosyayolu);
    kayitnumarasi= satirlar.Count(line => line.StartsWith("Kayıt #"))+1 ;
    

}
string kayit = $"\n>>> YENİ KAYIT <<<\n"+
               $"Kayıt Numarası: {kayitnumarasi}\n"+
               $"Tarih: {DateTime.Now}\n"+
               $"Ana Para: {anapara}\n"+
               $"Faiz Oranı: {faiz}\n"+
               $"Faiz Tipi: {faiztipi}"+
               $"Yıl: {yil}"+
               $"Toplam Kazanç: {toplamdeger}\n"+
               $"Kazanılan Faiz: {kazanilanfaiz}\n"+
               $"-------------------------";
File.AppendAllText(dosyayolu,kayit);
Console.WriteLine($"\n✅ Sonuçlar/{dosyayolu}/ dosyasına başarılı olarak kaydedildi.");






    }
}