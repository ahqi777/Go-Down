using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ScoreRecord",menuName = "ScoreRecord/create new ScoreRecord")]
public class ScoreRecord : ScriptableObject
{
    public string[] PlayerName;
    public int[] PlayerScore;
}
