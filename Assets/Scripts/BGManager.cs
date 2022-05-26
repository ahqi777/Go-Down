using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    public Sprite doubleBG;
    public Sprite[] scoreBGs;
    public GameObject bg;
    private void Update()
    {
        if (bg.transform.position.y >= 1)
        {
            bg = Instantiate(Resources.Load<GameObject>("Prefabs/BG/BG"), this.transform);
            bg.transform.position = new Vector3(bg.transform.position.x, -16, 0);
        }
        ChangeBG(ScoreManager.instance.score);
    }
    public void ChangeBG(int score)
    {
        Sprite temp;
        if (ScoreManager.instance.isdouble)//double背景
        {
            temp = doubleBG;
        }
        else if (score >= 1000)
        {
            temp = scoreBGs[6];
        }
        else if (score >= 800)
        {
            temp = scoreBGs[5];
        }
        else if (score >= 500)
        {
            temp = scoreBGs[4];
        }
        else if (score >= 300)
        {
            temp = scoreBGs[3];
        }
        else if (score >= 200)
        {
            temp = scoreBGs[2];
        }
        else if (score >= 100)
        {
            temp = scoreBGs[1];
        }
        else
        {
            temp = scoreBGs[0];
        }
        for (int i = 0; i < this.transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = temp;
        }
    }
}
