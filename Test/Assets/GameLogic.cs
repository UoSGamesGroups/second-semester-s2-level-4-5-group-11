using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameLogic : MonoBehaviour {
    public Move p1, p2;
    public barScript updBar;
    int selMtHeight = 70000;
    int climbPerSec;

    public bool redWin, blueWin;

    private IEnumerator coroutine;
    // Use this for initialization
    void Start() {
        updBar.maxMtHeight = selMtHeight;

        coroutine = Climb(2.0f);
        StartCoroutine(coroutine);
    }
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Update is called once per frame


    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Hazard")
        {
            Destroy(coll.gameObject);
        }
    }

    IEnumerator Climb(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            if (p1.climb == true && p1.climb == true)
            {
                climbPerSec = 1500;
            }
            else if (p1.climb == true || p1.climb == true)
            {
                climbPerSec = 500;
            }
            else
            {
                climbPerSec = 0;
            }
            Debug.Log(Time.time);
            updBar.currentMtHeight += climbPerSec;

            if (updBar.currentMtHeight >= updBar.maxMtHeight)
            {
                Debug.Log("P1 " + p1.scrPos.y);
                Debug.Log("P2 " + p2.scrPos.y);

                if (p2.scrPos.y > p1.scrPos.y)
                {
                    redWin = true;
                }
                else if (p1.scrPos.y > p2.scrPos.y)
                {
                    blueWin = true;
                }
                else if (p1.scrPos.y == p2.scrPos.y)
                {
                    blueWin = true;
                    redWin = true;
                }
                SceneManager.LoadScene(1);
            }
        }  
    }
}
