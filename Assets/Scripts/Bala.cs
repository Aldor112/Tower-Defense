
using UnityEngine;

public class Bala : MonoBehaviour {
	private Transform target;
	public float speed=70f;
	public GameObject impacteffect;
	public float explosionradius= 0f;
	public int damage=50;


	public void Seek(Transform _target)
	{
		target = _target;

	}

	// Update is called once per frame
	void Update () {

		if (target==null) {
			Destroy (gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distancethisframe = speed * Time.deltaTime;
		if (dir.magnitude <=distancethisframe) {
			HitTarget();
			return;
		}

		transform.Translate (dir.normalized * distancethisframe, Space.World);
		transform.LookAt (target);
	}

	void HitTarget(){
		GameObject effectins=(GameObject) Instantiate (impacteffect, transform.position, transform.rotation);
		Destroy (effectins, 2f);
		if (explosionradius > 0f) {
			explode ();

		} else {
		
			Damage (target);
		}
			

		Destroy (gameObject);

	}

	void explode()
	{
		Collider[] colliders = Physics.OverlapSphere (transform.position, explosionradius);
		foreach (Collider collider in colliders) {
			if (collider.tag=="enemy") {
				Damage (collider.transform);
			}
			
		}


	}
	void Damage(Transform enemy){
		enemy e=enemy.GetComponent<enemy> ();
		if (e != null) {
			e.takedamage (damage);
		}

	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, explosionradius);
	}


}
