
using UnityEngine;

public class Cameracontroller : MonoBehaviour {
	private bool domovement=true;
	public float Panspeed = 30f;
	public float Panborderthicc=10f;
	public float scrollspeed=5f;
	public float minY=10;
	public float maxY=80;

	// Update is called once per frame
	void Update () {
		if (GameManager.fin) {
			this.enabled = false;
			return;
		}
		//if (Input.GetKeyDown (KeyCode.Escape))
		//	domovement = !domovement;
		if (!domovement)
			return;
		if (Input.GetKey("w")|| Input.mousePosition.y >= Screen.height - Panborderthicc ) {

			transform.Translate (Vector3.forward*Panspeed*Time.deltaTime, Space.World);
		}

		if (Input.GetKey("s")|| Input.mousePosition.y <= Panborderthicc ) {

			transform.Translate (Vector3.back * Panspeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey("d")|| Input.mousePosition.x >= Screen.width - Panborderthicc ) {

			transform.Translate (Vector3.right *Panspeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey("a")|| Input.mousePosition.x <= Panborderthicc ) {

			transform.Translate (Vector3.left *Panspeed * Time.deltaTime, Space.World);
		}

		float scroll= Input.GetAxis("Mouse ScrollWheel");
		Vector3 pos = transform.position;
		pos.y -= scroll * 1000 * scrollspeed * Time.deltaTime;
		pos.y = Mathf.Clamp (pos.y, minY, maxY);
		transform.position = pos;


	}
}
