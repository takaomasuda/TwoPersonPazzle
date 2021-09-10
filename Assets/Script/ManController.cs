using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManController : MonoBehaviour
{
    Rigidbody body;
    float speed = 0.1f;
    float maxSpeed = 1.5f;

    int state;
    readonly int goStraight = 0;
    readonly int turnR = 1;
    readonly int turnL = 2;

    float targetYR = 0;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.velocity = transform.right * speed;

        int level = PlayerPrefs.GetInt("LEVEL");

        if (level < 3)
        {
            speed = speed * level;
        }
        else if (level < 5)
        {
            speed = 0.2f;
        }
        else if (level < 10)
        {
            speed = 0.25f;
        }
        else
        {
            speed = 0.25f + (level - 10) * 0.01f;
        }

        state = goStraight;
        targetYR = transform.rotation.eulerAngles.y;
    }

    float NormalizeAngle(float angle)
    {
        if (angle < 0)
        {
            return 360 + angle;
        }
        else
        {
            return angle;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float accel = 1;
        if (Input.GetKey(KeyCode.Space) && speed < maxSpeed) accel = maxSpeed / speed;

        float currentYR = NormalizeAngle(transform.rotation.eulerAngles.y);
        float dT = Time.deltaTime;
        if (state == turnR)
        {
            float dR = 90 * speed * accel * 2 / Mathf.PI * dT * 0.99f;
            currentYR += dR;
        }
        else if (state == turnL)
        {
            float dR = 90 * speed * accel * 2 / Mathf.PI * dT * 0.99f;
            currentYR -= dR;
        }
        else if (targetYR != currentYR)
        {
            currentYR = targetYR;
        }
        else
        {
            //do nothing
        }

        transform.rotation = Quaternion.Euler(new Vector3(270, NormalizeAngle(currentYR), 0));

        body.velocity = transform.right * speed * accel;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Woman")
        {
            var manItems = GameObject.FindGameObjectsWithTag("ManItem");
            var womanItems = GameObject.FindGameObjectsWithTag("WomanItem");
            if (manItems.Length == 0 &&
                womanItems.Length == 0)
            {
                SceneManager.LoadScene("ClearScene");
            }
            else
            {
                SceneManager.LoadScene("GameOverScene");
            }
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
        Vector3 pos = transform.position;
        Vector3 ang = transform.rotation.eulerAngles;
        Debug.Log("man Trigger " + other.gameObject.tag + "pos (" + pos.x + ", " + pos.y + ", " + pos.z + "), ang (" + ang.x + ", " + ang.y + ", " + ang.z + ") state " + state);
        float angleY = NormalizeAngle(targetYR);
        if (other.gameObject.tag == "TurnR")
        {
            if (state == turnL)
            {
                state = goStraight;
                Vector3 p = transform.position;
                transform.position = new Vector3(Mathf.Round(p.x), Mathf.Round(p.y), Mathf.Round(p.z));
            }
            else if (state == goStraight)
            {
                state = turnR;
                targetYR = angleY + 90;
            }
        }
        else if (other.gameObject.tag == "TurnL")
        {
            if (state == turnR)
            {
                state = goStraight;
                Vector3 p = transform.position;
                transform.position = new Vector3(Mathf.Round(p.x), Mathf.Round(p.y), Mathf.Round(p.z));
            }
            else if (state == goStraight)
            {
                state = turnL;
                targetYR = angleY - 90;
            }
        }
        else if (other.gameObject.tag == "ManItem")
        {
            Destroy(other.gameObject);
        }
        Debug.Log("man state " + state.ToString());
    }
}
