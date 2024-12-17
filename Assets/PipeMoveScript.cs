using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed;      // سرعة حركة الأنبوب
    public float deadZone = -45f;     // منطقة الحذف خارج الشاشة

    void Update()
    {
        // تحريك الأنبوب إلى اليسار
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // حذف الأنبوب عند خروجه من منطقة الرؤية
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe deleted");
            Destroy(gameObject);
        }
    }
}
