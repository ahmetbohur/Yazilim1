using System.Collections.Generic;
using UnityEngine;

public class ConditionalStatements : MonoBehaviour
{
    /*
       Koşul İfadeleri (If-Else, Else If ve Switch-Case)

       If-Else: Belirli bir koşulun doğru veya yanlış olup olmadığını kontrol etmek için kullanılır.
       Genel yapı:
       if (koşul)
       {
           // Koşul doğruysa çalışacak kod
       }
       else if (koşul2)
       {
           // İkinci koşul doğruysa çalışacak kod
       }
       else
       {
           // Koşullar sağlanmazsa çalışacak kod
       }

       Switch-Case: Bir değişkenin değerine göre farklı durumlara göre farklı kod blokları çalıştırmak için kullanılır.
       Genel yapı:
       switch (değişken)
       {
           case değer1:
               // değer1 için çalışacak kod
               break;
           case değer2:
               // değer2 için çalışacak kod
               break;
           default:
               // Hiçbir koşul sağlanmazsa çalışacak kod
               break;
       }
    */

    // Değişken Tanımları
    public int playerScore = 85; // Oyuncunun puanı

    private void Start()
    {
        // If-Else ve Else If Örneği
        if (playerScore >= 90)
        {
            Debug.Log("Mükemmel! Puanınız 90 ve üzeri.");
        }
        else if (playerScore >= 75 && playerScore < 90) // 75 ile 89 arasında
        {
            Debug.Log("İyi iş! Puanınız 75 ile 89 arasında.");
        }
        else if (playerScore >= 50 && playerScore < 75) // 50 ile 74 arasında
        {
            Debug.Log("Geçtiniz. Puanınız 50 ile 74 arasında.");
        }
        else
        {
            Debug.Log("Üzgünüm, geçemediniz. Puanınız 49 ve altı.");
        }

        // Switch-Case Örneği
        string grade;

        switch (playerScore / 10)
        {
            case 10:
            case 9:
                grade = "A";
                break;
            case 8:
                grade = "B";
                break;
            case 7:
                grade = "C";
                break;
            case 6:
                grade = "D";
                break;
            default:
                grade = "F";
                break;
        }

        Debug.Log("Oyuncunun notu: " + grade);
    }
}
