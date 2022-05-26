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
            anim.SetTrigger("Coll");
        }
    }
    public void Coll_Score()
    {
        ScoreManager.instance.HandleScore(this.gameObject.name);
        Destroy(gameObject);
    }
}
