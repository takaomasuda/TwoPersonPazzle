using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearDirector : MonoBehaviour
{
    GameObject clearText;
    int level;

    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("LEVEL");

        clearText = GameObject.Find("ClearLevel");
        clearText.GetComponent<Text>().text = "Clear Level " + level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            level++;
            PlayerPrefs.SetInt("LEVEL", level);
            SceneManager.LoadScene("GameScene");
        }
    }
}
