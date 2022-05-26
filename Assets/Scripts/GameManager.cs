using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
   
    public GameObject gameoverUI;
    public GameObject scoreInputUI;
    public GameObject pause;
    public GameObject joystick;
    public Button skillbtn;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void Gameover(bool dead)
    {
        if (dead)
        {
            if (ScoreManager.instance.CompareScore())
            {
                scoreInputUI.SetActive(true);
            }
            else
            {
                instance.gameoverUI.SetActive(true);
            }
            AudioManager.instance.BGMPause();
            Time.timeScale = 0f;
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        AudioManager.instance.BGMPause();
        skillbtn.enabled = false;
        pause.SetActive(true);
        joystick.SetActive(false);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        AudioManager.instance.BGMPlay();
        skillbtn.enabled = true;
        pause.SetActive(false);
        joystick.SetActive(true);
    }
}
