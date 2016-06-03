using UnityEngine;
using System.Collections;

public class Speedcontroller : MonoBehaviour {
    // these variable makes the car go down the road with a maxspeed and accleration that can be set from the unity editor
    public float maxspeed = 40.0f;
    public float accleration = 0.5f;
    private float speed = 1.0f;

    public Rigidbody myrb;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // we are checking if the velocity are lower than maxspeed
        if (myrb.velocity.y < maxspeed)
        {
            // adding more speed 
            speed = myrb.velocity.y + accleration;
            // updating the velocity 
            myrb.velocity = new Vector3(0, speed , 0);
        }
        
	}
}
