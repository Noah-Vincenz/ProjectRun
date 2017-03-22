using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class countdown : MonoBehaviour {

    public Text time = null;
	public GameObject timeGaOb;
    float timeLeft = 3;
	public AudioSource source;

	void Start () {
		timeGaOb.SetActive (true);
		source.Play ();


	}

    void Update()
    {
		if (timeLeft <= 1&&timeLeft>0) {
			timeLeft -= Time.deltaTime;
			time.text = "GO!";
		}

		else if(timeLeft<=0)
			SceneManager.LoadScene("InjectionGame");
		
        else
        {
            timeLeft -= Time.deltaTime;
            changeText();
        }

    }

    void changeText()
    {
        time.text = "" + Mathf.Round(timeLeft);
    }
		
}
