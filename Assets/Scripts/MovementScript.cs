using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
    public float speed = 1.0f;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
}
