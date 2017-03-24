using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyCream : MonoBehaviour {

    bool mouseDown = false;
	private AudioSource source;

	private void Start()
	{
		source = GetComponent<AudioSource>();
		source.time = 3f;
	}

    void OnMouseOver() //If mouse is over cream object
    {
       if (mouseDown) //If mouse is down then we increase timeDown counter (this is used to generate a value for the fill bar)
        {
            fillBar.timeDown++;

            if (this.name == "LeftArmCol") //At the same time we also check which exact cream object is clicked on (an generate a value for cream transparency)
            {
                creamTransparency.leftArmVal++;
            } else  
            if (this.name == "LeftlegCol")
            {
                creamTransparency.leftLegVal++;
            } else
            if (this.name == "RightArmCol")
            {
                creamTransparency.rightArmVal++;
            } else
            if (this.name == "RightlegCol")
            {
                creamTransparency.rightLegVal++;
            }
        }
    }

    private void OnMouseExit() //On the mouse exiting the valid region to click in we reset the timeDown value
    {                         
       if ((fillBar.timeDown != 0) & (mouseDown))
        {
            fillBar.timeDown = 0;
        }
    }

    void OnMouseDown() //A boolean is set to check when the mouse is being held down
    {
        mouseDown = true;
		source.Play ();
    }

    void OnMouseUp() //On mouse up we also reset the timeDown value to zero
    {
        if (fillBar.timeDown != 0)
        {
            fillBar.timeDown = 0;
        }
        mouseDown = false;
		source.Stop ();
    }

}
