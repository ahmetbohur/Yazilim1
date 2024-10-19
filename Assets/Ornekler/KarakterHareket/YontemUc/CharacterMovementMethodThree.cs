using UnityEngine;

public class CharacterMovementMethodThree : MonoBehaviour
{
    /*
        Karakter Hareketi (Position Tabanlı)
        
        Bu sınıf, bir karakterin Rigidbody kullanmadan, pozisyon tabanlı olarak hareket etme, zıplama ve dash (ani hareket) işlemlerini kontrol etmek için kullanılır.
        
        Kullanılan Değişkenler:
        
        - speed: Karakterin normal hareket hızını belirtir. (float)
        - dashSpeed: Karakterin dash (ani hareket) sırasında ulaştığı hız. (float)
        - jumpPower: Karakterin zıplama gücünü belirtir. (float)
        - isGrounded: Karakterin yerle temas edip etmediğini kontrol eder. (bool)
        - isDashing: Karakterin dash yapıp yapmadığını kontrol eder. (bool)
        - dashTime: Dash süresi. (float)
        - velocity: Karakterin mevcut hızını tutan vektör (Vector3)
        
        Metotlar:
        
        - Update(): Her frame'de çağrılan metot. Karakterin hareket, zıplama ve dash işlemlerini kontrol eder.
        - Move(): Karakterin yatay ve dikey eksenlerdeki hareketini yönetir.
        - Jump(): Karakterin zıplama işlemini gerçekleştirir.
        - StartDash(): Dash işlemini başlatır.
        - StopDash(): Dash işlemini durdurur.
        - OnCollisionEnter(Collision other): Karakterin yere temas ettiğinde çağrılan metot.
        - OnCollisionExit(Collision other): Karakterin yerden ayrıldığında çağrılan metot.
    */

    public float speed = 7; // Karakterin normal hareket hızı
    public float dashSpeed = 14; // Dash hızı
    public float jumpPower = 20; // Zıplama gücü
    public bool isGrounded = true; // Karakterin yere temas durumu
    public bool isDashing = false; // Dash durumu
    public float dashTime = 1f; // Dash süresi

    public Vector3 velocity; // Karakterin hızını tutan değişken

    private void Update()
    {
        Move(); // Karakterin hareket etme işlemini çağır
        Jump(); // Zıplama işlemini çağır
        StartDash(); // Dash işlemini başlat
    }

    private void Move()
    {
        // Yatay ve dikey eksenlerden girdi değerlerini al
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        // Eğer karakter dash yapıyorsa hareket etme
        if (isDashing) return;

        // Hareket yönünü ve hızını belirle
        velocity = new Vector3(horizontalAxis * speed, velocity.y, verticalAxis * speed);

        // Karakterin yeni pozisyonunu ayarla
        transform.position += velocity * Time.deltaTime;
    }

    private void Jump()
    {
        // Boşluk tuşuna basıldığında ve karakter yerle temas ediyorsa zıpla
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = jumpPower; // Zıplama gücünü ekle
        }
        
        // Karakterin yeni pozisyonunu güncelle
        transform.position += new Vector3(0, velocity.y, 0) * Time.deltaTime;
    }

    private void StartDash()
    {
        // LeftShift tuşuna basıldığında ve dashing yapılmadığında dash işlemini başlat
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            isDashing = true; // Dashing başladı
            Vector3 dashDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized; // Dash yönü
            velocity = dashDirection * dashSpeed; // Dash hızını ayarla

            // Dash işlemini sonlandırmak için belirli bir süre bekle
            Invoke(nameof(StopDash), dashTime);
        }
    }

    private void StopDash()
    {
        // Dash işlemi bittiğinde karakterin hızını normalleştir
        isDashing = false; // Dash sona erdi
    }

    private void OnCollisionEnter(Collision other)
    {
        // Karakter yere temas ettiğinde
        if (other.transform.CompareTag("Terrain"))
        {
            isGrounded = true; // Karakter yerle temas ediyor
            velocity.y = 0; // Zıplama sonrası yere indiğinde dikey hızı sıfırla
        }
    }

    private void OnCollisionExit(Collision other)
    {
        // Karakter yerden ayrıldığında
        if (other.transform.CompareTag("Terrain"))
        {
            isGrounded = false; // Karakter havada
        }
    }
}
