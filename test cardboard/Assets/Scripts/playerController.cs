﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public Transform vrCamera;

	public float speed = 1.0f;

	private CharacterController cc;

	public float toggleAngle = 30.0f;

	public bool moveForward;

	// Use this for initialization
	void Start () {
		
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		float translation = Input.GetAxis("Vertical");
		if (translation != 0.0f) {
			moveForward = true;
		} else {
			moveForward = false;
		}
		if(moveForward){

			Vector3 forward = vrCamera.TransformDirection (Vector3.forward);
			cc.SimpleMove (forward * speed);
		}
	}
}
