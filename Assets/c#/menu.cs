using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject resume1,playermove;

    private void Awake()
    {
        Time.timeScale = 1f;
    }
    private void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "choice" || sceneName == "choice1" || sceneName == "choice2" || sceneName == "choice3")
        {
            if (!GameObject.Find("Audio(Clone)"))
            {
                GameObject audio = (GameObject)Resources.Load("Audio");
                Instantiate(audio);
            }           
        }
        else
        {
            Destroy(GameObject.Find("Audio(Clone)"));
        }
    }
    public void multi()
    {
        SceneManager.LoadScene(11);
    }
    public void ranking()
    {
        SceneManager.LoadScene(10);
    }
    public void menu1()
    {
        SceneManager.LoadScene(0);
    }
    public void rule()
    {
        SceneManager.LoadScene(1);
    }
    public void choice()
    {
        SceneManager.LoadScene(2);
    }
    public void choice1()
    {
        SceneManager.LoadScene(3);
    }
    public void choice2()
    {
        SceneManager.LoadScene(4);
    }
    public void choice3()
    {
        SceneManager.LoadScene(5);
    }
    public void game()
    {
        SceneManager.LoadScene(6);
    }
    public void game1()
    {
        SceneManager.LoadScene(7);
    }
    public void game2()
    {
        SceneManager.LoadScene(8);
    }
    public void game3()
    {
        SceneManager.LoadScene(9);
    }
    public void pause()
    {
        Time.timeScale = 0f;
        FindObjectOfType<playermove>().audiostop();
        FindObjectOfType<skill>().allstop();
        resume1.SetActive(true);
        playermove.SetActive(false);
    }
    public void resume()
    {
        Time.timeScale = 1f;
        FindObjectOfType<playermove>().audiostart();
        FindObjectOfType<skill>().allstart();
        resume1.SetActive(false);
        playermove.SetActive(true);
    }
    public void quit()
    {
        Application.Quit();
    }
}
