using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private Movement movement;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		movement = gameObject.GetComponentInParent<Movement> ();
		rb = gameObject.GetComponentInParent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Ground" && rb.velocity.y == 0) {
			movement.grounded = true;
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Ground" && rb.velocity.y == 0) {
			movement.grounded = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		movement.grounded = false;
	}
}
