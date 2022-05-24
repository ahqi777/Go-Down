﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animbg : MonoBehaviour
{
    Material material;
    Vector2 move;
    public Vector2 speed;
    public Animator anim;
    public AudioSource doublebgm;
    public GameObject score100, score200, score300, score500, score1000;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        move += speed * Time.deltaTime;
        material.mainTextureOffset = move;
    }
    public void doublestart()
    {
        anim.SetBool("double", true);
        doublebgm.Play();
        FindObjectOfType<playermove>().audiostop();
    }
    public void doubleover()
    {
        anim.SetBool("double", false);
        doublebgm.Pause();
        FindObjectOfType<playermove>().audiostart();
    }
   public void score1()
    {
        score100.SetActive(true);
    }
    public void score2()
    {
        score100.SetActive(false);
        score200.SetActive(true);
    }
    public void score3()
    {
        score200.SetActive(false);
        score300.SetActive(true);
    }
    public void score5()
    {
        score300.SetActive(false);
        score500.SetActive(true);
    }
    public void score10()
    {
        score500.SetActive(false);
        score1000.SetActive(true);
    }
    
}