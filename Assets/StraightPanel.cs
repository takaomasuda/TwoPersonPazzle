using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightPanel : Panel
{
    // Start is called before the first frame update
    void Start()
    {
        points.Add(transform.Find("Front").position);
        points.Add(transform.Find("Back").position);


        int idx = 0;
        foreach (Vector3 point in points)
        {
            Debug.Log("Panel Status " + idx.ToString() + "(" + point.x + ", " + point.y + ", " + point.z + ")");
            idx++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
