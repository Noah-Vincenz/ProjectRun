using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class creamTransparency : MonoBehaviour {

    public static float leftArmVal = 0;
    public static float leftLegVal = 0;
    public static float rightArmVal = 0;
    public static float rightLegVal = 0;
    public Image[] creams;
    // Use this for initialization
    void Start()
    {
        Color color = creams[0].color;
        color.a = 0;
        creams[0].color = color;
        creams[1].color = color;
        creams[2].color = color;
        creams[3].color = color;
       
    }
	
	// Update is called once per frame
	void Update () {

        if (this.name == "LeftArmCream")
        {
            Color color = creams[0].color;
            color.a = (leftArmVal/150);
            creams[0].color = color;
        } else
        if (this.name == "LeftLegCream")
        {
            Color color = creams[1].color;
            color.a = (leftLegVal / 150);
            creams[1].color = color;
        } else
        if (this.name == "RightArmCream")
        {
            Color color = creams[2].color;
            color.a = (rightArmVal / 150);
            creams[2].color = color;
        } else
        if (this.name == "RightLegCream")
        {
            Color color = creams[3].color;
            color.a = (rightLegVal / 150);
            creams[3].color = color;

        }

    }
}
