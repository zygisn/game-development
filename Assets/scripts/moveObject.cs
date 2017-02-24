using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObject : MonoBehaviour {

	public float objectSpeed = 4f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		moveObjectLeft();

	}

	protected virtual void moveObjectLeft(){


		if(!gameManager.instance.getGameState()){

			transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));

			if(transform.localPosition.x <= -50){

				Vector3 newPosition = new Vector3(32.9f, transform.position.y);
				transform.position = newPosition;
			}
		}
	}
}
