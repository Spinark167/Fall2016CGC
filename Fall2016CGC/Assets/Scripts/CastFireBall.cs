using UnityEngine;
using System.Collections;

public class CastFireBall : MonoBehaviour {

	public GameObject fireBall;
	float direction = 1f;
	public GameObject mainChar;
	float timer = 0f;
	bool canShoot = true;

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
		mouseHeight = Input.mousePosition.y;
		mouseLength = Input.mousePosition.x;
		myHeight = camera.WorldToScreenPoint(gameObject.transform.position).y;
		myLength = camera.WorldToScreenPoint(gameObject.transform.position).x;

		distToMouse = Mathf.Sqrt ((mouseLength - myLength) * (mouseLength - myLength) + (mouseHeight - myHeight) * (mouseHeight - myHeight));

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
		if ((Input.GetKeyDown (KeyCode.F) || Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Mouse0)) && canShoot) {
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
		if (mainChar.transform.localScale.x > 0) {
			if (mouseLength > myLength) {
				GameObject newObj = Instantiate (fireBall, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
				newObj.GetComponent<Rigidbody2D> ().velocity = new Vector2 ((mouseLength - myLength) * shootFactor / distToMouse + mainChar.GetComponent<Rigidbody2D> ().velocity.x, (mouseHeight - myHeight) * shootFactor / distToMouse);
			} //else {
				//GameObject newObj = Instantiate (fireBall, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
				//newObj.GetComponent<Rigidbody2D> ().velocity = new Vector2 ((myLength - mouseLength)*shootFactor/distToMouse + mainChar.GetComponent<Rigidbody2D>().velocity.x, (mouseHeight-myHeight)*shootFactor/distToMouse);
			//}
		}
		if (mainChar.transform.localScale.x < 0) {
			if (mouseLength < myLength) {
				GameObject newObj = Instantiate (fireBall, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
				newObj.GetComponent<Rigidbody2D> ().velocity = new Vector2 ((mouseLength - myLength)*shootFactor/distToMouse + mainChar.GetComponent<Rigidbody2D>().velocity.x, (mouseHeight-myHeight)*shootFactor/distToMouse);
			} //else {
				//GameObject newObj = Instantiate (fireBall, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
				//newObj.GetComponent<Rigidbody2D> ().velocity = new Vector2 ((myLength - mouseLength)*shootFactor/distToMouse + mainChar.GetComponent<Rigidbody2D>().velocity.x, (mouseHeight-myHeight)*shootFactor/distToMouse);
			//}
		}
	}

	public void StopShooting(){
		mainChar.GetComponent<Movement> ().MakeAttackingFalse ();
	}
}
