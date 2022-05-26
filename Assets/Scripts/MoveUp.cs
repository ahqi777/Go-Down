using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    Vector3 move;
    GameObject topline;
    public float speed;
    float spaceTime;
    void Start()
    {
        topline = GameObject.Find("topline");
        move.y = speed;
        spaceTime = 20;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > spaceTime)
        {
            speed += 0.5f;
            spaceTime += 20f;
        }
        speed = Mathf.Clamp(speed, 0, 5);
        move.y = speed;
        movement(); 
    }
    void movement()
    {
        transform.position += move * Time.deltaTime;
        if (transform.CompareTag("BG") && transform.position.y >= 17)
        {
            Destroy(this.gameObject);
        }
        else if (!transform.CompareTag("BG") && transform.position.y >= topline.transform.position.y)
        {
            Destroy(this.gameObject);
        } 
    }
}
