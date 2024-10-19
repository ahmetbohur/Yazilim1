using UnityEngine;

public class Interfaces : MonoBehaviour
{
    /*
    Arayüzler (Interfaces)

    Arayüz Nedir?
    Arayüzler, nesne yönelimli programlamada belirli bir davranış setini tanımlayan yapılar olarak kullanılır. 
    Bir arayüz, yalnızca metod imzaları içerebilir ve bu metodlar, arayüzü uygulayan sınıflar tarafından gerçekleştirilmelidir.

    Arayüz Nasıl Tanımlanır - Arayüz Tanımlama Kuralları Nelerdir?

    [Erişim Belirleyici] interface [Arayüz Adı]
    
    Erişim Belirleyici: Arayüzün erişim düzeyini belirler.
    Örnekler:
        public: Her yerden erişilebilir.
        internal: Aynı derleme (assembly) içindeki diğer sınıflardan erişilebilir.

    Arayüz Adı: Arayüzün adıdır. Genellikle I ile başlar ve PascalCase formatında yazılır.
    Örneğin: IDamageable, IInteractable, IUpdatable.

    Metodlar: Arayüzde tanımlanan, ancak içi boş olan (implementasyon olmayan) metodlardır.
    Arayüzü uygulayan sınıflar, bu metodların içeriğini kendi ihtiyaçlarına göre tanımlamak zorundadır.

    Arayüzler, birden fazla sınıfın ortak bir davranış sergilemesine olanak tanır ve kodun yeniden kullanılabilirliğini artırır.
    */

    // Arayüz tanımları
    public interface IDamageable
    {
        void TakeDamage(int amount); // Hasar almayı temsil eden metod.
    }

    public interface IInteractable
    {
        void Interact(); // Etkileşimde bulunmayı temsil eden metod.
    }

    public interface IUpdatable
    {
        void UpdateStatus(); // Durum güncellemeyi temsil eden metod.
    }

    // Oyuncu sınıfı
    public class Player : MonoBehaviour, IDamageable, IInteractable
    {
        private int health = 100;

        // IDamageable arayüzündeki TakeDamage metodunu uyguluyoruz.
        public void TakeDamage(int amount)
        {
            health -= amount;
            Debug.Log($"Player took {amount} damage. Remaining health: {health}");
        }

        // IInteractable arayüzündeki Interact metodunu uyguluyoruz.
        public void Interact()
        {
            Debug.Log("Player interacted with an object.");
        }
    }

    // Düşman sınıfı
    public class Enemy : MonoBehaviour, IDamageable
    {
        private int health = 50;

        // IDamageable arayüzündeki TakeDamage metodunu uyguluyoruz.
        public void TakeDamage(int amount)
        {
            health -= amount;
            Debug.Log($"Enemy took {amount} damage. Remaining health: {health}");
        }
    }

    // Oyun yöneticisi sınıfı
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            // Oyuncu ve düşman nesnelerini oluşturma
            Player player = new Player();
            Enemy enemy = new Enemy();

            // Düşmana hasar verme
            enemy.TakeDamage(10);

            // Oyuncunun etkileşimde bulunması
            player.Interact();
        }
    }
}
