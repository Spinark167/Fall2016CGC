using UnityEngine;
using System.Collections;

public class FlyingScript : MonoBehaviour {

    public GameObject player;

    float distToPlayerSqrd = 100f;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (distToPlayerSqrd <= 25)
        {
            //BoxCollider2D does something...
        }
    }
}
