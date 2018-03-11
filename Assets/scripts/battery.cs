using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battery {

	private int value;

	public int Value {
		get {
			return value;
		}
		set {
			this.value = value;
			if (this.value > 100) {
				this.value = 100;
			}
			app.ludumdare39.ui.battery_percent.text = this.value.ToString ();
			if (value <= 0) {
				app.ludumdare39.gamestate = GameState.dead;
			}
		}
	}

	public battery(int value)
	{
		this.value = value;
	}
}