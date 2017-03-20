using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tapCream : MonoBehaviour {
    Texture2D texture;
    public Sprite sprite;
    Vector2 hotspot = Vector2.zero;
    public Collider2D[] colliders;
    public SpriteRenderer cursor = null;
    public Text text2 = null;
    public Text text3 = null;
  
    private void Start()
    {
       //createTexture();
    }

    /**
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //Cursor.SetCursor(texture,hotspot,CursorMode.Auto);
            
            colliders[0].enabled = true;
            colliders[1].enabled = true;
            colliders[2].enabled = true; 
            
        }
    }
    **/

    private void OnMouseDown()
    {
        //Cursor.SetCursor(texture, hotspot, CursorMode.Auto);
        colliders[0].enabled = true;
        colliders[1].enabled = true;
        colliders[2].enabled = true;
        colliders[3].enabled = true;
        cursor.enabled = true;
        text2.enabled = false;
        text3.enabled = true;
    }
    void createTexture()
    {
        texture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
        var px = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                (int)sprite.textureRect.y,
                                                (int)sprite.textureRect.width,
                                                (int)sprite.textureRect.height);
        texture.SetPixels(px);
        texture.Apply();
    }
  
}
