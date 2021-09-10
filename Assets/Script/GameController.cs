using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SwapPos(GameObject obj1, GameObject obj2)
    {
        Vector3 tempPos = obj1.transform.position;
        obj1.transform.position = obj2.transform.position;
        obj2.transform.position = tempPos;
    }

    // Update is called once per frame
    void Update()
    {
        var rightPanel = GameObject.FindGameObjectWithTag("RightPanel");
        var leftPanel = GameObject.FindGameObjectWithTag("LeftPanel");
        
        float dx = 0;
        float dz = 0;
        GameObject swapPanel = null;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dx = 2;
            swapPanel = rightPanel;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dx = -2;
            swapPanel = rightPanel;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dz = 2;
            swapPanel = rightPanel;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dz = -2;
            swapPanel = rightPanel;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            dx = 2;

            swapPanel = leftPanel;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            dx = -2;
            swapPanel = leftPanel;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            dz = 2;
            swapPanel = leftPanel;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            dz = -2;
            swapPanel = leftPanel;
        }

        if (swapPanel != null)
        {
            Vector3 swapPos = swapPanel.transform.position;
            Vector3 targetPos = new Vector3(swapPos.x + dx, swapPos.y, swapPos.z + dz);
            var panels = GameObject.FindGameObjectsWithTag("Panel");
            var manPos = GameObject.FindGameObjectWithTag("Man").transform.position;
            var womanPos = GameObject.FindGameObjectWithTag("Woman").transform.position;

            foreach (GameObject panel in panels)
            {
                Vector3 panelPos = panel.transform.position;
                if (panelPos == targetPos)
                {
                    if (manPos.x < targetPos.x + 1 &&
                        manPos.x > targetPos.x - 1 &&
                        manPos.z < targetPos.z + 1 &&
                        manPos.z > targetPos.z - 1)
                    {
                        //do nothing
                    }
                    else if (womanPos.x < targetPos.x + 1 &&
                        womanPos.x > targetPos.x - 1 &&
                        womanPos.z < targetPos.z + 1 &&
                        womanPos.z > targetPos.z - 1)
                    {
                        //do nothing
                    }
                    else
                    {
                        SwapPos(panel, swapPanel);
                    }
                    break;
                }
            }
        }
    }
}
