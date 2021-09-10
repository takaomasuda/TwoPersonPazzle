using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGenerator : MonoBehaviour
{

    int straightVPanelCount = 4;
    int straightHPanelCount = 3;

    int curveRPanelCount = 3;
    int curveLPanelCount = 3;
    int curveUPanelCount = 3;
    int curveDPanelCount = 3;

    public GameObject straightVPanel;
    public GameObject straightHPanel;
    public GameObject curveRPanel;
    public GameObject curveLPanel;
    public GameObject curveUPanel;
    public GameObject curveDPanel;

    struct PanelList { 
        public GameObject obj;
        public int count;

        public PanelList(GameObject obj, int count)
        {
            this.obj = obj;
            this.count = count;
        }
    };

    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> PosList = new List<Vector3> {
        new Vector3(-2, 0, 4),
        new Vector3(0, 0, 4),
        //new Vector3(2, 0, 4), default route
        new Vector3(-4, 0, 2),
        new Vector3(-2, 0, 2),
        new Vector3(0, 0, 2),
        new Vector3(2, 0, 2),
        new Vector3(4, 0, 2),
        new Vector3(-4, 0, 0),
        new Vector3(-2, 0, 0),
        new Vector3(0, 0, 0),
        new Vector3(2, 0, 0),
        new Vector3(4, 0, 0),
        new Vector3(-4, 0, -2),
        new Vector3(-2, 0, -2),
        new Vector3(0, 0, -2),
        new Vector3(2, 0, -2),
        new Vector3(4, 0, -2),
        //new Vector3(-2, 0, -4), default route
        new Vector3(0, 0, -4),
        new Vector3(2, 0, -4),
        };

        PanelList[] panels = new PanelList[] {
            new PanelList( straightVPanel, straightVPanelCount),
            new PanelList( straightHPanel, straightHPanelCount),
            new PanelList( curveRPanel, curveRPanelCount),
            new PanelList( curveLPanel, curveLPanelCount),
            new PanelList( curveUPanel, curveUPanelCount),
            new PanelList( curveDPanel, curveDPanelCount),
        };



        foreach (PanelList panelList in panels)
        {
            for (int count = 0; count < panelList.count; count++)
            {
                GameObject panel = Instantiate(panelList.obj) as GameObject;
                int idx = Random.Range(0, PosList.Count - 1);
                panel.transform.position = PosList[idx];
                PosList.RemoveAt(idx);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
