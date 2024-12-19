using UnityEngine;
using UnityEngine.Rendering;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D MyRigidbody;
    public float flapStrength;
    public float rotatespeed;
    public LogicScript logic;
    public bool birdIsAlive = true;

    private AudioSource birdAudio;    // مشغل الصوت

    [Header("Audio Clips")]
    public AudioClip flapSound;
    public AudioClip hitSound;
    public AudioClip coinSound;

    [Header("Audio Volumes")]
    public float hitVolume;

    private float topBound;
    private float bottomBound;

    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody2D>();
        birdAudio = GetComponent<AudioSource>();

        if (MyRigidbody == null)
            Debug.LogError("Rigidbody2D missing on " + gameObject.name);

        if (birdAudio == null)
            Debug.LogError("AudioSource missing on " + gameObject.name);

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        topBound = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        bottomBound = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            MyRigidbody.linearVelocity = Vector2.up * flapStrength;
            birdAudio.PlayOneShot(flapSound);
        }

        transform.rotation = Quaternion.Euler(0, 0, MyRigidbody.linearVelocity.y * rotatespeed);

        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, bottomBound, topBound),
            transform.position.z
        );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive)
        {
            birdAudio.PlayOneShot(hitSound, hitVolume);
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    public void CoinCollected()
    {
        birdAudio.PlayOneShot(coinSound, 0.5f);
    }
}
