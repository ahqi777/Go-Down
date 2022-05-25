using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRoleInfo",menuName = "RoleInfo/Create new RoleInfo")]
public class RoleInfo : ScriptableObject
{
    public Sprite roleImage;//選擇角色圖片
    public string roleName;//角色名稱
    public RuntimeAnimatorController animatorctrl;//動畫控制器
    public string roleSkillName;//技能名稱
    [TextArea]
    public string skillDescription;//技能說明
    public float MoveSpeed;//移動速度
    public float JumpSpeed;//跳躍力量
    public float Weight;//重量
    public float skillcoolingtime;//技能冷卻時間
}
