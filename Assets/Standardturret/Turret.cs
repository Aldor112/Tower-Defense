using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	private Transform target;
	private enemy targetenemy;
	[Header("Atributos")]
	public float range=15f;
	public float firerate=1f;
	public float firecountdown = 0f;

	[Header("Weas Pal Laser")]
	public bool useLaser = false;
	public LineRenderer linerenderer;
	public ParticleSystem impacteffect;
	public Light impact;
	public int DamageOverTime=30;
	public float Slowpct=.5f;
	[Header("Demas ajustes no tocar")]
	public string enemytag = "enemy";
	public Transform ejederotacion;
	public float velocidad=10f;
	public GameObject balaprefab;
	public Transform firepoint;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemytag);
		float shortdistance= Mathf.Infinity;
		GameObject nearestenemy = null;

		foreach (GameObject enemy in enemies) 
		{
		
			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
			if (distanceToEnemy<shortdistance) {
				shortdistance = distanceToEnemy;
				nearestenemy = enemy;
			}
		}
	
		if (nearestenemy !=null && shortdistance <= range) {
			target = nearestenemy.transform;
			targetenemy = nearestenemy.GetComponent<enemy>();
		}else {
			target = null;
		}

	}

	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			if (useLaser==true) {
				if (linerenderer.enabled) {
					linerenderer.enabled = false;
					impacteffect.Stop ();
					impact.enabled = false;
				}

			}
			return;
		}
		LockOnTarget ();
		if (useLaser == true) {
			Laser ();

		} else {
			
			if (firecountdown<=0f) {
				shoot ();
				firecountdown = 1f / firerate;
			}


		}

		firecountdown -= Time.deltaTime;

	}

	void LockOnTarget()
	{
		//para fijar objetivos
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 Rotation = Quaternion.Lerp(ejederotacion.rotation,lookRotation, Time.deltaTime* velocidad).eulerAngles;
		ejederotacion.rotation = Quaternion.Euler(0f, Rotation.y,0f);
	}

	void Laser()
	{

		targetenemy.takedamage (DamageOverTime * Time.deltaTime);
		targetenemy.Slow (Slowpct);
		if (!linerenderer.enabled) 
		{
			linerenderer.enabled = true;
			impacteffect.Play ();
			impact.enabled = true;
		}
		linerenderer.SetPosition (0, firepoint.position);
		linerenderer.SetPosition (1, target.position);
		Vector3 dir = firepoint.position - target.position;
		impacteffect.transform.position = target.position + dir.normalized ;
		impacteffect.transform.rotation = Quaternion.LookRotation (dir);

	}




	void shoot(){
		GameObject balaGO= (GameObject) Instantiate (balaprefab, firepoint.position, firepoint.rotation);
		Bala bala = balaGO.GetComponent<Bala>();
		if (bala !=null) {
			bala.Seek (target);
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}
