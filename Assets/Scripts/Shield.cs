using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public AudioSource pomusic;
    private void OnTriggerEnter2D(Collider2D other)//碰撞尖刺死亡
    {
        if (other.CompareTag("spike"))
        {
            pomusic.Play();
            this.gameObject.SetActive(false);
        }
    }
}
