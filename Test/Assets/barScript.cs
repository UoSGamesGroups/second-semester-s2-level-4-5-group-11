using UnityEngine;
using System.Collections;

public class barScript : MonoBehaviour {
    public float maxMtHeight;
    public float currentMtHeight;

    public float percentage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        percentage = (currentMtHeight / maxMtHeight);
        gameObject.transform.localScale = new Vector3(percentage, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
	}
}
