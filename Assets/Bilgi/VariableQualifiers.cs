using UnityEngine;

public class VariableQualifiers : MonoBehaviour
{
    /*
        Değişken Nitelikleri (Variable Qualifiers)

        Değişken nitelikleri, bir değişkenin davranışını ve kapsamını tanımlamak için kullanılır. 
        Aşağıda yaygın olarak kullanılan bazı değişken nitelikleri ve açıklamaları bulunmaktadır:

        1. static: 
           - Değişkenin sınıf düzeyinde olduğunu belirtir. 
           - Bellekte yalnızca bir kopyası vardır ve tüm örnekler bu kopyayı paylaşır.

        2. const:
           - Değişkenin sabit olduğunu ve değeri bir kez atandıktan sonra değiştirilemeyeceğini belirtir.
           - Derleme zamanında belirlenir.

        3. readonly:
           - Değişkenin yalnızca tanımlandığı yapıcıda atanabileceğini belirtir.
           - Yapıcı dışında değeri değiştirilemez.

        4. volatile:
           - Değişkenin değerinin her zaman ana bellekten okunması gerektiğini belirtir.
           - Genellikle çoklu iş parçacığı uygulamalarında kullanılır.

        5. unsafe:
           - Güvenli olmayan kod bloklarını tanımlar.
           - İşaretçi (pointer) ile bellek yönetimi yapılmasına izin verir.

        6. dynamic:
           - Dinamik olarak tür atamasını sağlar. 
           - Compile zamanında değil, runtime'da türü belirlenir.
    */

    // Değişken Tanımları
    public static int staticVariable = 10;                // Statik değişken
    public const float constantValue = 3.14f;              // Sabit değişken
    public readonly int readOnlyVariable;                  // Sadece bir kez atanabilir
    public volatile int volatileVariable;                   // Her an değişebilir
    private dynamic dynamicVariable = "Initial Value";     // Dinamik türde değişken

    // Yapıcı
    public VariableQualifiers()
    {
        readOnlyVariable = 100;  // Yapıcıda atanabilir
    }

    private void Start()
    {
        // Değişkenleri kullanma örnekleri
        Debug.Log("Static Variable: " + staticVariable);          // Statik değişkenin kullanımı
        Debug.Log("Constant Value: " + constantValue);            // Sabit değişkenin kullanımı
        Debug.Log("Read Only Variable: " + readOnlyVariable);    // ReadOnly değişkenin kullanımı
        Debug.Log("Volatile Variable: " + volatileVariable);      // Volatile değişkenin kullanımı
        // Debug.Log("Dynamic Variable: " + dynamicVariable);        // Dinamik değişkenin kullanımı

        // Dinamik değişkenin değerini değiştirme
        // dynamicVariable = 42;  // Şimdi bir tam sayı olabilir
        // Debug.Log("Dynamic Variable (after change): " + dynamicVariable);
    }
}
