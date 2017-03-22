using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startRadiationGame : MonoBehaviour {

	public Button myButton;
	public Text time = null;
	float timeLeft = 3;
	bool clicked=false;
	private AudioSource source;

	void Start()
	{
		source = GetComponent<AudioSource> ();
		Button btn = myButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void Update(){
		if (clicked) {
			if (!source.isPlaying&&timeLeft>2)
				source.Play ();

			if (timeLeft <= 1&&timeLeft>0) {
				timeLeft -= Time.deltaTime;
				time.text = "GO!";
			}

			else if(timeLeft<=0){
				SceneManager.LoadScene("CatchRadiationGame");
			}
			else
			{
				timeLeft -= Time.deltaTime;
				changeText();
			}
		}
	}

	void TaskOnClick()
	{
		clicked = true;
	}

	void changeText()
	{
		time.text = "" + Mathf.Round(timeLeft);
	}

}
