using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLidAnim : MonoBehaviour {

    public Animator anim = null;
    public Collider2D openCreamCol = null;
    public Text text = null;
    public Text text2 = null;
	private AudioSource source;


    private void Start()
    {
        anim = GetComponent<Animator>();
		source = GetComponent<AudioSource>();
    }

 
    void OnMouseDown()
    {
		source.Play ();
        anim.Play("LidOpen");
        openCreamCol.enabled = true;
        text.enabled = false;
        text2.enabled = true;

    }
}
