using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    //Declare public class variables
    //moveSpeed is multiplied by horizontal velocity to adjust speed of player.
	public float moveSpeed = 50.0f;
    //jumpPower is multiplied by vertical velocity to adjust jump height
	public float jumpPower = 150.0f;
    //Takes object that is relative to player. This object represents the position from where spells will be shot from
    public GameObject castPositioner;
    //Used to prevent jumping in mid air by the player. Is equal to true when player is touching ground
    public bool grounded;
    public static int playerHealth = 10;
    //Particle effect to be played when the player is destroyed
    public GameObject deathParticleEffect;
    //Is added to the y coordinate of the instantiation of particles in order to make it appear a bit above the player's center
    public float particleInstantiationHeight = 2f;

    //Declare private class variables
    private Animator anim;
	private Rigidbody2D rb2d;
    //Determines if the player has recently been hit by a damaging object or not
	private bool beenHit = false;
    //Determines if the player is attacking or not
	private bool attacking = false;

    //This method is called once at the beginning of the script
	void Start ()
    {
        //Initialize compoenents of player
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
	}
	
	//Update is called once per frame
	void Update ()
    {
        //Initialize values that determine what animation of the player is occuring
		anim.SetBool ("Grounded", grounded);
		anim.SetBool ("Attacking", attacking);

        //What happpens when the player dies
		if (playerHealth <= 0)
        {
			Destroy (gameObject);
            Instantiate(deathParticleEffect, new Vector2(transform.position.x, transform.position.y + particleInstantiationHeight), transform.rotation);
		}

        //Causes player's animations to correspond the the position that he is moving towards. Player flipping
		if (Input.GetAxis ("Horizontal") < -.1f)
        {
			transform.localScale = new Vector3 (-1, 1, 1);
		}
		if (Input.GetAxis ("Horizontal") > .1f)
        {
			transform.localScale = new Vector3 (1, 1, 1);
		}

		if ((Input.GetButtonDown ("Jump") || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && grounded)
        {
			rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpPower);
		}
	}

    //Physics code for player. This method is called once per frame, before any drawing to screen occurs
	void FixedUpdate()
    {
        //Gets keyboard input from player for horizontal axis
		float horizontalInput = Input.GetAxis ("Horizontal");
        //Player moves corresponding to user's horizontal input, unless they have been hit recently and are still flying backwards from the impact
		if (beenHit == false)
        {
			rb2d.velocity = new Vector2 (moveSpeed * horizontalInput, rb2d.velocity.y);
		} 
		anim.SetFloat ("Speed", Mathf.Abs(horizontalInput));
	}

    //Explanation required
	public void ShootAnimation()
    {
		attacking = true;
	}

    //Explanation required
	void ShootFire()
    {
		castPositioner.GetComponent<CastFireBall> ().Shoot ();
		attacking = true;
	}

    //What occurs when the player's Collider2D touches any other Collider2D
	void OnCollisionEnter2D(Collision2D other)
    {
        //Handles when an enemy attacks the player. Health is decremented by one and flung away a short distance
		if (other.gameObject.tag == "Enemy")
        {
			playerHealth--;
            float bugToPlayer = (gameObject.transform.position.x - other.transform.position.x) * 2500f;
			//Debug.Log (gameObject.transform.position.x - other.transform.position.x);
			if ((bugToPlayer/2500f) < 0.5f && (bugToPlayer/2500f) >= 0) {
				bugToPlayer = 0.5f*2500f;
				//Debug.Log ("hi");
			}
			if ((bugToPlayer/2500f) > -0.5f && (bugToPlayer/2500f) < 0) {
				bugToPlayer = -0.5f*2500f;
			}
			//Debug.Log (bugToPlayer);
            rb2d.AddForce(new Vector2(bugToPlayer, 2000f));
            beenHit = true;
        }

        //If the player is touching the ground, then they are finished being hit because being hit in the first place causes them to go into the air
		if (other.gameObject.tag == "Ground")
        {
			beenHit = false;
		}
	}

    //Explanation required
	public void MakeAttackingFalse()
    {
		attacking = false;
	}
}
