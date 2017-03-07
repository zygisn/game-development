using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingRock : moveObject {

	[SerializeField] private Vector3 topPosition;
	[SerializeField] private Vector3 bottomPosition;
	[SerializeField] private int floatingSpeed = 3;

	// Use this for initialization
	void Start () {
		topPosition = new Vector3(transform.localPosition.x, 16.0f);
		bottomPosition = new Vector3(transform.localPosition.x, 9.0f);

		StartCoroutine (Move(bottomPosition));
	}
	
	// Update is called once per frame
	void Update () {

		if(gameManager.instance.isPlayerActive()){

			base.moveObjectLeft();
		}

	}


	IEnumerator Move(Vector3 target){

		while(Mathf.Abs((target - transform.localPosition).y) > 0.2f){

			Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
			transform.localPosition += direction * (floatingSpeed * Time.deltaTime);

			yield return null;
		}

		yield return new WaitForSeconds(0.5f);
		Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;

		StartCoroutine (Move(newTarget));
	}



}
