using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text score1;
    public int eat;
    public bool isdouble;
    void Update()
    {
        score1.text = eat.ToString();
        score2();
    }
    public void appleeat()
    {
        if (isdouble == true)
        {
            eat += 4;
        }
        else
        {
            eat += 2;
        }
    }
    public void bananaeat()
    {
        if (isdouble == true)
        {
            eat += 8;
        }
        else
        {
            eat += 4;
        }
    }
    public void cherryeat()
    {
        if (isdouble == true)
        {
            eat += 12;
        }
        else
        {
            eat += 6;
        }
    }
    public void orangeeat()
    {
        if (isdouble == true)
        {
            eat += 20;
        }
        else
        {
            eat += 10;
        }
    }
    public void meloneat()
    {
        if (isdouble == true)
        {
            eat += 60;
        }
        else
        {
            eat += 30;
        }
    }

    public void pinappleeat()
    {
        if (isdouble == true)
        {
            eat -= 20;
        }
        else 
        {
            eat -= 10;
        } 
    }
    public void strawberryeat()
    {
        isdouble = true;
        FindObjectOfType<AnimBG>().Doublestart();
        Invoke("doublepointover", 10f);
    }
    void doublepointover()
    {
        isdouble = false;
    }//雙倍分數結束
    
    void score2()//換背景
    {
        if (eat >= 100)
        {
            FindObjectOfType<AnimBG>().Score1();
        }
        if (eat >= 200)
        {
            FindObjectOfType<AnimBG>().Score2();
        }
        if (eat >= 300)
        {
            FindObjectOfType<AnimBG>().Score3();
        }
        if (eat >= 500)
        {
            FindObjectOfType<AnimBG>().Score5();
        }
        if (eat >= 1000)
        {
            FindObjectOfType<AnimBG>().Score10();
        }
    }
}
