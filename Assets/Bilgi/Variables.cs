using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
   /*
      Variables (Değişkenler)
      
      Değişkenler Nedir?
      Değişkenler, programlama dillerinde veri saklamak için kullanılır. 
      Her değişkenin bir türü vardır ve bu tür, saklayabileceği verilerin tipini ve o verilerle yapılabilecek işlemleri belirler. 
      
      Değişken Nasıl Tanımlanır - Değişken Tanımlama Kuralları Nelerdir?
      
      [Erişim Belirleyici] [Veri Tipi] [Değişken Adı] = [Başlangıç Değeri];
      
      Erişim Belirleyici: Bir değişkenin erişim düzeyini belirler. 
      Örnekler:
         public: Her yerden erişilebilir.
         private: Sadece tanımlandığı sınıf içinde erişilebilir.
         protected: Sadece tanımlandığı sınıf ve alt sınıflar tarafından erişilebilir.
         internal: Aynı derleme (assembly) içindeki diğer sınıflardan erişilebilir.
         protected internal: Hem aynı derleme içindeki diğer sınıflardan, hem de alt sınıflardan erişilebilir.
         
      Veri Tipi: Değişkenin hangi türde veri saklayacağını belirtir. 
      Örnekler:
         int: Tam sayılar. (4 byte, -2,147,483,648 ile 2,147,483,647 arasında değer tutar)
         float: Ondalık sayılar. (4 byte, ±1.5 x 10^−45 ile ±3.4 x 10^38 arasında değer tutar)
         double: Daha yüksek hassasiyete sahip ondalık sayılar. (8 byte, ±5.0 x 10^−324 ile ±1.7 x 10^308 arasında değer tutar)
         decimal: Finansal ve yüksek hassasiyet gerektiren hesaplamalar için ondalık sayılar. (16 byte, ±1.0 x 10^−28 ile ±7.9 x 10^28 arasında değer tutar)
         string: Metin verileri. (her bir karakter için 2 byte; toplam karakter sayısı kadar byte tutar)
         bool: Doğru/yanlış değerleri. (1 byte, true veya false değerlerini tutar)
         char: Tek bir karakter. (2 byte, Unicode karakterlerini tutar)
         object: Herhangi bir veri tipini saklayabilen temel veri tipi. (4 byte veya 8 byte, nesne referansını tutar)
         List<T>: Belirli bir veri tipinden dinamik bir dizi. (referans tipi, içindeki öğelerin türüne bağlı olarak değişir)
         Array: Belirli bir veri tipinde sabit boyutlu dizi. (referans tipi, içindeki öğelerin türüne ve dizi boyutuna bağlı olarak değişir)
         enum: Belirli bir grup sabit değeri temsil eden bir veri tipi. (genellikle 4 byte, ancak temel türü değiştirilebilir; anlamlı isimler ile sabit değerler tanımlanabilir)
       
      Değişken Adı: Değişkenin tanımlandığı isimdir. 
      Genellikle, değişkenin neyi temsil ettiğini açıkça belirtmek için anlamlı bir isim seçilir. 
      Örneğin: age, totalPrice, isActive.
      
      Başlangıç Değeri: Değişkenin ilk değeri. Değişken tanımlandığında, bu değer ile başlatılır. 
      Örneğin: int age = 18; burada age değişkeninin başlangıç değeri 18'dir.
      
   */
   
   // Değişken Tanımları
   public int age = 18;                       // Tam sayı değişkeni
   private float height = 1.75f;              // Ondalık sayı değişkeni
   protected double balance = 1000.50;        // Daha yüksek hassasiyete sahip ondalık sayı değişkeni
   internal string playerName = "Player1";    // Metin verisi değişkeni
   public bool isActive = true;                // Doğru/yanlış değişkeni
   private char grade = 'A';                   // Tek bir karakter değişkeni
   public List<int> scores = new List<int>(); // Dinamik dizi değişkeni
   public decimal price = 19.99m;              // Finansal hesaplamalar için ondalık sayı
   private object data = "Sample Data";         // Herhangi bir veri tipini saklayabilen temel veri tipi
   private int[] fixedArray = new int[5];      // Sabit boyutlu dizi
   public string[] names = new string[] { "Alice", "Bob", "Charlie" }; // Sabit boyutlu dizi
   private float[] floatArray = new float[3];  // Ondalık sayı dizisi
   public enum GendersEnum
   {
      Male = 0,
      Female = 1,
   }

   private GendersEnum gender = GendersEnum.Male; // Enum değişkeni
   
   private void Start()
   {
      // Değişkenleri kullanma örnekleri
      scores.Add(85);                
      scores.Add(90);
      scores.Add(78);
        
      fixedArray[0] = 10;         
      fixedArray[1] = 20;
      
      Debug.Log("Player Name: " + playerName);
      Debug.Log("Player Age: " + age);
      Debug.Log("Player Height: " + height);
      Debug.Log("Player Balance: " + balance);
      Debug.Log("Is Player Active: " + isActive);
      Debug.Log("Player Grade: " + grade);
      Debug.Log("Player Scores: " + string.Join(", ", scores));
      Debug.Log("Price: " + price);
      Debug.Log("Data: " + data);
      Debug.Log("Name 0: " + names[0] + "Name 1:" + names[1] + "Name 2:" + names[2]);
   }
}
