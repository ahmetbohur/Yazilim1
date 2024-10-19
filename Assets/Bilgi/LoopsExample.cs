using System.Collections.Generic;
using UnityEngine;

public class LoopsExample : MonoBehaviour
{
    /*
       Döngüler (Loops)
       
       Döngüler Nedir?
       Döngüler, belirli bir koşul sağlandığı sürece belirli bir kod bloğunu tekrar tekrar çalıştırmak için kullanılır. 
       Programlama dillerinde yaygın olarak kullanılan döngü türleri arasında `for`, `foreach`, `while` ve `do-while` döngüleri bulunmaktadır.

       1. for Döngüsü:
       `for` döngüsü, belirli bir sayıda tekrarı ifade eder. Genellikle bir sayaç kullanarak belirli bir koşul sağlandığı sürece döngüyü çalıştırır.
       
       Yapısı:
       for (başlangıç_değeri; koşul; artış) {
           // Tekrar eden kod bloğu
       }

       Örnek:
       for (int i = 0; i < 5; i++) {
           Debug.Log("i: " + i);
       }

       2. foreach Döngüsü:
       `foreach` döngüsü, bir koleksiyonun (örneğin, dizi veya liste) her bir elemanı üzerinde döngü kurmak için kullanılır.
       
       Yapısı:
       foreach (veri_tipi eleman in koleksiyon) {
           // Tekrar eden kod bloğu
       }

       Örnek:
       List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
       foreach (string name in names) {
           Debug.Log("Name: " + name);
       }

       3. while Döngüsü:
       `while` döngüsü, belirli bir koşul doğru olduğu sürece döngüyü çalıştırır.
       
       Yapısı:
       while (koşul) {
           // Tekrar eden kod bloğu
       }

       Örnek:
       int count = 0;
       while (count < 5) {
           Debug.Log("Count: " + count);
           count++;
       }

       4. do-while Döngüsü:
       `do-while` döngüsü, kod bloğunu en az bir kez çalıştırır ve ardından koşulu kontrol eder.
       
       Yapısı:
       do {
           // Tekrar eden kod bloğu
       } while (koşul);

       Örnek:
       int number = 0;
       do {
           Debug.Log("Number: " + number);
           number++;
       } while (number < 5);
    */
    
    private void Start()
    {
        // for döngüsü örneği
        Debug.Log("For Döngüsü:");
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("i: " + i);
        }

        // foreach döngüsü örneği
        Debug.Log("\nForeach Döngüsü:");
        List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
        foreach (string name in names)
        {
            Debug.Log("Name: " + name);
        }

        // while döngüsü örneği
        Debug.Log("\nWhile Döngüsü:");
        int count = 0;
        while (count < 5)
        {
            Debug.Log("Count: " + count);
            count++;
        }

        // do-while döngüsü örneği
        Debug.Log("\nDo-While Döngüsü:");
        int number = 0;
        do
        {
            Debug.Log("Number: " + number);
            number++;
        } while (number < 5);
    }
}
