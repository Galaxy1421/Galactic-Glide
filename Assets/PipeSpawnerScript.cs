using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public GameObject coinPrefab;
    public float spawnRatePipes = 2f; // معدل ظهور الأنابيب
    public float spawnRateCoins = 3f; // معدل ظهور العملات
    public float heightOffsetPipes = 2f; // فرق الارتفاع للأنابيب
    public float heightOffsetCoins = 1.5f; // فرق الارتفاع للعملات

    private float pipeTimer = 0f;
    private float coinTimer = 0f;


    void Start()
    {
        SpawnPipe();
        SpawnCoin();
    }
    void Update()
    {
        // توليد الأنابيب
        pipeTimer += Time.deltaTime;
        if (pipeTimer >= spawnRatePipes)
        {
            SpawnPipe();
            pipeTimer = 0f;
        }

        // توليد العملات
        coinTimer += Time.deltaTime;
        if (coinTimer >= spawnRateCoins)
        {
            SpawnCoin();
            coinTimer = 0f;
        }
    }

    void SpawnPipe()
    {
        // تحديد نطاق ارتفاع الأنابيب بشكل عشوائي
        float lowestPoint = transform.position.y - heightOffsetPipes;
        float highestPoint = transform.position.y + heightOffsetPipes;

        // إنشاء الأنبوب
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0f), Quaternion.identity);
    }

    void SpawnCoin()
    {
        // تحديد موضع عشوائي للعملة
        float randomY = Random.Range(-heightOffsetCoins, heightOffsetCoins);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0f);

        // إنشاء العملة
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
