using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ThemeManager : MonoBehaviour
{
    public LogicScript logicScript; // مرجع إلى LogicScript للتحقق من العملات
    public GameObject lockedThemeMessage; // مرجع إلى رسالة UI
    public Text lockedThemeMessageText;  // النص داخل الرسالة


    private void Start()
    {
        // إيجاد LogicScript في المشهد
        logicScript = FindObjectOfType<LogicScript>();
        // gameObject.SetActive(false);
        if (lockedThemeMessage != null)
        {
            lockedThemeMessage.SetActive(false);
        }
        
    }





    

    // وظيفة لتحميل الثيم بناءً على الاسم

    public void LoadTheme(string themeName)
    {
        // تحقق إذا كان الثيم مفتوحًا
        if (logicScript.IsLevelUnlocked(themeName))
        {
            SceneManager.LoadScene(themeName); // تحميل الثيم
        }
        else
        {
            // حساب العملات المطلوبة بناءً على الثيم
            int requiredCoins = themeName == "PurpleTheme"
                ? logicScript.coinsRequiredToUnlockPurpleTheme
                : logicScript.coinsRequiredToUnlockNebulaTheme;

            Debug.Log("Theme is locked: " + themeName); // عرض رسالة في Console
                                                        // يمكنك هنا إضافة نافذة UI لعرض رسالة للمستخدم


            // تحديث النص داخل الرسالة
            if (lockedThemeMessageText != null)
            {
                lockedThemeMessageText.text = $"This theme is locked, collect {requiredCoins} coins to open.";
            }

            // إظهار الرسالة
            if (lockedThemeMessage != null)
            {
                lockedThemeMessage.SetActive(true);
                StartCoroutine(HideLockedThemeMessage());
            }
        }
}


    private IEnumerator HideLockedThemeMessage()
    {
        yield return new WaitForSeconds(3f); // مدة عرض الرسالة
        lockedThemeMessage.SetActive(false);
    }
    public void OpenThemes()
    {
        gameObject.SetActive(true);
    }

    public void CloseThemes()
    {
        gameObject.SetActive(false);
    }
}
