using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	public GameObject ui;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.P)) 
		{
			toggle ();
		}

	}
	public void toggle()
	{
		ui.SetActive (!ui.activeSelf);
		if (ui.activeSelf) {
			Time.timeScale = 0f;
		} else 
		{
			Time.timeScale = 1f;
		}
		}

	public void Retry ()
	{
		toggle ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
	public void Menu()
	{
		Debug.Log ("haz el menu flojo");
	}




}
