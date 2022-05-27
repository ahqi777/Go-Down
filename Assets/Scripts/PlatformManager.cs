using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();
    public float[] platformProbs;
    public float platformRandomTime;
    private float platformCountTime;

    public List<GameObject> traps = new List<GameObject>();
    public float[] trapProbs;
    public float trapRandomTime;
    private float trapCountTime;

    public List<GameObject> bgs = new List<GameObject>();
    public float[] bgProbs;
    public float bgRandomTime;
    private float bgCountTime;

    private Vector3 randomPosition;
    void Start()
    {
        randomPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Handle(ref platformCountTime,platformRandomTime, platformProbs, platforms);
        Handle(ref trapCountTime, trapRandomTime, trapProbs, traps);
        Handle(ref bgCountTime, bgRandomTime, bgProbs, bgs);
    }
    void Handle(ref float countTime, float randomTime, float[] probs, List<GameObject> gameObjects)
    {
        countTime += Time.deltaTime;
        if (countTime >= randomTime)
        {
            randomPosition.x = Random.Range(-3.5f, 3.5f);
            int index = Choose(probs);
            GameObject newGameObject = Instantiate(gameObjects[index], randomPosition, Quaternion.identity);
            newGameObject.transform.SetParent(this.gameObject.transform);
            countTime = 0;
        }
    }
    /// <summary>
    /// 隨機選擇
    /// </summary>
    /// <param name="probs"></param>
    /// <returns></returns>
    int Choose(float[] probs)
    {
        float total = 0;

        foreach (float item in probs)
        {
            total += item;
        }
        float randomPoint = Random.value * total;
        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }
}
