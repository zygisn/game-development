using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

	public static gameManager instance = null;

	private bool playerActive = false;
	private bool gameOver = false;


	void Awake(){

		if(instance == null){
			
			instance = this;

		}else if(instance != this){
		
			Destroy (gameObject);
		}

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool getPlayerState (){

		return playerActive;
	}

	public bool getGameState(){

		return gameOver;
	}

	public void playerBecomesActive (){
	
		playerActive = true;
	}

	public void gameIsOver(){

		gameOver = true;
	}

}
