using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartButton : MonoBehaviour {

	public GameObject panda;
	public float delayRays = 1f;
	public float delayBamboos = 7f;
	public float delayCubes = 2f;
	public GameObject RadioActive;
	public GameObject Bamboo;
	public GameObject Cube;
	public GameObject instructions;
	public Button btn;
	/*
	void Start () {
		panda = GameObject.Find("PandaRadioActiveGame");
		//UnityEnginer.UI.Button btn = GameObject.Find("Start button");
		//Button btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		panda.SetActive (false);
		//gameObject.SetActive (false);
	}

	void TaskOnClick(){
		startGame ();
	}

	void startGame() {
		instructions.SetActive (false);
		panda.SetActive (true);
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
	*/
}
