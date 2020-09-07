using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSprite : MonoBehaviour
{
   
	private SpriteRenderer boxSpriteRenderer;
	public Sprite box_0;

    void Start()
    {
       boxSpriteRenderer = GetComponent<SpriteRenderer>();
       
    }

   
    void OnCollisionEnter2D(Collision2D col)
    {
    	if(col.collider.tag == "pressurePad")
    	{
    		boxSpriteRenderer.sprite = box_0;
    	}
    }

}
