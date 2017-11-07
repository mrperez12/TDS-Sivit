﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleVrButton : MonoBehaviour {

	public float fillTime = 2f;
	private float time;
	public Slider mySlider;
	private bool gazeAt;
	private Coroutine fillSlide;
	public Toggle toggle;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void PointerEnter(){

		mySlider.gameObject.SetActive (true);

		gazeAt = true;

		fillSlide = StartCoroutine (fill());

	}

	public void PointerExit(){

		gazeAt = false;

		if (fillSlide != null) {
			StopCoroutine(fillSlide);
		}
		time = 0f;
		mySlider.value = 0f;
		mySlider.gameObject.SetActive (false);
	}

	private IEnumerator fill(){

		time = 0f;

		while (time < fillTime) {

			time += Time.deltaTime;

			mySlider.value = time / fillTime;

			yield return  null;

			if (gazeAt) {

				continue;
			}

			time = 0f;
			mySlider.value = 0f;
			yield break;
		}
		loadGrade (toggle);
	}

	private void loadGrade(Toggle toggle){

			toggle.isOn = true;
			mySlider.gameObject.SetActive (false);

	}

}
