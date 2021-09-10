using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject StartCountText;
    float second = 0;
    int CountDown = 3;

    GameObject NowLevelText;

    public GameObject man;
    public GameObject woman;

    // Start is called before the first frame update
    void Start()
    {
        StartCountText = GameObject.Find("StartCount");
        NowLevelText = GameObject.Find("NowLevel");

        int level = PlayerPrefs.GetInt("LEVEL");
        NowLevelText.GetComponent<Text>().text = "Level " + level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        second += Time.deltaTime;
        if (second >= 1 && CountDown > 0)
        {
            second = 0;
            CountDown--;
            if (CountDown > 0)
            {
                StartCountText.GetComponent<Text>().text = CountDown.ToString();
            }
            else
            {
                StartCountText.GetComponent<Text>().text = "";
                Instantiate(man);
                Instantiate(woman);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
