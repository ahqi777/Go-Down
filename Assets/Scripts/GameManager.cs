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

    public float currTime;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
    private void Start()
    {
        instance.currTime = 0;
    }
    private void Update()
    {
        instance.currTime += Time.deltaTime;
    }
    /// <summary>
    /// 重新開始
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    /// <summary>
    /// 遊戲結束
    /// </summary>
    /// <param name="dead"></param>
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
    /// <summary>
    /// 遊戲暫停
    /// </summary>
    public void Pause()
    {
        Time.timeScale = 0f;
        AudioManager.instance.BGMPause();
        skillbtn.enabled = false;
        pause.SetActive(true);
        joystick.SetActive(false);
    }
    /// <summary>
    /// 繼續遊戲
    /// </summary>
    public void Resume()
    {
        Time.timeScale = 1f;
        AudioManager.instance.BGMPlay();
        skillbtn.enabled = true;
        pause.SetActive(false);
        joystick.SetActive(true);
    }
}
