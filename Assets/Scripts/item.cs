using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
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
    public void Appledead()
    {
        FindObjectOfType<ScoreManager>().appleeat();
        anim.SetBool("Eat", false);
        Destroy(gameObject);
    }

    public void Bananadead()
    {
        FindObjectOfType<ScoreManager>().bananaeat();
        anim.SetBool("Eat", false);
        Destroy(gameObject);
    }
    public void Cherrydead()
    {
        FindObjectOfType<ScoreManager>().cherryeat();
        anim.SetBool("Eat", false);
        Destroy(gameObject);
    }
    public void Orangedead()
    {
        FindObjectOfType<ScoreManager>().orangeeat();
        anim.SetBool("Eat", false);
        Destroy(gameObject);
    }
    public void Melondead()
    {
        FindObjectOfType<ScoreManager>().meloneat();
        anim.SetBool("Eat", false);
        Destroy(gameObject);
    }
    public void Pinappledead()
    {
        FindObjectOfType<ScoreManager>().pinappleeat();
        anim.SetBool("Eat", false);
        Destroy(gameObject);
    }
}
