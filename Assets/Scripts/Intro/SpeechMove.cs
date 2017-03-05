using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeechMove : MonoBehaviour {

	public int StartDelay;
	Animator anim;
	// Use this for initialization

	void Start () {

		anim=GetComponent<Animator> ();
		StartCoroutine (DelayAnimation ());

	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator DelayAnimation(){
		Debug.Log ("delay animation reached and triggers");
		yield return new WaitForSeconds (StartDelay);

		anim.SetTrigger ("wait");
		anim.SetBool ("waited", true);
	}

	void OnMouseDown(){
		NextScene ();

	}

	public void NextScene(){
		SceneManager.LoadScene("WaitingRoom");

	}
}
