using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flame : MonoBehaviour {

	int count = 0;

	public GameObject flame1;
	public GameObject flame2;
	public GameObject flame3;

	// Use this for initialization
	void Update () {
		if (app.ludumdare39.gamestate == GameState.alive) {
			if (!IsInvoking ("Interval")) {
				InvokeRepeating ("Interval", 0.1f, 0.1f);
			}
		}
	}

	void Interval()
	{
		if (app.ludumdare39.gamestate == GameState.alive) {
			switch (count) {
			case 0:
				flame1.SetActive (false);
				flame2.SetActive (true);
				count = 1;
				break;
			case 1:
				flame2.SetActive (false);
				flame3.SetActive (true);
				count = 2;
				break;
			case 2:
				flame3.SetActive (false);
				flame1.SetActive (true);
				count = 0;
				break;
			default:
				break;
			}
		}
	}
}