using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
    public float speed = 50f;
    public float jumpPower = 150f;

    public bool grounded;
    private Rigidbody2D rb2d;

	void Start ()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
	
	}
}
