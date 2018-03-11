using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotating : MonoBehaviour {

	int random;

	void Awake()
	{
		while (random == 0) {
			random = Random.Range(-2, 2);
		}
	}

	void Update()
	{
		this.gameObject.transform.Rotate(new Vector3(0, 0, random));
	}
}
