using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    protected List<Vector3> points = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3[] GetPath(Vector3 start)
    {
        List<Vector3> temp = new List<Vector3>(points);
        Vector3[] path = new Vector3[points.Count];
        Vector3 p = start;

        Debug.Log("point count " + path.Length.ToString() + " : (" + start.x + ", " + start.y + ", " + start.z + ")");

        for (int idx = 0; idx < path.Length; idx++)
        {
            float distance = 255;
            foreach (Vector3 point in temp)
            {
                float d = (p - point).magnitude;
                if (distance > d)
                {
                    path[idx] = point;
                    distance = d;
                }
            }
            p = path[idx];
            temp.Remove(p);

            Debug.Log("GetPath " + idx.ToString() + "(" + p.x + ", " + p.y + ", " + p.z + ")");
        }
        return path;
    }
}
