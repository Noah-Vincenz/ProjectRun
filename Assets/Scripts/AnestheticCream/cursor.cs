using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour {
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePosNeed = new Vector3(mousePos.x, mousePos.y, mousePos.z);
        mousePosNeed.z = 5f;
        transform.position = mousePosNeed;
    }
}
