using UnityEngine;
using System.Collections;

public class SpawnBoulder : MonoBehaviour {
    public GameObject boulder1;
    bool spawn = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (spawn == true)
        {
            StartCoroutine(SpawnHazard(Random.Range(2f, 4f)));
            spawn = false;
        }
        
	}

    IEnumerator SpawnHazard(float wait)
    {
        yield return new WaitForSeconds(wait);
        Instantiate(boulder1, new Vector2(Random.Range(-8, 8), gameObject.transform.position.y), Quaternion.identity);
        spawn = true;
    }
}
