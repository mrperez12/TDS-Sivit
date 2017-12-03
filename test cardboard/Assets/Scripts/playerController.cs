using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public Transform vrCamera;

	public float speed = 1.0f;

	private CharacterController cc;

	public float toggleAngle = 30.0f;

	public bool moveForward;
	public bool moveBackward;


	// Use this for initialization
	void Start () {
		vrCamera.transform.position += new Vector3 (0, 1.5f, 0);
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		float translation = Input.GetAxis("Vertical");
		if (translation > 0.0f) {
			moveForward = true;
		}
		else if (translation < 0.0f){
			moveBackward = true;
		}
		else {
			moveForward = false;
			moveBackward = false;
		}
		if(moveForward){

			Vector3 forward = vrCamera.TransformDirection (Vector3.forward);
			cc.SimpleMove (forward * speed);
		}
		if (moveBackward) {
			
			Vector3 backward = vrCamera.TransformDirection (Vector3.forward);
			cc.SimpleMove (backward * -1 * speed);
		}
	}
}
