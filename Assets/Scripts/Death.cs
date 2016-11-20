using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {


    private GameObject respawner;

    private float fallDuration = 0.0f;
    
    public float fallLimit = 2.0f;
    public float deathLimit = 4.0f;

    private Rigidbody rb;

    private bool falling = false;

    private Animator anim;

	// Use this for initialization
	void Start () {
        fallDuration = 0.0f;
        rb = this.gameObject.GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (rb.velocity.y < 0)
        {
            fallDuration += Time.deltaTime;
            //Debug.Log("Falling:" + fallDuration);
        }
        else
        {
            fallDuration = 0.0f;
        }
        if(fallDuration > fallLimit)
        {
            if (fallDuration > deathLimit)
            {
                Respawn();
                anim.SetBool("isFalling", false);
            }
            else
            {
                anim.SetBool("isFalling", true);
                StartFall();
            }
        }
        else
        {
            falling = false;
        }
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawner"))
        {
            respawner = other.gameObject;

            Debug.Log("Found respawner");
        }
    }

    void StartFall()
    {
        Debug.Log("Starting fall");

        
        // stop camera and wait

        falling = true;
    }


    void Respawn()
    {
        Debug.Log("Respawn");
        this.gameObject.transform.position = respawner.transform.position;
        //respawner after few seconds

        fallDuration = 0.0f;
    }
}
