using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyCream : MonoBehaviour {

    bool mouseDown = false;

    void OnMouseOver()
    {
       if (mouseDown)
        {
            fillBar.timeDown++;

            if (this.name == "LeftArmCol")
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

    private void OnMouseExit()
    {
       if ((fillBar.timeDown != 0) & (mouseDown))
        {
            fillBar.timeDown = 0;
        }
    }

    void OnMouseDown()
    {
        mouseDown = true;
    }

    void OnMouseUp()
    {
        if (fillBar.timeDown != 0)
        {
            fillBar.timeDown = 0;
        }
        mouseDown = false;
    }

}
