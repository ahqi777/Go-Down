using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class strawberry : MonoBehaviour
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
   
    public void strawberrydead()
    {
        FindObjectOfType<score>().strawberryeat();
        Destroy(gameObject);
    }
    void Update()
    {
    }
   
   
}
