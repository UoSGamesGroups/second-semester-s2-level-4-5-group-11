using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Move : MonoBehaviour {
    public float MoveForce;

    public Rigidbody2D rb;
    public Rigidbody2D oRB;

    public bool stun;
    public bool climb;

    public Move OthObject;
    public Camera cam;

    Vector2 dir;
    public Vector3 scrPos; 

    float hitPercent = 1.0f;
    float pCoolDown = 1.5f;

    bool canPull = true;


    public KeyCode Up, Down, Left, Right, Pull;
    public PullUICooldown uiShow;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
       
    }
	
	// Update is called once per frame
	void Update () {
        scrPos = cam.WorldToScreenPoint(gameObject.transform.position);
        if (Input.GetKey(Up) && stun == false)
        {
            rb.AddForce(new Vector2(0,  MoveForce));
        }
        if (Input.GetKey(Down) && stun == false)
        {
            rb.AddForce(new Vector2(0, -MoveForce));
        }
        if (Input.GetKey(Left) && stun == false)
        {
            rb.AddForce(new Vector2(-MoveForce, 0));
        }
        if (Input.GetKey(Right) && stun == false)
        {
            rb.AddForce(new Vector2(MoveForce, 0));
        }
        if (Input.GetKeyDown(Pull) && stun == false && OthObject.stun == false && canPull == true)
        {
            canPull = false;
            dir = oRB.gameObject.transform.position - transform.position;
            dir = dir.normalized;
            oRB.AddForce(-dir * MoveForce * 65);
            StartCoroutine(PullCoolDown());
            uiShow.isPulled = true;
        }

        if (stun == true)
        {
            rb.gravityScale = 1;
            rb.mass = 0.1f;
            rb.freezeRotation = false;
        }
        if (stun == false)
        {
            rb.gravityScale = 0;
            rb.mass = 10f;
            rb.freezeRotation = true;
            rb.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
       // Vector3 scrPos = cam.WorldToScreenPoint(gameObject.transform.position); 
       // Debug.Log(Screen.height / 2 + " / " + scrPos.y);
        if(scrPos.y >= Screen.height / 4 && stun == false)
        {
            climb = true;
        }
        else
        {
            climb = false;
        }
        // rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * MoveForce, Input.GetAxis("Vertical") * MoveForce));



        
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Hazard")
        {
            hitPercent += 0.25f;
            stun = true;
            StartCoroutine(coolDown(hitPercent));
            Destroy(coll.gameObject);
        }
    }

    IEnumerator coolDown(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        stun = false;
    }
    IEnumerator PullCoolDown()
    {      
        yield return new WaitForSeconds(pCoolDown);
        uiShow.isPulled = false;
        canPull = true;
    }
}
