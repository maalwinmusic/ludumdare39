using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitText : MonoBehaviour {

	public GameObject text; 

	bool fuckthisshitfuck = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (app.ludumdare39.gamestate == GameState.dead && !fuckthisshitfuck) {
			text.SetActive (true);
			this.GetComponent<AudioSource> ().Play ();
			fuckthisshitfuck = true;
		}
	}
}