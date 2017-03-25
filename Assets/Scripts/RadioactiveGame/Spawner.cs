using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class that spawns objects that will fall from the sky and for the panda to collect / dodge
public class Spawner : MonoBehaviour {

	public float delayRays = 1f;
	public float delayBamboos = 6.8f;
	public float delayCubes = 2.3f;
	public GameObject RadioActive;
	public GameObject Bamboo;
	public GameObject Cube;

	void Start() {
		InvokeRepeating ("Spawn1", delayRays, delayRays);
		InvokeRepeating ("Spawn2", delayBamboos, delayBamboos);
		InvokeRepeating ("Spawn3", delayCubes, delayCubes);
	}

	void Spawn1() {
		Instantiate (RadioActive, new Vector3 (Random.Range (-6, 6), 5, 0), Quaternion.identity);
	}
	void Spawn2() {
		Instantiate (Bamboo, new Vector3 (Random.Range (-6, 6), 5, 0), Quaternion.identity);
	}
	void Spawn3() {
		Instantiate (Cube, new Vector3 (Random.Range (-4, 4), 5, 0), Quaternion.identity);
	}
}