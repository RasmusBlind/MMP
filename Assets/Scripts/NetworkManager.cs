using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.PunBehaviour {

    public string myplayer1 = "playerobj-1";
    public string myplayer2 = "playerobj-2";

    // Use this for initialization
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnJoinedLobby() // try to join random room
    {
        Debug.Log("Yes I joined lobby");
        PhotonNetwork.JoinRandomRoom();
    }
    void OnPhotonRandomJoinFailed() //no room? create one!!
    {
        Debug.Log("ohh no I Can't join random room!");
        PhotonNetwork.CreateRoom(null); //cant have an empty call (no overloaded functions), use null instead.
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.countOfPlayers > 1) {
            GameObject player = PhotonNetwork.Instantiate(myplayer2, GameObject.FindGameObjectWithTag("lane4").transform.position, Quaternion.identity, 0);
            //Speedcontroller controller = player.GetComponent<Speedcontroller>();
            //controller.enabled = true;

        }
        else
        {
            GameObject player = PhotonNetwork.Instantiate(myplayer1, GameObject.FindGameObjectWithTag("lane4").transform.position, Quaternion.identity, 0);
            //Speedcontroller controller = player.GetComponent<Speedcontroller>();
            //controller.enabled = true;
        }
        

        Debug.Log("Connected to Room Player-1");

        
    }
}
