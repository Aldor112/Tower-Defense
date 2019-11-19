using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static bool fin;
	public GameObject gameoverUI;
	// Update is called once per frame
	void Start(){

		fin = false;
	}
	void Update () {
		if (fin) {
			return;
		}
		if (Player_Stats.Lives <=0) {

			endgame ();
		}


	}

	void endgame(){
		fin = true;
		Debug.Log ("Game Over");
		gameoverUI.SetActive (true);
	}


}
