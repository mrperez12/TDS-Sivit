using UnityEngine;
using System.Collections;

public class shake : MonoBehaviour {

	public float speed = 1f; //velocidad de la oscilacion, puede ajustarse en el editor
	public float amount = 1f; //intensidad de la oscilacion, puede ajustarse en el editor
	public static float posX; // acceleracion en X
	public static float posZ; // acceleracion en Z
	public AnimationCurve curveS; // la curva que esta definida en el editor
	public AnimationCurve curveP; // la curva que esta definida en el editor
	//private float last;	//variable temporal para calcular la aceleracion
	private float speedxS; //velocidad en X
	private float speedzS; //velocidad en Z
	private float speedxP; //velocidad en X
	private float speedzP; //velocidad en Z
	public float randomangle; 
	public float perpangle; // angulo que define la direccion "perpendicular al epicentro"
	public float maxaccelX = 0; //maxima aceleracion X
	public float maxaccelZ = 0; //maxima aceleracion X
	public float durationS;
	public float durationP;
	public float time = 0;
	public float gradorichter;
	public float epidist;
	public float epidelay;
	public float randomfactor;
	public AudioClip sound;
	public bool finished;

	// Inicializacion
	void Start () {
		//last = 0;
		randomangle = Random.Range (0f, 2f) * Mathf.PI; //se define al azar por ahora
		perpangle = randomangle + 90f;
		//duration = Random.Range (10f, 60f);
		amount = Mathf.Pow (2,PlayerPrefs.GetFloat("grado")-6.5f);//Random.Range (1f, 2.1f);
		//amount = Mathf.Pow (2,gradorichter-6.5f);
		Debug.Log ("ESTE GRADO M3N " + amount);
		//epidelay = 24;//Random.Range (0f, 30f);
		epidist = epidelay * 2000;// 4500 * x - 2500 * x, distancia al epicentro en metros
		GetComponent<AudioSource>().clip = sound;
		GetComponent<AudioSource>().Play ();
	}
	
	// Llamada cada frame
	void Update () {
		time += Time.deltaTime;
		GetComponent<AudioSource> ().volume = (curveS.Evaluate (time / durationS) + curveS.Evaluate ((time-epidelay) / durationP))/2f;
		speedxS = Mathf.Sin (time * speed /*+ Random.Range (0f, 2f)*/ * Mathf.PI) * curveS.Evaluate ((time-epidelay)/durationS) * amount * Random.Range (randomfactor, 1f) * Mathf.Sin(perpangle);
		speedzS = Mathf.Sin (time * speed /*+ Random.Range (0f, 2f)*/ * Mathf.PI) * curveS.Evaluate ((time-epidelay)/durationS) * amount * Random.Range (randomfactor, 1f) * Mathf.Cos(perpangle) /* Random.Range (0.7f, 1f)*/;
		posX = speedxS+speedzS;//Mathf.Sin (time * speed * Mathf.PI) * curveS.Evaluate ((time-epidelay)/durationS) * amount;//GetComponent<Rigidbody>().velocity.x;//(GetComponent<Rigidbody>().velocity.x - speedx)/Time.deltaTime; //calculo de aceleraccion
		posZ = speedxP+speedzP;//Mathf.Sin (time * speed * Mathf.PI) * curveP.Evaluate (time / durationP) * amount;//GetComponent<Rigidbody>().velocity.z;//(GetComponent<Rigidbody>().velocity.z - speedz)/Time.deltaTime;
		speedxP = Mathf.Sin (time * speed /*+ Random.Range (0f, 2f)*/ * Mathf.PI) * curveP.Evaluate (time / durationP) * amount * Random.Range (randomfactor, 1f) * Mathf.Sin(randomangle) /* Random.Range (0.7f, 1f)*/;
		speedzP = Mathf.Sin (time * speed /*+ Random.Range (0f, 2f)*/ * Mathf.PI) * curveP.Evaluate (time / durationP) * amount * Random.Range (randomfactor, 1f) * Mathf.Cos(randomangle) /* Random.Range (0.7f, 1f)*/;
		if (Mathf.Abs (posX) > maxaccelX)
			maxaccelX = Mathf.Abs (posX); //registra maxima aceleracion
		if (Mathf.Abs (posZ) > maxaccelZ)
			maxaccelZ = Mathf.Abs (posZ);
		if (time > 1){ // luego de 1 segundo empieza el movimiento
			GetComponent<Rigidbody>().velocity = new Vector3( speedxP + speedxS, 0, speedzP + speedzS);
			//GetComponent<Rigidbody>().AddForce( 10000*speedx, 0, speedz);
		}
		gradorichter = 7f + Mathf.Log(amount,2);
		if(time > durationP + durationS - epidelay) finished = true;
	}
	void OnGUI()
	{
		if(PlayerPrefs.GetInt("debug") == 1){
		//GUI.Label(new Rect(10,500,100,20), "Delay: ");
		//GUI.Label(new Rect(60,500,100,20), epidelay.ToString());
		//GUI.Label(new Rect(10,520,100,20), "Max X velocity: ");
		//GUI.Label(new Rect(10,540,100,20), "Max Z velocity: ");
		//GUI.Label(new Rect(110,520,100,20), maxaccelX.ToString());
		//GUI.Label(new Rect(110,540,100,20), maxaccelZ.ToString());
		//GUI.Label(new Rect(10,560,100,20), "Duration: ");
		GUI.Label(new Rect(10,580,100,20), "Grado Richter: ");
		//GUI.Label(new Rect(70,560,100,20), duration.ToString());
		GUI.Label(new Rect(100,580,100,20), gradorichter.ToString());
		}
	}
}
