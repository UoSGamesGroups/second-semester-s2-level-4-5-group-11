using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PullUICooldown : MonoBehaviour {
    public bool isPulled;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isPulled)
        {
            gameObject.GetComponent<Image>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Image>().enabled = true;
        }
    }
}
