using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainCharacter"))
        {
            // End scene
            SceneManager.LoadScene(3);
        }
    }
}
