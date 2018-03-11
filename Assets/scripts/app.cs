using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class app : MonoBehaviour {

	public static app ludumdare39;
	public GameState gamestate;

	public ship ship;
	public ui ui;

	private void Awake()
	{
		ludumdare39 = this;
		gamestate = GameState.start;
	}


	public void StartGame()
	{
		gamestate = GameState.alive;
		GameObject.Find ("background").GetComponent<background> ().rb2d.gravityScale = 0.1f;
		//play sound effect
		//play dialog
		//start the counter
		//start the music
		//spawn the ship
	}

	private void Update()
	{
		switch (gamestate) {
		case GameState.start:
			if (Input.GetKeyDown (KeyCode.Space)) {
				StartGame ();
			}
			break;
		case GameState.dead:
			if (Input.GetKeyDown (KeyCode.Escape)) {
				if (PlayerPrefs.GetInt ("score", 0) < ship.score.Value) {
					PlayerPrefs.SetInt ("score", ship.score.Value);
				}
				SceneManager.LoadScene (1);
			}
			break;
		default:
			break;
		}
	}
}
public enum GameState {
	start,
	alive,
	dead
}