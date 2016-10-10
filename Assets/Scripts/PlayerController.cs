using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpForce = 12f;
	public float runningSpeed;
	public float maxSpeed = 35;
	//added 10/10/16
	public float traveledDistance = 0;
	public int collectedCoins = 0;


	private Rigidbody2D rigidBody;
	public Animator animator;

	public bool doubleJump = false;

	//making singleton
	public static PlayerController instance;

	//Starting Possition for player1
	private Vector3 startingPosition;
	private Vector3 previousPosition;

	void Awake() {
		instance = this;
		rigidBody = GetComponent<Rigidbody2D>();
		startingPosition = this.transform.position;
//		previousPosition = this.transform.position;
	}


	public void StartGame(){
		animator.SetBool("isAlive", true);
		rigidBody.constraints = RigidbodyConstraints2D.None;
		this.transform.position = startingPosition;
		collectedCoins = 0;
		runningSpeed = 0.1f;
	}

	void Start() {
		animator.SetBool("isAlive", true);
		rigidBody.constraints = RigidbodyConstraints2D.FreezePosition;

	}

	// Update is called once per frame
	void Update () {
		if (GameManager.instance.currentGameState == GameState.inGame) {

			if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.UpArrow)) {
				Jump ();
			}
			animator.SetBool ("isGrounded", IsGrounded ());
		}
	}

	void FixedUpdate(){
		if (GameManager.instance.currentGameState == GameState.inGame) {

			if (rigidBody.velocity.x < runningSpeed) {
				rigidBody.velocity = new Vector2 (runningSpeed, rigidBody.velocity.y);
			}
			if (instance.runningSpeed < instance.maxSpeed) {
				instance.runningSpeed += Time.deltaTime / 2;
			}
		}
	}

	void Jump() {
		if (IsGrounded ()) {
			rigidBody.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
			doubleJump = true;
		} else if (doubleJump && !IsGrounded()) {
			doubleJump = false;
			rigidBody.velocity = new Vector2 (runningSpeed, 0);
			rigidBody.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	public LayerMask groundLayer;

	bool IsGrounded() {

		if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer.value)) {
			return true;
		}
		else {
			return false;
		}
	}

	public void Kill(){

		GameManager.instance.GameOver ();
		animator.SetBool ("isAlive", false);
		//stoping the player after death
		rigidBody.constraints = RigidbodyConstraints2D.FreezePosition;

		//check if highscore save if it is
		if (PlayerPrefs.GetFloat ("highscore", 0) < this.GetDistance ()) {
			//saves new highscore
			PlayerPrefs.SetFloat("highscore", this.GetDistance());
		}
	}

	public void EndLevel(){
		rigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
		LevelManager.levelInstance.LevelComplete (GetDistance(), GetCoins());
		GameManager.instance.SetGameState (GameState.endLevel);
	}

	public float GetDistance(){
		//traveledDistance = Vector3.Distance (this.transform.position, startingPosition);
		//traveledDistance = Vector2.Distance (new Vector2 (startingPosition.x, 0), new Vector2 (this.transform.position.x, 0));
		traveledDistance = transform.position.x;// - startingPosition.x);
		return traveledDistance;// + totalDistance;
	}

	public void CollectedCoin(){
		collectedCoins++;
		if (collectedCoins >= 15) {
			EndLevel ();
		}
	}

	public int GetCoins(){
		return collectedCoins;
	}
}