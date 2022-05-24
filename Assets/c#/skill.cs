using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skill : MonoBehaviour
{
    private Animator anim;
    public AudioSource pressmusic;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
   
    public void press()
    {
        pressmusic.Play();
        GetComponent<Button>().enabled = false;
        anim.SetBool("press",true);
    }
    public void pressdone()
    {
        GetComponent<Button>().enabled = true;
        anim.SetBool("press", false);
    }
    public void maskmanskillstart()//面具男技能開始
    {
        Time.timeScale = 0.5f;
    }
    public void maskmanskillover()//面具男技能結束
    {
        Time.timeScale = 1f;
    }
    public void guykillstart()//guy技能開始
    {
        FindObjectOfType<playermove>().guykillstart();
    }
    public void guykillov()//guy技能結束
    {
        FindObjectOfType<playermove>().guykillov();
    }
    public void allstop()//暫停
    {
        GetComponent<Button>().enabled = false;
    }
    public void allstart()//開始
    {
        GetComponent<Button>().enabled = true;
    }
}
