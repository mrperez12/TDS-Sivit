using UnityEngine;
using System.Collections;

public class SpriteManager : MonoBehaviour {
	public GameObject safe;
	public GameObject danger;
	public Health player;
	private UnityEngine.UI.Image ssprite;
	private UnityEngine.UI.Image dsprite;
	public Color strans;
	private Color dtrans;
	
	// Use this for initialization
	void Start () {
		ssprite = safe.transform.GetComponentInParent<UnityEngine.UI.Image> ();
		strans = ssprite.color;
		strans.a = 0f;
		dsprite = danger.transform.GetComponentInParent<UnityEngine.UI.Image> ();
		dtrans = dsprite.color;
		dtrans.a = 0f;
		safe.SetActive (false);
		danger.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (player.safe) {//GetComponentInParent<Health> ().safe) {
			safe.SetActive (true);
			if (strans.a < 1f){
				strans.a += 0.1f;
				ssprite.color = strans;
			}
		} else {
			if (strans.a > 0f){
				strans.a -= 0.1f;
				ssprite.color = strans;
			}
			if(strans.a <= 0f) safe.SetActive (false);
		}
		if (player.danger) {
			danger.SetActive (true);
			if (dtrans.a < 1f){
				dtrans.a += 0.1f;
				dsprite.color = dtrans;
			}
		} else {
			if (dtrans.a > 0f){
				dtrans.a -= 0.1f;
				dsprite.color = dtrans;
			}
			if(dtrans.a <= 0f) danger.SetActive (false);
		}
	}
}
