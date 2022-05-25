using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
   
    public GameObject gameoverUI;

    public GameObject pause;
    public GameObject joystick;

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
    public static void Gameover(bool dead)
    {
        if (dead)
        {
            instance.gameoverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        FindObjectOfType<PlayerCtrl>().Audiostop();
        FindObjectOfType<SkillManager>().allstop();
        pause.SetActive(true);
        joystick.SetActive(false);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        FindObjectOfType<PlayerCtrl>().Audiostart();
        FindObjectOfType<SkillManager>().allstart();
        pause.SetActive(false);
        joystick.SetActive(true);
    }
}
