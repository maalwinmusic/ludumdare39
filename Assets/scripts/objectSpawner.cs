using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner : MonoBehaviour {

	public List<GameObject> rocks;
	public List<GameObject> powerups;

	public GameObject batteryobject;

	public bool shouldI = false;

	int random;

	private void Update()
	{
		if (app.ludumdare39.gamestate == GameState.alive && shouldI) { //check if you are also in space
			random = Random.Range (1, 50);
			if (random == 1) {
				int randomRock = Random.Range (0, rocks.Count);
				int randomSpawn = Random.Range (0, this.gameObject.transform.childCount);
				Instantiate (rocks [randomRock], this.gameObject.transform.GetChild (randomSpawn).position, Quaternion.identity);
			}

			random = Random.Range (1, 201);
			if (random == 1) {
				int randomPowerUp = Random.Range (0, powerups.Count);
				int randomSpawn = Random.Range (0, this.gameObject.transform.childCount);
				Instantiate (powerups [randomPowerUp], this.gameObject.transform.GetChild (randomSpawn).position, Quaternion.identity);
			}

			random = Random.Range (1, 169);
			if (random == 1) {
				int randomSpawn = Random.Range (0, this.gameObject.transform.childCount);
				Instantiate (batteryobject, this.gameObject.transform.GetChild (randomSpawn).position, Quaternion.identity);
			}
		}
	}
}