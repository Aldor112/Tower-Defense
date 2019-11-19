using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	public float StartSpeed=10f;
	public float speed = 10f;
	private Transform target;
	private int wavepointIndex = 0;
	public float health= 100f;
	public int value=50;
	public GameObject deatheffect;


	// Use this for initialization
	void Start () {
		speed = StartSpeed;
		target = Waypoint.points [0];
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);
		if (Vector3.Distance(transform.position, target.position)<=0.4f)
		{

			GetNextWaypoint ();
		}

		speed = StartSpeed;
			

	}

	public void takedamage(float amount)
	{
		health -= amount;
		if (health <=0) {

			Die ();
		}



	}

	public void Slow(float pct)
	{
		speed = StartSpeed * (1f - pct);

	}
	void Die(){
		Player_Stats.Money += value;
		GameObject effect=(GameObject)Instantiate (deatheffect, transform.position, Quaternion.identity);
		Destroy (effect, 5f);
		Destroy (gameObject);
	}

	void GetNextWaypoint(){
		if (wavepointIndex >= Waypoint.points.Length - 1) {
			endpath ();
			return;
		}
		wavepointIndex++;
		target = Waypoint.points [wavepointIndex];

	}

	void endpath()
	{
		Player_Stats.Lives--;
		Destroy (gameObject);
	}



}





	