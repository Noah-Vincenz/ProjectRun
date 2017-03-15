using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanTrigger : MonoBehaviour {

	public ScanPanda scanScript;

	void OnMouseDown(){

		scanScript.canWalkOn ();

	}

}
