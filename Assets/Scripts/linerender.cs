using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linerender : MonoBehaviour
{
    LineRenderer line;
    public Transform startpoint;
    public Transform endpoint;
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, startpoint.position);
        line.SetPosition(1, endpoint.position);
    }
}
