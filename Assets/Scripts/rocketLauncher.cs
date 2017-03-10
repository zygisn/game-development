using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketLauncher : MonoBehaviour {

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		if(gameManager.instance.isPlayerActive()){
			rb.transform.Translate(Vector3.left * (10f * Time.deltaTime));

		}
		
	}
				
}
