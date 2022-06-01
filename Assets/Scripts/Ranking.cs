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
            if (PlayerPrefs.GetString("No1") == null)
            {
                norecord.SetActive(true);
                return;
            }
            else
            {
                norecord.SetActive(false);
                playerList[i].transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetString("No" + (i+1).ToString());
                playerList[i].transform.GetChild(1).GetComponent<Text>().text = PlayerPrefs.GetInt("No" + (i + 1).ToString() + "Score").ToString();
                record.SetActive(true);
            }
        }
    }
}
