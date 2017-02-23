using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	Animator anim;


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		jump();
	}

	public void jump(){

		if(Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0) && Input.GetTouch(0).phase == TouchPhase.Began){

			anim.Play("jump");


		}


	}
}
