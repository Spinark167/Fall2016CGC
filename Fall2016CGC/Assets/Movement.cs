using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float moveSpeed = 15.0f;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			rb.velocity = new Vector3 (-moveSpeed, rb.velocity.y, 0f);
		}
	}
}
