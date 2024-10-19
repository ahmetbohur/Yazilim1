using UnityEngine;

public class CharacterMovementMethodOne : MonoBehaviour
{
    /*
        Karakter Hareketi (Character Movement)
        
        Bu sınıf, bir karakterin hareket etme, zıplama ve dash (ani hareket) işlemlerini kontrol etmek için kullanılır. 
        Karakter, sahne üzerinde yatay ve dikey eksenlerde hareket edebilir, zıplayabilir ve hızlı bir şekilde ileri atılabilir.
        
        Kullanılan Değişkenler:
        
        - speed: Karakterin normal hareket hızını belirtir. (float)
        - dashSpeed: Karakterin dash (ani hareket) sırasında ulaştığı hız. (float)
        - jumpPower: Karakterin zıplama gücünü belirtir. (float)
        - isGrounded: Karakterin yerle temas edip etmediğini kontrol eder. (bool)
        - isDashing: Karakterin dash yapıp yapmadığını kontrol eder. (bool)
        - dashTime: Dash süresi. (float)
        - rigidBody: Karakterin fiziksel özelliklerini yöneten Rigidbody bileşenini tutar. (Rigidbody)
        
        Metotlar:
        
        - Update(): Her frame'de çağrılan metot. Karakterin hareket, zıplama ve dash işlemlerini kontrol eder.
        - Move(): Karakterin yatay ve dikey eksenlerdeki hareketini yönetir.
        - Jump(): Karakterin zıplama işlemini gerçekleştirir.
        - StartDash(): Dash işlemini başlatır.
        - StopDash(): Dash işlemini durdurur.
        - OnCollisionEnter(Collision other): Karakterin yere temas ettiğinde çağrılan metot. 
        - OnCollisionExit(Collision other): Karakterin yerden ayrıldığında çağrılan metot.
    */

    public float speed = 7; // Karakterin normal hareket hızı (float)
    public float dashSpeed = 14; // Karakterin dash sırasında ulaştığı hız (float)
    public float jumpPower = 20; // Zıplama gücü (float)
    public bool isGrounded = true; // Karakterin yere temas durumu (bool)
    public bool isDashing = false; // Dash yapılıp yapılmadığını kontrol eden değişken (bool)
    public float dashTime = 1f; // Dash süresi (float)
    
    public Rigidbody rigidBody; // Karakterin Rigidbody bileşeni (Rigidbody)
    
    private void Update()
    {
        Move(); // Karakterin hareket etme işlemini çağır
        Jump(); // Zıplama işlemini çağır
        StartDash(); // Dash işlemini başlat
    }

    private void Move()
    {
        // Yatay ve dikey eksenlerdeki girdi değerlerini al
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        // Karakterin mevcut hızını al
        Vector3 characterVelocity = rigidBody.velocity;
        
        // Eğer karakter dash yapıyorsa hareket etme
        if(isDashing) return;
        
        // Karakterin yeni hızını ayarla
        rigidBody.velocity = new Vector3(horizontalAxis * speed, characterVelocity.y, verticalAxis * speed); 
    }

    private void Jump()
    {
        // Boşluk tuşuna basıldığında ve karakter yerle temas ediyorsa zıpla
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Zıplama gücünü ekle
            rigidBody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse); 
            
            /*
                ForceMode.Impulse: Anlık bir kuvvet uygular; bu kuvvetin etkisi hemen görülür.
                Genellikle zıplama gibi ani hareketlerde kullanılır. 
                Karakterin zıplama gücünü anında uygular, bu yüzden zıplama için en uygun seçenektir.
            */
        }
    }

    private void StartDash()
    {
        // LeftShift tuşuna basıldığında ve dashing yapılmadığında dash işlemini başlat
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            isDashing = true; // Dashing başladı
            Vector3 dashDirection = rigidBody.velocity.normalized; // Mevcut hareket yönünü al
            rigidBody.AddForce(dashDirection * dashSpeed, ForceMode.Impulse); // Dash kuvveti ekle
            Invoke(nameof(StopDash), dashTime); // Belirtilen süre kadar bekle ve StopDash metodunu çağır
        }
    }

    private void StopDash()
    {
        // Dash işlemi bittiğinde karakterin hızını normalleştir
        Vector3 direction = rigidBody.velocity.normalized; // Mevcut hareket yönünü al
        rigidBody.velocity = direction * speed; // Karakterin hızını normal hareket hızına ayarla
        isDashing = false; // Dashing bitti
    }
    
    private void OnCollisionEnter(Collision other)
    {
        // Karakter yere temas ettiğinde
        if (other.transform.CompareTag("Terrain"))
        {
            isGrounded = true; // Karakterin yere temas ettiği bilgisi
        } 
    }

    private void OnCollisionExit(Collision other)
    {
        // Karakter yerden ayrıldığında
        if (other.transform.CompareTag("Terrain"))
        {
            isGrounded = false; // Karakterin yere temas etmediği bilgisi
        }
    }
}
