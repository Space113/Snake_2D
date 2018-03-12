using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject snakePrefab;
	public Snake head;
	public Snake tail;

	private Rigidbody2D rb2d; 
	// Current Movement Direction
	// (by default it moves to the right)
	Vector2 dir = Vector2.up;

	void Start () {
//		rb2d = GetComponent<Rigidbody2D> ();


		// Move the Snake every 300ms
		InvokeRepeating("Move", 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		// Move in a new Direction?
		if (Input.GetKey(KeyCode.RightArrow))
			dir = Vector2.right;
		else if (Input.GetKey(KeyCode.DownArrow))
			dir = -Vector2.up;    // '-up' means 'down'
		else if (Input.GetKey(KeyCode.LeftArrow))
			dir = -Vector2.right; // '-right' means 'left'
		else if (Input.GetKey(KeyCode.UpArrow))
			dir = Vector2.up;
	}

	void Move() {
		transform.Translate (dir);
	}
}
