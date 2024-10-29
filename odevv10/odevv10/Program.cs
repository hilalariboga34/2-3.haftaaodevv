using System;
using System.Collections.Generic;

class Program
{
    // Geçerli işlemi kontrol eden fonksiyon
    static bool IslemGecerli(double sonuc, char op, double num)
    {
        if (op == '+') return sonuc + num > 0;
        if (op == '-') return sonuc - num > 0;
        if (op == '*') return sonuc * num > 0;
        if (op == '/' && num != 0) return sonuc / num > 0;
        return false;
    }

    // Operasyonları gerçekleştirerek tapınağın kapısını açan kombinasyonu bulmaya çalışır
    static void KapıyıAcma(List<double> sayilar, List<char> islemler, int index, double sonuc)
    {
        if (index == sayilar.Count)
        {
            if (sonuc > 0) Console.WriteLine("Kombinasyon bulundu, sonuç: " + sonuc);
            return;
        }

        foreach (char op in islemler)
        {
            if (IslemGecerli(sonuc, op, sayilar[index]))
            {
                double yeniSonuc = 0;
                switch (op)
                {
                    case '+':
                        yeniSonuc = sonuc + sayilar[index];
                        break;
                    case '-':
                        yeniSonuc = sonuc - sayilar[index];
                        break;
                    case '*':
                        yeniSonuc = sonuc * sayilar[index];
                        break;
                    case '/':
                        if (sayilar[index] != 0)
                            yeniSonuc = sonuc / sayilar[index];
                        break;
                }

                KapıyıAcma(sayilar, islemler, index + 1, yeniSonuc);
            }
        }
    }

    static void Main()
    {
        // Örnek sayılar ve işlemler
        List<double> sayilar = new List<double> { 5, 3, 2 };
        List<char> islemler = new List<char> { '+', '-', '*', '/' };

        // İlk sayıyı başlangıç değeri olarak kullanıyoruz
        double baslangicSonuc = sayilar[0];

        Console.WriteLine("Geçerli kombinasyonlar:");
        KapıyıAcma(sayilar, islemler, 1, baslangicSonuc);
    }
}
