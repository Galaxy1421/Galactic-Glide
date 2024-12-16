using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed; // سرعة الأنبوب تُضبط عند التوليد
    public float deadZone = -45; // منطقة الحذف خارج الشاشة
    private bool isPassed = false; // لتجنب احتساب الأنبوب أكثر من مرة
    public Transform bird; // موقع اللاعب

    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < bird.position.x && !isPassed)
        {
            isPassed = true; 
            FindObjectOfType<BirdScript>().PassPipe(); 
        }

   
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe deleted");
            Destroy(gameObject);
        }
    }
}
