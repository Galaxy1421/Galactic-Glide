using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThemeManager : MonoBehaviour
{

    void Start()
    {
        gameObject.SetActive(false);
    }

    // وظيفة لتحميل الثيم بناءً على الاسم
    public void LoadTheme(string themeName)
    {
        SceneManager.LoadScene(themeName);
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
