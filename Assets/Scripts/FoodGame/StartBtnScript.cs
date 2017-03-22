using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class StartBtnScript : MonoBehaviour {
	private Rigidbody2D rb;

	public GameObject background;

	public Text time = null;
	float timeLeft = 3;
	private bool readyToTransition;
	private AudioSource source;


	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		rb = GetComponent<Rigidbody2D> ();
		readyToTransition = false;
		var material1 = background.GetComponent<Renderer>().material;
		var color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);

	}
	
	// Update is called once per frame
	void Update () {
		var material = background.GetComponent<Renderer>().material;
		var color = material.color;
		if (readyToTransition) {

			if (!source.isPlaying&&timeLeft>2)
				source.Play ();
			
			if (timeLeft <= 1&&timeLeft>0) {
				timeLeft -= Time.deltaTime;
				time.text = "GO!";
			}

			else if(timeLeft<=0){
				background.SetActive (enabled);
				material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));
				Invoke ("loadScene", 1.5f);
			}
			else
			{
				timeLeft -= Time.deltaTime;
				changeText();
			}
		}
	}


	void OnMouseDown() {
		Debug.Log ("Clicks on startBtn");
		readyToTransition = true;
	}

	void changeText()
	{
		time.text = "" + Mathf.Round(timeLeft);
	}

	void loadScene()
	{
		SceneManager.LoadScene("FoodGame");
	}
}
