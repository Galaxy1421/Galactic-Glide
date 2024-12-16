using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogicScript : MonoBehaviour
{
    public int playScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject winScreen;
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playScore = playScore +scoreToAdd;
        scoreText.text = playScore.ToString();
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
