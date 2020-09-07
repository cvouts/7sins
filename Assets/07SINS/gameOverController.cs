using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gamekit2D
{

    public class gameOverController : MonoBehaviour
    {
        
    	public GameObject doorDialogue;
        public GameObject player;
    	public AudioClip woo;
        public GameObject door;
        public float restartDelay = 3f;

    	private AudioSource audioSource;
        private Animator playerAnimator;
        private CharacterController2D playerMovement;
        private SpriteRenderer doorSpriteRenderer;
        private float restartTimer;
        private bool startRestart = false;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            playerAnimator = player.GetComponent<Animator>();
            playerMovement = player.GetComponent<CharacterController2D>();
            doorSpriteRenderer = door.GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            if(startRestart == true)
            {
                Restart();
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
        	if(other.tag == "Player")
        	{	
        		doorDialogue.SetActive(true);
        	}
        }

        void OnTriggerExit2D(Collider2D other)
        {
        	if(other.tag == "Player")
        	{	
        		doorDialogue.SetActive(false);
        	}
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if(other.tag == "Player" && doorSpriteRenderer.sprite.name == "HubDoor3")
        	{
        		if(Input.GetKeyDown("e"))
            	{
           			audioSource.PlayOneShot(woo, 1.0F);
                    playerAnimator.enabled = !playerAnimator.enabled;
                    playerMovement.enabled = !playerMovement.enabled;
                    startRestart = true;      
            	}
        	}
        }

        void Restart()
        {
            restartTimer += Time.deltaTime;
            if(restartTimer >= restartDelay)
            {
                SceneManager.LoadScene("Scene01", LoadSceneMode.Single);    
            }
        }
    }
}
