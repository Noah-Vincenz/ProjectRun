using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameEndNext : MonoBehaviour {

    public bool clicked = false;
	// Use this for initialization
	void Start () {
        if (ScoreKeeper.recentGame == "FoodGame")
        {
			switch (SceneManagerController.Instance.getProcedure()) { // switch dependant on selected game 

			case "Meckel":
				SceneManager.LoadScene ("ScanningRoom");
				// protocol not implemented — only DMSA path is supported
				break;


			default:
				SceneManager.LoadScene ("WaitingRoom");
				break;
			}
		
        }
        else
        if (ScoreKeeper.recentGame == "InjectionGame")
        {
			switch (SceneManagerController.Instance.getProcedure()) { // switch dependant on selected game 

			case "DMSA":
				SceneManager.LoadScene ("3hrClockScene");
				break;

			case "Meckel":
				SceneManager.LoadScene ("FoodGameIntroduction");
				// protocol not implemented — only DMSA path is supported
				break;

			case "RENOGRAMin":
				SceneManager.LoadScene ("ScanningRoom");
				// protocol not implemented — only DMSA path is supported
				break;

			case "RENOGRAM":
				SceneManager.LoadScene ("ScanningRoom");
				// protocol not implemented — only DMSA path is supported
				break;

			default:
				SceneManager.LoadScene ("WaitingRoom");
				break;
			}
		}
        	 
    }
}

   
