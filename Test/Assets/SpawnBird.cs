using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBird : MonoBehaviour {
    public GameObject bird1;
    bool spawn = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawn == true)
        {
            StartCoroutine(SpawnHazard(Random.Range(2f, 4f)));
            spawn = false;
        }

    }

    IEnumerator SpawnHazard(float wait)
    {
        yield return new WaitForSeconds(wait);
        Instantiate(bird1, new Vector2(gameObject.transform.position.x,Random.Range(-3.3f, 4.2f)), Quaternion.identity);
        spawn = true;
    }
}
