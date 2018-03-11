using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour {

	public Text highscore;

	private void Awake()
	{
		highscore.text = (PlayerPrefs.GetInt ("score", 0) / 1000).ToString () + " KM";
	}

	public void Play()
	{
		SceneManager.LoadScene (2);
	}

	public void Options()
	{
		//change the ui, might not implement this, if I don't have time.. it would only be some audio stuff etc anyways..
	}

	public void Quit()
	{
		Application.Quit ();
	}
}