using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score {
	
	private int value;

	public int Value {
		get {
			return value;
		}
		set {
			this.value = value;
			app.ludumdare39.ui.km_count.text = (this.value / 1000).ToString ();
		}
	}

	public score(int value)
	{
		this.value = value;
	}
}