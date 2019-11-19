using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class wavespawner : MonoBehaviour {

	public Transform enemyprefab;
	public float timebetweenwaves= 5f;
	private float countdown= 2f;
	public int wavenumber=0;
	public Text wavecountdown;
	public Transform spawnpoint;
	void Update()
	{
	
		if (countdown <= 0) {

			StartCoroutine (Spawnwave());
			countdown = timebetweenwaves;
		}

		countdown -= Time.deltaTime;
		countdown = Mathf.Clamp (countdown, 0f, Mathf.Infinity);

		wavecountdown.text = string.Format ("{0:00.00}", countdown);
	}

	IEnumerator Spawnwave(){
		for (int i = 0; i < wavenumber; i++) {

			spawnenemy ();
			yield return new WaitForSeconds (0.5f);
		}
		wavenumber++;
		Player_Stats.round++;
	}
	void spawnenemy()
	{

		Instantiate (enemyprefab, spawnpoint.position, spawnpoint.rotation);
	}









	}

