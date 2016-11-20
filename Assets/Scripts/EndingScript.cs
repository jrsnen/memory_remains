using UnityEngine;
using System.Collections;

public class EndingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        if (other.gameObject.CompareTag("MainCharacter"))
        {
            Debug.Log("yes");
        }
    }
}
