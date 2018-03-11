using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {

	public Material mat;
	public Rigidbody2D rb2d;

	void Update () {
		if (app.ludumdare39.ship.boost.enable) {
			mat.mainTextureOffset = new Vector2 (0, mat.mainTextureOffset.y + 0.01f);
		} else {
			mat.mainTextureOffset = new Vector2 (0, mat.mainTextureOffset.y + 0.001f);
		}
	}
}
