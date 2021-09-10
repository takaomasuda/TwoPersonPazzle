using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class PersonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Woman")
        {
            SceneManager.LoadScene("ClearScene");
        }
        else if (collision.gameObject.tag == "Defeat" ||
                 collision.gameObject.tag == "RightPanel" ||
                 collision.gameObject.tag == "LeftPanel")
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 p = other.gameObject.transform.position; 
        Debug.Log("Trigger " + other.gameObject.tag + " (" + p.x + ", " + p.y + ", " + p.z + ")");
        if (other.gameObject.tag == "Panel")
        {
            Vector3[] path = other.gameObject.GetComponent<Panel>().GetPath(transform.position);

            int idx = 0;
            foreach (Vector3 point in path)
            {
                Debug.Log(idx.ToString() + "(" + point.x + ", " + point.y + ", " + point.z + ")");
                idx++;
            }

            transform.DOLocalPath(path, 2.0f, PathType.CatmullRom)
              .SetEase(Ease.Linear)
              .SetLookAt(0.01f, Vector3.left)
              .SetOptions(false, AxisConstraint.Y);
        }
    }
}
