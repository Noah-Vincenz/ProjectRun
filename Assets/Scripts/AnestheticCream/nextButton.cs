using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        creamTransparency.leftArmVal = 0;
        creamTransparency.leftLegVal = 0;
        creamTransparency.rightArmVal = 0;
        creamTransparency.rightLegVal = 0;
        SceneManager.LoadScene("45minClockScene");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
