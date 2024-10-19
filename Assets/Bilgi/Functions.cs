using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    /*
       Fonksiyonlar (Methodlar)

       Fonksiyonlar Nedir?
       Fonksiyonlar, belirli bir görevi yerine getirmek için bir araya getirilen kod bloklarıdır. 
       Fonksiyonlar, kodun tekrar kullanılabilirliğini artırır ve kodun daha düzenli olmasına yardımcı olur.

       Fonksiyon Nasıl Tanımlanır - Fonksiyon Tanımlama Kuralları Nelerdir?

       [Erişim Belirleyici] [Veri Tipi] [Fonksiyon Adı]([Parametreler])
       {
           // Fonksiyonun içeriği
       }

       Erişim Belirleyici: Fonksiyonun erişim düzeyini belirler.
       Örnekler:
          public: Her yerden erişilebilir.
          private: Sadece tanımlandığı sınıf içinde erişilebilir.
          protected: Sadece tanımlandığı sınıf ve alt sınıflar tarafından erişilebilir.

       Veri Tipi: Fonksiyonun geriye döndüreceği değerin türünü belirtir. 
       Örnekler:
          void: Hiçbir değer döndürmeyen fonksiyonlar için.
          int: Tam sayı döndüren fonksiyonlar için.
          float: Ondalık sayı döndüren fonksiyonlar için.

       Fonksiyon Adı: Fonksiyonun tanımlandığı isimdir. 
       Genellikle, fonksiyonun ne yaptığına dair anlamlı bir isim seçilir.
       Örneğin: CalculateArea, GetPlayerName.

       Parametreler: Fonksiyona dışarıdan veri geçmek için kullanılır. 
       Birden fazla parametre virgülle ayrılarak tanımlanabilir.
    */

    // Örnek Fonksiyonlar

    // Toplama işlemi yapan bir fonksiyon
    public int Add(int a, int b)
    {
        return a + b;
    }

    // İki sayının ortalamasını hesaplayan bir fonksiyon
    public float CalculateAverage(float[] numbers)
    {
        float sum = 0f;
        foreach (float number in numbers)
        {
            sum += number;
        }
        return sum / numbers.Length;
    }

    // Metinleri birleştiren bir fonksiyon
    public string ConcatenateStrings(string str1, string str2)
    {
        return str1 + " " + str2;
    }

    // Belirli bir sayının karekökünü hesaplayan bir fonksiyon
    public float CalculateSquareRoot(float number)
    {
        return Mathf.Sqrt(number);
    }

    private void Start()
    {
        // Fonksiyonları kullanma örnekleri
        int sum = Add(5, 10);
        Debug.Log("Sum: " + sum);

        float[] scores = { 85.5f, 90.0f, 78.0f };
        float average = CalculateAverage(scores);
        Debug.Log("Average Score: " + average);

        string fullName = ConcatenateStrings("John", "Doe");
        Debug.Log("Full Name: " + fullName);

        float squareRoot = CalculateSquareRoot(16.0f);
        Debug.Log("Square Root of 16: " + squareRoot);
    }
}
