using UnityEngine;
using System.Collections;

public class BackgroundFollow : MonoBehaviour {

		public GameObject player; 

		float posX = 0.0f;
		

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {
			posX = player.transform.position.x;
			

		gameObject.transform.position = new Vector3 (posX, gameObject.transform.position.y, gameObject.transform.position.z);
		}
	}

