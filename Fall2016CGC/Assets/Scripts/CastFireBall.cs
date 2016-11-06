using UnityEngine;
using System.Collections;

public class CastFireBall : MonoBehaviour {

	public GameObject fireBall;
	float direction = 1f;
	public GameObject mainChar;
	float timer = 0f;
	bool canShoot = true;

	float screenHeight;
	float mouseHeight;
	float mouseLength;
	float myLength;
	float myHeight;
	float distToMouse;
	public float shootFactor = 50f;
	public Camera camera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		screenHeight = Screen.height;
		mouseHeight = Input.mousePosition.y;
		mouseLength = Input.mousePosition.x;
		//Debug.Log (mouseHeight);
		myHeight = camera.WorldToScreenPoint(gameObject.transform.position).y;
		myLength = camera.WorldToScreenPoint(gameObject.transform.position).x;
		//Debug.Log ("Mouse: " + mouseLength);
		//Debug.Log ("shooter: " + myLength);

		distToMouse = Mathf.Sqrt ((mouseLength - myLength) * (mouseLength - myLength) + (mouseHeight - myHeight) * (mouseHeight - myHeight));

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
		if (mainChar.transform.localScale.x > 0) {
			if (mouseLength > myLength) {

			}
		}
		if (Input.GetKeyDown (KeyCode.F) && canShoot) {
			if (mainChar.transform.localScale.x > 0) {
				if (mouseLength > myLength) {
					mainChar.GetComponent<Movement> ().ShootAnimation ();
					timer = .25f;
				}
			}
			if (mainChar.transform.localScale.x < 0) {
				if (mouseLength < myLength) {
					mainChar.GetComponent<Movement> ().ShootAnimation ();
					timer = .25f;
				}
			}
		}
	}

	public void Shoot(){
		GameObject newObj = Instantiate (fireBall, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
		//newObj.GetComponent<Rigidbody2D> ().velocity = new Vector2 (6f * direction + mainChar.GetComponent<Rigidbody2D>().velocity.x, (screenHeight/mouseHeight));
		newObj.GetComponent<Rigidbody2D> ().velocity = new Vector2 ((mouseLength - myLength)*shootFactor/distToMouse, (mouseHeight-myHeight)*shootFactor/distToMouse);
	}

	public void StopShooting(){
		mainChar.GetComponent<Movement> ().MakeAttackingFalse ();
	}
}
