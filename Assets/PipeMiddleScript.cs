using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic; 
    private bool hasScored = false; // منع تكرار تسجيل النقاط

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.CompareTag("Player") && !hasScored)
        {
            logic.addPipeScore(1); // إضافة نقطة للأنبوب
            hasScored = true;      // تحديد أن النقاط قد سُجلت
            gameObject.SetActive(false); // تعطيل الكائن لمنع المزيد من التصادمات
            Debug.Log("Pipe passed! Score updated.");
        }
    }
}
