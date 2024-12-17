using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float moveSpeed = 2f; // سرعة تحرك العملة
    public int coinValue = 1; // قيمة العملة عند جمعها

    // Update يتم استدعاؤه مرة واحدة كل إطار
    void Update()
    {
        // تحرك العملة نحو اليسار
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // حذف العملة إذا خرجت من الشاشة لتوفير الأداء
        if (transform.position.x < -10f) // قيمة مناسبة خارج حدود الشاشة
        {
            Destroy(gameObject);
        }
    }

    // استدعاء عند تصادم اللاعب مع العملة
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // إضافة النقاط (أو التفاعل مع النظام)
            FindObjectOfType<LogicScript>().addScore(1);

            // حذف العملة عند جمعها
            Destroy(gameObject);
        }
    }
}
