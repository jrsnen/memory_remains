using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
    Vector3 position = new Vector3(0,1,-5);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        position.y += Time.deltaTime;
        this.transform.position = position;
	}

}
