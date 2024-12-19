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

    [ContextMenu("Increase Score")]



    void Start()
    {
        UpdateScoreUI();
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
        finalScoreText.text = "You passed " + pipeScore + " pipes\n" +
                              "and collected " + coinScore + " coins!";
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
}
