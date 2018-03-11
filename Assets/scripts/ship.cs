using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour {

	public bubble bubble;
	public boost boost;

	public battery battery;
	public score score;

	private Vector2 position;

	public GameObject stars;

	public List<AudioClip> clips;

	bool batteryFlip = false;

	private void Awake()
	{
		battery = new battery (100);
		score = new score (0);
		InvokeRepeating ("CustomeUpdate", 0.5f, 0.5f);
	}

	private void CustomeUpdate()
	{
		switch (app.ludumdare39.gamestate) {
		case GameState.alive:
			battery.Value -= 1;
			break;
		case GameState.dead:
			Debug.Log (battery.Value);
			Debug.Log (score.Value);
			Destroy (this.gameObject);
			break;
		default:
			break;
		}
	}

	//when you stop clicking, start going towards straight
	//when you click, don't go further than you should
	private void Update()
	{
		if (!batteryFlip) {
			if (battery.Value < 25) {
				batteryFlip = true;
				this.GetComponent<AudioSource> ().clip = clips [2];
				this.GetComponent<AudioSource> ().Play ();
			}
		} else {
			if (battery.Value > 25) {
				batteryFlip = false;
			}
		}
		switch (app.ludumdare39.gamestate) {
		case GameState.alive:
			position = this.gameObject.transform.position;
			if (Input.GetKey (KeyCode.A)) {
				position.x -= 0.1f;

				if (this.gameObject.transform.rotation.eulerAngles.z <= 25 || this.gameObject.transform.rotation.eulerAngles.z > 344) {
					this.gameObject.transform.Rotate(new Vector3(0, 0, 1));
					stars.gameObject.transform.Rotate(new Vector3(0, 0, 1));
				}

			}
			if (Input.GetKey (KeyCode.D)) {
				position.x += 0.1f;

				if (this.gameObject.transform.rotation.eulerAngles.z > 345 || this.gameObject.transform.rotation.eulerAngles.z < 26) {
					this.gameObject.transform.Rotate(new Vector3(0, 0, -1));
					stars.gameObject.transform.Rotate(new Vector3(0, 0, -1));
				}
			}
			if (position.x < 2.3f && position.x > -2.3f) {
				this.gameObject.transform.position = position;
			}

			if (boost.enable) {
				score.Value += 4000;
			} else {
				score.Value += 2000;
			}
			break;
		default:
			break;
		}
		if (this.gameObject.transform.rotation.eulerAngles.z > 360) {
			this.gameObject.transform.rotation = new Quaternion (0, 0, 0, 0);
		}
		if (this.gameObject.transform.rotation.eulerAngles.z < 0) {
			this.gameObject.transform.rotation = new Quaternion (0, 0, 0, 0);
		}
	}

	//todo
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("i hit something");
		switch (other.gameObject.tag) {
		case "battery":
			battery.Value += 5;

			break;
		case "rock":
			if (!bubble.enable) {
				battery.Value -= 10;
				if (!this.GetComponent<AudioSource> ().isPlaying) {
					this.GetComponent<AudioSource> ().clip = clips [1];
					this.GetComponent<AudioSource> ().Play ();
				}
			}
			break;
		case "bubble":
			if (!bubble.enable) {
				bubble.Activate ();
			}
			if (!this.GetComponent<AudioSource> ().isPlaying) {
				this.GetComponent<AudioSource> ().clip = clips [0];
				this.GetComponent<AudioSource> ().Play ();
			}
			break;
		case "boost":
			if (!boost.enable) {
				boost.Activate ();
			}
			if (!this.GetComponent<AudioSource> ().isPlaying) {
				this.GetComponent<AudioSource> ().clip = clips [0];
				this.GetComponent<AudioSource> ().Play ();
			}
			break;
		case "sky":
			GameObject.Find ("objectSpawner").GetComponent<objectSpawner> ().shouldI = true;
			break;
		default:
			break;
		}
		if (other.gameObject.tag == "sky") {
			return;
		}
		Destroy (other.gameObject);
	}
}