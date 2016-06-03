using UnityEngine;
using System.Collections;
using Photon;

public class NetworkPlayer : Photon.MonoBehaviour {
    // variable that will be used for activation of the game 
    public Camera myCam;
    public GameObject myspeedcont;
    public bool start = false;

    // these are used for synchronization of the other players in the game
    private Vector3 correctPlayerPos;
    private Quaternion correctPlayerRot;
    

    

    // Use this for initialization
    void Start()
    {  
        // we find the roadmanager and activate it this was to prevent errors because the coincollision script could not find the players position
        GameObject.FindGameObjectWithTag("Road").GetComponent<RoadManager>().enabled = true;
        
        // this if statement activates the player for the local player
        if (photonView.isMine)
        { 
            myCam.enabled = true;
            myCam.GetComponent<AudioListener>().enabled = true;
            GetComponent<Movementbehavior>().enabled = true;
            GetComponent<SpeechManager>().enabled = true;
        }
    }
	
	void Update () {
        if(!photonView.isMine)
        {
           //makes the movement of the object smooth
            transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 10);
            transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 10);
        }

        // we start a Remote protocall call RPC that will start the speed of the car so they will go down the map 
        if (start == true)
        {
            GetComponent<PhotonView>().RPC("go", PhotonTargets.All);

        }
        // we also have it with key input for debugging reasons 
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<PhotonView>().RPC("go", PhotonTargets.All);
        }



    }

     void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    
    {
        if(stream.isWriting)
        {
            //We own this player: send the our data
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            // network player, reciving data 
            this.correctPlayerPos = (Vector3)stream.ReceiveNext();
            this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
        }

    }

}
