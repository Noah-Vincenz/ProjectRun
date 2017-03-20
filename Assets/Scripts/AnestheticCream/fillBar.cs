using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fillBar : MonoBehaviour {

    public static float timeDown = 0;
    public Image image = null;
    public Sprite[] sprites = null;
    public Image panda = null;
    public Image next = null;
    public Text text = null;

    void Start () {
        image.GetComponent<Image>();
        image.fillAmount = 0;
    }
	
	void Update () {
        image.fillAmount = image.fillAmount + (timeDown / 20000);
        if (image.fillAmount == 1)
        {
            panda.sprite = sprites[2];
            next.enabled = true;
            text.text = "Well done! Press next to move on.";
        } else
        if (image.fillAmount >= 0.5)
        {
            panda.sprite = sprites[1];
        }
    }
}
