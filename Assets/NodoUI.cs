using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoUI : MonoBehaviour {
	private Nodo target;
	public GameObject ui;

	public void SetTarget(Nodo _target)
	{
		target = _target;
		transform.position =target.transform.position ;
		ui.SetActive (true);
	}
	public void Hide()
	{
		ui.SetActive (false);	
	}

}
