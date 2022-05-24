using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rankmanager : MonoBehaviour
{
    public List<playerdata> playerdatas = new List<playerdata>();
    public group[] group;
    // Start is called before the first frame update
    void Start()
    {
        calhighestscore();
        Debug.Log(calhighestscore());
    }

    // Update is called once per frame
    void Update()
    {
        playerdatas.Sort(sortbyscore);
        updaterank();
    }

    private string calhighestscore()
    {
        int highestscore = 0;
        string topname = "";

        for (int i=0; i < playerdatas.Count; i++)
        {
            if (playerdatas[i].score > highestscore)
            {
                highestscore = playerdatas[i].score;
                topname = playerdatas[i].playername;
            }
        }
        return topname;
    }
    private int sortbyscore(playerdata _playerA,playerdata _playerB)//比較playerdata的值 ab比較 
    {
        return _playerA.score.CompareTo(_playerB.score);
    }
    private void updaterank()
    {
        for (int i = 0; i < playerdatas.Count; i++)
        {
            group[i].playerdata = playerdatas[i];
            group[i].Updategroup();
        }
    }
}
