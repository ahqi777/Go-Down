using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    Vector3 move;
    GameObject topline;
    public float speed;
    void Start()
    {
        topline = GameObject.Find("topline");
        move.y = speed;
    }

    // Update is called once per frame
    void Update()
    {
     
        movement(); 
    }
    void movement()
    {
        transform.position += move * Time.deltaTime;
        
        if (transform.position.y >= topline.transform.position.y)
        {
            Destroy(gameObject);
        } 
    }
   
   
}
