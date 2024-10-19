using System.Collections.Generic;
using UnityEngine;

namespace GameNamespace // Oyun ile ilgili sınıfların bulunduğu ad alanı
{
    /*
       Namespace Tanımlama Kuralları

       [namespace Anahtar Kelimesi] [Namespace Adı]
       
       Namespace, programlama dillerinde sınıfları, arayüzleri, yapıları ve diğer veri türlerini gruplamak için kullanılan bir yapıdır.
       Namespace'ler, isim çakışmalarını önlemek ve kod organizasyonunu geliştirmek amacıyla kullanılır.

       Namespace Nasıl Tanımlanır?
       Aşağıdaki biçimde tanımlanır:

       namespace NamespaceAdı // Namespace Tanımı
       {
           // Sınıflar, arayüzler ve diğer veri türleri burada tanımlanır.
       }

       Kullanım Örneği:
       Farklı isim alanları içinde aynı isimde sınıflar tanımlanabilir ve böylece isim çakışmaları önlenir.
       
       Örnek:
       namespace GameNamespace // Bu, oyunun ana ad alanını tanımlar
       {
           public class Player // Player sınıfı
           {
               public string Name; // Oyuncu ismi
           }
       }

       namespace EnemyNamespace // Düşman ad alanı
       {
           public class Player // Bu, farklı bir ad alanındaki Player sınıfıdır
           {
               public string Name; // Düşman ismi
           }
       }
    */

    namespace PlayerNamespace // Oyuncu sınıflarının bulunduğu ad alanı
    {
        public class Player : MonoBehaviour
        {
            public string playerName = "Player1"; // Oyuncunun ismi
            public int playerScore = 0;            // Oyuncunun skoru

            private void Start()
            {
                Debug.Log("Player Name: " + playerName);
                Debug.Log("Player Score: " + playerScore);
            }
        }
    }

    namespace EnemyNamespace // Düşman sınıflarının bulunduğu ad alanı
    {
        public class Enemy : MonoBehaviour
        {
            public string enemyName = "Goblin"; // Düşmanın ismi
            public int enemyHealth = 100;        // Düşmanın sağlığı

            private void Start()
            {
                Debug.Log("Enemy Name: " + enemyName);
                Debug.Log("Enemy Health: " + enemyHealth);
            }
        }
    }

    namespace ItemNamespace // Eşya sınıflarının bulunduğu ad alanı
    {
        public class Item : MonoBehaviour
        {
            public string itemName = "Health Potion"; // Eşyanın ismi
            public int itemValue = 50;                // Eşyanın değeri

            private void Start()
            {
                Debug.Log("Item Name: " + itemName);
                Debug.Log("Item Value: " + itemValue);
            }
        }
    }

    namespace UtilityNamespace // Yardımcı sınıfların bulunduğu ad alanı
    {
        public static class GameHelper
        {
            public static void PrintWelcomeMessage()
            {
                Debug.Log("Welcome to the Game!");
            }

            public static int CalculateDamage(int baseDamage, int multiplier)
            {
                return baseDamage * multiplier; // Hasar hesaplama fonksiyonu
            }
        }
    }
}
