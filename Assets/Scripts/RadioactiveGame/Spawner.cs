using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

	public float delayRays = 1f;
	public float delayBamboos = 7f;
	public float delayCubes = 4f;
	public GameObject RadioActive;
	public GameObject Bamboo;
	public GameObject Cube;

	void Start() {
		InvokeRepeating ("Spawn1", delayRays, delayRays);
		InvokeRepeating ("Spawn2", delayBamboos, delayBamboos);
		InvokeRepeating ("Spawn3", delayCubes, delayCubes);
	}
		
	void Spawn1() {
		Instantiate (RadioActive, new Vector3 (Random.Range (-9, 9), 5, 0), Quaternion.identity);
	}
	void Spawn2() {
		Instantiate (Bamboo, new Vector3 (Random.Range (-9, 9), 5, 0), Quaternion.identity);
	}
	void Spawn3() {
		Instantiate (Cube, new Vector3 (Random.Range (-4, 4), 5, 0), Quaternion.identity);
	}
}
