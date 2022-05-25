using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRoleInfo",menuName = "RoleInfo/Create new RoleInfo")]
public class RoleInfo : ScriptableObject
{
    [InspectorName("角色團片")]
    public Sprite roleImage;
    [InspectorName("角色名稱")]
    public string roleName;
    [InspectorName("角色技能名稱")]
    public string roleSkillName;
    [InspectorName("技能說明"), TextArea]
    public string skillDescription;
    [InspectorName("移動速度")]
    public float MoveSpeed;
    [InspectorName("跳躍力")]
    public float JumpSpeed;
    [InspectorName("重量")]
    public float Weight;
}
