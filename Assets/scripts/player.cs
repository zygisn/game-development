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

		if(Input.GetKeyDown(KeyCode.Space)){

			anim.Play("jump");

		}


	}
}
