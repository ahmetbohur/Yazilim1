using UnityEngine;
public class RotateToTargetAxis : MonoBehaviour
{
    // Hedef dönüş açısını belirlemek için bir Vector3 değişkeni.
    public Vector3 targetRotation; 
    
    // Dönme hızını ayarlamak için bir float değişkeni. Varsayılan değeri 1f olarak ayarlanmıştır.
    public float rotationSpeed = 1f; 

    // Update metodu, her frame'de bir kez çağrılır. Oyun döngüsü sırasında sürekli çalışır.
    void Update()
    {
        // Hedef dönüşü belirlemek için Quaternion.Euler kullanılarak, targetRotation vektörü quaternion formatına dönüştürülüyor.
        Quaternion target = Quaternion.Euler(targetRotation);
        
        // Mevcut dönüş (transform.rotation) ile hedef dönüş (target) arasında yumuşak bir geçiş sağlanıyor.
        // Quaternion.RotateTowards metodu, iki dönüş arasında belirli bir hızda geçiş yapar.
        // rotationSpeed değişkeni, ne kadar hızlı döneceğini belirler ve Time.deltaTime ile çarpılarak
        // frame bağımsız bir dönüş hızı sağlanır.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, rotationSpeed * Time.deltaTime);
    }
}