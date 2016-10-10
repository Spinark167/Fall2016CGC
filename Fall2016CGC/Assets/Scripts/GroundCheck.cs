using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private Movement movement;

	// Use this for initialization
	void Start () {
		movement = gameObject.GetComponentInParent<Movement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		movement.grounded = true;
	}

	void OnTriggerStay2D(Collider2D col){
		movement.grounded = true;
	}

	void OnTriggerExit2D(Collider2D col){
		movement.grounded = false;
	}
}
