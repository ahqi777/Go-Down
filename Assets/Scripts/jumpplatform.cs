using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpplatform : MonoBehaviour
{
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.Play("jump");
            Invoke("destroy", 0.25f);
        }
    }
    public void destroy()
    {
        Destroy(gameObject);
    }
}
