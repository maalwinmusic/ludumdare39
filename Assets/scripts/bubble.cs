using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble : MonoBehaviour {

	public bool enable;
	public int cooldown;

	public void Activate()
	{
		enable = !enable;
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = !this.gameObject.GetComponent<SpriteRenderer> ().enabled;
		if (enable) {
			Invoke ("Activate", cooldown);
		}
	}
}