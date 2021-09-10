using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject manItemPrefab;
    public GameObject womanItemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        int level = PlayerPrefs.GetInt("LEVEL");

        List<Vector3> PosList = new List<Vector3> {
        new Vector3(-4, 1, 4), // 0
        new Vector3(-2, 1, 4), // 1
        new Vector3(0, 1, 4),  // 2
        new Vector3(-4, 1, 2), // 3
        new Vector3(-2, 1, 2), // 4
        new Vector3(0, 1, 2),  // 5
        new Vector3(2, 1, 2),  // 6
        new Vector3(4, 1, 2),  // 7
        new Vector3(-4, 1, 0), // 8
        new Vector3(-2, 1, 0), // 9
        new Vector3(0, 1, 0),  // 10
        new Vector3(2, 1, 0),  // 11
        new Vector3(4, 1, 0),  // 12
        new Vector3(-4, 1, -2),// 13
        new Vector3(-2, 1, -2),// 14
        new Vector3(0, 1, -2), // 15
        new Vector3(2, 1, -2), // 16
        new Vector3(4, 1, -2), // 17
        new Vector3(0, 1, -4), // 18
        new Vector3(2, 1, -4), // 19
        new Vector3(4, 1, -4), // 20
        };

        if (level <= 2)
        {
            // do nothing
        }
        else if (level == 3)
        {
            GameObject womanItem = Instantiate(womanItemPrefab) as GameObject;
            womanItem.transform.position = new Vector3(-2, 1, 2);

            GameObject manItem = Instantiate(manItemPrefab) as GameObject;
            manItem.transform.position = new Vector3(2, 1, -2);
        }
        else if (level == 4)
        {
            GameObject womanItem = Instantiate(womanItemPrefab) as GameObject;
            womanItem.transform.position = new Vector3(2, 1, 2);

            GameObject manItem = Instantiate(manItemPrefab) as GameObject;
            manItem.transform.position = new Vector3(-2, 1, -2);
        }
        else if (level == 5)
        {
            GameObject womanItem = Instantiate(womanItemPrefab) as GameObject;
            womanItem.transform.position = new Vector3(-2, 1, -2);

            GameObject manItem = Instantiate(manItemPrefab) as GameObject;
            manItem.transform.position = new Vector3(2, 1, 2);
        }
        else if (level == 6)
        {
            GameObject womanItem = Instantiate(womanItemPrefab) as GameObject;
            womanItem.transform.position = new Vector3(2, 1, 2);

            womanItem = Instantiate(womanItemPrefab) as GameObject;
            womanItem.transform.position = new Vector3(-2, 1, 2);

            GameObject manItem = Instantiate(manItemPrefab) as GameObject;
            manItem.transform.position = new Vector3(2, 1, -2);

            manItem = Instantiate(manItemPrefab) as GameObject;
            manItem.transform.position = new Vector3(-2, 1, -2);
        }
        else if (level == 7)
        {
            GameObject womanItem = Instantiate(womanItemPrefab) as GameObject;
            womanItem.transform.position = new Vector3(2, 1, -2);

            GameObject manItem = Instantiate(manItemPrefab) as GameObject;
            manItem.transform.position = new Vector3(-2, 1, 2);
        }
        else if (level < 10)
        {
            int idx = Random.Range(0, PosList.Count - 1);
            GameObject womanItem = Instantiate(womanItemPrefab) as GameObject;
            womanItem.transform.position = PosList[idx];
            PosList.RemoveAt(idx);

            idx = Random.Range(0, PosList.Count - 1);
            GameObject manItem = Instantiate(manItemPrefab) as GameObject;
            manItem.transform.position = PosList[idx];
        }
        else
        {
            int idx = Random.Range(0, PosList.Count - 1);
            GameObject womanItem = Instantiate(womanItemPrefab) as GameObject;
            womanItem.transform.position = PosList[idx];
            PosList.RemoveAt(idx);

            idx = Random.Range(0, PosList.Count - 1);
            womanItem = Instantiate(womanItemPrefab) as GameObject;
            womanItem.transform.position = PosList[idx];
            PosList.RemoveAt(idx);

            idx = Random.Range(0, PosList.Count - 1);
            GameObject manItem = Instantiate(manItemPrefab) as GameObject;
            manItem.transform.position = PosList[idx];
            PosList.RemoveAt(idx);

            idx = Random.Range(0, PosList.Count - 1);
            manItem = Instantiate(manItemPrefab) as GameObject;
            manItem.transform.position = PosList[idx];
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
