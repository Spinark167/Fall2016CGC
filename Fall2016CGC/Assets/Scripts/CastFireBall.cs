using UnityEngine;
using System.Collections;

public class CastFireBall : MonoBehaviour {

	public GameObject fireBall;
	float direction = 1f;
	public GameObject mainChar;
	float timer = 0f;
	bool canShoot = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ((mainChar.transform.position.x - gameObject.transform.position.x) > 0) {
			direction = -1f;
		}
		if ((mainChar.transform.position.x - gameObject.transform.position.x) < 0) {
			direction = 1f;
		}

		timer -= Time.deltaTime;

		if (timer <= 0) {
			canShoot = true;
		}

		if (timer >= 0) {
			canShoot = false;
		}

		if (Input.GetKeyDown (KeyCode.F) && canShoot) {
			mainChar.GetComponent<Movement> ().ShootAnimation ();
			timer = .25f;
		}
	}

	public void Shoot(){
		GameObject newObj = Instantiate (fireBall, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
		newObj.GetComponent<Rigidbody2D> ().velocity = new Vector2 (6f * direction + mainChar.GetComponent<Rigidbody2D>().velocity.x, -1.5f);
	}

	public void StopShooting(){
		mainChar.GetComponent<Movement> ().MakeAttackingFalse ();
	}
}
