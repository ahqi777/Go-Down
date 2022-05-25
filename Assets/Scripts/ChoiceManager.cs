using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChoiceManager : MonoBehaviour
{
    public static ChoiceManager instance;

    public Image roleImage;
    public TMP_Text nameText;
    public TMP_Text skillNameText;
    public TMP_Text skilldescriptionText;

    public RoleInfo[] roleInfos;
    public static int currindex = 0;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }
    private void Start()
    {
        instance.roleInfos = Resources.LoadAll<RoleInfo>("RoleInfo");
    }
    // Update is called once per frame
    void Update()
    {
        instance.roleImage.sprite = instance.roleInfos[currindex].roleImage;
        instance.nameText.text = instance.roleInfos[currindex].roleName;
        instance.skillNameText.text = "技能: " + instance.roleInfos[currindex].roleSkillName;
        instance.skilldescriptionText.text = instance.roleInfos[currindex].skillDescription;
    }
    public void Next()
    {
        if (currindex == instance.roleInfos.Length - 1)
        {
            currindex = 0;
            return;
        }
        currindex =  Mathf.Clamp(++currindex, 0, instance.roleInfos.Length - 1);
    }
    public void Back()
    {
        if (currindex == 0)
        {
            currindex = instance.roleInfos.Length - 1;
            return;
        }
        currindex = Mathf.Clamp(--currindex, 0, instance.roleInfos.Length - 1);
    }
}
