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

    // Use this for initialization
    void Start () {

        for (int j = 0; j < 8; j++)
        {
            lanepos[j] = GameObject.FindGameObjectWithTag("lane" + (j + 1));
            Debug.Log("lane" + (j + 1));
        }

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

		//synchronize the actual position (xpos) of the car to the current position (curpos)
		if (xpos != curxpos) {
			gameObject.transform.position = new Vector3(Mathf.Lerp(xpos, curxpos , Time.deltaTime*4), gameObject.transform.position.y, gameObject.transform.position.z);
		}

		// calculate a turn speed that will be used to change how much the car will be rotated 
		turnspeed = (curxpos-xpos)/10;
       
		// a state machine that will make the car rotate alittle to left or right when the lane are changed. there are a threshold on how much the car can and will turn
        // when we are not turning turnspeed less than 0.2 we will return the rotationg to 0.0 or almost 
		if (turnspeed> 0.3 && rotatepoint.rotation.x < 0.3f)
        {
            rotatepoint.Rotate(0, 0, 1 * turnspeed);
        }
        else if (turnspeed < 0.3 && rotatepoint.rotation.x > 0.01f)
        {
            rotatepoint.Rotate(0, 0, -1f);
        }
        else if (turnspeed > -0.3 && rotatepoint.rotation.x < -0.01f)
        {
            rotatepoint.Rotate(0, 0, 1f);
        }
		else if (turnspeed < -0.3 && rotatepoint.rotation.x > -0.3f)
        {
           
            rotatepoint.Rotate(0, 0, 1 * turnspeed);
        }
        
        
    }
}
