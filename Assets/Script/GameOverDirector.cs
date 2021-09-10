using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverDirector : MonoBehaviour
{
    int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("LEVEL");
        if (level > 10)
        {
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(level);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (level <= 8)
            {
                // do nothing
            }
            else if (level <= 10)
            {
                level = 8;
            }
            else
            {
                level = 10;
            }
            PlayerPrefs.SetInt("LEVEL", level);

            SceneManager.LoadScene("GameScene");
        }
    }
}
