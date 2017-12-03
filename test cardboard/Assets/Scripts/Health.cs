using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public bool safe;
	public bool danger;

	// Use this for initialization
	void Start () {
		//Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter (Collider other){
		if (other.tag == "safezone") {
			Debug.Log ("SAFE ZONE MADAFAKA");
			safe = true;
		}
		if (other.tag == "dangerzone") {
			//Debug.Log ("DANGEROUS ZONE MADAFAKA");
			danger = true;
		}
	}
	void OnTriggerExit (Collider other){
		if (other.tag == "safezone") {
			Debug.Log ("SAFE ZONE MADAFAKA");
			safe = false;
		}
		if (other.tag == "dangerzone") {
			//Debug.Log ("DANGEROUS ZONE MADAFAKA");
			danger = false;
		}
	}
}
