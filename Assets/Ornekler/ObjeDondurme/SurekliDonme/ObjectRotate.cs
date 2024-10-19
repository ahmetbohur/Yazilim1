using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    // Dönme eksenini belirlemek için bir Vector3 değişkeni. Varsayılan olarak sol ekseni kullanır.
    public Vector3 rotateAxis = Vector3.left; 
    
    // Dönme hızını ayarlamak için bir float değişkeni.
    public float rotateSpeed; 
    
    // Rotate isimli özel bir metot tanımlanıyor. Bu metot objeyi döndürmek için kullanılıyor.
    private void Rotate()
    {
        // Dönüş işlemi: objenin dönüş ekseni ve hızı kullanılarak döndürülüyor.
        // Time.deltaTime, frame süresine göre dönüş hızını ayarlamak için kullanılıyor,
        // böylece döndürme işlemi farklı cihazlarda tutarlılık sağlar.
        transform.Rotate(rotateAxis * rotateSpeed * Time.deltaTime);
    }

    // Update metodu, her frame'de bir kez çağrılır. Oyun döngüsü sırasında sürekli çalışır.
    private void Update()
    {
        // Rotate metodu çağrılarak objenin her frame'de döndürülmesi sağlanıyor.
        Rotate();
    }
}