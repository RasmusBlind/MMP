using UnityEngine;
using System.Collections;

public class Movementbehavior : MonoBehaviour {
    // boolean to change lanes
    public bool turnR = false;
	public bool turnL = false;
    
    // variable that controlls what lane the player are in 
    private float curxpos;
    public GameObject [] lanepos = new GameObject[8];
    private int arraypos;
    private float xpos;

	// variable to controll the turning animation
	// how much the car should turn 
    private float turnspeed;
	// a reference to where the car should turn around
    public Transform rotatepoint;

    public Camera mycam;

    // Use this for initialization
    void Start () {
        
		// makes a start position for our car
        arraypos = (int)(Random.value * 8);
        curxpos = lanepos[arraypos].transform.position.x;
        xpos = curxpos;
        
        


    }
	
	// Update is called once per frame
	void Update () {
        
        
		// a state machine that changes the position if the bool turnL or turnR are true
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


		// to controll the car while the speach recognition are not implemented
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            turnR = true;            
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            turnL = true;
        }

		// gets referance to xpos because we need to use it multiply time
        xpos = gameObject.transform.position.x;

		//change the gameobject position to the next one that they would like to move to
		if (xpos != curxpos) {
			gameObject.transform.position = new Vector3(Mathf.Lerp(xpos, curxpos + 20, Time.deltaTime*4), gameObject.transform.position.y, gameObject.transform.position.z);
		}

		// calculate a turn speed that will be used to change how much the car will be rotated 
		turnspeed = (curxpos-xpos+20)/10;
       
		// a state machine that will make the car rotate alittle to left or right when the lane are changed
		if (turnspeed> 0.2 && rotatepoint.rotation.x < 0.3f)
        {
            rotatepoint.Rotate(0, 0, 1 * turnspeed);
        }
        else if (turnspeed < 0.2 && rotatepoint.rotation.x > 0.01f)
        {
            rotatepoint.Rotate(0, 0, -0.9f);
        }
        else if (turnspeed > -0.2 && rotatepoint.rotation.x < -0.01f)
        {
            rotatepoint.Rotate(0, 0, 0.9f);
        }
		else if (turnspeed < -0.2 && rotatepoint.rotation.x > -0.3f)
        {
            Debug.Log(rotatepoint.rotation.x + " " + turnspeed);
            rotatepoint.Rotate(0, 0, 2 * turnspeed);
        }
        
        
    }
}
