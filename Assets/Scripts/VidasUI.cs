using UnityEngine.UI;
using UnityEngine;

public class VidasUI : MonoBehaviour {

	public Text VidasText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		VidasText.text = Player_Stats.Lives.ToString()+ "Hits";
	}
}
