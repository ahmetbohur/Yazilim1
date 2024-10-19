using System.Collections.Generic;
using UnityEngine;

public class Classes : MonoBehaviour
{
    /*
        Sınıflar (Classes)

        Sınıf Nedir?
        Sınıflar, nesne yönelimli programlamada veri ve davranışları bir araya getiren yapı taşlarıdır. 
        Bir sınıf, özellikler (değişkenler) ve metodlar (fonksiyonlar) içerebilir.

        Sınıf Nasıl Tanımlanır - Sınıf Tanımlama Kuralları Nelerdir?

        [Erişim Belirleyici] class [Sınıf Adı]
        
        Erişim Belirleyici: Sınıfın erişim düzeyini belirler.
        Örnekler:
            public: Her yerden erişilebilir.
            private: Sadece tanımlandığı sınıf içinde erişilebilir.
            protected: Sadece tanımlandığı sınıf ve alt sınıflar tarafından erişilebilir.
            internal: Aynı derleme (assembly) içindeki diğer sınıflardan erişilebilir.

        Sınıf Adı: Sınıfın adıdır. Genellikle PascalCase formatında yazılır.
        Örneğin: Player, Enemy, GameManager.

        Özellikler: Sınıfın verilerini tutan değişkenlerdir.
        Metodlar: Sınıfın işlevlerini tanımlayan fonksiyonlardır.

    */

    // Sınıf Tanımları
    public class Player
    {
        // Özellikler
        public string playerName;
        public int playerAge;
        private float playerHeight;

        // Constructor
        public Player(string name, int age, float height)
        {
            playerName = name;
            playerAge = age;
            playerHeight = height;
        }

        // Metod
        public void DisplayInfo()
        {
            Debug.Log($"Player Name: {playerName}, Age: {playerAge}, Height: {playerHeight}");
        }
    }

    public class Enemy
    {
        // Özellikler
        public string enemyType;
        public int health;

        // Constructor
        public Enemy(string type, int health)
        {
            enemyType = type;
            this.health = health;
        }

        // Metod
        public void TakeDamage(int damage)
        {
            health -= damage;
            Debug.Log($"{enemyType} took {damage} damage! Remaining health: {health}");
        }
    }

    // Başlangıç Metodu
    private void Start()
    {
        // Player Sınıfından bir nesne oluşturma
        Player player1 = new Player("Alice", 25, 1.70f);
        player1.DisplayInfo();

        // Enemy Sınıfından bir nesne oluşturma
        Enemy enemy1 = new Enemy("Goblin", 100);
        enemy1.TakeDamage(20);
    }
}
