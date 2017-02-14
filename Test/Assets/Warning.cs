using UnityEngine;
using System.Collections;

public class Warning : MonoBehaviour {
	int timer;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (Flash (1.0F));
		if (timer >= 5){
		Destroy (gameObject);
		}
	}
	IEnumerator Flash(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		timer++;
	}
}
