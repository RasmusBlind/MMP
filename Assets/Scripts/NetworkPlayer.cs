using UnityEngine;
using System.Collections;
using Photon;

public class NetworkPlayer : Photon.MonoBehaviour {
    public Camera myCam;
    private Vector3 correctPlayerPos;
    private Quaternion correctPlayerRot;
    public GameObject myspeedcont;

    public bool start = false;

    // Use this for initialization
    void Start()
    {
        GameObject.FindGameObjectWithTag("Road").GetComponent<RoadManager>().enabled = true;
        
        if (photonView.isMine)
        { 
            myCam.enabled = true;
            myCam.GetComponent<AudioListener>().enabled = true;
            GetComponent<Movementbehavior>().enabled = true;
            GetComponent<SpeechManager>().enabled = true;
            
            
        }
    }
	
	// Update is called once per frame
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
