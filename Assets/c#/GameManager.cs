using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
   
    public GameObject gameoverUI;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //score.text = Time.timeSinceLevelLoad.ToString("00");
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void quit()
    {
        Application.Quit();
    }
    public static void gameover(bool dead)
    {
        if (dead)
        {
            
            instance.gameoverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
