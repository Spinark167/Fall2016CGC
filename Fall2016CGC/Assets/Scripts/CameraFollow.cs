using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject player; 

	float posX = 0.0f;
	float posY = 0.0f;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		posX = player.transform.position.x;
		posY = player.transform.position.y + 4.115f;

		gameObject.transform.position = new Vector3 (posX, posY, gameObject.transform.position.z);
	}
}
