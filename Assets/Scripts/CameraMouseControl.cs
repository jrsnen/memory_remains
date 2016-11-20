using UnityEngine;
using System.Collections;

public class CameraMouseControl : MonoBehaviour {


    public GameObject followed;

    private float distance = 0.0f;
    private float maxAngle = 45.0f;

	// Use this for initialization
	void Start () {
        distance = Vector3.Distance(followed.transform.position, this.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        getInput();
        changePosition();

	}

    void LateUpdate()
    {
        this.transform.LookAt(followed.transform.position);
    }

    void getInput()
    { }

    void changePosition()
    { }

}
