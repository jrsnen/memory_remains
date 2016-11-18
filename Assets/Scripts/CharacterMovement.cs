using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	[System.Serializable]
	public class MoveSettings
	{
		public float forwardVel = 12;
		public float rotateVel  = 100;
        public float jumpVel = 25;
        public float distToGround = 0.1f;
        public LayerMask ground; 
	}

	[System.Serializable]
	public class PhysSettings
	{
        public float downAccel = 0.75f;
	}

	[System.Serializable]
	public class InputSettings
	{
		public float inputDelay = 0.1f;
        public string FORWARD_AXIS = "Vertical";
        public string TURN_AXIS = "Horizontal";
        public string JUMP_AXIS = "Jump";
    }

    public MoveSettings moveSettings = new MoveSettings();
    public PhysSettings physSettings = new PhysSettings();
    public InputSettings inputSettings = new InputSettings();

    Quaternion targetRotation;
	private Rigidbody rBody;
    float forwardInput, turnInput;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);

		if (Input.GetKeyDown ("space")){
			transform.position += transform.up * Time.deltaTime * jumpSpeed;
		} 
	}
}
