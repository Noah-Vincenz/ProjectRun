using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLidAnim : MonoBehaviour {

    public Animator anim = null;
    public Collider2D openCreamCol = null;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
 
    void OnMouseDown()
    {
        anim.Play("LidOpen");
        openCreamCol.enabled = true;

    }
}
