using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zoomHighlight : MonoBehaviour {

	public float fillTime = 2f; /*tiempo que se demora en llenarse el slider*/
	private float time; /*contador de tiempo*/
	public Slider mySlider; /*linea de carga del objeto al que apunto*/
	public Toggle myToggle; /*boton selector para seleccionar la escena*/
	private bool gazeAt; /*booleano que indica si estoy apuntando al objeto o no*/
	private Coroutine fillSlide; /*corutina para llenar el slider*/
	public Image scene; /*imagen de la escena a la que apunto*/

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*Funcion que se llama al entrar la mira sobre el objeto con event trigger*/
	public void PointerEnter(){

		scene.transform.position = new Vector3 (scene.transform.position.x, scene.transform.position.y, scene.transform.position.z - 1.0f);
		mySlider.gameObject.SetActive (true);

		gazeAt = true;

		fillSlide = StartCoroutine (fill());
	}
	/*Funcion que se llama al salir la mira de sobre el objeto con event trigger*/
	public void PointerExit(){

		scene.transform.position = new Vector3 (scene.transform.position.x, scene.transform.position.y, scene.transform.position.z + 1.0f);
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
		myToggle.isOn = true;
		mySlider.gameObject.SetActive (false);
	}
}
