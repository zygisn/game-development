﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	[SerializeField] private float jumpForce = 70f;
	private Animator anim;
	private Rigidbody rb;


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate (){
	
		jump();
	}

	public void jump(){

		if(Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0) && Input.GetTouch(0).phase == TouchPhase.Began){

			rb.useGravity = true;
			rb.velocity = new Vector2(0f, 0f); // Disabling player falling velocity 
			rb.freezeRotation = true; // Disabling player rotation on Y axis
			rb.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
			anim.Play("jump");


		}


	}
}
