using UnityEngine;
using System.Collections;

public class Speedcontroller : MonoBehaviour {
    public float maxspeed = 40.0f;
    public float accleration = 0.5f;
    public float speed = 1.0f;

    public Rigidbody myrb;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (myrb.velocity.y < maxspeed)
        {
            speed = myrb.velocity.y + accleration;
            myrb.velocity = new Vector3(0, speed , 0);
        }
        
	}
}
