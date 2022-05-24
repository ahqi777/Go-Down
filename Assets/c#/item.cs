using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item : MonoBehaviour
{
    public Animator anim;
    public AudioSource itemmusic;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            itemmusic.Play();
            anim.SetBool("Eat", true);
            
        }
       
    }
    public void appledead()
    {
        FindObjectOfType<score>().appleeat();
        anim.SetBool("Eat", false);
        Destroy(gameObject);
    }

    public void bananadead()
    {
        FindObjectOfType<score>().bananaeat();
        anim.SetBool("Eat", false);
        Destroy(gameObject);
    }
    public void cherrydead()
    {
        FindObjectOfType<score>().cherryeat();
        anim.SetBool("Eat", false);
        Destroy(gameObject);
    }
    public void orangedead()
    {
        FindObjectOfType<score>().orangeeat();
        anim.SetBool("Eat", false);
        Destroy(gameObject);
    }
    public void melondead()
    {
        FindObjectOfType<score>().meloneat();
        anim.SetBool("Eat", false);
        Destroy(gameObject);
    }
    public void pinappledead()
    {
        FindObjectOfType<score>().pinappleeat();
        anim.SetBool("Eat", false);
        Destroy(gameObject);
    }
    
    void Update()
    {
    }
   
   
}
