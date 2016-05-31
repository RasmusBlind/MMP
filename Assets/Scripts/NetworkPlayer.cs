using UnityEngine;
using System.Collections;
using Photon;

public class NetworkPlayer : Photon.MonoBehaviour {
    public Camera myCam;
    private Vector3 correctPlayerPos;
    private Quaternion correctPlayerRot;

    // Use this for initialization
    void Start()
    {
        if (photonView.isMine)
        { 
            myCam.enabled = true;
            myCam.GetComponent<AudioListener>().enabled = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(!photonView.isMine)
        {
           // transform.position=this.correctPlayerPos;
            // transform.rotation=this.correctPlayerRot;
            transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
            Debug.Log(correctPlayerPos + " " + transform.position );
            
            transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
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
