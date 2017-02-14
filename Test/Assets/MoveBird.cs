using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBird : MonoBehaviour {
    public GameObject Warning;
    public int speed;
    // Use this for initialization
    void Start () {
        Instantiate(Warning, new Vector2(8.38f, gameObject.transform.position.y), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}
}
