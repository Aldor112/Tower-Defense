
using UnityEngine;
using UnityEngine.EventSystems;

public class Nodo : MonoBehaviour {
	public Color Hovercolor;
	public Color SinDinero;
	private Renderer rend;
	private Color startcolor;
	[Header("Opcional")]
	public GameObject turret;
	public Vector3 PositionOffset;
	BuildManager buildmanager;

	void Start()
	{
		rend = GetComponent<Renderer> ();
		startcolor = rend.material.color;
		buildmanager = BuildManager.instance;

	}

	void OnMouseDown()
	{

		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}

		if (turret !=null) {
			buildmanager.Selectnodo (this);
			return;
		}
		if (!buildmanager.CanBuild) {
			return;
		}

		buildmanager.BuiltTurretOn (this);

	}


	void OnMouseEnter()
	{

		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}

		if (buildmanager.HasMoney) {
			rend.material.color = Hovercolor;

		} else {
			rend.material.color = SinDinero;
		}

		if (buildmanager.CanBuild) {
			return;
		}


	}

	void OnMouseExit()
	{

		rend.material.color=startcolor;
	}

}
