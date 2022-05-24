using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[CreateAssetMenu(menuName="playerdata",fileName ="playerdata")]
public class playerdata : ScriptableObject
{
    public string playername;
    public int score=FindObjectOfType<score>().eat;
}
