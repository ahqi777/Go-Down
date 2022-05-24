using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class group : MonoBehaviour
{
    public playerdata playerdata;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        Updategroup();
    }

    // Update is called once per frame
    public void Updategroup()
    {
        Name.text = playerdata.playername;
        score.text = playerdata.score.ToString();
    }
}
