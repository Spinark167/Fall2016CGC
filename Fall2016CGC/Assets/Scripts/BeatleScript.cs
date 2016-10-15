using UnityEngine;
using System.Collections;

public class BeatleScript : MonoBehaviour {

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
	//I'm going to actually give this guy code later this is just to see how the animation works with the speed im giving it.
		rb = gameObject.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2 (-3f, rb.velocity.y);
	}
}
