using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;  //to catch empty Serialize fields

public class player : MonoBehaviour {

	[SerializeField] private float jumpForce = 70f;
	[SerializeField] private AudioClip sfxJump;
	[SerializeField] private AudioClip sfxDeath;

	private Animator anim;
	private Rigidbody rb;
	private AudioSource audioSource;


	void Awake() {

		Assert.IsNotNull (sfxJump);
		Assert.IsNotNull (sfxDeath);

	}


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate (){
	
		jump();
	}

	public void jump(){

		if(!gameManager.instance.isGameOver() && gameManager.instance.isGameStarted()){

			if(Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0) && Input.GetTouch(0).phase == TouchPhase.Began){

				gameManager.instance.playerBecomesActive();
				rb.useGravity = true;
				rb.velocity = new Vector2(0f, 0f); // Disabling player falling velocity 
				rb.freezeRotation = true; // Disabling player rotation on Y axis
				rb.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
				audioSource.PlayOneShot(sfxJump);
				anim.Play("jump");

			}
		}

	}

	void OnCollisionEnter(Collision collision){

		if(collision.gameObject.tag == "rock"){
		
			rb.AddForce(-20f, -40f, 0f, ForceMode.Impulse);
			audioSource.PlayOneShot(sfxDeath);
			gameManager.instance.gameIsOver();
			StartCoroutine(gameManager.instance.gameOverTxt());
		
		}


	}


}
