using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	public Text roundtext;

	void OnEnable()
	{
	
		roundtext.text = Player_Stats.round.ToString();
	}
	public void Retry()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void Menu()
	{
		Debug.Log ("AL menu");
	}
}
