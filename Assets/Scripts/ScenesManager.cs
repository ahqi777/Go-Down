using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void Ranking()
    {
        SceneManager.LoadScene(4);
    }
    public void First()
    {
        SceneManager.LoadScene(0);
    }
    public void Rule()
    {
        SceneManager.LoadScene(1);
    }
    public void Choice()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;//如果遊戲暫停或者死亡，返回選角，timeScale要重置
    }
    public void Game()
    {
        SceneManager.LoadScene(3);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
