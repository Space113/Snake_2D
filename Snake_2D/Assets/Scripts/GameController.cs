using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject tailPrefab;
//	public Snake head;
	// Keep Track of Tail

	private bool ate = false;
	private List<Transform> tail = new List<Transform>();

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
		// Save current position (gap will be here)
		Vector2 v = transform.position;

		transform.Translate (dir);
		// Ate something? Then insert new Element into gap
		if (ate) {
			// Load Prefab into the world
			GameObject g =(GameObject)Instantiate(tailPrefab, v, transform.rotation);

			// Keep track of it in our tail list
			tail.Insert(0, g.transform);

			// Reset the flag
			ate = false;
		}
		// Do we have a Tail?
		else if (tail.Count > 0) {
			// Move last Tail Element to where the Head was
			tail.Last().position = v;

			// Add to front of list, remove from the back
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count-1);
		}

	}

	void OnTriggerEnter2D(Collider2D coll) {
		// Food?
		if (coll.gameObject.CompareTag ("PickUp")) {
			// Get longer in next Move call
			ate = true;

			// Remove the Food
			coll.gameObject.SetActive (false);
//			Destroy(coll.gameObject);

		}
		// Collided with Tail or Border
		else {
			// ToDo 'You lose' screen
		}
	}
}
