using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

 // to catch empty Serialized fields
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

	public static gameManager instance = null;

	private Vector3 fp;
	//First touch position
	private Vector3 lp;
	//Last touch position
	private float dragDistance;
	private int points = 0;

	[SerializeField] private GameObject mainMenu;
	[SerializeField] private GameObject gameOverTexture;
	[SerializeField] private GameObject zombie;
	[SerializeField] private GameObject zombieOnPlay;

	[SerializeField] private GameObject rockets;
	[SerializeField] private GameObject warning;
	[SerializeField] private Text score;


	private bool playerActive = false;
	private bool gameOver = false;
	private bool gameStarted = false;
	public Color originalPlayerMaterialColor;
	public Color currentPlayerMaterialColor;
	// pakeisti i private lauka




	void Awake ()
	{

		Assert.IsNotNull (mainMenu);

		if (instance == null) {
			
			instance = this;

		} else if (instance != this) {
		
			Destroy (gameObject);
		}

	}

	// Use this for initialization
	void Start ()
	{
		score.text = "Score: 0";
		dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen

		originalPlayerMaterialColor = zombie.GetComponent<Renderer> ().material.color;
		currentPlayerMaterialColor = originalPlayerMaterialColor;

		InvokeRepeating("createRockets", 5f, 15f);
		InvokeRepeating("addPoints", 5f, 10f);

	}
	
	// Update is called once per frame
	void Update ()
	{
		swipeControlls ();
		//Invoke("createRockets", 5f);

	}

	public bool isPlayerActive ()
	{

		return playerActive;
	}

	public void playerBecomesActive ()
	{

		playerActive = true;
	}


	public bool isGameOver ()
	{

		return gameOver;
	}

	public void gameIsOver ()
	{

		gameOver = true;

	}


	public void startTheGame ()
	{

		mainMenu.SetActive (false);
		gameStarted = true;
		zombieOnPlay.GetComponent<Renderer>().material.color = currentPlayerMaterialColor;
	}

	public bool isGameStarted ()
	{

		return gameStarted;
	}

	public IEnumerator gameOverTxt ()
	{

		yield return new WaitForSeconds (3f);
		gameOverTexture.SetActive (true);

	}

	public void restartTheScene ()
	{

		SceneManager.LoadScene ("game");
		//mainMenu.SetActive(false);
	}

	public void createRockets(){

		if(isPlayerActive()){
			float y = Random.Range(-10f, 0f);
			//Instantiate(warning, new Vector3(13.07f, y-2, 1f), Quaternion.identity);
			Instantiate(rockets, new Vector3(transform.position.x,y,0), Quaternion.identity);
			Instantiate(rockets, new Vector3(transform.position.x+9,y-2,0), Quaternion.identity);
			Instantiate(rockets, new Vector3(transform.position.x+18,y-4,0), Quaternion.identity);

		}

	}

	public void addPoints(){

		if(isPlayerActive() && !isGameOver()){
			points += 20;
			score.text = "Score: " + points;
		}

	}


	public void swipeControlls ()
	{

		if (!gameStarted) {

			if (Input.touchCount == 1) { // user is touching the screen with a single touch
				Touch touch = Input.GetTouch (0); // get the touch
				if (touch.phase == TouchPhase.Began) { //check for the first touch
					fp = touch.position;
					lp = touch.position;
				} else if (touch.phase == TouchPhase.Moved) { // update the last position based on where they moved
					lp = touch.position;
				} else if (touch.phase == TouchPhase.Ended) { //check if the finger is removed from the screen
					lp = touch.position;  //last touch position. Ommitted if you use list

					//Check if drag distance is greater than 20% of the screen height
					if (Mathf.Abs (lp.x - fp.x) > dragDistance || Mathf.Abs (lp.y - fp.y) > dragDistance) {//It's a drag
						//check if the drag is vertical or horizontal
						if (Mathf.Abs (lp.x - fp.x) > Mathf.Abs (lp.y - fp.y)) {   //If the horizontal movement is greater than the vertical movement...
							if ((lp.x > fp.x)) {  //If the movement was to the right)//Right swipe
								zombie.GetComponent<Renderer> ().material.color = Color.red;
								currentPlayerMaterialColor = zombie.GetComponent<Renderer> ().material.color;

								Debug.Log ("Right Swipe");
							} else {   //Left swipe
								zombie.GetComponent<Renderer> ().material.color = originalPlayerMaterialColor;
								currentPlayerMaterialColor = zombie.GetComponent<Renderer> ().material.color;
								Debug.Log ("Left Swipe");
							}
						} else {   //the vertical movement is greater than the horizontal movement
							if (lp.y > fp.y) {  //If the movement was up//Up swipe
								Debug.Log ("Up Swipe");
							} else {   //Down swipe
								Debug.Log ("Down Swipe");
							}
						}
					} else {   //It's a tap as the drag distance is less than 20% of the screen height
						Debug.Log ("Tap");
					}
				}
			}
		}
	}

}
