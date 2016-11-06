using UnityEngine;
using System.Collections;

public class MovingLogs : MonoBehaviour {

    public GameObject logInstance;
    // Use this for initialization

    float timer = 3f;

    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        

        timer = (timer - Time.deltaTime);
        if (timer <= 0)
        {
            GameObject newObj = Instantiate(logInstance, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
           // newObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 4f);
            timer = 3f;
        }
	}
}
