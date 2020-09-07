using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFadeOut : MonoBehaviour
{
  	public float fadeTime = 1.0f;
	private AudioSource music;
	private IEnumerator coroutine;

	void Start()
	{
		music = GetComponent<AudioSource>();
		coroutine = FadeOut();
	}

	IEnumerator FadeOut()
    {
    	float startVolume = music.volume;
	 
        while (music.volume > 0) 
        {
        	Debug.Log("here!");
            music.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
 
        music.Stop ();
    }

    public void DemoStarting()
    {
    	StartCoroutine(coroutine);
    }
}
