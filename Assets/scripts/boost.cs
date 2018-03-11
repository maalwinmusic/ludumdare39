using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boost : MonoBehaviour {

	public bool enable;
	public int cooldown;

	public GameObject flame_normal;
	public GameObject flame_boost;

	public void Activate()
	{
		enable = !enable;
		flame_normal.SetActive (!flame_normal.activeSelf);
		flame_boost.SetActive (!flame_boost.activeSelf);
		if (enable) {
			Invoke ("Activate", cooldown);
		}
	}
}
