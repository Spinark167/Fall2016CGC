using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float moveSpeed = 50.0f;
	public float jumpPower = 150.0f;

	private Animator anim; 

	private Rigidbody2D rb;

	public bool grounded;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") < -.1f) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		if (Input.GetAxis ("Horizontal") > .1f) {
			transform.localScale = new Vector3 (1, 1, 1);
		}

		if ((Input.GetButtonDown ("Jump") || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && grounded) {
			rb.velocity = new Vector2 (rb.velocity.x, jumpPower);
		}
	}

	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (moveSpeed * h, rb.velocity.y);
	}
}
