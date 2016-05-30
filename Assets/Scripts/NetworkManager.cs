using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.PunBehaviour {

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
        Debug.Log("In on joined lobby");
        PhotonNetwork.JoinRandomRoom();
    }
    void OnPhotonRandomJoinFailed() //no room? create one!!
    {
        Debug.Log("Can't join random room!");
        PhotonNetwork.CreateRoom(null); //cant have an empty call (no overloaded functions), use null instead.
    }

    public override void OnJoinedRoom()
    {
        //PhotonNetwork.Instantiate("Cube", Vector3.up * 5, Quaternion.identity, 0); //instantiate player "cube"
        PhotonNetwork.Instantiate("Player-1", new Vector3(0, 1, 0), Quaternion.identity, 0);
        Debug.Log("Connected to Room");
    }
}
