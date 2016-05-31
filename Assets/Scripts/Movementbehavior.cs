using UnityEngine;
using System.Collections;

public class Movementbehavior : MonoBehaviour {
	private bool turnR = false;
	private bool turnL = false;

	

    private float curxpos;
    public GameObject [] lanepos = new GameObject[8];
    private int arraypos;
    private float xpos;

    private float turnspeed;
    public Transform rotatepoint;

    
    // Use this for initialization
    void Start () {
        arraypos = (int)(Random.value * 8);
        curxpos = lanepos[arraypos].transform.position.x;
        xpos = curxpos;
        


    }
	
	// Update is called once per frame
	void Update () {
        
        
	    if(turnL == true && arraypos > 0)
        {
            turnL = false;
            arraypos--;
            curxpos = lanepos[arraypos].transform.position.x;
        }
        else if (turnR ==true && arraypos < 7)
        {
            turnR = false;
            arraypos++;
            curxpos = lanepos[arraypos].transform.position.x;
            
        }
		
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            turnR = true;            
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            turnL = true;
        }
        xpos = gameObject.transform.position.x;

        gameObject.transform.position = new Vector3(Mathf.Lerp(xpos, curxpos + 20, Time.deltaTime*4), gameObject.transform.position.y, gameObject.transform.position.z);
        turnspeed = (curxpos-xpos+20)/10;
        //transform.RotateAround(rotatepoint.position, Vector3.forward, 20 * Time.deltaTime);

        if (turnspeed> 0.2)
        {
            rotatepoint.Rotate(0, 0, 2 * turnspeed);
        }
        else if (turnspeed < 0.2 && rotatepoint.rotation.x > 0.01f)
        {
            rotatepoint.Rotate(0, 0, -0.5f);
        }
        else if (turnspeed > -0.2 && rotatepoint.rotation.x < -0.01f)
        {
            rotatepoint.Rotate(0, 0, 0.5f);
        }
        else if (turnspeed < -0.2)
        {
            Debug.Log(rotatepoint.rotation.x + " " + turnspeed);
            rotatepoint.Rotate(0, 0, 2 * turnspeed);
        }
        
        
    }
}
