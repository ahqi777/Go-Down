using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public int score;
    public bool isdouble;
    public BGManager bGManager;
    public ScoreRecord scoreRecord;
    public TMP_InputField playerName;
    public Text storeScore;
    public GameObject hint;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }

    private void Start()
    {
        instance.score = 0;
    }
    void Update()
    {
        instance.score = Mathf.Clamp(instance.score, 0, int.MaxValue);
        instance.scoreText.text = instance.score.ToString();
        if (playerName.text.Length > 8)
        {
            hint.SetActive(true);
        }
        else
        {
            hint.SetActive(false);
        }
    }
    /// <summary>
    /// 判斷加給分
    /// </summary>
    /// <param name="name"></param>
    public void HandleScore(string name)
    {
        int temp = 0;
        switch (name)
        {
            case "Apple":
                temp = 2;
                break;
            case "Banana":
                temp = 4;
                break;
            case "Cherry":
                temp = 6;
                break;
            case "Orange":
                temp = 10;
                break;
            case "Melon(Clone)":
                temp = 30;
                break;
            case "Pineapple(Clone)":
                temp = -10;
                break;
            case "Strawberry(Clone)":
                instance.Strawberry_Coll();
                break;
            default:
                temp = 0;
                break;
        }
        if (instance.isdouble)
            temp = temp * 2;
        instance.score = instance.score + temp;
    }
    public void Strawberry_Coll()
    {
        instance.isdouble = true;
        AudioManager.instance.ChangeBGM();
        Invoke("DoublePointOver", 10f);
    }

    /// <summary>
    /// 雙倍分數結束
    /// </summary>
    void DoublePointOver()
    {
        instance.isdouble = false;
        AudioManager.instance.ChangeBGM();
    }
    /// <summary>
    /// 遊戲結束，比較分數能否上前三
    /// </summary>
    public bool CompareScore()
    {
        for (int i = 0; i < scoreRecord.PlayerScore.Length - 1; i++)
        {
            if (score > scoreRecord.PlayerScore[i])
            {
                storeScore.text = score.ToString();
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// 儲存分數
    /// </summary>
    public void StoreScore()
    {
        if (playerName.text.Length > 8 || playerName.text == "")
        {
            return;
        }
        for (int i = scoreRecord.PlayerScore.Length - 1; i >= 0; i--)//從最小的開始比
        {
            if (score >= scoreRecord.PlayerScore[i])//如果大於最小值，直接取代掉
            {
                scoreRecord.PlayerName[i] = playerName.text;
                scoreRecord.PlayerScore[i] = score;
                break;
            }
        }
        UpdateRecord();//更新排行榜的順序
        hint.transform.parent.gameObject.SetActive(false);
        hint.transform.parent.parent.GetChild(6).gameObject.SetActive(true);
    }
    /// <summary>
    /// 更新排行榜的順序
    /// </summary>
    void UpdateRecord()
    {
        for (int i = 0; i < scoreRecord.PlayerScore.Length - 1; i++)
        {
            for (int j = 0; j < scoreRecord.PlayerScore.Length - 1 - i; j++)
            {
                if (scoreRecord.PlayerScore[j] <= scoreRecord.PlayerScore[j + 1])
                {
                    string tempname = scoreRecord.PlayerName[j];
                    int tempscore = scoreRecord.PlayerScore[j];
                    scoreRecord.PlayerName[j] = scoreRecord.PlayerName[j + 1];
                    scoreRecord.PlayerScore[j] = scoreRecord.PlayerScore[j + 1];
                    scoreRecord.PlayerName[j + 1] = tempname;
                    scoreRecord.PlayerScore[j + 1] = tempscore;
                }
            }
        }
    }
}
