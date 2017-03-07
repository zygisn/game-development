using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class gameManager : MonoBehaviour {

	public static gameManager instance = null;

	[SerializeField] private GameObject mainMenu;
	[SerializeField] private GameObject gameOverTexture;

	private bool playerActive = false;
	private bool gameOver = false;
	private bool gameStarted = false;


	void Awake(){

		Assert.IsNotNull(mainMenu);

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

	public bool isPlayerActive (){

		return playerActive;
	}

	public void playerBecomesActive (){

		playerActive = true;
	}
		

	public bool isGameOver(){

		return gameOver;
	}

	public void gameIsOver(){

		gameOver = true;

	}
		

	public void startTheGame(){

		mainMenu.SetActive(false);
		gameStarted = true;
	}

	public bool isGameStarted(){

		return gameStarted;
	}

	public IEnumerator gameOverTxt(){

		yield return new WaitForSeconds(3f);
		gameOverTexture.SetActive(true);

	}

}
