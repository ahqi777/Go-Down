using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Strawberry : MonoBehaviour
{
    public Animator anim;
    public AudioSource music;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            music.Play();
            anim.Play("strawberry_coll");
        }
       
    }
    public void Strawberrydead()
    {
        FindObjectOfType<ScoreManager>().strawberryeat();
        Destroy(gameObject);
    }
}
