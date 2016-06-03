using UnityEngine;
using System.Collections;

public class startsynch : MonoBehaviour {

    // this scripts will add remote procedure calls RPC for our game
    // a photon extention to be used on both players
	[PunRPC]
    void go()
    {
        // we set both cars in motions by activating the script to move them forward
        GameObject.FindGameObjectWithTag("Player1").GetComponent<Speedcontroller>().enabled = true;
        GameObject.FindGameObjectWithTag("Player2").GetComponent<Speedcontroller>().enabled = true;
    }
    // RPC call to make the score count for both players
    [PunRPC]
    void addpointplayer1()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().addpointplayer1();
    }
    [PunRPC]
    void addpointplayer2()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().addpointplayer2();
    }
}
