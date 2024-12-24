using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogicScript : MonoBehaviour
{
    public int pipeScore = 0; // عدد الأنابيب التي مر بها
    public int coinScore = 0; // عدد العملات التي تم جمعها
    public Text pipeScoreText; // نص عرض عدد الأنابيب
    public Text coinScoreText; // نص عرض عدد العملات
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public Text finalScoreText;      // نص عرض النقاط النهائية عند انتهاء اللعبة
    public Text timerText;           // نص عرض الوقت المتبقي
  

    private float timer = 0f;        // المؤقت الزمني
    public float gameDuration = 60f; // مدة اللعبة (دقيقة واحدة)


    public int coinsRequiredToUnlockPurpleTheme;
    public int coinsRequiredToUnlockNebulaTheme;

    public GameObject lockedThemePurplePanel; // Panel لثيم Purple
    public GameObject lockedThemeNebulaPanel; // Panel لثيم Nebula
    private bool purpleThemeUnlocked = false; // حالة فتح الثيم البنفسجي
    private bool nebulaThemeUnlocked = false; // حالة فتح الثيم النيبولا





    [ContextMenu("Increase Score")]



    void Start()
    {
       
        UpdateScoreUI();
        // استرجاع حالة فتح الثيمات عند بدء اللعبة
        purpleThemeUnlocked = PlayerPrefs.GetInt("PurpleThemeUnlocked", 0) == 1;
        nebulaThemeUnlocked = PlayerPrefs.GetInt("NebulaThemeUnlocked", 0) == 1;
    }

    void Update()
    {
        // تحديث الوقت المتبقي
        timer += Time.deltaTime;
        if (timerText != null)
        {
            float timeLeft = Mathf.Ceil(gameDuration - timer); // الوقت المتبقي بالثواني
            timerText.text = "Time Left: " + timeLeft + "s";
        }

        // إنهاء اللعبة عند انقضاء الوقت
        if (timer >= gameDuration)
        {
            EndGame();
        }
    }
    public void addPipeScore(int numOfpipes)
    {
        pipeScore += numOfpipes; // أضف القيمة إلى المتغير العام
        UpdateScoreUI();
    }

    // زيادة نقاط العملات
    public void addCoinScore(int coinValue)
    {
        coinScore += coinValue;
        UpdateScoreUI();
        CheckForThemeUnlock(); // تأكد من استدعاء هذه الوظيفة

    }

    void CheckForThemeUnlock()
    {
        if (coinScore >= coinsRequiredToUnlockPurpleTheme && !purpleThemeUnlocked)
        {
            purpleThemeUnlocked = true; // حدد أن الثيم قد تم فتحه
            PlayerPrefs.SetInt("PurpleThemeUnlocked", 1); // حفظ حالة الفتح
            ShowThemeUnlockedPanel("PurpleTheme");
        }
        if (coinScore >= coinsRequiredToUnlockNebulaTheme && !nebulaThemeUnlocked)
        {
            nebulaThemeUnlocked = true; // حدد أن الثيم قد تم فتحه
            PlayerPrefs.SetInt("NebulaThemeUnlocked", 1); // حفظ حالة الفتح
            ShowThemeUnlockedPanel("NebulaTheme");
        }
    }

    void ShowThemeUnlockedPanel(string themeName)
    {
        if (themeName == "PurpleTheme" && lockedThemePurplePanel != null)
        {
            lockedThemePurplePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (themeName == "NebulaTheme" && lockedThemeNebulaPanel != null)
        {
            lockedThemeNebulaPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
  
    public void CloseThemePanel(string themeName)
    {
        if (themeName == "PurpleTheme" && lockedThemePurplePanel != null)
        {
            lockedThemePurplePanel.SetActive(false);
        }
        else if (themeName == "NebulaTheme" && lockedThemeNebulaPanel != null)
        {
            lockedThemeNebulaPanel.SetActive(false);
        }

        Time.timeScale = 1; // استئناف اللعبة
    }

    // تحديث النصوص في واجهة المستخدم
    void UpdateScoreUI()
    {
        if (pipeScoreText != null)
        {
            pipeScoreText.text = "Score: " + pipeScore;
        }
        if (coinScoreText != null)
        {
            coinScoreText.text = "Coins: " + coinScore;
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        winScreen.SetActive(true); 
        finalScoreText.text = "Pipes: " + pipeScore + "\n\n" +
                              "Coins: " + coinScore;
    }


    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene("menu"); 
    }


    public bool IsLevelUnlocked(string levelName)
    {
        if (levelName == "PurpleTheme")
            return PlayerPrefs.GetInt("PurpleThemeUnlocked", 0) == 1;

        if (levelName == "NebulaTheme")
            return PlayerPrefs.GetInt("NebulaThemeUnlocked", 0) == 1;

        return false;
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll(); // حذف جميع البيانات المحفوظة
        purpleThemeUnlocked = false;
        nebulaThemeUnlocked = false;
    }


}
