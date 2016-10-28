using UnityEngine;
using System.Collections;

public class MonsterJump : MonoBehaviour {

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponentInParent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Ground") {
			rb.velocity = new Vector2 (rb.velocity.x, 6f);
		}
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Ground") {
			rb.velocity = new Vector2 (rb.velocity.x, 6f);
		}
	}
}
