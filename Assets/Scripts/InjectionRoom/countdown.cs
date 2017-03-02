using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class countdown : MonoBehaviour {

    public Text time = null;
    float timeLeft = 5;

    void Update()
    {
        if (Mathf.Round(timeLeft) == 1)
        {
            SceneManager.LoadScene("InjectionGame");
        }

        timeLeft -= Time.deltaTime;
        changeText();

    }

    void changeText()
    {
        time.text = "" + Mathf.Round(timeLeft);
    }
}
