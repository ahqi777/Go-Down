using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class protect : MonoBehaviour
{
    public AudioSource pomusic;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)//碰撞尖刺死亡
    {
        if (other.CompareTag("spike"))
        {
            pomusic.Play();
            gameObject.SetActive(false);
        }
    }
}
