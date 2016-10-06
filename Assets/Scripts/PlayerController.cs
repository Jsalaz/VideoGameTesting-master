using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpForce = 12f;
	public float runningSpeed = 5.1f;
	private Rigidbody2D rigidBody;
	public Animator animator;

	//making singleton
	public static PlayerController instance;

	//Starting Possition for player1
	private Vector3 startingPosition;

	void Awake() {
		instance = this;
		rigidBody = GetComponent<Rigidbody2D>();
		startingPosition = this.transform.position;
	}


	public void StartGame(){
		animator.SetBool("isAlive", true);
		rigidBody.constraints = RigidbodyConstraints2D.None;
		this.transform.position = startingPosition;
		runningSpeed = 5.0f;
	}

	void Start() {
		animator.SetBool("isAlive", true);
		rigidBody.constraints = RigidbodyConstraints2D.FreezePosition;

	}


	// Update is called once per frame
	void Update () {

		if (GameManager.instance.currentGameState == GameState.inGame) {

			if (Input.GetMouseButtonDown (0)) {
				Jump ();
				//Debug.Log("jumping");
			}

			if (Input.GetKeyDown (KeyCode.UpArrow))
				Jump ();

			animator.SetBool ("isGrounded", IsGrounded ());
		}
	}


	void FixedUpdate() {

		if (GameManager.instance.currentGameState == GameState.inGame) {

			if (rigidBody.velocity.x < runningSpeed) {
				rigidBody.velocity = new Vector2 (runningSpeed, rigidBody.velocity.y);
			}
		}
	}


	void Jump() {
		if (IsGrounded()) {
			rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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

	public float GetDistance(){
		float traveledDistance = Vector2.Distance (new Vector2 (startingPosition.x, 0), new Vector2 (this.transform.position.x, 0));

		return traveledDistance;
	}
}