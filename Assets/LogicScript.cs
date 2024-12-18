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
    [ContextMenu("Increase Score")]


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
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void winGame()
    {
        winScreen.SetActive(true); // تفعيل شاشة الفوز
        Time.timeScale = 0;        // إيقاف اللعبة
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1; // إعادة تشغيل الوقت إذا كان موقوفًا
        SceneManager.LoadScene("menu"); // استبدلي "menu" باسم مشهد القائمة الرئيسية لديكِ
    }
}
