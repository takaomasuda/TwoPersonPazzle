using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvePanel : Panel
{

    // Start is called before the first frame update
    void Start()
    {
        points.Add(transform.Find("TurnR").position);
        points.Add(transform.Find("Center").position);
        points.Add(transform.Find("TurnL").position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
