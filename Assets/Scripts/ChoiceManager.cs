using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChoiceManager : MonoBehaviour
{
    public Image roleImage;
    public TMP_Text nameText;
    public TMP_Text skillNameText;
    public TMP_Text skilldescriptionText;

    public RoleInfo[] roleInfos;
    public int currindex = 0;
    // Start is called before the first frame update
    void Awake()
    {
        roleInfos = Resources.LoadAll<RoleInfo>("RoleInfo");
    }

    // Update is called once per frame
    void Update()
    {
        roleImage.sprite = roleInfos[currindex].roleImage;
        nameText.text = roleInfos[currindex].roleName;
        skillNameText.text = "技能: " + roleInfos[currindex].roleSkillName;
        skilldescriptionText.text = roleInfos[currindex].skillDescription;
    }
    public void Next()
    {
        if (currindex == roleInfos.Length - 1)
        {
            currindex = 0;
            return;
        }
        currindex =  Mathf.Clamp(++currindex, 0, roleInfos.Length - 1);
    }
    public void Back()
    {
        if (currindex == 0)
        {
            currindex = roleInfos.Length - 1;
            return;
        }
        currindex = Mathf.Clamp(--currindex, 0, roleInfos.Length - 1);
    }
}
