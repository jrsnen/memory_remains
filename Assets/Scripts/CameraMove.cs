using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour {
    Vector3 position = new Vector3(0,1,-5);
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        position.y += Time.deltaTime;
        this.transform.position = position;

        float randomNumber = Random.Range(14, 18);
        if (position.y > randomNumber) SceneManager.LoadScene(2);
	}

}
