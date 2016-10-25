using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float moveSpeed = 50.0f;
	public float jumpPower = 150.0f;
	public GameObject castPositioner;

	private Animator anim; 

	private Rigidbody2D rb;

	public bool grounded;

	private float health = 10;

	bool beenHit = false;

	bool attacking = false;

	//Vector3 bugToPlayer;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("Grounded", grounded);
		anim.SetBool ("Attacking", attacking);

		if (health <= 0) {
			Destroy (gameObject);
		}

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
		if (beenHit == false) {
			rb.velocity = new Vector2 (moveSpeed * h, rb.velocity.y);
		} 
		anim.SetFloat ("Speed", Mathf.Abs(h));
	}

	public void ShootAnimation(){
		attacking = true;
	}

	void ShootFire(){
		castPositioner.GetComponent<CastFireBall> ().Shoot ();
		attacking = true;
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Beatle") {
			health--;
			beenHit = true;
			float bugToPlayer = (gameObject.transform.position.x - other.transform.position.x) * 2500f;
			rb.AddForce (new Vector2(bugToPlayer,2000f));
		}

		if (other.gameObject.tag == "Ground") {
			beenHit = false;
		}
	}

	public void MakeAttackingFalse(){
		attacking = false;
	}
}
