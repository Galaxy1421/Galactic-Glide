using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel; // لوحة الإيقاف المؤقت

    void Update()
    {
        // تحقق من ضغط مفتاح Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc pressed!"); // تحقق من استجابة المفتاح
            if (pausePanel.activeSelf)
            {
                ResumeGame(); // استئناف اللعبة إذا كانت متوقفة
            }
            else
            {
                PauseGame(); // إيقاف اللعبة
            }
        }
    }

    // وظيفة لإيقاف اللعبة
    public void PauseGame()
    {
        Debug.Log("Game Paused");
        pausePanel.SetActive(true); // عرض لوحة الإيقاف المؤقت
        Time.timeScale = 0; // إيقاف الوقت
    }

    // وظيفة لاستئناف اللعبة
    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        pausePanel.SetActive(false); // إخفاء لوحة الإيقاف المؤقت
        Time.timeScale = 1; // استئناف الوقت
    }

    
    public void LoadMainMenu()
    {
        Time.timeScale = 1; // استئناف الوقت قبل العودة
        SceneManager.LoadScene("menu"); // تحميل مشهد القائمة الرئيسية
    }
}
