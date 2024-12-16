using UnityEngine;
using UnityEngine.Rendering;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D MyRigidbody;
    public float flapStrength;
    public float rotatespeed;
    public LogicScript logic;
    public bool birdIsAlive = true;

    private float topBound;
    private float bottomBound;
    private AudioSource birdAudio;
    public AudioClip flapSound;       // صوت القفز
    public AudioClip hitSound;        // صوت الارتطام
    public AudioClip gameOverSound;      // صوت الخسارة
    public AudioClip winSound;              // صوت الفوز
    public float hitVolume;       // مستوى صوت الارتطام
    public float gameOverVolume;  // مستوى صوت الخسارة
    public float winVolume;          // مستوى صوت الفوز



    private int pipesPassed = 0;            // عدد العوائق التي مر بها اللاعب
    public int pipesToWin = 20;             // الشرط المطلوب للفوز
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        topBound = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        bottomBound = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        birdAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            MyRigidbody.linearVelocity = Vector2.up * flapStrength;
            birdAudio.PlayOneShot(flapSound);
        }

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, MyRigidbody.linearVelocity.y * rotatespeed);

       
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, bottomBound, topBound), 
            transform.position.z
        );

        if (pipesPassed >= pipesToWin && birdIsAlive)
        {
            WinGame();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive)
        {
            birdAudio.PlayOneShot(hitSound, hitVolume); // تشغيل صوت الارتطام
            birdAudio.PlayOneShot(gameOverSound, gameOverVolume);   
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    // دالة يتم استدعاؤها عند المرور بعائق ناجح
    public void PassPipe()
    {
        if (birdIsAlive)
        {
            pipesPassed++; // زيادة العوائق التي مر بها اللاعب
        }
    }

    // دالة الفوز
    void WinGame()
    {
        birdIsAlive = false; // إيقاف حركة اللاعب
        birdAudio.PlayOneShot(winSound, winVolume); // تشغيل صوت الفوز
        Debug.Log("You Win!"); // التأكيد في Console
        logic.winGame();
    }
    

}
