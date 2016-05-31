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
        //PhotonNetwork.Instantiate("Cube", Vector3.up * 5, Quaternion.identity, 0); //instantiate player "cube"
        GameObject player = PhotonNetwork.Instantiate("Player-1", new Vector3(0, 1, 0), Quaternion.identity, 0);
        playerControl controller = player.GetComponent<playerControl>();
        controller.enabled = true;
       // Camera camera = player.
        //camera.enabled = true;
        
        Debug.Log("Connected to Room Player-1");

      //  PhotonNetwork.Instantiate("Player-2", new Vector3(1, 1, 0), Quaternion.identity, 0);
      //  Debug.Log("Connected to Room Player-2");
    }
}
