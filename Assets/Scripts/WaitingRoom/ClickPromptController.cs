using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPromptController : MonoBehaviour {
	public float sec;
	public GameObject panda;
	// Use this for initialization
	void Start () {
		Debug.Log(" lateCall ");
		StartCoroutine("LateCall");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator LateCall()
	{
		Debug.Log("before wait ");
		yield return new WaitForSeconds(sec);
		Debug.Log("after wait ");
		//Do Function here...
	}
}
