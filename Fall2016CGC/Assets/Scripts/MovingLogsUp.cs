using UnityEngine;
using System.Collections;

public class MovingLogsUp : MonoBehaviour {

    // Use this for initialization
    float lifeTimer = 6f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(new Vector2(0f, (Time.deltaTime)*1.5f));
	}
}
