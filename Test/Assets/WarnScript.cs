using UnityEngine;
using System.Collections;

public class WarnScript : MonoBehaviour {
    public GameObject Warning;
	// Use this for initialization
	void Start () {
        Instantiate(Warning, new Vector2(transform.position.x, 4.269f), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

}
