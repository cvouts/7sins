using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffScript : MonoBehaviour
{
    public GameObject tipCanvas;

     void OnTriggerExit2D(Collider2D other)
    {
    	if(other.tag == "Player")
    	{	
	    	tipCanvas.SetActive(false);
        }
    }
}
