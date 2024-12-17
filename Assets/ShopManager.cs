using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    // أزرار اختيار الشخصيات
    public Button starcornButton, astroBuddyButton, lunaExplorerButton, spacePupButton, cosmoKittyButton, orbitBuddyButton;

    private void Start()
    {
        // ربط الأزرار بالدوال لاختيار الشخصيات (بدون Prefabs خاصة بالمتجر)
        starcornButton.onClick.AddListener(() => SelectCharacter("Starcorn"));
        astroBuddyButton.onClick.AddListener(() => SelectCharacter("Astro Buddy"));
        lunaExplorerButton.onClick.AddListener(() => SelectCharacter("Luna Explorer"));
        spacePupButton.onClick.AddListener(() => SelectCharacter("Space Pup"));
        cosmoKittyButton.onClick.AddListener(() => SelectCharacter("Cosmo Kitty"));
        orbitBuddyButton.onClick.AddListener(() => SelectCharacter("Orbit Buddy"));
    }

    void SelectCharacter(string characterName)
    {
        Debug.Log("Selected Character: " + characterName);
        PlayerPrefs.SetString("SelectedCharacter", characterName); // تخزين اسم الشخصية
        gameObject.SetActive(false); // إغلاق المتجر
    }

    public void OpenShop()
    {
        gameObject.SetActive(true);
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }
}

