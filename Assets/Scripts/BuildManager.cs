
using UnityEngine;

public class BuildManager : MonoBehaviour {
	private TurretBlueprints TurretTobuild;
	private Nodo Nodoselected;
	public static BuildManager instance;

	void Awake ()
	{
		if (instance !=null) {
			Debug.LogError ("mas de un buildingmanager ");
			return;
		}
		instance = this;

	}


	public GameObject standardTurretPrefab;
	public GameObject MisileTurret;
	public GameObject Buildefect;
	public NodoUI nodoui;
	public bool CanBuild{get{return TurretTobuild !=null;}}
	public bool HasMoney{get{return Player_Stats.Money >= TurretTobuild.cost; }}

	public void BuiltTurretOn(Nodo nodo){
		if (Player_Stats.Money < TurretTobuild.cost) {
			Debug.Log ("Dinero insuficiente");

			return;
		}
		Player_Stats.Money -= TurretTobuild.cost;
		GameObject turret = (GameObject)Instantiate(TurretTobuild.prefab, nodo.transform.position + nodo.PositionOffset, Quaternion.identity);
		nodo.turret = turret;
		GameObject effect =  (GameObject)Instantiate (Buildefect, nodo.transform.position + nodo.PositionOffset, Quaternion.identity);
		Destroy (effect, 5f);
		Debug.Log ("Torreta Comprada, dinero que queda: "+Player_Stats.Money);
	}
	public void Selectnodo(Nodo nodo)
	{
		if (Nodoselected==nodo) {
			DeselectNodo ();
			return;
		}
		Nodoselected = nodo;
		TurretTobuild = null;
		nodoui.SetTarget (nodo);
	}
	public void DeselectNodo()
	{
		Nodoselected = null;
		nodoui.Hide ();
			
	}
	public void SelectTurretTobuild(TurretBlueprints turret)
	{
	
		TurretTobuild = turret;
		DeselectNodo ();
	}







}
