using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab الخاص بالعملة
    public float spawnRate = 2f; // معدل ظهور العملات
    public float heightOffset = 2.5f; // مجال ارتفاع العملات

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnCoin();
            timer = 0f;
        }
    }

    void SpawnCoin()
    {
        // تحديد موضع عشوائي لظهور العملة
        float randomY = Random.Range(-heightOffset, heightOffset);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0f);

        // إنشاء العملة في الموضع العشوائي
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
