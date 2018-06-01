using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed; // Movement Speed of the Player
	private Animator theAnimator; // Animator Used
	private bool isMoving; // Is Player Moving
	public Vector2 lastMove; // Last Movement in X and Y Axis

	// Use this for initialization
	void Start () {
		theAnimator = GetComponent<Animator> (); // Reference to the Animator, will get the animator of the object this script is attached to
	}
	
	// Update is called once per frame
	void Update () {
		isMoving = false; // NOT moving

		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) { // If you are pressing either A or D or Left or Right Arrow Keys, positive means to the right, negative value means to the left
			transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f)); // Will make the player move in this axis at this amount
			isMoving = true; // OBVIOUSLY moving
			lastMove = new Vector2 (Input.GetAxisRaw("Horizontal"), 0f); // Getting the Last Movement
		}

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) { // Same Logic as Above
			transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
			isMoving = true;
			lastMove = new Vector2 (0f, Input.GetAxisRaw("Vertical"));
		}

		theAnimator.SetFloat ("moveX", Input.GetAxisRaw ("Horizontal")); // Setting the Value in Float Move X in Animator
		theAnimator.SetFloat ("moveY", Input.GetAxisRaw ("Vertical")); // Same Logic as Above
		theAnimator.SetBool ("isMoving", isMoving);
		theAnimator.SetFloat ("lastMoveX", lastMove.x);
		theAnimator.SetFloat ("lastMoveY", lastMove.y);
	}
}
