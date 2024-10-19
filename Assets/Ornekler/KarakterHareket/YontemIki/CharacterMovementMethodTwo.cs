using System;
using UnityEngine;

public class CharacterMovementMethodTwo : MonoBehaviour
{
    /*
        Bu sınıf, bir karakterin hareket, zıplama ve dash (ani hızlanma) işlemlerini kontrol eder.
        Karakter, sahnede yatay ve dikey eksenlerde hareket edebilir, zıplayabilir ve hızlıca ileri doğru atılabilir.
        
        Kullanılan Değişkenler:
        
        - speed: Karakterin normal hareket hızını belirtir. (float)
        - dashSpeed: Dash sırasında karakterin ulaştığı hız. (float)
        - jumpPower: Zıplama gücü, karakterin ne kadar yükseğe zıplayacağını belirler. (float)
        - isGrounded: Karakterin yere temas edip etmediğini kontrol eder. (bool)
        - isDashing: Karakterin şu anda dash yapıp yapmadığını belirtir. (bool)
        - dashTime: Dash işleminin ne kadar süreceğini belirler. (float)
        - gravity: Yerçekimi kuvveti, karakterin aşağı doğru çekilme hızını belirtir. (Vector3)
        - jumpTime: Zıplama süresi, karakterin zıplama işleminin ne kadar süreceğini kontrol eder. (float)
        - verticalVelocity: Karakterin dikey eksendeki hızı. (float)
        - dashDirection: Dash sırasında karakterin hangi yöne hareket ettiğini gösterir. (Vector3)
        - dashTimer: Dash işlemi sırasında zamanlayıcıdır. Dash süresi boyunca geri sayım yapar. (float)
        - isJumping: Karakterin zıplama yapıp yapmadığını belirler. (bool)
        - jumpTimer: Zıplama süresini geri sayar. (float)
    */

    public float speed = 7; // Karakterin normal hareket hızı (float)
    public float dashSpeed = 14; // Karakterin dash sırasında ulaştığı hız (float)
    public float jumpPower = 5; // Zıplama gücü (float)
    public bool isGrounded = true; // Karakterin yere temas durumu (bool)
    public bool isDashing = false; // Dash yapılıp yapılmadığını kontrol eden değişken (bool)
    public float dashTime = 1f; // Dash süresi (float)
    public Vector3 gravity = new Vector3(0, -9.81f, 0); // Yer çekimi kuvveti (Vector3)
    public float jumpTime = 0.5f; // Zıplama süresi (float)

    public float verticalVelocity; // Dikey hareket hızı (float)
    public Vector3 dashDirection; // Dash yönü (Vector3)
    public float dashTimer; // Dash süresi sayacı (float)
    public bool isJumping = false; // Zıplama yapılıp yapılmadığını kontrol eden değişken (bool)
    public float jumpTimer; // Zıplama süresi sayacı (float)

    private void Update()
    {
        // Eğer karakter zıplıyorsa zıplama fonksiyonunu çalıştır
        if (isJumping)
        {
            Jump(); 
        }
        // Eğer karakter dash yapıyorsa dash fonksiyonunu çalıştır
        else if (isDashing)
        {
            Dash(); 
        }
        // Eğer ne zıplıyor ne dash yapıyorsa normal hareket işlemlerini uygula
        else
        {
            Move(); // Hareket fonksiyonu
            StartDash(); // Dash başlatma işlemi
            if (!isJumping)
            {
                StartJump(); // Zıplama başlatma işlemi
            }
            ApplyGravity(); // Yer çekimi kuvvetini uygula
        }
    }

    private void LateUpdate()
    {
        CheckGrounded(); // Karakterin yere temas durumunu kontrol eder
    }

    private void Move()
    {
        // Yatay ve dikey eksenlerdeki girdi değerlerini al
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        // Karakterin yeni pozisyonunu belirle
        Vector3 movement = new Vector3(horizontalAxis * speed, verticalVelocity, verticalAxis * speed);
        transform.Translate(movement * Time.deltaTime, Space.World); // Hareketi zamanla çarpıp uygula
    }
    
    private void StartDash()
    {
        // Eğer LeftShift tuşuna basılırsa ve karakter şu an dash yapmıyorsa
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            isDashing = true; // Dash işlemi başlar
            dashDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized; // Dash yönünü al
            dashTimer = dashTime; // Dash süresi başlatılır
        }
    }

    private void Dash()
    {
        if(!isDashing) return; // Eğer dash yapılmıyorsa işlem yapma
        
        // Dash süresi bitene kadar dash işlemini devam ettir
        if (dashTimer > 0)
        {
            transform.Translate(dashDirection * dashSpeed * Time.deltaTime, Space.World); // Dash yönünde hareket et
            dashTimer -= Time.deltaTime; // Dash süresi geri sayar
        }
        else
        {
            StopDash(); // Dash süresi bitince durdur
        }
    }

    private void StopDash()
    {
        isDashing = false; // Dash işlemi sona erdi
    }

    private void StartJump()
    {
        // Eğer Space tuşuna basılırsa ve karakter yerle temas halindeyse
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true; // Zıplama başlar
            verticalVelocity = jumpPower; // Zıplama gücü uygulanır
            jumpTimer = jumpTime; // Zıplama süresi başlar
            isGrounded = false; // Karakter artık yere temas etmiyor
        }
    }

    private void Jump()
    {
        if(!isJumping) return; // Eğer zıplama yapılmıyorsa işlem yapma
        
        // Zıplama süresi bitene kadar zıplama işlemini devam ettir
        if (jumpTimer > 0)
        {
            transform.Translate(new Vector3(0, verticalVelocity, 0) * Time.deltaTime, Space.World); // Zıplama işlemini uygula
            jumpTimer -= Time.deltaTime; // Zıplama süresi geri sayar
        }
        else
        {
            StopJump(); // Zıplama süresi bitince zıplamayı durdur
        }
    }

    private void StopJump()
    {
        isJumping = false; // Zıplama işlemi sona erdi
    }

    private void ApplyGravity()
    {
        // Eğer karakter yere temas etmiyorsa yer çekimi kuvvetini uygula
        if (!isGrounded && !isJumping)
        {
            verticalVelocity += gravity.y * Time.deltaTime; // Yer çekimi uygulanır
        }

        // Zıplama ve yer çekimi etkilerini uygula
        transform.Translate(new Vector3(0, verticalVelocity, 0) * Time.deltaTime, Space.World); 
    }

    private void CheckGrounded()
    {
        // Karakterin yerle temas durumunu kontrol et
        if (transform.position.y <= 0.1f)
        {
            isGrounded = true; // Karakter yere temas etti
            if(!isJumping)
                verticalVelocity = 0; // Dikey hız sıfırlanır
            transform.position = new Vector3(transform.position.x, 0, transform.position.z); // Karakter yere temas eder
        }
        else
        {
            isGrounded = false; // Karakter havada
        }
    }
}
