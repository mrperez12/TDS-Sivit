﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Values : MonoBehaviour {
	
	public Toggle opt1;
	public Toggle opt2;
	public Toggle opt3;
	public Toggle opt4;
	public float grade;
	//public Toggle warningtoggler;
	//public int warning;

	// Use this for initialization
	void Start () {
		if(opt1.isOn){
			grade = 8.0f;
		}
		if(opt2.isOn){
			grade = 7.0f;
		}
		if(opt3.isOn){
			grade = 6.0f;
		}
		if(opt4.isOn){
			grade = 5.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(opt1.isOn){
			grade = 8.0f;
		}
		if(opt2.isOn){
			grade = 7.0f;
		}
		if(opt3.isOn){
			grade = 6.0f;
		}
		if(opt4.isOn){
			grade = 5.0f;
		}
		PlayerPrefs.SetFloat("grado",grade);
		//if (warningtoggler.isOn)
		//	warning = 1;
		//else
		//	warning = 0;
		//PlayerPrefs.SetInt ("warning", warning);
	}
}
