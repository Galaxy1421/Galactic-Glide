using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public Transform spawnPoint; // موقع البداية

    void Start()
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter", "Cosmo Kitty"); // الشخصية الافتراضية
        Debug.Log("Selected Character: " + selectedCharacter);

        // تحميل الـ Prefab من Resources
        GameObject characterPrefab = Resources.Load<GameObject>("Characters/" + selectedCharacter);

        if (characterPrefab != null)
        {
            GameObject characterInstance = Instantiate(characterPrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log("Character Spawned at: " + spawnPoint.position);

            // التحقق من المكونات
            if (characterInstance.GetComponent<Rigidbody2D>() == null)
            {
                characterInstance.AddComponent<Rigidbody2D>(); // إضافة Rigidbody إذا كان مفقودًا
                Debug.LogWarning("Rigidbody2D was missing and has been added to " + selectedCharacter);
            }

            if (characterInstance.GetComponent<BirdScript>() == null)
            {
                characterInstance.AddComponent<BirdScript>(); // إضافة سكربت BirdScript إذا كان مفقودًا
                Debug.LogWarning("BirdScript was missing and has been added to " + selectedCharacter);
            }

            // ضبط التهيئة
            Rigidbody2D rb = characterInstance.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1; // ضبط الجاذبية
            rb.constraints = RigidbodyConstraints2D.FreezeRotation; // تجميد الدوران إذا كان مطلوبًا

            characterInstance.SetActive(true);
        }
        else
        {
            Debug.LogError("Failed to load character: " + selectedCharacter);
        }
    }
}
