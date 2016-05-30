using UnityEngine;
using System.Collections;

public class Movementbehavior : MonoBehaviour {

	public float initialspeed = 5.0f;
	public float speedlimited = 20.0f;

	private bool turnR = false;
	private bool turnL = false;

	private float turnspeed;

    private float curxpos;
    public GameObject [] lanepos = new GameObject[8];
    private int arraypos;
    private float xpos;
    
    // Use this for initialization
    void Start () {
        arraypos = (int)(Random.value * 8);
        curxpos = lanepos[arraypos].transform.position.x;
        Debug.Log(curxpos);
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
        //Debug.Log(this.gameObject.transform.GetChild(0).transform.position);
		
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            turnR = true;            
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            turnL = true;
        }
        xpos = this.gameObject.transform.GetChild(0).transform.position.x;
        Debug.Log(xpos);
        if (xpos != curxpos)
        {
            
            this.gameObject.transform.GetChild(0).transform.position = new Vector3(Mathf.Lerp(xpos, curxpos + 20, Time.deltaTime*4), this.gameObject.transform.GetChild(0).transform.position.y, this.gameObject.transform.GetChild(0).transform.position.z);
            
        }
        
	}
}
