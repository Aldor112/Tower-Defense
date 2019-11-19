
using UnityEngine;

public class shop : MonoBehaviour {
	public TurretBlueprints standardturret;
	public TurretBlueprints misilelauncher;
	public TurretBlueprints LaserTurret;

	BuildManager buildmanager;

	void Start(){
	
		buildmanager = BuildManager.instance;
	}


	public void Seleccionrtorretaestandar()
	{
		buildmanager.SelectTurretTobuild(standardturret);
		Debug.Log ("Seleccionada estandar");

	}

	public void SeleccionartorretaMisiles()
	{
		buildmanager.SelectTurretTobuild (misilelauncher);
		Debug.Log ("Seleccionada misiles");

	}

	public void SeleccionarTorretaLaser()
	{
		buildmanager.SelectTurretTobuild (LaserTurret);
		Debug.Log ("Seleccionada Laser");

	}



}
