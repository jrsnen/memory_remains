using UnityEngine;
using System.Collections;

public class EndingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainCharacter"))
        {
            // End scene
            Application.LoadLevel(3);
        }
    }
}
