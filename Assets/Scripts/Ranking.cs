using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public ScoreRecord scoreRecord;
    public GameObject record;
    public GameObject norecord;
    public GameObject[] playerList;
    private void Update()
    {
        for (int i = 0; i < scoreRecord.PlayerName.Length; i++)
        {
            if (scoreRecord.PlayerName[0] == "")
            {
                norecord.SetActive(true);
                return;
            }
            else
            {
                norecord.SetActive(false);
                playerList[i].transform.GetChild(0).GetComponent<Text>().text = scoreRecord.PlayerName[i] + " : ";
                playerList[i].transform.GetChild(1).GetComponent<Text>().text = scoreRecord.PlayerScore[i].ToString();
                record.SetActive(true);
            }
        }
    }
}
