using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClickMenu : MonoBehaviour {

	public void LoadScene (int level)
	{
		SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
	}

}
