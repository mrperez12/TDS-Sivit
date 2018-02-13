using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vrViewMovement : MonoBehaviour {

	public Transform vrCamera;
	public float toggleAngle = 30.0f;
	public float upperToggleAngle = 90.0f;
	public float speed = 3.0f;
	public bool move;

	private CharacterController cc;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < upperToggleAngle) {
			move = true;
		} else {
			move = false;
		}
		if (move) {
			Vector3 forward = vrCamera.TransformDirection (Vector3.forward);
			cc.SimpleMove (forward * speed);
		}
	}
}
