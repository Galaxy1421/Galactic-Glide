using UnityEngine;
using UnityEngine.SceneManagement;
public class buttonmanger : MonoBehaviour
{
    public AudioSource begin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void level1()
    {
        begin.Play();
        SceneManager.LoadScene("level1");
    }

    public void level2()
    {
        begin.Play();
        SceneManager.LoadScene("level2");
    }

    public void Quit()
    {
        Application.Quit();
    
    }


}
