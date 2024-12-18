using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float pipeMoveSpeed = 5f;  // سرعة حركة الأنبوب
    public float deadZone = -45f;    // منطقة الحذف خارج الشاشة
    public int coinValue = 1;        // قيمة العملة عند جمعها
    public int pipeScore;
    public float respawnRangeY = 5f; // النطاق العشوائي لإعادة ظهور العملة
    private bool pipeScored = false;      // لتجنب احتساب نقاط الأنبوب مرتين
    public LogicScript logic;

    void Start()
    {
        logic = FindObjectOfType<LogicScript>(); // إيجاد مرجع لسكربت إدارة النقاط
    }


    void Update()
    {
        // تحريك الأنبوب إلى اليسار
        transform.position += Vector3.left * pipeMoveSpeed * Time.deltaTime;

        // حذف الأنبوب عند خروجه من منطقة الرؤية
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe deleted");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // إضافة النقاط
        
            if (logic != null)
            {
                logic.addCoinScore(coinValue);
            }
           
            BirdScript bird = other.GetComponent<BirdScript>();
        
                bird.CoinCollected();
            

            // إعادة تعيين موضع العملة إلى مكان عشوائي جديد
            RespawnCoin();
        }
    }

    void RespawnCoin()
    {
        // تعيين موضع جديد للعملة
        float randomY = Random.Range(-respawnRangeY, respawnRangeY);
        float respawnX = transform.position.x + Random.Range(10f, 20f); // مكان جديد بعيد للأمام
        transform.position = new Vector3(respawnX, randomY, transform.position.z);

        Debug.Log("Coin respawned at: " + transform.position);
    }
}
