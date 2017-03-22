using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class countdown : MonoBehaviour {

    public Text time = null;
    float timeLeft = 3;

    void Update()
    {
        if (Mathf.Round(timeLeft) == 1)
        {
            Invoke("loadScene", 1.5f);
        }
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

    void loadScene()
    {
        SceneManager.LoadScene("InjectionGame");
    }
}
