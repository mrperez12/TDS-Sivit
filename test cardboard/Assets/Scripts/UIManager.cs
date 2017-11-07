using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {
	
	//El canvas del menu de pausa
    public GameObject pausePanel;
	//La camara del jugador
	public GameObject camVR;
	//Tag para saber si ya se obtuvo la posicion para el canvas
	public bool counter;
	//Tag para saber si el juego esta pausado
    public bool isPaused;

	// Use this for initialization
	void Start () {
		
        isPaused = false;
		counter = false;
	}
	
	// Update is called once per frame
	void Update () {
        /*if (isPaused)
        {
            PauseGame(true);
            Debug.Log(Time.deltaTime);
        }
        else
        {
            PauseGame(false);
        }*/

        if (Input.GetButtonDown("Submit"))
        {
            switchPause();
        
        }
    }

	//funcion que obtiene la posicion de la camara y rotacion, se la asigna al canvas y lo activa o desactiva
    void PauseGame(bool state)
    {
        if (state)
        {
			if (counter == false) {
				pausePanel.transform.position = camVR.transform.position + camVR.transform.forward * 1.5f;
				pausePanel.transform.rotation = Quaternion.LookRotation (pausePanel.transform.position - camVR.transform.position);
				counter = true;
			}
            pausePanel.SetActive(true);
            Time.timeScale = 0.1f;
        }
        else
        {
			counter = false;
            Time.timeScale = 1.0f;
            pausePanel.SetActive(false);
        }
    }

	//funcion que cambia el valor de isPaused al salir del menu de pausa
    public void switchPause()
    {
        if (isPaused)
        {
            isPaused = false;
			PauseGame(false);
        }
        else
        {
            isPaused = true;
			PauseGame (true);
        }
    }

}
