using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    private Image image_btn;
    private Image image;
    private Button skill_Btn;
    private AudioSource pressmusic;
    private float coolingTime;
    private float pressDownTime;

    public PlayerCtrl playerCtrl;
    public bool ispress;
    private void Start()
    {
        image_btn = GetComponent<Image>();
        image = transform.GetChild(0).gameObject.GetComponent<Image>();
        skill_Btn = GetComponent<Button>();
        pressmusic = GetComponent<AudioSource>();
        coolingTime = playerCtrl.roleInfo.skillcoolingtime;
    }
    private void LateUpdate()
    {
        if (ispress)
        {
            if (!IsCooling())
            {
                Color red = new Color32(255, 0, 0, 255);
                Color white = new Color32(255, 255, 255, 255);
                image_btn.color = red;
                image.color = white;
                skill_Btn.enabled = true;
                ispress = false;
            }
        }   
    }
    public bool IsCooling()
    {
        //冷卻時間-(按下到現在已經過去的時間-剩餘的冷卻時間)
        float time = coolingTime - (Time.time - pressDownTime);
        image_btn.fillAmount = (Time.time - pressDownTime) / coolingTime;
        image.fillAmount = (Time.time - pressDownTime) / coolingTime;
        if (time <= 0)
        {
            time = 0;
        }
        return (coolingTime - time) < coolingTime;
    }
    public void Press()
    {
        playerCtrl.Skill();
        Color red = new Color32(255, 0, 0, 50);
        Color white = new Color32(255, 255, 255, 50);
        image_btn.color = red;
        image.color = white;
        image_btn.fillAmount = 0;
        image.fillAmount = 0;
        pressDownTime = Time.time;
        pressmusic.Play();
        skill_Btn.enabled = false;
        ispress = true;
    }
    public void allstop()//暫停
    {
        skill_Btn.enabled = false;
    }
    public void allstart()//開始
    {
        skill_Btn.enabled = true;
    }
}
