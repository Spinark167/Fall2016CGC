using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	float timer = 0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(0f,0f,15f);

		timer += Time.deltaTime;
		if (timer >= 5f) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		Destroy (gameObject);
	}
}
