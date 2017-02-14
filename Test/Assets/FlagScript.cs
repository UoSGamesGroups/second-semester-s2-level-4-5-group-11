using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour {
    public GameLogic result;
	// Use this for initialization
	void Start () {
        result = (GameLogic)GameObject.FindObjectOfType(typeof(GameLogic));

		if(result.redWin == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (result.blueWin == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (result.blueWin == true && result.redWin == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
