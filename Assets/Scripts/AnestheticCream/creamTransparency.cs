using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class creamTransparency : MonoBehaviour {

    public static float leftArmVal = 0;
    public static float leftLegVal = 0;
    public static float rightArmVal = 0;
    public static float rightLegVal = 0;
    public GameObject[] creams;
    // Use this for initialization
    void Start()
    {
        Material mat = creams[0].GetComponent<Renderer>().material;
        Color color = mat.color;
        creams[0].GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 0); //Initiating cream game object to be fully transparent
        creams[1].GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 0);
        creams[2].GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 0);
        creams[3].GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 0);

    }
	
	// Update is called once per frame
	void Update () {

        if (this.name == "LeftArmCream") //Based on which cream object this script is being attached to...
        {
            Material mat = creams[0].GetComponent<Renderer>().material;
            Color color = mat.color;
            if ((leftArmVal / 150) <= 1) //If the fill bar isn't full (the value isn't great enough to fill the bar)
            {
                creams[0].GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, (leftArmVal / 150)); //Change transparency of the image
            }
        }
        else
        if (this.name == "LeftLegCream")
        {
            Material mat = creams[1].GetComponent<Renderer>().material;
            Color color = mat.color;
            if ((leftLegVal / 150) <= 1)
            {
                creams[1].GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, (leftLegVal / 150));
            }
        } else
        if (this.name == "RightArmCream")
        {
            Material mat = creams[2].GetComponent<Renderer>().material;
            Color color = mat.color;
            if ((rightArmVal / 150) <= 1)
            {
                creams[2].GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, (rightArmVal / 150));
            }
        } else
        if (this.name == "RightLegCream")
        {
            Material mat = creams[3].GetComponent<Renderer>().material;
            Color color = mat.color;
            if ((rightLegVal / 150) <= 1)
            {
                creams[3].GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, (rightLegVal / 150));
            }

        }

    }
}
