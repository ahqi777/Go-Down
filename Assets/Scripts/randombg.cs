using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randombg : MonoBehaviour
{
    public List<GameObject> bg = new List<GameObject>();
    public float randomtime;
    private float counttime;
    private Vector3 randomposition;
    void Start()

    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bgrandom();
    }
    public void bgrandom()
    {
        counttime += Time.deltaTime;
        randomposition = transform.position;
        randomposition.x = Random.Range(-3.5f, 3.5f);

        if (counttime>= randomtime)
        {
            creatbg();
            counttime = 0;
        }
    }
    void creatbg()
    {
        int index = Random.Range(0, bg.Count);
        
        GameObject newbg = Instantiate(bg[index], randomposition, Quaternion.identity);
        
        newbg.transform.SetParent(this.gameObject.transform);

    }
}
