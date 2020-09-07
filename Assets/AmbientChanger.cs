using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientChanger : MonoBehaviour
{
	public float fadeTime;

	private AudioSource[] ambiences;
	private AudioSource outsideAmbience;
	private AudioSource insideAmbience;

	private IEnumerator out_coroutine;
	private IEnumerator in_coroutine;

	void Start()
	{
		ambiences = GetComponents<AudioSource>();
		outsideAmbience = ambiences[0];
		insideAmbience = ambiences[1]; 

		out_coroutine = FadeOut();
		in_coroutine = FadeIn();
	}

	 IEnumerator FadeOut()
    {
    	float startVolume = outsideAmbience.volume;
	 
        while (outsideAmbience.volume > 0) 
        {
            outsideAmbience.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
 
        outsideAmbience.Stop ();
    }


    IEnumerator FadeIn()
    {
    	float endVolume = 0.4f;
	 
        while (insideAmbience.volume < endVolume) 
        {
            insideAmbience.volume += Time.deltaTime / fadeTime;
            yield return null;
        }
    }

	 void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.tag == "Player")
    	{	
	    	StartCoroutine(out_coroutine);
        }
    }

     void OnTriggerExit2D(Collider2D other)
    {
    	if(other.tag == "Player")
    	{	
	    	StartCoroutine(in_coroutine);
        }
    }
}
