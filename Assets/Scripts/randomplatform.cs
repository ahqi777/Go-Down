using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomplatform : MonoBehaviour
{
    public List<GameObject> platform = new List<GameObject>();
    public float randomtime;
    private float counttime;
    private Vector3 randomposition;
    void Start()

    {
        
    }

    // Update is called once per frame
    void Update()
    {
        platformrandom();
    }
    public void platformrandom()
    {
        counttime += Time.deltaTime;
        randomposition = transform.position;
        randomposition.x = Random.Range(-3.5f, 3.5f);

        if (counttime>= randomtime)
        {
            creatplatform();
            counttime = 0;
        }
    }
    void creatplatform()
    {
        int index = Random.Range(0, platform.Count);

        int spikenum = 0;
        if (index == 5)
        {
            spikenum++;
        }
        if (spikenum > 1)
        {
            spikenum = 0;
            counttime = randomtime;
            return;
        }
        GameObject newplatform = Instantiate(platform[index], randomposition, Quaternion.identity);
        newplatform.transform.SetParent(this.gameObject.transform);
    }
}
